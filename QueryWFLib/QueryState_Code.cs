using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.IBLL;
using PMS.Model.SMSModel;
using ISMS;

namespace QueryWFLib
{

    public sealed class QueryState_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<PMS.Model.Enum.MMS_Enum> isMMS { get; set; }
        

        //返回查询状态（先设定为string）类型
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        //public OutArgument<int> State { get; set; }

        /// <summary>
        /// 本次查询的回执
        /// </summary>
        public OutArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }

        //public OutArgument<List<MMSModel_QueryReceive>> List_QueryReceive_MMS { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //qu
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            //短彩信标识（枚举）
            var ismms = context.GetValue(this.isMMS);
            //执行查询操作
            var list_query = new List<PMS.IModel.SMSModel.IQueryReceive>();    

            ISMSQuery smsQuery;
            //此处查询只是将msgid传入即可
            //只保留smsIndex为1的xml节点并转成对象集合
            switch (ismms)
            {
                case PMS.Model.Enum.MMS_Enum.mms:
                    smsQuery=new SMSFactory.MMSQuery();
                    break;
                case PMS.Model.Enum.MMS_Enum.sms:
                    smsQuery = new SMSFactory.SMSQuery();
                    break;
                default:
                    smsQuery = new SMSFactory.SMSQuery();
                    break;
            }
            var list_QueryReceive = new List<SMSModel_QueryReceive>();
           bool isGetReturnMsg = ToQueryList(smsQuery, out list_QueryReceive);
            //根据传入的状态集合进行判断当前的状态
            //赋值
            //此处可不判断查询状态
            context.SetValue(List_QueryReceive, list_QueryReceive);
        }

        /// <summary>
        /// 根据传入的query（短彩信查询实现对象）查询并以集合的形式放回
        /// </summary>
        /// <param name="query"></param>
        /// <param name="list_QueryReceive_mms"></param>
        /// <returns></returns>
        private bool ToQueryList(ISMSQuery query,out List<SMSModel_QueryReceive> list_QueryReceive_mms)
        {
            //读取配置文件中的账号及密码
            Common.Config.SMSSignConfigHelper smsSign = new Common.Config.SMSSignConfigHelper();
            SMSModel_Query sign = new SMSModel_Query()
            {
                account = smsSign.account,
                password = smsSign.password
            };
          
            //6 查询发送状态            
            //根据传入的信息进行查询，并有一个状态信息集合
            return query.QueryMsg(sign, out list_QueryReceive_mms);            
        }

        //查询彩信
        private PMS.Model.Enum.QueryState_Enum ToQueryFunc_MMS(CodeActivityContext context,PMS.IModel.SMSModel.IQuerySign sign)
        {
            
            IMMSQuery smsQuery = new SMSFactory.MMSQuery();
            //6 查询发送状态
            List</*MMSModel_QueryReceive*/SMSModel_QueryReceive> list_QueryReceive_mms;
            var state = new PMS.Model.Enum.QueryState_Enum();
            //根据传入的信息进行查询，并有一个状态信息集合
            bool isGetReturnMsg = smsQuery.QueryMsg(sign, out list_QueryReceive_mms);
            //将查询集合写回上下文中
            context.SetValue(List_QueryReceive, list_QueryReceive_mms);
            //根据传入的状态集合进行判断当前的状态
            var enum_state = smsQuery.GetQueryState(list_QueryReceive_mms);
           state = enum_state;
            if (!isGetReturnMsg)
            {
                //查询结果有问题，跳出本次查询
               state = PMS.Model.Enum.QueryState_Enum.error;
            }        
            return state;
        }

        //查询短信
        private PMS.Model.Enum.QueryState_Enum ToQueryFunc_SMS(CodeActivityContext context,PMS.IModel.SMSModel.IQuerySign sign)
        {

            //以后通过spring .net 实现
            //设置状态初始值为未知状态
            var state = PMS.Model.Enum.QueryState_Enum.unknown;

            ISMSQuery smsQuery = new SMSFactory.SMSQuery();

           
            List<SMSModel_QueryReceive> list_QueryReceive;

            //根据传入的信息进行查询，并有一个状态信息集合
            bool isGetReturnMsg = smsQuery.QueryMsg(sign, out list_QueryReceive);
            //将查询集合写回上下文中
            context.SetValue(List_QueryReceive, list_QueryReceive);
            //根据传入的状态集合进行判断当前的状态
            var enum_state = smsQuery.GetQueryState(list_QueryReceive);

            //为变量赋值            
            state = enum_state;

            if (!isGetReturnMsg)
            {
                //查询结果有问题，跳出本次查询
              state = PMS.Model.Enum.QueryState_Enum.error;
               
            }
            return state;
        }

        #region 之前的短彩信查询——已注释
        /// <summary>
        /// 根据msgid执行查询接收短信状态
        /// qu
        /// </summary>
        /// <param name="msgid"></param>
        //public static void ToQuery(out List<SMSModel_QueryReceive> list_queryReceive, out int state)
        //{
        //    //IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();
        //    //以后通过spring .net 实现
        //    //设置状态初始值为未知状态
        //    state = (int)PMS.Model.Enum.QueryState_Enum.unknown;
        //    ISMSQuery smsQuery = new SMSFactory.SMSQuery();

        //    IS_SMSContentBLL smsContentBLL = new PMS.BLL.S_SMSContentBLL();
        //    IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();

        //    //2017-01-22 通过config帮助类从配置文件中读取账号及密码
        //    //string account = "dh74381"; //账号"dh74381";
        //    //string passWord = "uAvb3Qey";//密码 = "uAvb3Qey";

        //    Common.Config.SMSSignConfigHelper smsSign = new Common.Config.SMSSignConfigHelper();

        //    //6 查询发送状态(是否加入等待时间？)
        //    SMSModel_Query queryMsg = new SMSModel_Query()
        //    {
        //        account = smsSign.account,
        //        password = smsSign.password

        //        //phoneNums=model.PhoneNums
        //    };
        //    List<SMSModel_QueryReceive> list_QueryReceive;

        //    //根据传入的信息进行查询，并有一个状态信息集合
        //    bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg, out list_QueryReceive);
        //    //根据传入的状态集合进行判断当前的状态
        //    var enum_state = smsQuery.GetQueryState(list_QueryReceive);

        //    //为变量赋值
        //    list_queryReceive = list_QueryReceive;
        //    state = (int)enum_state;

        //    if (!isGetReturnMsg)
        //    {
        //        //查询结果有问题，跳出本次查询
        //        state = (int)PMS.Model.Enum.QueryState_Enum.error;
        //        return;
        //        // return Content("服务器错误");
        //    }


        //    #region 判断是否包含report标签留到后面实现
        //    ////当查询返回的集合数量为1，且唯一的对象的desc为成功，则直接跳出，不进行下面的操作，并对state赋值为1
        //    //if (list_QueryReceive.Count() == 1 && list_queryReceive.FirstOrDefault().desc == "成功" && list_queryReceive.FirstOrDefault().phoneNumber == null)
        //    //{
        //    //    //返回的desc=成功
        //    //    state = 1;

        //    //    //return;
        //    //}
        //    #endregion

        //    #region 写入数据库操作留到后面实现
        //    //7 获取该次发送的SMSContent的ID
        //    //var list = smsContentBLL.GetListBy(p => p.msgId.Equals(0));
        //    //int scid = list.FirstOrDefault().ID;

        //    ////向数据库中写入本集合中的对象   
        //    //bool isSaveCurrnetMsgOk = smsRecord_CurrentBLL.SaveReceieveMsg(list_QueryReceive, scid);
        //    //if (list_QueryReceive.Count() == 0)
        //    //{
        //    //    state = 99;
        //    //    //ToShow("当前取出的对象中接收内容有误");
        //    //    //return;
        //    //}
        //    #endregion
        //}

        /// <summary>
        /// 彩信查询
        /// </summary>
        /// <param name="list_queryReceive"></param>
        /// <param name="state"></param>
        //public static void ToQuery(out List<MMSModel_QueryReceive> list_queryReceive, out int state)
        //{

        //    //以后通过spring .net 实现
        //    //设置状态初始值为未知状态
        //    state = (int)PMS.Model.Enum.QueryState_Enum.unknown;
        //    IMMSQuery smsQuery = new SMSFactory.MMSQuery();

        //    Common.Config.SMSSignConfigHelper smsSign = new Common.Config.SMSSignConfigHelper();



        //    //6 查询发送状态
        //    MMSModel_Query queryMsg = new MMSModel_Query()
        //    {
        //        account = smsSign.account,
        //        password = smsSign.password
        //    };
        //    List<MMSModel_QueryReceive> list_QueryReceive;

        //    //根据传入的信息进行查询，并有一个状态信息集合
        //    bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg, out list_QueryReceive);
        //    //根据传入的状态集合进行判断当前的状态
        //    var enum_state = smsQuery.GetQueryState(list_QueryReceive);

        //    //为变量赋值
        //    list_queryReceive = list_QueryReceive;
        //    state = (int)enum_state;

        //    if (!isGetReturnMsg)
        //    {
        //        //查询结果有问题，跳出本次查询
        //        state = (int)PMS.Model.Enum.QueryState_Enum.error;
        //        return;
        //    }
        //}
        #endregion
    }
}
