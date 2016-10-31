using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace QuartzJobFactory
{
    public static class JobFactory
    {
        /// <summary>
        /// 根据Class名称通过反射的方式创建IJobDetial
        /// 注意需要向J_JobInfo中拓展的UID赋值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IJobDetail CreateJobInstance(J_JobInfo jobInfo)
        {
            //1 通过反射的方式创建Job实例
            IJob job_temp= JobAbstractFactory.CreateJob(jobInfo.JobClassName);
            //2 获取创建的Job实例的Type
            Type type = job_temp.GetType();
            #region 注释掉用以下方式替代
            //var obj= Activator.CreateInstance(type);

            //正常创建：
            //IJobDetail job=JobBuilder.Create<Job_Test>()
            //                        .WithIdentity("myJob", "group1")
            //                        .Build();
            #endregion
            //3 创建Job
            //获取传递过来的UID
            IJobDetail job = JobBuilder.Create(type)
                                    .WithIdentity(jobInfo.JobName, jobInfo.JobGroup)
                                    .UsingJobData("UID",jobInfo.UID)
                                    .Build();
            return job;
        }

        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        public static ITrigger CreateTrigger(J_JobInfo jobInfo)
        {
            //
            var trigger = TriggerBuilder.Create()
                          .WithIdentity(jobInfo.JobName, jobInfo.JobGroup)      //添加Job名与群组名
                          .StartAt(jobInfo.StartRunTime) //任务起始时间
                          .EndAt(jobInfo.EndRunTime);   //终止时间

            //根据条件添加Cron表达式
            if (jobInfo.CronStr != null)
            {
                trigger.WithCronSchedule(jobInfo.CronStr);
            }

            //创建最终的计时器并返回
           return trigger.Build();
        }
    }
}
