using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Common;

namespace log4netDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.LogHelper.WriteLog("测试");
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            //var logInfo = log4net.LogManager.GetLogger("loginfo");
            //logInfo.Info("测试测试");
            //LogHelper.WriteLog("测试日志");

            Console.ReadLine();
        }
    }
}
