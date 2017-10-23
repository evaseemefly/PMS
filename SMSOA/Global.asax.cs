using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using PMS.Model;
using Spring.Web.Mvc;
using System.IO;
using System.Web.Http;


namespace SMSOA
{
    public class MvcApplication : SpringMvcApplication/*System.Web.HttpApplication*/
    {
        protected void Application_Start()
        {
            //读取log4net的配置信息
            //12月8日暂时注释掉
            //log4net.Config.XmlConfigurator.Configure();
            //将配置文件写在log4net.config文件中
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            AreaRegistration.RegisterAllAreas();
            //注册全局过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(App_Start.WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;

            string fileLogPath = Server.MapPath("/Log/");//保存错误日志文件的文件夹路径
            ThreadPool.QueueUserWorkItem((a)=>CallBack(), fileLogPath);  
        }

        ///// <summary>
        ///// 为国际化注册路由
        ///// </summary>
        ///// <param name="routes"></param>
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        "Globalization", // 路由名称
        //        "{lang}/{controller}/{action}/{id}", // 带有参数的 URL
        //        new { lang = "zh", controller = "Home", action = "Index", id = UrlParameter.Optional }, // 参数默认值
        //        new { lang = "^[a-zA-Z]{2}(-[a-zA-Z]{2})?$" }    //参数约束
        //    );

        //    routes.MapRoute(
        //        "Default", // 路由名称
        //        "{controller}/{action}/{id}", // 带有参数的 URL
        //        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
        //    );

        //}

        private void CallBack()
        {
            while(true)
            {
                //若错误队列中有数据
                if (PMS.Model.ExceptionModel.MyExceptionAttribute.exceptionQueue.Count()>0)
                {
                    //取出错误队列中的对象
                    Exception ex = PMS.Model.ExceptionModel.MyExceptionAttribute.exceptionQueue.Dequeue();
                    //向日志文件写入
                    if(ex!=null)
                    {
                        Common.LogHelper.WriteError("error", ex);
                      
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}
