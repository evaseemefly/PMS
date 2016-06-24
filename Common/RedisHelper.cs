using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Redis.Generic;

namespace Common
{
    public class RedisHelper
    {
        private static readonly RedisClient reids = null;

        //Redis缓冲池
        PooledRedisClientManager poolRedis = new PooledRedisClientManager();

        /// <summary>
        /// 创建Redis连接池管理对象
        /// </summary>
        /// <param name="readWriteUrl"></param>
        /// <param name="readOnlyUrl"></param>
        /// <returns></returns>
        public static PooledRedisClientManager CreateManager(string[] readWriteUrl,string[] readOnlyUrl)
        {
            var manager = new PooledRedisClientManager(readWriteUrl, readOnlyUrl);
            return manager;
        }

        static RedisHelper()
        {
            string[] writeServerList=
        }
    }
}
