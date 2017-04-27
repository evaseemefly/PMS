using Common;
using Quartz;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Test
{
    public class QueryJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Activity workflow_temp = new QueryWFLib.Activity1();
            var dic = new Dictionary<string, object>()
            {
                {"isMMS",PMS.Model.Enum.MMS_Enum.sms }
            };
            
            var work = WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
        }
    }
}
