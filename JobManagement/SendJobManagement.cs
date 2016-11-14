using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.SMSModel;

namespace JobManagement
{
    /// <summary>
    /// 执行发送操作的委托
    /// </summary>
    /// <param name="model"></param>
    /// <param name="response"></param>
    /// <returns></returns>
    public delegate bool DoSendJobDelegate(PMS.Model.CombineModel.SendAndMessage_Model model,out SMSModel_Receive response);

    /// <summary>
    /// 
    /// </summary>
    public class SendJobManagement
    {
        /// <summary>
        /// 注册发送方法的事件
        /// 
        /// </summary>
        public event DoSendJobDelegate DoSendJobs;

        /// <summary>
        /// 执行发送作业（延时或立刻）
        /// 需要先注册发送方法
        /// </summary>
        /// <param name="model">发送对象</param>
        /// <param name="response">响应</param>
        public void JobsRun(PMS.Model.CombineModel.SendAndMessage_Model model, out SMSModel_Receive receive)
        {
            receive = new SMSModel_Receive();
            if (DoSendJobs != null)
            {
                DoSendJobs(model,out receive);
            }
            else
            {
                //response = new PMS.Model.Message.BaseResponse() { Message = "未绑定方法", Success = false };
            }
        }
    }
    
}
