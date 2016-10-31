using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzDemo
{
    public class MyJobListener : IJobListener
    {
       // private string name;
        public string Name
        {
            get
            {
                return "11";
            }
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 作业执行后执行向数据库中写入的操作
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jobException"></param>
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            //context.JobDetail.JobDataMap
            Console.WriteLine("被执行了");
        }
    }
}
