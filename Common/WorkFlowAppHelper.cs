using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Threading;

namespace Common
{
    public class WorkFlowAppHelper
    {

        static AutoResetEvent syncEvent = new AutoResetEvent(false);

        /// <summary>
        /// 创建持久化的工作流，并返回该工作流宿主
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static WorkflowApplication CreateWorkflowApplication(Activity activity, IDictionary<string, object> dict)
        {

            //启动工作流的方式（二）
            //使用WorkflowApplication承载工作流
            //1.1 创建传入的参数字典（可以传入多个参数）
            //1.2 创建工作流活动实例（现为传入一个工作流实例）

            //2 将活动实例传递给工作流
            WorkflowApplication app = new WorkflowApplication(activity, dict);

            //3 将工作流写入数据库中
            string connect_str = GetConfig();

            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connect_str);
            store.InstanceCompletionAction = InstanceCompletionAction.DeleteAll;//工作流结束后删除该工作流实例的相关数据
            app.InstanceStore = store;//workflow存储到数据库中。

            //4 注册工作流的各类事件
            app.Unloaded += OnUloaded;
            app.Aborted += OnAborted;
            app.Completed += OnCompleted;
            app.Idle += OnIdle;
            app.PersistableIdle += OnPersistableIdle;
            app.OnUnhandledException += OnUnhandledException;

            //5 启动工作流
            app.Run();
            return app;
        }




        /// <summary>
        /// 加载持久化的工作流，并返回该工作流宿主
        /// </summary>
        /// <param name="activity">活动对象实例</param>
        /// <param name="guid">具体实例的guid</param>
        /// <returns></returns>
        public static WorkflowApplication LoadWorkflowApplication(Activity activity, Guid guid)
        {
            WorkflowApplication app = new WorkflowApplication(activity);

            string connect_str = GetConfig();
SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connect_str);

            app.InstanceStore = store;//workflow存储到数据库中。
           
            
            app.Unloaded += OnUloaded;
            app.Aborted += OnAborted;
            app.Completed += OnCompleted;
            app.Idle += OnIdle;
            app.PersistableIdle += OnPersistableIdle;
            app.OnUnhandledException += OnUnhandledException;
            

            app.Load(guid);
            return app;
        }

        /// <summary>
        /// 读取配置文件中的工作流连接字符串（数据库连接字符串）
        /// </summary>
        /// <returns></returns>
        public static string GetConfig()
        {
            return Common.ConfigHelper.GetSettingValue("workflowConnection");
        }

        private static UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs arg)
        {
            Console.WriteLine("异常了!!");
            syncEvent.Set();
            return UnhandledExceptionAction.Abort;
        }

        private static PersistableIdleAction OnPersistableIdle(WorkflowApplicationIdleEventArgs arg)
        {
            Console.WriteLine("持久化");
            return PersistableIdleAction.Unload;
        }

        private static void OnIdle(WorkflowApplicationIdleEventArgs obj)
        {
            syncEvent.Set();
            Console.WriteLine("工作流空闲!!");
        }

        private static void OnCompleted(WorkflowApplicationCompletedEventArgs obj)
        {
            syncEvent.Set();
            Console.WriteLine("工作流完成了!!");
        }

        private static void OnAborted(WorkflowApplicationAbortedEventArgs obj)
        {
            syncEvent.Set();
            Console.WriteLine("工作流终止了!!");
        }

        private static void OnUloaded(WorkflowApplicationEventArgs obj)
        {
            syncEvent.Set();
            Console.WriteLine("工作流卸载");
        }
    }
}
