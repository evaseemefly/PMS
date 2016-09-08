using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace WFTest
{

    class Program
    {
        static void Main(string[] args)
        {
            //启动工作流的方式（一）
            //Activity workflow_temp = new MainStatistics_Advanced();
            //WorkflowInvoker.Invoke(workflow1);

            //启动工作流的方式（二）
            //使用WorkflowApplication承载工作流
            //此种方式已经封装至Common中的WorkFlowHelper类中
            #region 此种方法已被封装，此处注释掉
            ////1.1 创建传入的参数字典（可以传入多个参数）
            ////1.2 创建工作流活动实例
            //Activity workflow_temp = new MainStatistics_Advanced();
            ////2 将活动传递给工作流
            //WorkflowApplication app = new WorkflowApplication(workflow_temp);

            ////3 将工作流写入数据库中
            //string connect_str = Common.ConfigHelper.GetSettingValue("workflowConnection");

            //SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connect_str);

            //app.InstanceStore = store;

            ////封装至Common中的WorkFlowHelper类中
            #endregion
            Activity workflow_temp = new MainStatistics_Advanced();
            var dic = new Dictionary<string, object>() { { "query_obj", "测试流程" } };
            var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);

            Console.WriteLine("工作流结束，输入任何键退出");
            Console.ReadLine();
        }
    }
}
