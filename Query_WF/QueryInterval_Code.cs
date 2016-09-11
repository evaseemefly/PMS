using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;

namespace Query_WF
{

    public sealed class QueryInterval_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        //public InArgument<string> Text { get; set; }
        /// <summary>
        /// 线程休眠时间
        /// </summary>
        public InArgument<int> Sleep_Interval { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);
            //执行休眠操作
            Console.WriteLine("线程开始休眠Zzzzzzzz......");
            int sleep_time = context.GetValue(Sleep_Interval);
            Thread.Sleep(sleep_time);
            Console.WriteLine("已唤醒！");
        }
    }
}
