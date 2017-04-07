using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager
{
    public class MyConfig: ConfigurationSection
    {
        public MyConfig() { }

        public static MyConfig GetConfig()
        {
            MyConfig section = GetConfig("customconfig");
            return section;
        }

        public static MyConfig GetConfig(string sectionName)
        {
            //var obj = ConfigurationManager.GetSection(sectionName);
            MyConfig section = (MyConfig)ConfigurationManager.GetSection(sectionName);
            if (section == null)
            {
                throw new ConfigurationErrorsException("section" + sectionName + "is not found");
            }
            return section;
        }

        [ConfigurationProperty("user", IsRequired =false)]
        public string user
        {
            get
            {
                return (string)base["user"];
            }
            set
            {
                base["user"] =value;
            }
        }
    }
}
