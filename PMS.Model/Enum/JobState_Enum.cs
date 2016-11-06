using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    public enum JobState_Enum
    {
        /// <summary>
        /// 正在运行
        /// </summary>
        running=0,
        /// <summary>
        /// 休眠
        /// </summary>
        sleepping=1,
        /// <summary>
        /// 暂停
        /// </summary>
        suspend=2,
        ///<summary>
        /// 终止
        /// </summary>
        stop=3
    }
}
