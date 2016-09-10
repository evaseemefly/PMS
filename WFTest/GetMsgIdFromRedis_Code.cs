using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common.Redis;
using Common;
using PMS.IBLL;
using ISMS;

namespace WFTest
{

    public sealed class GetMsgIdFromRedis_Code : CodeActivity
    {
        #region 各种帮助类
        /// <summary>
        /// redis集合帮助类
        /// </summary>
        //private ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper;
        #endregion

        #region 公用变量
        //private int sleepTime;
        //private string list_id;
        //private double seconds_add;
        #endregion


        #region 业务逻辑层调用对象
         //IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();

         //ISMS.ISMSQuery smsQuery = new SMSFactory.SMSQuery();

         //IS_SMSContentBLL smsContentBLL = new PMS.BLL.S_SMSContentBLL();
        #endregion

        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }
        public InArgument<int> sleepTime { get; set; }
        public InArgument<string> list_id { get; set; }
        public InArgument<double> seconds_add { get; set; }
     


        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            ReadAppConfig();
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);

            //1.1 创建redis操作类
            ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper;
            redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(context.GetValue(this.list_id));

            //1.2 根据Redis中保存的集合id查询到该集合                
            var list_final = redisListhelper.GetLast();

            //1.3 判断集合第一个对象的时间是否已经超过规定的时间
            CheckTimeOut_RedisList(list_final, context.GetValue(this.seconds_add));
        }


        /// <summary>
        /// 读取配置文件中以上配置节的值
        /// </summary>
        private void ReadAppConfig()
        {
            sleepTime = int.Parse(ConfigHelper.GetSettingValue("sleepTime"));
            list_id = ConfigHelper.GetSettingValue("list_id");
            seconds_add = double.Parse(ConfigHelper.GetSettingValue("seconds_add"));
           
        }

        /// <summary>
        /// 查询传入的Redis List中超过规定时间的对象，并执行查询短信发送状态的操作
        /// </summary>
        /// <param name="list_final">最新从Redis中获取的对象</param>
        /// <param name="seconds_add">超出时间</param>
        public void CheckTimeOut_RedisList(List<PMS.Model.QueryModel.Redis_SMSContent> list_final, double seconds_add)
        {
            ////3 判断集合第一个对象的时间是否已经超过规定的时间
            //if (list_final.Count > 0)
            //{
            //    if (list_final.First().Dt < DateTime.Now.AddSeconds(seconds_add))
            //    {
            //        //7月28日添加若发送人数超过一百人需要连续进行两次查询
            //        var model = list_final.First();
            //        //获取总共需要查几遍
            //        int pageCount = (model.PersonCount / 100) + 1;
            //        //多次查询多次插入
            //        for (int i = 0; i < pageCount; i++)
            //        {
            //            //3.1 超过约定的时间执行查询操作
            //            ToQuery(list_final.First());
            //        }
            //        //ToShow("从最近的Redis集合中取出msgid" + DateTime.Now.ToLongDateString());
            //        //3.2 并从redis中删除第一个对象
            //        redisListhelper.Delete(list_id);
            //        //ToShow("取出集合首元素");
            //        //3.3 从redisList中取出排在第一个的对象
            //        list_final.RemoveAt(0);
            //        //3.4 继续执行此操作
            //        CheckTimeOut_RedisList(list_final, seconds_add);
            //    }
            //    else
            //    {
            //        //ToShow("现有Redis集合中以没有时间范围内的对象");
            //        //ToShow("现Redis集合中共有:" + list_final.Count());
            //        return;
            //    }
            //}
            ////直到出现集合第一个对象时间已经不再超过规定时间则跳出
            //else
            //{
            //    //ToShow("现有Redis集合中以没有时间范围内的对象");
            //    //ToShow("现Redis集合中共有:" + list_final.Count());
            //    return;
            //}
        }

        /// <summary>
        /// 根据msgid执行查询接收短信状态
        /// </summary>
        /// <param name="msgid"></param>
        public void ToQuery(PMS.Model.QueryModel.Redis_SMSContent model)
        {
            if (model.msgid == string.Empty)
            {
                //ToShow("读取msgid错误");
                return;
            }
            if (model.PhoneNums == string.Empty)
            {
                //ToShow("发送联系人列表为空");
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


            ISMS.ISMSQuery smsQuery = new SMSFactory.SMSQuery();

            bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg, out list_QueryReceive);
            if (!isGetReturnMsg)
            {
                // return Content("服务器错误");
            }
            //7 获取改次发送的SMSContent的ID
            IS_SMSContentBLL smsContentBLL = new PMS.BLL.S_SMSContentBLL();
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
                    //ToShow("当前取出的对象中接收内容有误");
                    return;
                }
                IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();

                bool isSaveCurrnetMsgOk = smsRecord_CurrentBLL.SaveReceieveMsg(list_QueryReceive, scid);
            }

        }
    }
}
