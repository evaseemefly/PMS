using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common;

namespace QueryWFLib
{

    public sealed class LogIn_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<string> LogIn { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            string logInfo = context.GetValue(this.LogIn);
           // LogHelper.WriteWarn(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+logInfo);
            
           LogHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + logInfo);
        }
    }
}
