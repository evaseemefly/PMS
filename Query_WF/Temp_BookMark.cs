using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Query_WF
{

    public sealed class Temp_BookMark<T> : NativeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<string> BookName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {

            context.CreateBookmark("测试书签", new BookmarkCallback(ContinueExecuteWF));
        }

        /// <summary>
        /// 需要重写此方法并返回true，否则工作流无法执行异步操作
        /// </summary>
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 恢复bookmark后调用的方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public void ContinueExecuteWF(
    NativeActivityContext context,
    Bookmark bookmark, object value)
        {
            //继续执行查询方法
            //var data = (PMS.Model.WFModel.BookMarkObj<T>)value;
            var data = value.ToString();
        }
    

    }
}
