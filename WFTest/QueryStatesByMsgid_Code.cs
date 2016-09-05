using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;

namespace WFTest
{

    public sealed class QueryStatesByMsgid_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数E:\03协同开发\短信\PMS\0630\PMS\WFTest\QueryStatesByMsgid_Code.cs
        public InArgument<string> Text { get; set; }

            /// <summary>
            /// 查询条件对象
            /// </summary>
        public InArgument<SMSModel_Query> query_model { get; set; }

        //返回查询状态（先设定为string）类型
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        public OutArgument<bool> State { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);
            
            //进行查询传入的msgid的
            
        }
    }
}
