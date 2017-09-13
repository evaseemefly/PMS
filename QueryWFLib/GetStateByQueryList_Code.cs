using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;
using PMS.Model.Enum;
using ISMS;
using Common.Ioc;

namespace QueryWFLib
{

    public sealed class GetStateByQueryList_Code : CodeActivity
    {

        ISMSQuery smsQuery;  /*new SMSFactory.SMSQuery();*/

        IMMSQuery mmsQuery; /*new SMSFactory.MMSQuery();*/

        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<PMS.Model.Enum.MMS_Enum> isMMS { get; set; }

        //返回查询状态（已改为枚举类型）
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        public OutArgument<QueryState_Enum> State { get; set; }

        //返回查询状态（已改为枚举类型）
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        //public OutArgument<QueryState_Enum> State_MMS { get; set; }

        /// <summary>
        /// 传入的查询回执对象集合
        /// </summary>
        public InArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }       

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            smsQuery = /*new SMSFactory.SMSQuery();*/UnityServiceLocator.Instance.GetService<ISMSQuery>();
            mmsQuery = /*new SMSFactory.MMSQuery();*/UnityServiceLocator.Instance.GetService<IMMSQuery>();
            //获取外部传入的参数
            #region 获取外部传入的参数
            var ismms = context.GetValue(this.isMMS);  
            //短信时获取短信查询集合
            var list_sms = context.GetValue(List_QueryReceive);
            #endregion

            QueryState_Enum state_enum=QueryState_Enum.error;
           
            switch (ismms)
            {
                case MMS_Enum.mms:
                    //根据传入的集合判断查询状态（结束，还可查询）
                    state_enum = mmsQuery.GetQueryState(list_sms);
                    break;
                default:                    
                    //根据传入的集合判断查询状态（结束，还可查询）
                    state_enum = smsQuery.GetQueryState(list_sms);                   
                    break;
            }
            //写入日志 2017-05-15
            LogIn(()=>{
                string msgid_temp = list_sms.FirstOrDefault() == null ? "empty" : list_sms.FirstOrDefault().msgId;
                Common.LogHelper.WriteLog(string.Format("步骤{0}：msgid为{1}传入的集合判断其状态{2}", "2", msgid_temp, state_enum.ToString()));
            });            
            context.SetValue(State, state_enum);
            //context.SetValue(State_MMS, state_enum_mms);
        }

        private void LogIn(Action action)
        {
            action();
        }
    }
}
