using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;
using PMS.Model.Enum;
using ISMS;

namespace QueryWFLib
{

    public sealed class GetStateByQueryList_Code : CodeActivity
    {

        ISMSQuery smsQuery = new SMSFactory.SMSQuery();

        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        //返回查询状态（已改为枚举类型）
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        public OutArgument<QueryState_Enum> State { get; set; }

        /// <summary>
        /// 传入的查询回执对象集合
        /// </summary>
        public InArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            
            List<SMSModel_QueryReceive> list = context.GetValue(List_QueryReceive);

            //根据传入的集合判断查询状态（结束，还可查询）
            var state_enum = smsQuery.GetQueryState(list);

            context.SetValue(State, state_enum);
        }
    }
}
