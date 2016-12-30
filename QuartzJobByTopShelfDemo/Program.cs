using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuartzJobByTopShelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            JobManagerService jobSer = new JobManagerService(); 
            jobSer.Start();

            Console.ReadLine();
        }
    }
}
