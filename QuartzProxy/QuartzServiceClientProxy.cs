using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using QuartzServiceLib;
using PMS.IModel;
using PMS.Model;
using PMS.Model.JobDataModel;


namespace QuartzProxy
{
    /// <summary>
    /// 作业调度服务代理类
    /// </summary>
   public class QuartzServiceClientProxy:ClientBase<ServiceReference_QuartzService.IJobService>,ServiceReference_QuartzService.IJobService
    {
        public void AddListener(object jobListener, string JobName, string GroupName)
        {
            throw new NotImplementedException();
        }

        public Task AddListenerAsync(object jobListener, string JobName, string GroupName)
        {
            throw new NotImplementedException();
        }

        public object AddScheduleJob(J_JobInfo jobInfo, IJobData data_temp)
        {
            var response= base.Channel.AddScheduleJob(jobInfo, data_temp) as PMS.Model.Message.BaseResponse;

            return response;
        }
        

        public Task<object> AddScheduleJobAsync(J_JobInfo jobInfo, SendJobDataModel data_temp)
        {
            throw new NotImplementedException();
        }

        public Task<object> AddScheduleJobAsync(J_JobInfo jobInfo, object data_temp)
        {
            throw new NotImplementedException();
        }

        public object PauseJob(J_JobInfo job)
        {
            var response = base.Channel.PauseJob(job) as PMS.Model.Message.BaseResponse;
            return response;
        }

        public Task<object> PauseJobAsync(J_JobInfo job)
        {
            throw new NotImplementedException();
        }

        public object RemovceJob(J_JobInfo job)
        {
            throw new NotImplementedException();
        }

        public Task<object> RemovceJobAsync(J_JobInfo job)
        {
            throw new NotImplementedException();
        }

        public void ResumeAllJob()
        {
            base.Channel.ResumeAllJob();
        }

        public object RemoveJob(J_JobInfo job)
        {
            return base.Channel.RemoveJob(job);
        }

        public Task<object> RemoveJobAsync(J_JobInfo job)
        {
            throw new NotImplementedException();
        }


        public Task ResumeAllJobAsync()
        {
            throw new NotImplementedException();
        }

        public object ResumeTargetJob(J_JobInfo job)
        {
            return base.Channel.ResumeTargetJob(job);
        }

        public Task<object> ResumeTargetJobAsync(J_JobInfo job)
        {
            throw new NotImplementedException();
        }

        public object AddScheduleJob(J_JobInfo jobInfo, object data_temp)
        {
            var response = base.Channel.AddScheduleJob(jobInfo, data_temp) as PMS.Model.Message.BaseResponse;

            return response;
        }
    }
}
