using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IModel;
using Common;

namespace QuartzServiceLib
{
    public static class JobFactory
    {
        /// <summary>
        /// 根据Class名称通过反射的方式创建IJobDetial
        /// 注意需要向J_JobInfo中拓展的UID赋值
        /// 修改传入的对象为IJ_JobInfo的实现类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IJobDetail CreateJobInstance(IJ_JobInfo jobInfo, IJobData jobdatamap)
        {
            //1 通过反射的方式创建Job实例
            IJob job_temp = null;
            IJobDetail job = null;
            try
            {
                job_temp = JobAbstractFactory.CreateJob(jobInfo.JobClassName);

            }
            catch (Exception)
            {
                return null;
            }           
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
            try
            {
                job = JobBuilder.Create(type)
                                    .WithIdentity(jobInfo.JID.ToString(), jobInfo.JobGroup)
                                    .UsingJobData("UID", jobInfo.UID)
                                    .UsingJobData(jobdatamap.JobDataKey, SerializerHelper.SerializerToString(jobdatamap.JobDataValue))        //添加一个需要传向作业调度中的对象（发送对象——含一些必要的信息）
                                    
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
            var trigger = TriggerBuilder.Create()
                         .WithIdentity(jobInfo.JID.ToString(), jobInfo.JobGroup)      //添加Job名（现使用的是JID——防止重名）与群组名
                         .StartAt(jobInfo.StartRunTime) //任务起始时间
                         .EndAt(jobInfo.EndRunTime);//终止时间
            if (jobInfo.Interval_quartz != 0)
            {
                //配置触发器中重复执行的时间间隔
                //trigger= trigger.WithSimpleSchedule(a => a.WithIntervalInSeconds(jobInfo.Interval_quartz)); 

            }
            //根据条件添加Cron表达式
            if (jobInfo.CronStr != null)
            {
               trigger= trigger.WithCronSchedule(jobInfo.CronStr);
                //trigger= trigger.WithCronSchedule("0/10 * * * * ?");
            }

            //创建最终的计时器并返回
            return trigger.Build();
        }
    }
}
