using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model;

namespace QueryWFLib
{

    public sealed class CheckMsgidExistInRedis : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public OutArgument<PMS.Model.Enum.ExistEnum> enum_Exist { get; set; }
        

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //判断传入的msgid是否在redis中
        //liu
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
        }
    }
}
