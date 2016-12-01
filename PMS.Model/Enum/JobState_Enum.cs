using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    public enum JobState_Enum:int
    {
        /// <summary>
        /// 正在运行
        /// </summary>
        running=0,

        /// <summary>
        /// 作业完成
        /// </summary>
        COMPLETE=1,

        /// <summary>
        /// 等待
        /// </summary>
        WAITING = 2,

        /// <summary>
        /// 暂停
        /// </summary>
        PAUSED=5,

        /// <summary>
        /// 休眠
        /// </summary>
        sleepping =3,
        
        ///<summary>
        /// 终止
        /// </summary>
        STOP=4,

        ///<summary>
        /// 已捕获
        /// </summary>
        ACQUIRED = 6,
    }
}
