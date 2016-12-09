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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;

            string fileLogPath = Server.MapPath("/Log/");//保存错误日志文件的文件夹路径
            ThreadPool.QueueUserWorkItem((a)=>CallBack(), fileLogPath);  
        }

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
