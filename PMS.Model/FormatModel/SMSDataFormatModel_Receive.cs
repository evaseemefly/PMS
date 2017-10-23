using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.FormatModel
{
   public class SMSDataFormatModel_Receive
    {
        public string msgid { get; set; }

        public string result { get; set; }

        public string desc { get; set; }

        public string failPhones { get; set; }
    }
}
