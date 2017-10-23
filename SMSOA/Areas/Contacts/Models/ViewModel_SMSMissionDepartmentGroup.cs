using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class ViewModel_SMSMissionDepartmentGroup
    {
        public string SMSMissionID { get; set; }

        public string groupIds { get; set; }

        public string g_isPasses { get; set; }
        public string departmentIds { get; set; }

        public string d_isPasses { get; set; }

        /// <summary>
        /// 2017-04-12
        /// 添加前台传过来的短彩信标记
        /// eg:短信 sms
        ///    彩信 mms
        ///    casablanca
        /// </summary>
        public string isMMS { get; set; }
    }
}