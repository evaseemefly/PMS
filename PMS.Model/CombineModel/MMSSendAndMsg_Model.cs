using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IModel;

namespace PMS.Model.CombineModel
{
    public class MMSSendAndMsg_Model:BaseMessage_Model,ISendAndMessage_Model
    {
        /// <summary>
        /// 
        /// </summary>
        public SMSModel.MMSModel_Send Model_MMS { get; set; }
    }
}
