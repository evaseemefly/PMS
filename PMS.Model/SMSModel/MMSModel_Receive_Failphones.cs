using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class MMSModel_Receive_Failphones
    {
        /// <summary>
        /// 提交失败的电话号码(此处仅为一个电话号码)
        /// </summary>
        public string phoneNum { set; get; }
        /// <summary>
        /// 此电话号码提交失败的原因(响应中不为0 status),根据status_failPhone在字典中获取
        /// </summary>
        public string desc_failPhone { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string status_failPhone { get; set; }
    }
}
