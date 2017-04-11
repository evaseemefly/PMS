using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IModel;

namespace PMS.Model.SMSModel
{
   public class SMSModel_Receive:BaseModel_Receive,ISMSModel_Receive
    {       

        /// <summary>
        /// 状态描述
        /// eg:"提交成功"
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// 如果提交的号码中含有错误（格式）号码将在此显示。
        /// eg:"12935353535,110,130123123"
        /// </summary>
        public string[] failPhones { get; set; }
    }
}
