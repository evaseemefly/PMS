using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Common.Redis
{
    public class BaseRedisOperatHelper : IDisposable
    {
        public static IRedisClient redis_client { get; set; }

        private bool _disposed = false;

        static BaseRedisOperatHelper()
        {
            redis_client = BaseRedisHelper.GetClient();
        }

        public static void DoDispose()
        {
            redis_client.Dispose();
            redis_client = null;
               
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    redis_client.Dispose();
                    redis_client = null;
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        public void Save()
        {
            redis_client.Save();
        }
        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        public void SaveAsync()
        {
            redis_client.SaveAsync();
        }
    }
}
