using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Models
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 异常队列
        /// </summary>
        public static Queue<Exception> exceptionQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //1 将异常处理上下文中的异常对象加入到异常队列中
            exceptionQueue.Enqueue(filterContext.Exception);
            //2 跳转至错误页面
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}