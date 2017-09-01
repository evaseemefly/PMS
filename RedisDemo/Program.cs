using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Threading;
using Common;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringRWTest(11);
            //StringRWbyThread(2);
            Redis_Test redis = new Redis_Test();
            //Common.Redis.BaseRedisHelper helper = new Common.Redis.BaseRedisHelper();
            redis.ListRWTest(5);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Format("取出{0},编号{1}",redis.GetRedis(i.ToString()),i)); 
            }
           
            //StringRWTest(10000);
            //查询首元素并取出
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(list_helper.GetFirstObj(list_key));
            //    list_helper.DequeueItemFromList(list_key);
            //    Console.WriteLine("取出并删除首元素");
            //}

            //Console.WriteLine("取出第一个对象"+list_helper.DequeueItemFromList(list_key));

            Console.ReadLine();
        }

        static void ListRWTest()
        {
            Common.Redis.ListReidsHelper<string> list_helper = new Common.Redis.ListReidsHelper<string>();
            string list_key = "list1";
            TimeSpan ts = new TimeSpan(0, 0, 10);
            for (int i = 0; i < 5; i++)
            {
                list_helper.RPush(list_key, "a" + i, ts);
            }
            Console.WriteLine("录入成功");
            Console.WriteLine(list_helper.Count(list_key));
            Console.WriteLine(list_helper.Count(list_key));
        }

        

        static void StringRWTest(int count)
        {
            //Common.Redis.StringRedisHelper redisHelper = new Common.Redis.StringRedisHelper();
            Common.Redis.StringRedisHelper stringHelper = new Common.Redis.StringRedisHelper();
            for (int i = 0; i < count; i++)
            {
                //Random random = new Random();                
                //redisHelper.Set(random.Next().ToString(), "1", DateTime.Now.AddSeconds(10));
                stringHelper.Set(i.ToString(), "ok", DateTime.Now.AddSeconds(120));
                Console.WriteLine(i + ":" + "ok");
            }
            
        }

      
        static void StringRWbyThread(int count)
        {
            for (int i = 0; i < count; i++)
            {
                
                ThreadPool.QueueUserWorkItem(o =>
                {
                    //Common.Redis.StringRedisHelper redisHelper = new Common.Redis.StringRedisHelper();
                    Common.Redis.StringReidsHelper_test stringHelper = new Common.Redis.StringReidsHelper_test();
                    //Random random = new Random();
                    //string radom_str = random.Next().ToString();

                    //var index= redisHelper.Set(i.ToString(), "1", DateTime.Now.AddSeconds(10));
                    var index = stringHelper.Set(i.ToString(), "1", DateTime.Now.AddSeconds(10));
                    //stringHelper.
                    Console.WriteLine(i + ":"+index);
                });
                   
            }
        }
    }
}
