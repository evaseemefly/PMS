using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;

namespace Common
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class LogHelper
    {
        #region 2017-05-05 不使用此种方式，注释
        //private static readonly log4net.ILog logInfo = log4net.LogManager.GetLogger("Info");

        //private static readonly ILog logWarn = LogManager.GetLogger("WARN");

        //private static readonly log4net.ILog logError = log4net.LogManager.GetLogger("ERROR");
        #endregion


        private static string path_logConfig = string.Empty;

        private static log4net.Core.LogImpl logImpl;

        static LogHelper()
        {
            string path_logConfig=Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(path_logConfig));
           logImpl= log4net.LogManager.GetLogger("mylogger") as log4net.Core.LogImpl;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            //logInfo.Info(info);
            //logImpl.Info(info);
            if (logImpl.IsInfoEnabled)   //IsInfoEnabled？
            {
                logImpl.Info(info);
            }
        }

        /// <summary>
        /// 写入警告
        /// </summary>
        /// <param name="warn"></param>
        public static void WriteWarn(string warn)
        {
            if (logImpl.IsWarnEnabled)
            {
                logImpl.Warn(warn);               
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        public static void WriteError(string info,Exception ex=null)
        {
            if(logImpl.IsErrorEnabled)  //IsErrorEnabled?
            {
                if (ex != null)
                    logImpl.Error(info, ex);
                else
                    logImpl.Error(info);
            }
        }
    }
}
