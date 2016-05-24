using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Model.SMSModel
{
    public class SMSModel_MsgResult
    {
        public List<SMSModel_Blacklist> list_Blacklist { get; set; }

        public List<SMSModel_SendFails> list_SendFails { get; set; }

    }
}