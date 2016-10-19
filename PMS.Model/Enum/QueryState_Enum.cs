using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    public enum QueryState_Enum
    {
        /// <summary>
        /// 返回的只包含desc为成功这一个节点——代表查询结束，没有新的返回状态
        /// </summary>
        finish,

        /// <summary>
        /// 仍可继续查询
        /// </summary>
        remnant,

        /// <summary>
        /// 出现错误
        /// </summary>
        error,

        /// <summary>
        /// 未知原因
        /// </summary>
        unknown
    }
}
