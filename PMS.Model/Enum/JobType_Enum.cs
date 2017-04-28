using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    public enum JobType_Enum
    {
        /// <summary>
        /// 发送作业
        /// </summary>
        sendJob=0,
        /// <summary>
        /// 查询作业
        /// </summary>
        queryJob=1,
        mmsqueryJob=3,
        /// <summary>
        /// 其他作业
        /// </summary>
        otherJob=99
    }
}
