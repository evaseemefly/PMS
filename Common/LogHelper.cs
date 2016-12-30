using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Common
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class LogHelper
    {
        private static readonly log4net.ILog logInfo = log4net.LogManager.GetLogger("loginfo");

        private static readonly ILog logWarn = LogManager.GetLogger("logWarn");

        private static readonly log4net.ILog logError = log4net.LogManager.GetLogger("logerror");

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            //logInfo.Info(info);
            if (logInfo.IsInfoEnabled)   //IsInfoEnabled？
            {
                logInfo.Info(info);
            }
        }

        /// <summary>
        /// 写入警告
        /// </summary>
        /// <param name="warn"></param>
        public static void WriteWarn(string warn)
        {
            if (logWarn.IsWarnEnabled)
            {
                logWarn.Warn(warn);               
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        public static void WriteError(string info,Exception ex=null)
        {
            if(logError.IsErrorEnabled)  //IsErrorEnabled?
            {
                if (ex != null)
                    logError.Error(info, ex);
                else
                    logError.Error(info);
            }
        }
    }
}
