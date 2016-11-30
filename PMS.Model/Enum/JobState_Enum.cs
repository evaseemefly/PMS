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
        /// 暂停
        /// </summary>
        WAITING = 2,

        /// <summary>
        /// 休眠
        /// </summary>
        sleepping =3,
        
        ///<summary>
        /// 终止
        /// </summary>
        stop=4,

        
    }
}
