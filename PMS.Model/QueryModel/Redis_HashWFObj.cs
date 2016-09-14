using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.QueryModel
{
    public class Redis_HashWFObj
    {
        public string MsgId { get; set; }

        public string WFId { get; set; }

        public DateTime Dt { get; set; }

        public int WF_Result { get; set; }
    }
}
