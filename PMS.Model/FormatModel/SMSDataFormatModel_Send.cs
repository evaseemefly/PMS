using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.FormatModel
{
    public class SMSDataFormatModel_Send
    {
        public string account { get; set; }

        public string password { get; set; }

        public string msgid { get; set; }

        public string phones { get; set; }

        public string content { get; set; }

        public string sign { get; set; }

        public string subcode { get; set; }

        public string sendtime { get; set; }
    }
}
