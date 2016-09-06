using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFTest
{

    public sealed class QueryState_BookMark : NativeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// 工作流名称
        /// </summary>
        public InArgument<string> BookMarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            //1 从当前的上下文对象中获取指定名称的书签
            string bookMarkName = context.GetValue(BookMarkName);
            //2 创建书签
            context.CreateBookmark(bookMarkName, new BookmarkCallback(ContinueExecuteWF));
            throw new NotImplementedException();
        }

        /// <summary>
        /// 恢复bookmark后调用的方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public void ContinueExecuteWF(
    NativeActivityContext context,
    Bookmark bookmark,object value)
        {
            //继续执行查询方法

        }

    }
}
