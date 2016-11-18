using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
   public class QueryQuartzConfigHelper:ConfigHelper
    {
        /// <summary>
        /// msgid在缓存中保存的过期时间
        /// </summary>
        private static int Interval_QueryAgain { get; set; }

        /// <summary>
        /// 获取当前的静态私有属性——查询间隔
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalQueryAgain()
        {
            return int.Parse(GetSettingValue("Interval_QueryAgain"));
        }

        public QueryQuartzConfigHelper()
        {
            Interval_QueryAgain = int.Parse(GetSettingValue("Interval_QueryAgain"));
        }
    }
}
