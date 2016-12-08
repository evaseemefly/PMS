using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Topshelf;
using Quartz.Impl;
using System.IO;
using QuartzJobFactory;

namespace JobManager.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            HostFactory.Run(hc =>
            {
                hc.Service<JobManagerService>(s =>
                {
                    s.ConstructUsing(a => new JobManagerService());
                    s.WhenStarted(a => a.Start());
                    s.WhenStopped(a => a.Stop());

                });

                hc.RunAsLocalSystem();

                hc.SetDescription("使用topshelf创建的作业调度服务");
                hc.SetDisplayName("quartz调度服务");
                hc.SetServiceName("quartzService");
            });

        }
    }
}
