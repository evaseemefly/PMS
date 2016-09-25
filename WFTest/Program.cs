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
            //暂时注释掉
            Activity workflow_temp = new MainStatistics_Advanced();
            //var bookmark = new PMS.Model.WFModel.BookMarkObj<int>()
            //{
            //    BookMarkName = "恢复书签",
            //    State = 1,
            //    StepId = 1,
            //    WF_Result = 4,
            //    MsgId = obj_hashWFObj.MsgId
            //};

            #region 9月25日 测试简单的工作流恢复的问题，此处暂时注释掉
            //var dic = new Dictionary<string, object>() { { "TempBookMarkName", "书签1" } };
            ////var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(workflow_temp, dic);
            ////{370159d5-24b5-4a54-b3d6-1ac569938a78}

            //var work_reus = Common.WorkFlowAppHelper.LoadWorkflowApplication(workflow_temp, Guid.Parse("b74a2dea-e669-4a6e-8c7c-74df9602039b"));

            //var bookmark = new PMS.Model.WFModel.BookMarkObj<int>()
            //{
            //    BookMarkName = "恢复书签",
            //    State = 1,
            //    StepId = 1,
            //    WF_Result = 6 //57403176c40e4368977735c42ab45539
            //};
            //work_reus.ResumeBookmark("书签1", bookmark);
            #endregion

            //测试 持久化 已经可以持久化（注意 数据库的 连接字符串）
            #region 测试持久化问题（已解决）
            Activity activity = new Activity_Test();
            //1 创建工作流
            //1.1 此处为为创建的工作流输入的参数
            Dictionary<string, object> dic = new Dictionary<string, object>() { { "temp", "测试输入参数" } };
            //var work = Common.WorkFlowAppHelper.CreateWorkflowApplication(activity, dic);

            //2 恢复工作流
            var work_reus = Common.WorkFlowAppHelper.LoadWorkflowApplication(activity, Guid.Parse("c47b9971-473a-48b9-8535-d5ac09c0e9b1"));
            //第一个参数为工作流创建时为书签所起的名字，第二个参数为创建书签时，声明的回调方法BookmarkCallback指定的某个方法
            //BookmarkCallback 要求的 签名 为 
            //NativeActivityContext context, Bookmark bookmark, object value
            //此处的dic及为方法签名中的第三个参数value
            work_reus.ResumeBookmark("测试书签", dic);
            #endregion


            Console.WriteLine("工作流结束，输入任何键退出");
            Console.ReadLine();
        }
    }
}
