using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class ConfigHelper
    {
        /// <summary>
        /// 读取AppSetting配置节中的key对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSettingValue(string key)
        {
           return ConfigurationManager.AppSettings[key];
        }
    }
}
