using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzJobFactory;
using PMS.Model;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString());
            //InDBExmaple example = new InDBExmaple();
            //example.Run();
            IJobService jobSer = new JobService();
            J_JobInfo job = new J_JobInfo() {
                 JobName="test1"+Guid.NewGuid().ToString(),
                 JobGroup="group1",
                 JobClassName="HelloJob",
                 StartRunTime=DateTime.Now.AddSeconds(120),
                 EndRunTime=DateTime.Now.AddSeconds(121)
            };
            //jobSer.AddScheduleJob(job);

            jobSer.ResumeAllJob();
            Console.ReadLine();
        }
    }
}
