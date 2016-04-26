using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class SMSModel_Send
    {
        private string temp { get; set; }

        public string account { get; set; }

        public string password { get; set; }

        public string msgid { get; set; }

        public string[] phones { get; set; }

        public string content { get; set; }

        public string sign { get { return "【国家海洋预报台】"; } }

        public string subcode { get; set; }

        public DateTime sendtime { get; set; }

    }
}
