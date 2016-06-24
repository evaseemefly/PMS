using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Redis.Generic;

using System.Configuration;

namespace Common
{
   public sealed class RedisConfig:ConfigurationSection
    {
        public static RedisConfig GetConfig()
        {
            var section =(RedisConfig)ConfigurationManager.GetSection("RedisConfig");

            return section;
        }

        public static RedisConfig GetConfig(string sectionName)
        {
            var section = (RedisConfig)ConfigurationManager.GetSection(sectionName);
            if(section==null)
            {
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            }
            return section;
        }

        [ConfigurationProperty]
        public string WriteServerList
        {
            get
            {
                return (string)base["WriteServerList"];
            }
            set
            {
                base["WriteServerList"] = value;
            }
        }

        public string ReadServerList
        {
            get
            {
                return (string)base["ReadServerList"];
            }
            set
            {
                base["ReadServerList"] = value;
            }
        }
    }
}
