using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Activities;

namespace Common.Quartz.Job
{
    public class QueryJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Activity workflow_temp = new QueryWFLib.Activity1();
            //var dic = new Dictionary<string, object>() { };
            //var work = WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
        }
    }
}
