using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Activities;
using Common;
using PMS.IBLL;
using PMS.BLL;
using Common.Ioc;

namespace JobInstances
{
    public class QueryJob : BaseJob.JobAbstract
    {
        protected IJ_JobInfoBLL jobInfoBLL { get; set; }

        protected override void ExceuteBody(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            Activity workflow_temp = new QueryWFLib.Activity1();
            if (dataMap["isMMS"] != null)
            {
                var value_isMMS = Common.SerializerHelper.DeSerializerToObject<PMS.Model.Enum.MMS_Enum>(dataMap["isMMS"].ToString());
                var dic = new Dictionary<string, object>() { { "isMMS", value_isMMS } };
                LogHelper.WriteLog("启动查询wf");
                var work = WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
                LogHelper.WriteLog("跳出wf");
            }
            else {
                LogHelper.WriteLog("datamap中参数错误，启动wf失败");
            }
            
        }

        protected override void Exceuted(IJobExecutionContext context)
        {
            LogHelper.WriteLog("开始写入作业状态");
            //执行后执行的方法封装在父类中，此处注释 2017-04-21 casablanca
            //AfterExceuted(context);

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void AfterExceuted(IJobExecutionContext context)
        {
            if (jobInfoBLL == null)
            {
                //jobInfoBLL = new J_JobInfoBLL();
                jobInfoBLL = UnityServiceLocator.Instance.GetService<IJ_JobInfoBLL>();
            }
            if (userInfoBLL == null)
            {
               // userInfoBLL = new UserInfoBLL();
                userInfoBLL= UnityServiceLocator.Instance.GetService<IUserInfoBLL>();
            }
            if (qrtz_triggerBLL == null)
            {
                //qrtz_triggerBLL = new QRTZ_TRIGGERSBLL();
                qrtz_triggerBLL =UnityServiceLocator.Instance.GetService<IQRTZ_TRIGGERSBLL>();
            }
            #region 11月8日测试修改数据库的bug，现注释
            //11月8日测试修改数据库的bug，现注释
            //var targetJob = jobInfoBLL.GetListBy(j => j.JID == 18).FirstOrDefault();
            //if (targetJob != null)
            //{
            //    targetJob.JobState = 2;

            //}
            //jobInfoBLL.Update(targetJob);
            #endregion

            //向数据库中写入
            //获取JobDataMap
            var data = context.JobDetail.JobDataMap;
            //1 需要传入一个用户id
            if (data == null)
            {
                LogHelper.WriteError("JobDataMap中未保存对象");
                return;
            }
            var uid = data.GetInt("UID");
            
            if (uid != 0)
            {
                //var uid_int = int.Parse(uid);
                var user_temp = userInfoBLL.GetListBy(u => u.ID == uid,true).FirstOrDefault();
                //2 根据用户id查询查询该用户所拥有的作业
                var list = userInfoBLL.GetJobListByUser(user_temp.ID);

                //3 取出对应的作业
                //取出的context.JobDetail.Key.Name实际为JID
                //**查错，暂时注释**
                var targetJob = (from j in list
                                 where j.JID == Convert.ToInt32(context.JobDetail.Key.Name)  /*&& j.JobGroup == context.JobDetail.Key.Group*/
                                 select j).FirstOrDefault();
                

                //UpdateJobState(targetJob);
                //4 若存在则更新作业状态
                //**查错，暂时注释**
                if (targetJob == null)
                {
                    LogHelper.WriteWarn(string.Format("未找到\"{0}\"作业", context.JobDetail.Key.Name));
                }
                if (targetJob != null)
                {
                    //4 更新作业状态的思路
                    //4-1 获取trigger的状态
                    var trigger_temp = qrtz_triggerBLL.GetListBy(t => t.TRIGGER_NAME == context.JobDetail.Key.Name).FirstOrDefault();
                    //注意若完成时其中的
                    if (trigger_temp != null)
                    {
                        var dic = PMS.Model.Dictionary.Quartz_TriggerStateDictionary.GetResponseCode();
                        //4-2获取trigger其他状态
                        //1)修改往数据库中写入的作业状态
                        targetJob.JobState = dic[trigger_temp.TRIGGER_STATE == null ? "null" : trigger_temp.TRIGGER_STATE];
                        //2)修改作业结束时间（世界时需+8）
                        targetJob.EndRunTime = context.Trigger.EndTimeUtc.GetValueOrDefault().DateTime.AddHours(8);
                        //3)修改作业下次执行时间（世界时需+8）                 
                        if (context.Trigger.GetNextFireTimeUtc() != null)
                        {
                            targetJob.NextRunTime = context.Trigger.GetNextFireTimeUtc().GetValueOrDefault().DateTime.AddHours(8);
                        }
                    }
                    if (UpdateJobState(targetJob))
                        LogHelper.WriteLog("更新作业状态成功！");
                   
                }
                //4 若不存在则创建新的作业
            }

        }
    }
}
