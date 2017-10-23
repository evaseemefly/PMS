using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace QuartzDemo
{
    public class PlanJobManager
    {
        /// <summary>
        /// 任务计划
        /// </summary>
        public static IScheduler scheduler = null;
        public static IScheduler GetScheduler()
        {
            if (scheduler != null)
            {
                return scheduler;
            }
            else
            {
                ISchedulerFactory schedf = new StdSchedulerFactory();
                IScheduler sched = schedf.GetScheduler();
                return sched;
            }
        }
        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <returns></returns>
        public bool AddScheduleJob(J_JobInfo m)
        {
            try
            {
                if (m != null)
                {
                    if (m.StartRunTime == null)
                    {
                        m.StartRunTime = DateTime.Now;
                    }
                    DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(m.StartRunTime, 1);
                    if (m.EndRunTime == null)
                    {
                        m.EndRunTime = DateTime.MaxValue.AddDays(-1);
                    }
                    DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(m.EndRunTime, 1);
                    scheduler = GetScheduler();
                    IJobDetail job = JobBuilder.Create<HttpJob>()
                      .WithIdentity(m.JobName, m.JobGroup)
                      .Build();
                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                 .StartAt(starRunTime)
                                                 .EndAt(endRunTime)
                                                 .WithIdentity(m.JobName, m.JobGroup)
                                                 .WithCronSchedule(m.CronStr)
                                                 .Build();
                    scheduler.ScheduleJob(job, trigger);
                    scheduler.Start();
                    //StopScheduleJob(m.JobValue, m.JobName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //DoApplication.WriteLogFile(ex.Message + "\r\n" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 暂停指定任务计划
        /// </summary>
        /// <returns></returns>
        //public string StopScheduleJob(string jobGroup, string jobName)
        //{
        //    try
        //    {
        //        scheduler = GetScheduler();
        //        scheduler.PauseJob(new JobKey(jobName, jobGroup));
        //        new WJ_ScheduleManage().UpdateScheduleStatus(new WJ_ScheduleEntity() { JobName = jobName, JobGroup = jobGroup, Status = (int)ADJ.Job.Entity.EnumType.JobStatus.已停止 });
        //        return Json(new StatusView() { Status = 0, Msg = "停止任务计划成功！" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        DoApplication.WriteLogFile(ex.Message + "/r/n" + ex.StackTrace);
        //        return Json(new StatusView() { Status = -1, Msg = "停止任务将计划失败！" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        /// <summary>
        /// 开启指定的任务计划
        /// </summary>
        /// <returns></returns>
        //public JsonResult RunScheduleJob(string jobGroup, string jobName)
        //{
        //    try
        //    {
        //        var sm = new WJ_ScheduleManage().GetScheduleModel(new WJ_ScheduleEntity() { JobName = jobName, JobGroup = jobGroup });
        //        AddScheduleJob(sm);
        //        sm.Status = (int)ADJ.Job.Entity.EnumType.JobStatus.已启用;
        //        new WJ_ScheduleManage().UpdateScheduleStatus(sm);
        //        scheduler = GetScheduler();
        //        scheduler.ResumeJob(new JobKey(jobName, jobGroup));
        //        return Json(new StatusView() { Status = 0, Msg = "启动成功！" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        DoApplication.WriteLogFile(ex.Message + "/r/n" + ex.StackTrace);
        //        return Json(new StatusView() { Status = -1, Msg = "启动失败！" }, JsonRequestBehavior.AllowGet);
        //    }
        //}


    }
}
