using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IModel
{
    public interface IJ_JobInfo
    {
        string JobClassName { get; set; }

        int UID { get; set; }

        int JID { get; set; }

        string JobGroup { get; set; }

        DateTime StartRunTime { get; set; }

        DateTime EndRunTime { get; set; }

        string CronStr { get; set; }

        /// <summary>
        /// 重复执行间隔（单位—秒）
        /// </summary>
        int Interval_quartz { get; set; }
    }
}
