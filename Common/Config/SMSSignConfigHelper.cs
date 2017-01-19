using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    /// <summary>
    /// 短信签名配置类
    /// </summary>
    public class SMSSignConfigHelper
    {
        /// <summary>
        /// 发送短信账户
        /// </summary>
        public string account { get; set; }

        /// <summary>
        /// 发送短信密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 发送短信签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 构造函数通过配置文件初始化三个属性
        /// </summary>
        public SMSSignConfigHelper()
        {
            this.account = ConfigHelper.GetSettingValue("SMSAccount");
            this.password = ConfigHelper.GetSettingValue("SMSPwd");
            this.sign = ConfigHelper.GetSettingValue("SMSSign");
        }
    }
}
