using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Threading;
using PMS.IBLL;
using PMS.BLL;
using PMS.Model;

namespace ConsoleApplication2
{
    public class HttpJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ThreadPool.QueueUserWorkItem(delegate (Object o)
            {
                IQuartz_JobBLL jobBLL = new Quartz_JobBLL();
                try
                {
                    //DoApplication.WriteLogFile(context.JobDetail.Key.Group + "---" + context.JobDetail.Key.Name + "---" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "---" + context.NextFireTimeUtc.Value.DateTime.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"));
                    //jobBLL.GetListBy
                    //var sm = new WJ_ScheduleManage().GetScheduleModel(new WJ_ScheduleEntity() { JobGroup = context.JobDetail.Key.Group, JobName = context.JobDetail.Key.Name });
                    //
                    Quartz_Job jobModel = new Quartz_Job()
                    {
                        JobName = context.JobDetail.Key.Name,
                        JobValue=context.JobDetail.Key.Group,
                        State=1,//执行中

                    };

                    jobBLL.Create(jobModel);


                    //new WJ_ScheduleManage().UpdateScheduleRunStatus(new WJ_ScheduleEntity() { JobGroup = context.JobDetail.Key.Group, JobName = context.JobDetail.Key.Name, RunStatus = (int)ADJ.Job.Entity.EnumType.JobRunStatus.执行中 });
                    //ESBRequest req = new ESBRequest(sm.ServiceCode, sm.ApiCode);

                    //DataResult result = req.Request();
                    //new WJ_ScheduleManage().UpdateScheduleRunStatus(new WJ_ScheduleEntity() { JobGroup = context.JobDetail.Key.Group, JobName = context.JobDetail.Key.Name, RunStatus = (int)ADJ.Job.Entity.EnumType.JobRunStatus.待运行 });
                    //if (result.Code == 1)
                    //{
                    //    #region 加入执行明细
                    //    WJ_ScheduleDetailsEntity dm = new WJ_ScheduleDetailsEntity();
                    //    dm.ActionDescribe = "执行完成:" + result.Message;
                    //    dm.ActionStep = (int)ADJ.Job.Entity.EnumType.JobStep.执行完成;
                    //    dm.CreateTime = DateTime.Now;
                    //    dm.JobGroup = context.JobDetail.Key.Group;
                    //    dm.JobName = context.JobDetail.Key.Name;
                    //    dm.IsSuccess = 1;
                    //    new WJ_ScheduleManage().AddScheduleDetails(dm);
                    //    #endregion
                    //}
                    //else
                    //{
                    //    #region 加入执行明细
                    //    WJ_ScheduleDetailsEntity dm = new WJ_ScheduleDetailsEntity();
                    //    dm.ActionDescribe = "执行任务计划中，执行计划过程出错." + result.Message;
                    //    dm.ActionStep = (int)ADJ.Job.Entity.EnumType.JobStep.执行任务计划中;
                    //    dm.CreateTime = DateTime.Now;
                    //    dm.JobGroup = context.JobDetail.Key.Group;
                    //    dm.JobName = context.JobDetail.Key.Name;
                    //    dm.IsSuccess = 0;
                    //    new WJ_ScheduleManage().AddScheduleDetails(dm);
                    //    #endregion
                    //}
                    //new WJ_ScheduleManage().UpdateScheduleNextTime(new WJ_ScheduleEntity() { JobGroup = context.JobDetail.Key.Group, JobName = context.JobDetail.Key.Name, NextTime = context.NextFireTimeUtc.Value.DateTime.AddHours(8) });
                }
                catch (Exception ex)
                {
                    //#region 加入执行明细
                    //WJ_ScheduleDetailsEntity dm = new WJ_ScheduleDetailsEntity();
                    //dm.ActionDescribe = "执行任务计划中，执行计划过程出错：" + ex.Message + "/r/n" + ex.StackTrace;
                    //dm.ActionStep = (int)ADJ.Job.Entity.EnumType.JobStep.执行任务计划中;
                    //dm.CreateTime = DateTime.Now;
                    //dm.JobGroup = context.JobDetail.Key.Group;
                    //dm.JobName = context.JobDetail.Key.Name;
                    //dm.IsSuccess = 0;
                    //new WJ_ScheduleManage().AddScheduleDetails(dm);
                    //#endregion
                    //DoApplication.WriteLogFile(ex.Message + "\r\n" + ex.StackTrace);
                }
            });
        }
        
    }
}
