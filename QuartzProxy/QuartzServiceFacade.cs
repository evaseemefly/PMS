using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzServiceLib;
using PMS.IModel;
using PMS.Model.Message;
using PMS.Model;

namespace QuartzProxy
{
   public class QuartzServiceFacade
    {
        private ServiceReference_QuartzService.IJobService jobService;

        /// <summary>
        /// 使用构造函数实现依赖注入（wcf代理类）
        /// </summary>
        /// <param name="jobSer"></param>
        public QuartzServiceFacade(ServiceReference_QuartzService.IJobService jobSer)
        {
            this.jobService = jobSer;
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <param name="data_temp"></param>
        /// <returns></returns>
        public IBaseResponse AddScheduleJob(J_JobInfo jobInfo, /*PMS.Model.JobDataModel.SendJobDataModel*/IJobData data_temp)
        {
            return jobService.AddScheduleJob(jobInfo.ToMiddleModel(),data_temp) as IBaseResponse;
        }

        /// <summary>
        /// 恢复全部作业
        /// </summary>
        public void ResumeAllJob()
        {
            jobService.ResumeAllJob();
        }

        /// <summary>
        /// 恢复指定作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse ResumeTargetJob(J_JobInfo job)
        {
           return jobService.ResumeTargetJob(job.ToMiddleModel()) as IBaseResponse;
        }

        /// <summary>
        /// 暂未实现
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse RemovceJob(J_JobInfo job)
        {
            return jobService.RemovceJob(job.ToMiddleModel()) as IBaseResponse;
        }

        /// <summary>
        /// 暂停指定作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse PauseJob(J_JobInfo job)
        {
            return jobService.PauseJob(job.ToMiddleModel()) as IBaseResponse;
        }

        /// <summary>
        /// 终止指定作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse RemoveJob(J_JobInfo job)
        {
            return jobService.RemoveJob(job.ToMiddleModel()) as IBaseResponse;
        }
    }
}
