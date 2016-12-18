using PMS.Model;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzByWCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //方式一：直接调用服务
            #region 直接调用服务
            //ServiceReference_QuartzService.IJobService jobSer = new ServiceReference_QuartzService.JobServiceClient();
            //J_JobInfo job = new J_JobInfo()
            //{
            //    JobName = "1234",
            //    JobGroup = "quartz",
            //    JobClassName = "QueryJob",
            //    StartRunTime = DateTime.Now.AddSeconds(2),
            //    EndRunTime = DateTime.Now.AddSeconds(3),
            //    UID = 3
            //};

            //QuartzJobFactory.IJobService jobClass = new QuartzJobFactory.JobService();
            //ServiceReference_QuartzService.JobServiceClient client = new ServiceReference_QuartzService.JobServiceClient();
            //client.AddScheduleJob(job, new PMS.Model.JobDataModel.SendJobDataModel());
            //jobClass.AddScheduleJob(job, null);
            //jobSer.AddScheduleJob(job, new PMS.Model.JobDataModel.SendJobDataModel());
            #endregion

            //方式二：使用代理类的方式
            QuartzProxy.QuartzServiceFacade quartzService = new QuartzProxy.QuartzServiceFacade(new QuartzProxy.QuartzServiceClientProxy());
            J_JobInfo jobInstance = new J_JobInfo()
            {
                JobName = "1234",
                JobGroup = "quartz",
                JobClassName = "QueryJob",
                StartRunTime = DateTime.Now.AddSeconds(2),
                EndRunTime = DateTime.Now.AddSeconds(3),
                UID = 3
            };

            PMS.Model.JobDataModel.SendJobDataModel jobData = new PMS.Model.JobDataModel.SendJobDataModel()
            {
                JobDataValue = new PMS.Model.CombineModel.SendAndMessage_Model()
                {
                    Model_Send = new SMSModel_Send()
                    { },

                    Model_Message = new PMS.Model.ViewModel.ViewModel_Message()
                    { }
                }
            };

            var response_base = quartzService.AddScheduleJob(jobInstance, jobData);
        }
    }
}
