using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.QueryModel
{
    public class Redis_ListMsgIdObj
    {
        /// <summary>
        /// MsgId
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Dt { get; set; } 
    }
}
