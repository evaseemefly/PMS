using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("初始化队列");

            var client = new RedisClient("192.168.31.202");
            client.Set<string>("user", "登录用户名");
            var pwd = client.Get<string>("user");
            Console.WriteLine(pwd);
            Console.ReadLine();
        }
    }
}
