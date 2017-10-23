using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.JobDataModel
{
    public class SendJobDataModel : BaseJobDataModel
    {
        /// <summary>
        /// 重写key的值
        /// </summary>
        /// <returns></returns>
        public override string GetKey()
        {
            return "SendModel";
        }
    }
}
