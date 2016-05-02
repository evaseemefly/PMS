using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMSSendDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("初始化队列");
            StartConstumer();
            StartProducer();
            Console.ReadLine();
        }

        private static void Constumer()
        {
            Console.WriteLine("---------开始出队---------");
            //var sms1 = SMSFactory.SMSSessionFactory.GetInstance();
            //int index = 0;
            //while(true)
            //{
            //    while(sms1.GetqueueCount() != 0)
            //    {
            //        if (index >= 3)
            //        {
            //            Thread.Sleep(3000);
            //            Console.WriteLine("数据太多了休息3秒钟");
            //            index = 0;
            //        }
            //        else
            //        {
            //            index++;
            //            Console.WriteLine(sms1.Dequeue() + "出队成功");
            //        }

            //    }
            //    if (sms1.GetqueueCount() == 0)
            //    {
            //        Thread.Sleep(3000);
            //        Console.WriteLine("队列中不存在数据休息3秒钟");
            //    }
               
            //}
            
            Console.WriteLine("--------出队结束--------");
        }

        private static void Producer()
        {
            string[] person = new string[] { "李飞", "万凤菊", "屈远", "王豹", "王豹2222", "王豹333333", "王豹4444444" };
            //var sms = SMSFactory.SMSSessionFactory.GetInstance();
            //foreach (var item in person)
            //{
            //    if (sms.Enqueue(item))
            //        Console.WriteLine(item + "已经入队");
            //}
            Console.WriteLine("---------入队结束---------");
        }
        private static void StartConstumer()
        {
            Thread thread = new Thread(new ThreadStart(Constumer));
            thread.Start();
            Console.WriteLine("---------消费者线程启动------------");
            //Thread.Sleep(3000);

        }

        private static void StartProducer()
        {
            Thread thread = new Thread(new ThreadStart(Producer));
            thread.Start();
            Console.WriteLine("---------生产者线程启动------------");
        }
    }
}
