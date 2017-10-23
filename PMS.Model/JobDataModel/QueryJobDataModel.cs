using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.JobDataModel
{
    public class QueryJobDataModel : BaseJobDataModel
    {
        public override string GetKey()
        {
            return "isMMS";
        }
    }
}
