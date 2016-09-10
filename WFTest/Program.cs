using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WFTest
{

    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow1 = new MainStatistics_Advanced();
            WorkflowInvoker.Invoke(workflow1);
            Console.WriteLine("工作流结束，输入任何键退出");
            Console.ReadLine();
        }
    }
}
