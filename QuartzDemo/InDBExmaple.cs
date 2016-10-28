using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    public class InDBExmaple
    {
        public static IScheduler scheduler = null;

        public static IScheduler GetScheduler()
        {
            if (scheduler != null)
            {
                return scheduler;
            }
            else
            {
                //写在配置文件中
                #region 创建properties对象——已注释
                ////1.首先创建一个作业调度池 
                //var properties = new System.Collections.Specialized.NameValueCollection();
                ////存储类型 
                //properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";

                ////表明前缀 
                //properties["quartz.jobStore.tablePrefix"] = "QRTZ_";

                ////驱动类型 
                //properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";

                ////数据源名称 
                //properties["quartz.jobStore.dataSource"] = "PMS20160406";
                ////连接字符串
                //properties["quartz.dataSource.PMS20160406.connectionString"] = "Data Source=DESKTOP-5A1BQQ7;Initial Catalog=PMS20160406;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                ////sqlserver版本
                //properties["quartz.dataSource.PMS20160406.provider"] = "SqlServer-20";
                //最大链接数 
                //properties["quartz.dataSource.myDS.maxConnections"] = "5"; 
                #endregion

                //ISchedulerFactory sf = new StdSchedulerFactory(properties);
                var sched = StdSchedulerFactory.GetDefaultScheduler();
                //IScheduler sched = sf.GetScheduler();
                return sched;
            }
        }

        public void Run()
        {


            var scheduler_temp = GetScheduler();
            IJobDetail job = JobBuilder.Create<HelloJob>()
                                       .WithIdentity("testname", "testgroup")
                                       .Build();

            DateTime dt_now = DateTime.Now;

            var trigger = TriggerBuilder.Create()
                .StartAt(dt_now.AddSeconds(15))
                .EndAt(dt_now.AddSeconds(16))
                .Build();

            scheduler_temp.ScheduleJob(job, trigger);

            scheduler_temp.Start();
        }

        public void PauseAll()
        {
            var scheduler_temp = GetScheduler();
            scheduler_temp.PauseAll();
        }

        public void ResumeJob(string jobName, string jobGroup)
        {
            var scheduler_temp = GetScheduler();
            if (!scheduler_temp.IsStarted) { scheduler_temp.Start(); }
            //scheduler.ResumeTrigger(new TriggerKey(jobName, jobGroup)); 
            scheduler_temp.ResumeJob(JobKey.Create(jobName, jobGroup));
        }
    }
}
