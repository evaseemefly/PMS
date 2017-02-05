using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Common.Redis
{
    public class StringRedisHelper:BaseRedisHelper
    {
        
        protected IRedisClient redisClient { get; set; }

        public StringRedisHelper()
        {
            redisClient = base.GetClient();
        }

            #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        public bool Set(string key, string value)
        {
            return redisClient.Set<string>(key, value);
            // return redis_client.Set<string>(key, value);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, DateTime dt)
        {
            bool isOk = false;
            try
            {
                redisClient.Set<string>(key, value, dt);
                //redis_client.Set<string>(key, value, dt);
                isOk = true;
            }
            catch (Exception ex)
            {

            }
            return isOk;
        }

            /// <summary>
            /// 设置key的value并设置过期时间
            /// </summary>
            public bool Set(string key, string value, TimeSpan sp)
            {
                return redis_client.Set<string>(key, value, sp);
            }
            /// <summary>
            /// 设置多个key/value
            /// </summary>
            public void Set(Dictionary<string, string> dic)
            {
                redis_client.SetAll(dic);
            }

            #endregion
            #region 追加
            /// <summary>
            /// 在原有key的value值之后追加value
            /// </summary>
            public long Append(string key, string value)
            {
                return redis_client.AppendToValue(key, value);
            }
            #endregion
            #region 获取值
            /// <summary>
            /// 获取key的value值
            /// </summary>
            public string Get(string key)
            {
                return redis_client.GetValue(key);
            }
            /// <summary>
            /// 获取多个key的value值
            /// </summary>
            public List<string> Get(List<string> keys)
            {
                return redis_client.GetValues(keys);
            }
            /// <summary>
            /// 获取多个key的value值
            /// </summary>
            public List<T> Get<T>(List<string> keys)
            {
                return redis_client.GetValues<T>(keys);
            }
            #endregion
            #region 获取旧值赋上新值
            /// <summary>
            /// 获取旧值赋上新值
            /// </summary>
            public string GetAndSetValue(string key, string value)
            {
                return redis_client.GetAndSetEntry(key, value);
            }
            #endregion
            #region 辅助方法
            /// <summary>
            /// 获取值的长度
            /// </summary>
            public long GetCount(string key)
            {
            return -1;
                //return redis_client.getGetStringCount(key);
            }
            /// <summary>
            /// 自增1，返回自增后的值
            /// </summary>
            public long Incr(string key)
            {
                return redis_client.IncrementValue(key);
            }
            /// <summary>
            /// 自增count，返回自增后的值
            /// </summary>
            public double IncrBy(string key, int count)
            {
                return redis_client.IncrementValueBy(key, count);
            }
            /// <summary>
            /// 自减1，返回自减后的值
            /// </summary>
            public long Decr(string key)
            {
                return redis_client.DecrementValue(key);
            }
            /// <summary>
            /// 自减count ，返回自减后的值
            /// </summary>
            /// <param name="key"></param>
            /// <param name="count"></param>
            /// <returns></returns>
            public long DecrBy(string key, int count)
            {
                return redis_client.DecrementValueBy(key, count);
            }
            #endregion
        
    }
}
