using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Redis;

namespace RedisDemo
{
    public class Redis_Test
    {
        public string GetRedis(string id)
        {
            StringRedisHelper redis_string = new StringRedisHelper();
           return redis_string.Get(id);
        }

        public void ListRWTest(int count)
        {
            StringRedisHelper stringHelper = new StringRedisHelper();
            for (int i = 0; i < count; i++)
            {
                //Random random = new Random();                
                //redisHelper.Set(random.Next().ToString(), "1", DateTime.Now.AddSeconds(10));
                stringHelper.Set(i.ToString(), "ok", DateTime.Now.AddSeconds(120));
                Console.WriteLine(i + ":" + "ok");
            }
        }
    }
}
