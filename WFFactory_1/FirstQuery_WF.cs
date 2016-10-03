using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest;

namespace WFFactory
{
    public class FirstQuery_WF : BaseQuery_WF
    {
        public override void Execute()
        {
            Activity workflow_temp = new MainStatistics_Advanced();
            var dic = new Dictionary<string, object>() { { "TempBookMarkName", "书签1" } };
            var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
        }
    }
}
