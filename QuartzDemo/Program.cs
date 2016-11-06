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
            //无法通过WCF的方式使用反射的对象
            //ServiceReference_Job.IJobService jobSer = new ServiceReference_Job.JobServiceClient();
            IJobService jobSer = new JobService();
            var job_id = "test1" + Guid.NewGuid().ToString();
            var job_group = "group1";
            J_JobInfo job = new J_JobInfo() {
                 JobName= job_id,
                 JobGroup= job_group,
                 JobClassName="HelloJob",
                 StartRunTime=DateTime.Now.AddSeconds(2),
                 EndRunTime=DateTime.Now.AddSeconds(3),
                 UID=3
            };
            jobSer.AddScheduleJob(job);
            //MyJobListener listener = new MyJobListener();
            //jobSer.AddListener(listener, job_id, job_group);
            //jobSer.ResumeAllJob();
            Console.ReadLine();
        }
    }
}
