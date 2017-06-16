using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common;
//using System.Web.Http.Filters;

namespace SMSOA.Filters
{
    public class RangeExceptionAttribute : FilterAttribute,IExceptionFilter
    {
        /// <summary>
        /// 重写异常过滤器的接口
        /// </summary>
        /// <param name="filterContext"></param>
       public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled/*&&filterContext.Exception is ArgumentOutOfRangeException*/)
            {
                //1 重定向
                //可添加异常页面
                //filterContext.Result = new RedirectResult("~/Login/Login/Index");
                //2 指定该异常是否已经处理
                filterContext.ExceptionHandled = true;
                //3 记录日志
                if(filterContext.Exception is PMS.Model.ExceptionModel.PMSException)
                {
                    LogHelper.WriteError(string.Format("发生异常：{0}", filterContext.Exception.Message));
                    return;
                }
                LogHelper.WriteWarn(string.Format("发生异常：{0}", filterContext.Exception.ToString()));
            }            
        }
    }
}