using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IModel;

namespace QuartzJobFactory
{
    static class JobFactory
    {
        /// <summary>
        /// 根据Class名称通过反射的方式创建IJobDetial
        /// 注意需要向J_JobInfo中拓展的UID赋值
        /// 修改传入的对象为IJ_JobInfo的实现类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IJobDetail CreateJobInstance(IJ_JobInfo jobInfo)
        {
            //1 通过反射的方式创建Job实例
            IJob job_temp= JobAbstractFactory.CreateJob(jobInfo.JobClassName);
            //2 获取创建的Job实例的Type
            Type type = job_temp.GetType();
            IJobDetail job = null;
            #region 注释掉用以下方式替代
            //var obj= Activator.CreateInstance(type);

            //正常创建：
            //IJobDetail job=JobBuilder.Create<Job_Test>()
            //                        .WithIdentity("myJob", "group1")
            //                        .Build();
            #endregion
            //3 创建Job
            //获取传递过来的UID
            try
            {
                job = JobBuilder.Create(type)
                                    .WithIdentity(jobInfo.JID.ToString(), jobInfo.JobGroup)
                                    .UsingJobData("UID", jobInfo.UID)
                                    .Build();
            }
            catch (Exception)
            {
                
            }
            
            return job;
        }

        /// <summary>
        /// 创建计时器
        /// 修改传入的对象为IJ_JobInfo的实现类
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
       public static ITrigger CreateTrigger(IJ_JobInfo jobInfo)
        {
            //
            var trigger = TriggerBuilder.Create()
                          .WithIdentity(jobInfo.JID.ToString(), jobInfo.JobGroup)      //添加Job名（现使用的是JID——防止重名）与群组名
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
