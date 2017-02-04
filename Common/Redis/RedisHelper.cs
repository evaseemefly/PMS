using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Redis.Generic;

namespace Common.Redis
{
    public class RedisHelper
    {
        /// <summary>
        /// Redis客户端
        /// </summary>
        private static readonly RedisClient redis_client;

        /// <summary>
        /// 自定义的Redis配置对象
        /// </summary>
        private static readonly RedisConfig redis_config = RedisConfig.GetConfig();

        /// <summary>
        /// Redis缓冲池管理对象
        /// </summary>
        private static PooledRedisClientManager prc_Manager;

        //缓存过期时间
        private static int seconds_TimeOut = 30 * 60;

       // private static RedisClient redis;

        //Redis缓冲池
       // PooledRedisClientManager poolRedis = new PooledRedisClientManager();

        /// <summary>
        /// 创建Redis连接池管理对象
        /// </summary>
        /// <param name="readWriteUrl"></param>
        /// <param name="readOnlyUrl"></param>
        /// <returns></returns>
        public static void CreateManager(string[] readWriteUrl,string[] readOnlyUrl)
        {
            prc_Manager = new PooledRedisClientManager(readWriteUrl, readOnlyUrl);
            //return manager;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        static RedisHelper()
        {
            //1 获取Redis配置的配置属性
            //6月24日 
            //1.1 只获取写入和读取ip数组
            var writeServerArray = SplitString(redis_config.WriteServerList, ",").ToArray();
            var readServerArray = SplitString(redis_config.ReadServerList, ",").ToArray();

            //2 执行创建缓存池对象
            CreateManager(writeServerArray, readServerArray);
            
            //3 通过缓存连接池获取Redis客户端对象，并赋给本类中定义的私有变量
            if(redis_client==null)
            {
                redis_client = prc_Manager.GetClient() as RedisClient;
            }
        }



        /// <summary>
        /// 将传入的字符串根据 第二个参数分隔返回数组
        /// </summary>
        /// <param name="source_str"></param>
        /// <param name="split_str"></param>
        /// <returns></returns>
        private static IEnumerable<string> SplitString(string source_str,string split_str)
        {
            return source_str.Split(split_str.ToArray());
        }


        private static IRedisClient GetClient()
        {
            //获取客户端缓存操作对象
            return prc_Manager.GetClient();
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="t">value</param>
        /// <param name="time_out">缓存失效时间（若为负数则不设置过期时间），设置为0则为默认失效时间（单位：s）</param>
        /// <returns></returns>
        public static bool Set<T>(string key,T t,int time_out = 0)
        {
            var client = GetClient() as RedisClient;
            if (time_out >= 0)
            {
                if(time_out>0)
                {
                    seconds_TimeOut = time_out;
                }
                
               
                client.Expire(key, seconds_TimeOut);

            }

            return client.Add<T>(key, t);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            var client = GetClient() as RedisClient;

           

            return client.Get<T>(key);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetAll<T>() where T : class, new()
        {
            var client=GetClient() as RedisClient;
            
           return client.GetAll<T>();
        }

        public static List<string> GetSort()
        {
            var client = GetClient() as RedisClient;

            return client.GetAllItemsFromSortedSet("");
        }

        public static IList<string> GetList(string query)
        {
            var client = GetClient() as RedisClient;

           
            return client.GetAllKeys();
        }
        
        public static List<string> GetAllKeys()
        {
            var client = GetClient() as RedisClient;
            return client.GetAllKeys();
        }

        
    }
}
