using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.BLL;
using PMS.IBLL;

namespace QuartzDemo
{
    public  class HelloJob : JobAbstract
    {
        protected IUserInfoBLL userInfoBLL { get; set; }

        protected IJ_JobInfoBLL jobInfoBLL { get; set; }

        protected IQRTZ_TRIGGERSBLL qrtz_triggerBLL { get; set; }

        protected override void ExceuteBody(IJobExecutionContext context)
        {
            Console.WriteLine("————————Hello Job is Execute,this time is {0}————————", DateTime.Now.ToString());
        }

        protected override void Exceuted(IJobExecutionContext context)
        {
            jobInfoBLL = new J_JobInfoBLL();
            var targetJob = jobInfoBLL.GetListBy(j => j.JID == 36).FirstOrDefault();
            if (targetJob != null)
            {
                targetJob.JobState = 2;

            }
            jobInfoBLL.Update(targetJob);

            //向数据库中写入
            //获取JobDataMap
            var data = context.JobDetail.JobDataMap;
            //1 需要传入一个用户id
            //if (base.userInfoBLL != null)
            //{
            //    var uid = data.GetInt("UID");
            //    if (uid != null)
            //    {
            //        //var uid_int = int.Parse(uid);
            //       var user_temp= userInfoBLL.GetListBy(u => u.ID == uid).FirstOrDefault();
            //        //2 根据用户id查询查询该用户所拥有的作业
            //        //userInfoBLL
            //       var list= userInfoBLL.GetJobListByUser(user_temp.ID);


            //        //3 取出对应的作业
            //        //取出的context.JobDetail.Key.Name实际为JID
            //        //**查错，暂时注释**
            //        //var targetJob = (from j in list
            //        //                 where j.JID ==Convert.ToInt32(context.JobDetail.Key.Name)  /*&& j.JobGroup == context.JobDetail.Key.Group*/
            //        //                 select j).FirstOrDefault();

            //        //**查错，暂时注释**
            //        //var targetJob = (from j in list
            //        //                 where j.JID == 41
            //        //                 select j).FirstOrDefault();
            //        //PMS.BLL.J_JobInfoBLL job_temp = new PMS.BLL.J_JobInfoBLL();
                    
            //        //UpdateJobState(targetJob);
            //        //4 若存在则更新作业状态
            //        //**查错，暂时注释**
            //        //if (targetJob != null)
            //        //{
            //        //    //var job_temp= base.jobInfoBLL.GetListBy(j => j.JobName == targetJob.JobName && j.JobGroup == targetJob.JobGroup).FirstOrDefault();
            //        //    //4 更新作业状态的思路
            //        //    //4-1 获取trigger的状态
            //        //    var trigger_temp = base.qrtz_triggerBLL.GetListBy(t => t.TRIGGER_NAME == context.JobDetail.Key.Name).FirstOrDefault();
            //        //    if (trigger_temp != null)
            //        //    {
            //        //        var dic = PMS.Model.Dictionary.Quartz_TriggerStateDictionary.GetResponseCode();
            //        //        //获取状态
            //        //        //job_temp.JobState = dic[trigger_temp.TRIGGER_STATE==null?"null": trigger_temp.TRIGGER_STATE];
            //        //        //job_temp.JobState = 1;
            //        //        //job_temp.EndRunTime = context.Trigger.EndTimeUtc.GetValueOrDefault().DateTime.AddHours(8);
            //        //        targetJob.JobState = 1;
            //        //        targetJob.EndRunTime = context.Trigger.EndTimeUtc.GetValueOrDefault().DateTime.AddHours(8);
            //        //        //job_temp.NextRunTime = context.Trigger.GetNextFireTimeUtc().GetValueOrDefault().DateTime.AddHours(8);
            //        //    }
            //        //    UpdateJobState(targetJob);
            //        //    //job_temp.JobState=
            //        //    //base.jobInfoBLL.Update()

            //        //}
            //        //4 若不存在则创建新的作业
            //    }

            }
            
        

        /// <summary>
        /// 更新作业状态
        /// </summary>
        /// <param name="job"></param>
        private void UpdateJobState(PMS.Model.J_JobInfo job)
        {
            //此处有问题，对象已经修改但数据库中未更新
            //base.jobInfoBLL.Update(job);
        }
    }
}
