using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    public class RedisConfigHelper:ConfigHelper
    {
        /// <summary>
        /// 保存在redis中的msgid的key
        /// </summary>
        public string redis_list_id { get; set; }

        /// <summary>
        /// msgid在缓存中保存的过期时间
        /// </summary>
        public int Interval_OverTime { get; set; }

        public RedisConfigHelper()
        {
            this.redis_list_id = GetSettingValue("list_msgid");
            this.Interval_OverTime = int.Parse(GetSettingValue("Interval_OverTime"));
        }
    }
}
