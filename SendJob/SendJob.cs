using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseJob;
using Quartz;
using PMS.IBLL;
using PMS.BLL;
using ISMS;
using SMSFactory;

namespace JobInstances
{
    public class SendJob : JobAbstract
    {
        protected IUserInfoBLL userInfoBLL { get; set; }

        protected IJ_JobInfoBLL jobInfoBLL { get; set; }

        protected IQRTZ_TRIGGERSBLL qrtz_triggerBLL { get; set; }

        protected ISMS.ISMSSend smsSendBLL { get; set; }

        public SendJob():base()
        {
            //注意：
            //为操作对象实例化不能放在默认的构造函数中，此构造函数在调用时会被调用两遍，会出现无法修改的问题（原因不明）
            //if (jobInfoBLL == null)
            //{
            //    jobInfoBLL = new J_JobInfoBLL();
            //}
            
        }

        protected override void ExceuteBody(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;

            //反序列化
            //var send_model =Common.SerializerHelper.DeSerializerToObject<PMS.Model.SMSModel.SMSModel_Send>(dataMap["SendModel"].ToString());
            var sendjob_model = Common.SerializerHelper.DeSerializerToObject<PMS.Model.JobDataModel.SendJobDataModel>(dataMap["SendModel"].ToString());
           var obj= sendjob_model.JobDataValue;
            var send_model = Common.SerializerHelper.DeSerializerToObject<PMS.Model.SMSModel.SMSModel_Send>(obj.ToString());

            //var send_model = dataMap["SendModel"] as PMS.Model.JobDataModel.SendJobDataModel;

            ISMS.ISMSSend send = new SMSFactory.SMSSend();

            PMS.Model.SMSModel.SMSModel_Receive receive_model = new PMS.Model.SMSModel.SMSModel_Receive();

            PMS.Model.Message.BaseResponse response = new PMS.Model.Message.BaseResponse();

            send.SendMsg(new PMS.Model.CombineModel.SendAndMessage_Model() { Model_Send = send_model, Model_Message = new PMS.Model.ViewModel.ViewModel_Message() { isTiming = false } } , out receive_model);
            PMS.Model.ViewModel.ViewModel_Message model = new PMS.Model.ViewModel.ViewModel_Message()
            {
                UID =0,
                SMSMissionID="",
                Content=""
            };
          
            smsSendBLL.AfterSend(model, receive_model,)
        }

        protected void AfterSend()
        {
            if (this.smsSendBLL == null)
            {
                smsSendBLL = new SMSFactory.SMSSend();
            }
            
        }

        protected override void Exceuted(IJobExecutionContext context)
        {
            if (jobInfoBLL == null)
            {
                jobInfoBLL = new J_JobInfoBLL();
            }
            if (userInfoBLL == null)
            {
                userInfoBLL = new UserInfoBLL();
            }
            if (qrtz_triggerBLL == null)
            {
                qrtz_triggerBLL = new QRTZ_TRIGGERSBLL();
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

            var uid = data.GetInt("UID");
            if (uid != null)
            {
                //var uid_int = int.Parse(uid);
                var user_temp = userInfoBLL.GetListBy(u => u.ID == uid).FirstOrDefault();
                //2 根据用户id查询查询该用户所拥有的作业
                var list = userInfoBLL.GetJobListByUser(user_temp.ID);

                //3 取出对应的作业
                //取出的context.JobDetail.Key.Name实际为JID
                //**查错，暂时注释**
                var targetJob = (from j in list
                                 where j.JID == Convert.ToInt32(context.JobDetail.Key.Name)  /*&& j.JobGroup == context.JobDetail.Key.Group*/
                                 select j).FirstOrDefault();
                PMS.BLL.J_JobInfoBLL job_temp = new PMS.BLL.J_JobInfoBLL();

                //UpdateJobState(targetJob);
                //4 若存在则更新作业状态
                //**查错，暂时注释**
                if (targetJob != null)
                {
                    //4 更新作业状态的思路
                    //4-1 获取trigger的状态
                    var trigger_temp = qrtz_triggerBLL.GetListBy(t => t.TRIGGER_NAME == context.JobDetail.Key.Name).FirstOrDefault();
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
                    UpdateJobState(targetJob);
                }
                //4 若不存在则创建新的作业
            }


        }


        /// <summary>
        /// 更新作业状态
        /// </summary>
        /// <param name="job"></param>
        private bool UpdateJobState(PMS.Model.J_JobInfo job)
        {
            //此处有问题，对象已经修改但数据库中未更新
            if (jobInfoBLL != null)
                return jobInfoBLL.Update(job);
            else
                return false;
        }

        public class ServiceReference1
        {
            public class SendMsgRequest
            {
            }

            public class SendMsgResponse
            {
            }
        }
    }
}
