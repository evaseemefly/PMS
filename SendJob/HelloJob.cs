using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobInstances
{
    public class HelloJob : BaseJob.JobAbstract
    {
        protected override void ExceuteBody(IJobExecutionContext context)
        {
            Console.WriteLine("————————Hello Job is Execute,this time is {0}————————", DateTime.Now.ToString());
        }
    }
}
