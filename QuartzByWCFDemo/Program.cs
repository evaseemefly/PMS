using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzByWCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference_QuartzService.IJobService jobSer = new ServiceReference_QuartzService.JobServiceClient();
            J_JobInfo job = new J_JobInfo()
            {
                JobName = "1234",
                JobGroup = "quartz",
                JobClassName = "QueryJob",
                StartRunTime = DateTime.Now.AddSeconds(2),
                EndRunTime = DateTime.Now.AddSeconds(3),
                UID = 3
            };

            QuartzJobFactory.IJobService jobClass = new QuartzJobFactory.JobService();
            //jobClass.AddScheduleJob(job, null);
            jobSer.AddScheduleJob(job, null);
        }
    }
}
