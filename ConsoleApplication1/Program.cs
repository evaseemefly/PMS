using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Redis;
using System.Configuration;
using PMS.Model;
using System.Threading;
using ISMS;
using PMS.IBLL;
using Common;

namespace SMSbackground
{
    public class UserTemp
    {
        public string id;

        public DateTime Dt;
    }

    

    class Program
    {
        private static int sleepTime;
        private static string list_id;
        private static double seconds_add;
        private static ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper;
        static ISMSQuery smsQuery = new SMSFactory.SMSQuery();
       static IS_SMSContentBLL smsContentBLL = new PMS.BLL.S_SMSContentBLL();

        static IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();

        

        static void Main(string[] args)
        {
            ToShow("短信发送统计程序已启动");
            ToShow("读取配置节");
            ReadAppConfig();
            //1 创建操作集合的Redis操作类
            redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(list_id);
            ToShow("已创建Redis操作控制器");
            CallBack();     
            Console.ReadLine();
        }

        /// <summary>
        /// 读取配置文件中以上配置节的值
        /// </summary>
        private static void ReadAppConfig()
        {
            sleepTime = int.Parse(ConfigHelper.GetSettingValue("sleepTime"));
            list_id = ConfigHelper.GetSettingValue("list_id");
            seconds_add = double.Parse(ConfigHelper.GetSettingValue("seconds_add"));
            ToShow("读取配置节成功");
        }

        public static void CallBack()
        {
            while (true)
            {
                ToShow("线程启动!Now：" + DateTime.Now.ToLongTimeString());
                //1 根据Redis中保存的集合id查询到集合                
                var list_final = redisListhelper.GetLast();
                //2 判断集合第一个对象的时间是否已经超过规定的时间
                CheckTimeOut_RedisList(list_final, seconds_add);
                ToShow("线程休眠Zzzzzzz.....");
                ToShow("-----------------------------------------------");
                Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// 查询传入的Redis List中超过规定时间的对象，并执行查询短信发送状态的操作
        /// </summary>
        /// <param name="list_final">最新从Redis中获取的对象</param>
        /// <param name="seconds_add">超出时间</param>
        public static void CheckTimeOut_RedisList(List<PMS.Model.QueryModel.Redis_SMSContent> list_final, double seconds_add)
        {
            //3 判断集合第一个对象的时间是否已经超过规定的时间
            if(list_final.Count>0)
            {
                if (list_final.First().Dt < DateTime.Now.AddSeconds(seconds_add))
                {
                    //3.1 超过约定的时间执行查询操作
                    ToQuery(list_final.First());
                    ToShow("从最近的Redis集合中取出msgid" + DateTime.Now.ToLongDateString());
                    //3.2 并从redis中删除第一个对象
                    redisListhelper.Delete(list_id);
                    ToShow("取出集合首元素");
                    //3.3 从redisList中取出排在第一个的对象
                    list_final.RemoveAt(0);
                    //3.4 继续执行此操作
                    CheckTimeOut_RedisList(list_final, seconds_add);
                }
                else
                {
                    ToShow("现有Redis集合中以没有时间范围内的对象");
                    ToShow("现Redis集合中共有:" + list_final.Count());
                    return;
                }
            }            
            //直到出现集合第一个对象时间已经不再超过规定时间则跳出
            else
            {
                ToShow("现有Redis集合中以没有时间范围内的对象");
                ToShow("现Redis集合中共有:" + list_final.Count());
                return;
            }
        }

        public static void ToShow(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// 根据msgid执行查询接收短信状态
        /// </summary>
        /// <param name="msgid"></param>
        public static void ToQuery(PMS.Model.QueryModel.Redis_SMSContent model)
        {
            if(model.msgid==string.Empty)
            {
                ToShow("读取msgid错误");
                return;
            }
            if (model.PhoneNums == string.Empty)
            {
                ToShow("发送联系人列表为空");
                return;
            }
            string account = "dh74381"; //账号"dh74381";
            string passWord = "uAvb3Qey";//密码 = "uAvb3Qey";
            //6 查询发送状态(是否加入等待时间？)
            PMS.Model.SMSModel.SMSModel_Query queryMsg = new PMS.Model.SMSModel.SMSModel_Query()
            {
                account = account,
                password = passWord,
                smsId = model.msgid,
                //phoneNums=model.PhoneNums
            };
            List<PMS.Model.SMSModel.SMSModel_QueryReceive> list_QueryReceive;
            bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg, out list_QueryReceive);
            if (!isGetReturnMsg)
            {
               // return Content("服务器错误");
            }
            //7 获取改次发送的SMSContent的ID
            var list = smsContentBLL.GetListBy(p => p.msgId.Equals(model.msgid));
            if (list.Count() < 1)
            {

                return;
            }
            else
            {
                int scid = list.FirstOrDefault().ID;
                if (list_QueryReceive.Count() == 0)
                {
                    ToShow("当前取出的对象中接收内容有误");
                    return;
                }
                bool isSaveCurrnetMsgOk = smsRecord_CurrentBLL.SaveReceieveMsg(list_QueryReceive, scid);
            }
            
            //暂时不用
            #region 6月26日 暂时注释掉的——与前台交互的代码
            //if (!isSaveCurrnetMsgOk)
            //{
            //    // return Content("服务器错误");
            //}

            //PMS.Model.SMSModel.SMSModel_MsgResult msgResult = new PMS.Model.SMSModel.SMSModel_MsgResult();
            ////7 返回blacklist中的电话号码
            //// smsContentBLL.getResult(receive, msgResult);
            ////8 返回查询结果中的失败的电话号码
            //// smsRecord_CurrentBLL.getResult(list_QueryReceive, msgResult);
            //var result = Common.SerializerHelper.SerializerToString(msgResult);
            #endregion

        }


    }
}
