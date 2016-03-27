﻿using System;
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
        private static readonly log4net.ILog logInfo = log4net.LogManager.GetLogger("logInfo");

        private static readonly log4net.ILog logError = log4net.LogManager.GetLogger("logoError");

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if(logInfo.IsInfoEnabled)   //IsInfoEnabled？
            {
                logInfo.Info(info);
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        public static void WriteError(string info,Exception ex)
        {
            if(logError.IsErrorEnabled)  //IsErrorEnabled?
            {
                logError.Error(info, ex);
            }
        }
    }
}