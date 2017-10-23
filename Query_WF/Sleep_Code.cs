using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Query_WF
{

    public sealed class Sleep_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// 传入的休眠时间
        /// </summary>
        public InArgument<int> Sec { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            //根据传入的休眠时间（秒），将当前线程挂起n秒
            
        }
    }
}
