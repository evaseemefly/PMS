using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Activities;
using Common;

namespace JobInstances
{
    public class QueryJob : BaseJob.JobAbstract
    {
        protected override void ExceuteBody(IJobExecutionContext context)
        {
            Activity workflow_temp = new QueryWFLib.Activity1();
            var dic = new Dictionary<string, object>() { };
            var work = WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
        }

        protected override void Exceuted(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
