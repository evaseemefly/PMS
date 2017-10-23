using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    public enum ExistEnum
    {
        /// <summary>
        /// 写入成功
        /// </summary>
        ok,
        /// <summary>
        /// 已经存在
        /// </summary>
        isExist,
        /// <summary>
        /// 写入失败
        /// </summary>
        error,
        ///<summary>
        /// 不存在
        /// </summary>
        isNotExist,

    }
}
