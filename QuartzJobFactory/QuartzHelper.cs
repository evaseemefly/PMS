using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace QuartzJobFactory
{
    public class QuartzHelper
    {
        private static object obj = new object();

        private static IScheduler sche = null;

        /// <summary>
        /// 初始化任务调度对象
        /// </summary>
        public static void InitScheduler()
        {
            try
            {
                lock (obj)
                {
                    if (sche == null)
                    {
                        //使用配置文件的方式配置quartz实例
                        sche= StdSchedulerFactory.GetDefaultScheduler();
                        LogHelper.WriteLog("任务调度初始化成功");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("任务调度初始化失败！", ex);
            }
        }

        /// <summary>
        /// 启动调度池
        /// </summary>
        public static void StartScheduler()
        {
            try
            {
                if (!sche.IsStarted)
                {
                    sche.Start();
                    LogHelper.WriteLog("调度池启动成功");
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteError("调度池启动失败",ex);
            }
        }

        /// <summary>
        /// 终止调度池
        /// </summary>
        public static void StopScheduler()
        {
            try
            {
                if (!sche.IsShutdown)
                {
                    sche.Shutdown(true);
                    LogHelper.WriteLog("调度池停止");
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteError("调度池停止失败", ex);
            }
        }
    }
}
