using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.QueryModel
{
   public class Redis_SMSContent
    {
        public string msgid { get; set; }

        public DateTime Dt { get; set; }

        public string PhoneNums { get; set; }
    }
}
