using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Redis.Generic;

using System.Configuration;

namespace Common.Redis
{
    /// <summary>
    /// Redis配置对象
    /// </summary>
   public sealed class RedisConfig:ConfigurationSection
    {
        /// <summary>
        /// 获取Redis配置对象
        /// </summary>
        /// <returns></returns>
        public static RedisConfig GetConfig()
        {
            //读取配置文件中 RedisConfig配置节，并转成RedisConfig(当前类，并通过下面定义的属性获取配置节节点中的值）
            var section =(RedisConfig)ConfigurationManager.GetSection("RedisConfig");

            return section;
        }

     

        public static RedisConfig GetConfig(string sectionName)
        {
            //根据指定的 名称 查找对应的配置节
            var section = (RedisConfig)ConfigurationManager.GetSection(sectionName);
            if(section==null)
            {
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            }
            return section;
        }

        /// <summary>
        /// 可写的Redis链接地址
        /// </summary>
        [ConfigurationProperty("WriteServerList", IsRequired = false)]
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

        /// <summary>
        /// 可读的Redis链接地址
        /// </summary>
        [ConfigurationProperty("ReadServerList", IsRequired = false)] 
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

        /// <summary>
       /// 最大写链接数
         /// </summary>
         [ConfigurationProperty("MaxWritePoolSize", IsRequired = false, DefaultValue = 5)]
        public int MaxWritePoolSize
       {
            get
            {
                var maxWritePoolSize = (int)base["MaxWritePoolSize"];
               return maxWritePoolSize > 0 ? maxWritePoolSize : 5;
             }
            set
            {
                 base["MaxWritePoolSize"] = value;
            }
        }     
           
         /// <summary>
       /// 最大读链接数
         /// </summary>
       [ConfigurationProperty("MaxReadPoolSize", IsRequired = false, DefaultValue = 5)]
       public int MaxReadPoolSize
        {
            get
            {
                var maxReadPoolSize = (int)base["MaxReadPoolSize"];
                return maxReadPoolSize > 0 ? maxReadPoolSize : 5;
            }
            set
            {
                base["MaxReadPoolSize"] = value;
            }
        }        
        /// <summary>
        /// 自动重启
        /// </summary>
        [ConfigurationProperty("AutoStart", IsRequired = false, DefaultValue = true)]
          public bool AutoStart
          {
              get
              {
                  return (bool)base["AutoStart"];
              }
              set
              {
                  base["AutoStart"] = value;
              }
          }        
          /// <summary>
          /// 本地缓存到期时间，单位:秒
         /// </summary>
         [ConfigurationProperty("LocalCacheTime", IsRequired = false, DefaultValue = 36000)]
         public int LocalCacheTime
         {
             get
             {
                 return (int)base["LocalCacheTime"];
             }
             set
             {
                 base["LocalCacheTime"] = value;
             }
         }
         /// <summary>
         /// 是否记录日志,该设置仅用于排查redis运行时出现的问题,如redis工作正常,请关闭该项
         /// </summary>
         [ConfigurationProperty("RecordeLog", IsRequired = false, DefaultValue =false)]
         public bool RecordeLog
         {
             get
             {
                 return (bool)base["RecordeLog"];
             }
             set
             {
                 base["RecordeLog"] = value;
             }
         }
     }
    
}
