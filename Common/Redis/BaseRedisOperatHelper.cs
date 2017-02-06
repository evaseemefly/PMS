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
        protected IRedisClient Redis { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
