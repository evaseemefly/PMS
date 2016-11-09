using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IModel;

namespace PMS.Model
{
    public partial class J_JobInfo:IJ_JobInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UID { get; set; }
    }
}
