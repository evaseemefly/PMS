using PMS.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Message;


namespace QuartzJobFactory
{
    public interface IJobService
    {
        
        #region 1 添加任务计划
        /// <summary>
        /// 根据工作对象 添加任务计划
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        IBaseResponse AddScheduleJob(J_JobInfo jobInfo, Object data_temp);
        #endregion

        #region 2 添加监听器——可用此种方式实现作业执行后更新数据库中状态——未使用此种方式
        /// <summary>
        /// 为指定的作业添加监听器
        /// </summary>
        /// <param name="jobListener"></param>
        /// <param name="JobName"></param>
        /// <param name="GroupName"></param>
        void AddListener(IJobListener jobListener, string JobName, string GroupName);
        
        #endregion

        #region 3 恢复全部作业
        /// <summary>
        /// 恢复全部作业
        /// </summary>
        void ResumeAllJob();
        #endregion

        #region 4 恢复指定作业
        /// <summary>
        /// 恢复指定的作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse ResumeTargetJob(J_JobInfo job);
        #endregion

        #region 5 删除指定作业
        /// <summary>
        /// 删除某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse RemovceJob(J_JobInfo job);
        #endregion

        #region 6 暂停指定作业
        /// <summary>
        /// 暂停某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        IBaseResponse PauseJob(J_JobInfo job);
        #endregion
    }
}
