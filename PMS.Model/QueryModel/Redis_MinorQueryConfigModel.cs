using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.QueryModel
{
    public class Redis_MinorQueryConfigModel
    {
        /// <summary>
        /// 第二线程读取对象判断的时间间隔
        /// </summary>
        public TimeSpan Interval_QueryAgain { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan Interval_OverTime { get; set; }

        /// <summary>
        /// list的key
        /// </summary>
        public string List_Key { get; set; }

        /// <summary>
        /// hash的key
        /// </summary>
        public string Hash_Key { get; set; }

    }
}
