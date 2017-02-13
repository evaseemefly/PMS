using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigManager
{
    public class ConfigSection: ConfigurationSection
    {
        public static ConfigSection GetConfig()
        {
            return GetConfig("mysection");
        }

        public static ConfigSection GetConfig(string sectionName)
        {
            //找到配置节中的 传入的 "mysection" 的配置节 将其转为对象
            return (ConfigSection)ConfigurationManager.GetSection(sectionName);
        }

        public ConfigSection()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 在配置文件中找到指定配置节中的user对应的值
        /// </summary>
        [ConfigurationProperty("user", DefaultValue = "yanghong", IsRequired = true)]
        public string User
        {
            get { return (string)this["user"]; }
            set { this["user"] = value; }
        }

        [ConfigurationProperty("password", DefaultValue = "password", IsRequired = true)]
        public string PassWord
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
        
    }
}
