using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Collections.Specialized;
using Quartz.Impl;
using Quartz;
using Quartz.Impl.Matchers;
using PMS.Model.Message;
using PMS.IModel;
using Common;

namespace QuartzServiceLib
{
    public class JobService:IJobService
    {
        /// <summary>
        /// 定义为静态的属性（只能被赋值一遍）
        /// </summary>
       static IScheduler sche { get; set; }

        //*****12月7日添加：锁
        private static object obj = new object();

        #region 无参构造函数实例化调度池
        public JobService()
        {
            //if (sche != null)
            //{

            //}
            //else
            //{
            //    sche = StdSchedulerFactory.GetDefaultScheduler();
            //}
            InitScheduler();
        }

        #endregion

        static void InitScheduler()
        {
            try
            {
                lock (obj)
                {
                    if (sche == null)
                    {
                        //使用配置文件的方式配置quartz实例
                        sche = StdSchedulerFactory.GetDefaultScheduler();
                        LogHelper.WriteLog("任务调度初始化成功");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("任务调度初始化失败！", ex);
            }
        }

        /// <summary>
        /// *****12月7日添加
        /// 启动调度池
        /// </summary>
        public static void StartScheduler()
        {
            try
            {
                //若作业调度池为空，则需要初始化
                if (sche == null)
                {
                    InitScheduler();
                }
                if (!sche.IsStarted)
                {
                    sche.Start();
                    LogHelper.WriteLog("调度池启动成功");
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteError("调度池启动失败", ex);
            }
        }

        /// <summary>
        /// *****12月7日添加
        /// 终止调度池
        /// </summary>
        public static void StopScheduler()
        {
            try
            {
                //若作业调度池为空，则需要初始化
                if (sche == null)
                {
                    InitScheduler();
                }
                if (!sche.IsShutdown)
                {
                    sche.Shutdown(true);
                    LogHelper.WriteLog("调度池停止");
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteError("调度池停止失败", ex);
            }
        }

        #region 1 添加任务计划
        /// <summary>
        /// 根据工作对象 添加任务计划
        /// 作业需要含UID
        /// </summary>
        /// <param name="jobInfo">作业（含UID）</param>
        /// <param name="data_temp">向作业调度中传的临时数据</param>
        /// <returns></returns>
        public IBaseResponse AddScheduleJob(J_JobInfo jobInfo, /*PMS.Model.JobDataModel.SendJobDataModel*/IJobData data_temp)
        {
            //1 根据Job的类名通过反射的方式创建IJobDetial
            IBaseResponse response = new BaseResponse() { Success = false };
            IJobDetail job = null;
            //1月20日
            try
            {
                //在作业工厂类 创建实例方法中 对代码进行修改，若出错则返回null
                job = JobFactory.CreateJobInstance(jobInfo, data_temp);                
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return response;
            }
            

            if (job == null)
            {
                response.Message = string.Format("创建作业实例时出错");
            }
            //2 创建定时器
            var trigger = JobFactory.CreateTrigger(jobInfo);

            //3 将定时器加入job中
            //var sche = new SchedulerFactory().GetScheduler();
            try
            {
                //若调度池为空，则初始化
                if (sche == null)
                {
                    InitScheduler();
                }
                sche.ScheduleJob(job, trigger);
                LogHelper.WriteLog(string.Format("添加任务id：{0},name：{1}，添加成功，创建时间{2}，创建者{3}\n定时器cron：{4}，下次执行时间：{5}", jobInfo.JID, jobInfo.JobName, jobInfo.CreateTime.ToString(), jobInfo.CreateUser,jobInfo.CronStr??"cron为空",jobInfo.NextRunTime.ToString()));
                //4 启动工作
                //不启动该调度池
                //sche.Start();

                response.Success = true;
                response.Message = string.Format("作业已添加至调度池中");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.ToString();
                //response.Message = string.Format("作业添加至调度池时出错");
            }

            return response;
        }
        #endregion
        #region 2 添加监听器——可用此种方式实现作业执行后更新数据库中状态——未使用此种方式
        /// <summary>
        /// 为指定的作业添加监听器
        /// </summary>
        /// <param name="jobListener"></param>
        /// <param name="JobName"></param>
        /// <param name="GroupName"></param>
        public void AddListener(IJobListener jobListener, string JobName, string GroupName)
        {
            sche.ListenerManager.AddJobListener(jobListener, KeyMatcher<JobKey>.KeyEquals(new JobKey(JobName, GroupName)));

        }
        #endregion

        #region 3 恢复全部作业
        /// <summary>
        /// 恢复全部作业
        /// </summary>
        public void ResumeAllJob()
        {
            //var scheduler_temp = new SchedulerFactory().GetScheduler();

            if (!sche.IsStarted) { sche.Start(); }
            sche.ResumeAll();
        }
        #endregion

        #region 4 恢复指定作业
        /// <summary>
        /// 恢复指定的作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse ResumeTargetJob(J_JobInfo job)
        {
            IBaseResponse response = new BaseResponse() { Success = false };
            try
            {
                //if (!sche.IsStarted) { sche.Start(); }

                sche.ResumeJob(new JobKey(job.JID.ToString(), job.JobGroup));
                response.Success = true;
                response.Message = string.Format("job:{0}，group:{1}已恢复", job.JobName, job.JobGroup);
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = string.Format("job:{0}，group:{1}恢复时出错", job.JobName, job.JobGroup);

            }
            //var scheduler_temp = new SchedulerFactory().GetScheduler();
            return response;

        }
        #endregion

        #region 5 删除指定作业
        /// <summary>
        /// 删除某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse RemovceJob(J_JobInfo job)
        {
            IBaseResponse response = new BaseResponse() { Success = false };
            try
            {
                var trigger = new TriggerKey(job.JID.ToString(), job.JobGroup);
                sche.PauseJob(new JobKey(job.JID.ToString(), job.JobGroup));
                sche.UnscheduleJob(trigger);
                sche.DeleteJob(new JobKey(job.JID.ToString(), job.JobGroup));
                response.Success = true;
                response.Message = string.Format("job:{0},group{1}已删除工作", job.JobName, job.JobGroup);
            }
            catch (Exception)
            {
                response.Message = string.Format("job:{0},group{1}删除工作时出错", job.JobName, job.JobGroup);
            }

            return response;
        }
        #endregion

        #region 6 暂停指定作业
        /// <summary>
        /// 暂停某个作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse PauseJob(J_JobInfo job)
        {
            IBaseResponse response = new BaseResponse() { Success = false };
            try
            {

                sche.PauseJob(new JobKey(job.JID.ToString(), job.JobGroup));
                response.Success = true;
                response.Message = string.Format("job:{0},group{1}已暂停工作", job.JobName, job.JobGroup);
            }
            catch (Exception ex)
            {
                response.Message = string.Format("job:{0},group{1}暂停工作时出错", job.JobName, job.JobGroup);
            }

            return response;
        }
        #endregion 

        #region 7 终止指定作业
        /// <summary>
        /// 终止指定作业
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public IBaseResponse RemoveJob(J_JobInfo job)
        {
            IBaseResponse response = new BaseResponse() { Success = false };
            try
            {

                sche.PauseJob(new JobKey(job.JID.ToString(), job.JobGroup));
                //1 取出指定的触发器
                var trigger = new TriggerKey(job.JID.ToString(), job.JobGroup);
                //2 先暂停触发器（试一下若不暂停触发器可否？——11月20日）
                sche.PauseTrigger(trigger);
                //3 调度中的该方法只能传入触发器
                sche.UnscheduleJob(trigger);

                response.Success = true;
                response.Message = string.Format("job:{0},group{1}已终止工作", job.JobName, job.JobGroup);
            }
            catch (Exception)
            {
                response.Message = string.Format("job:{0},group{1}终止工作时出错", job.JobName, job.JobGroup);
            }

            return response;
        }
        #endregion


        #region 暂时不用的
        public void SaveScheduleInDB()
        {
            #region 已在配置文件中配置
            ////1.首先创建一个作业调度池
            //var properties = new NameValueCollection();
            ////存储类型
            //properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            ////表明前缀
            //properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            ////驱动类型
            //properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";                //数据源名称
            //properties["quartz.jobStore.dataSource"] = "myDS";
            ////连接字符串
            //properties["quartz.dataSource.myDS.connectionString"] = Config.QuartzConnStr;
            ////sqlserver版本
            //properties["quartz.dataSource.myDS.provider"] = "SqlServer-20";
            //最大链接数
            //properties["quartz.dataSource.myDS.maxConnections"] = "5";
            #endregion
            //ISchedulerFactory sf = new StdSchedulerFactory(properties);
            //IScheduler sched = sf.GetScheduler();
            IScheduler sched = StdSchedulerFactory.GetDefaultScheduler();
        }
        #endregion

       

       
    }
}
