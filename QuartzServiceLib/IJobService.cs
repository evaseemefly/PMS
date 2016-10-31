using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Quartz;

namespace QuartzServiceLib
{
    [ServiceContract]
    public interface IJobService
    {
        /// <summary>
        /// 根据工作对象 添加任务计划
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddScheduleJob(J_JobInfo jobInfo);

        /// <summary>
        /// 恢复全部作业
        /// </summary>
        [OperationContract]
        void ResumeAllJob();

        /// <summary>
        /// 根据作业名及群组名暂停指定作业
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="jobGroup"></param>
        [OperationContract]
        void PauseJob(string jobName, string jobGroup);

        void AddListener(IJobListener jobListener, string JobName, string GroupName);
    }
}
