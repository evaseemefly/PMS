using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryWFLib;
using PMS.BLL;

namespace WF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow_temp = new QueryWFLib.Activity1();
            var dic = new Dictionary<string, object>() { };
            var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);

            //PMS.IBLL.IS_SMSContentBLL contentBLL = new S_SMSContentBLL();
            //var content_temp = contentBLL.GetListBy(c => c.msgId == "1").FirstOrDefault();
            Console.ReadLine();
        }
    }
}
