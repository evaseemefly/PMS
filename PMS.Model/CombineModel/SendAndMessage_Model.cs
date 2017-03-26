using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IModel;

namespace PMS.Model.CombineModel
{
    public class SendAndMessage_Model: BaseMessage_Model,ISendAndMessage_Model
    {       
        /// <summary>
        /// 提交的发送对象
        /// </summary>
        public SMSModel.SMSModel_Send Model_Send { get; set; }
        
    }
}
