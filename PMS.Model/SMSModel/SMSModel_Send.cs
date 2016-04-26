using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class SMSModel_Send
    {
        private string temp;

        public string account;

        public string password;

        public string msgid;

        public string[] phones;

        public string content;

        public string sign { get { return "【国家海洋预报台】"; } }

        public string subcode;

        public DateTime sendtime;
        
    }
}
