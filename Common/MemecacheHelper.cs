using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MemecacheHelper
    {
        

        /// <summary>
        /// memcache 客户端实例
        /// </summary>
        private static readonly Memcached.ClientLibrary.MemcachedClient mc = null;

        /// <summary>
        /// 静态构造函数——不需要使用public
        /// </summary>
        static MemecacheHelper()
        {
            string startIp = ConfigurationManager.AppSettings["startIp"];//192.168.0.163:11211
            string endIp = ConfigurationManager.AppSettings["endIp"];
            string[] serverlist = { startIp, endIp };//一定要将地址写到Web.config文件中。
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();

            pool.SetServers(serverlist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();

            // 获得客户端实例
            mc = new MemcachedClient();
            mc.EnableCompression = false;
        }

        /// <summary>
        /// 向memcache中写入数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, object value)
        {
            mc.Set(key, value);
        }

        /// <summary>
        /// 向memcache中写入数据（并加入过期时间）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dt">过期时间</param>
        public static void Set(string key, object value, DateTime dt)
        {
            mc.Set(key, value, dt);
        }

        /// <summary>
        /// 获取保存在缓存中的指定对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return mc.Get(key);
        }

        /// <summary>
        /// 删除缓存中的指定对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Delete(string key)
        {
            //1 判断是否存在指定key对应的缓存
            if (mc.KeyExists(key))
            {
                return mc.Delete(key);
            }
            else
            {
                return false;
            }

        }
    }
}
