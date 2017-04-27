using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryWFLib;
using PMS.BLL;
using Quartz;
using Quartz.Impl;

namespace WF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Activity workflow_temp = new QueryWFLib.Activity1();
            //var dic = new Dictionary<string, object>() { };
            //var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);

            Run();

            //PMS.IBLL.IS_SMSContentBLL contentBLL = new S_SMSContentBLL();
            //var content_temp = contentBLL.GetListBy(c => c.msgId == "1").FirstOrDefault();
            Console.ReadLine();
        }

       private static void Run()
        {
            //构造调度工厂
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            //获取一个调度
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<QueryJob>()
                .WithIdentity("myQueryJob", "query")
                //UsingJobData("isMMS",(int)PMS.Model.Enum.MMS_Enum.mms)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myQueryTrigger", "query")
              .StartNow()
              //.WithSimpleSchedule(x => x
              //    //.WithIntervalInSeconds(120)
              //    .RepeatForever())
              .Build();

            sched.ScheduleJob(job, trigger);

            sched.Start();
        }
    }
}
