using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.Redis.ListReidsHelper<string> list_helper = new Common.Redis.ListReidsHelper<string>();
            string list_key = "list1";
            TimeSpan ts = new TimeSpan(0, 0, 10);
            for (int i = 0; i < 5; i++)
            {
                list_helper.RPush(list_key, "a" + i,ts);
            }
            Console.WriteLine("录入成功");
            Console.WriteLine(list_helper.Count(list_key));
            //查询首元素并取出
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(list_helper.GetFirstObj(list_key));
            //    list_helper.DequeueItemFromList(list_key);
            //    Console.WriteLine("取出并删除首元素");
            //}

            //Console.WriteLine("取出第一个对象"+list_helper.DequeueItemFromList(list_key));
            Console.WriteLine(list_helper.Count(list_key));
            Console.ReadLine();
        }
    }
}
