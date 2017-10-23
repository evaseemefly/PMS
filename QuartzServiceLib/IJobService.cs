using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Quartz;
using PMS.Model.Message;
using PMS.IModel;

namespace QuartzServiceLib
{
    [ServiceContract]
    public interface IJobService
    {
        
        #region 1 添加任务计划
        /// <summary>
        /// 根据工作对象 添加任务计划
        /// 作业需要含UID
        /// </summary>
        /// <param name="jobInfo">作业（含UID）</param>
        /// <param name="data_temp">向作业调度中传的临时数据</param>
        /// <returns></returns>
        [OperationContract]
        //[ServiceKnownType(typeof(IJobData))]
        //[ServiceKnownType(typeof(PMS.Model.CombineModel.SendAndMessage_Model))]
        [ServiceKnownType(typeof(PMS.Model.JobDataModel.QueryJobDataModel))]
        [ServiceKnownType(typeof(PMS.Model.JobDataModel.SendJobDataModel))]
        [ServiceKnownType(typeof(PMS.Model.CombineModel.SendAndMessage_Model))]        
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        IBaseResponse AddScheduleJob(J_JobInfo jobInfo, /*PMS.Model.JobDataModel.SendJobDataModel*/IJobData data_temp);
        #endregion

        [OperationContract]
        #region 2 添加监听器——可用此种方式实现作业执行后更新数据库中状态——未使用此种方式
        /// <summary>
        /// 为指定的作业添加监听器
        /// </summary>
        /// <param name="jobListener"></param>
        /// <param name="JobName"></param>
        /// <param name="GroupName"></param>
        void AddListener(IJobListener jobListener, string JobName, string GroupName);

        #endregion

        [OperationContract]
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        #region 3 恢复全部作业
        /// <summary>
        /// 恢复全部作业
        /// </summary>
        void ResumeAllJob();
        #endregion

        [OperationContract]
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        #region 4 恢复指定作业
        /// <summary>
        /// 恢复指定的作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse ResumeTargetJob(J_JobInfo job);
        #endregion

        [OperationContract]
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        #region 5 删除指定作业
        /// <summary>
        /// 删除某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse RemovceJob(J_JobInfo job);
        #endregion

        [OperationContract]
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        #region 6 暂停指定作业
        /// <summary>
        /// 暂停某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse PauseJob(J_JobInfo job);
        #endregion

        [OperationContract]
        [ServiceKnownType(typeof(PMS.Model.Message.BaseResponse))]
        #region 7 终止指定作业
        /// <summary>
        /// 终止指定作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse RemoveJob(J_JobInfo job);
        #endregion
        
    }
}
