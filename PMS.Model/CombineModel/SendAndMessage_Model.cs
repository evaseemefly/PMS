using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.CombineModel
{
    public class SendAndMessage_Model
    {
        /// <summary>
        /// 含提交的短信的相关内容及作业相关信息
        /// </summary>
        public ViewModel.ViewModel_Message Model_Message {get;set;}

        /// <summary>
        /// 提交的发送对象
        /// </summary>
        public SMSModel.SMSModel_Send Model_Send { get; set; }
    }
}
