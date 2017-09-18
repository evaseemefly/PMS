using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    public class HttpConfig:ConfigHelper
    {
        /// <summary>
        /// cookie中保存的session id
        /// </summary>
        private string cookie_SessionId;

        /// <summary>
        /// cookie中保存的session id
        /// 外部可访问的只读属性
        /// </summary>
        public string Cookie_SessionId { get { return cookie_SessionId; } }

        public HttpConfig()
        {
            this.cookie_SessionId = GetSettingValue("cookiesessionid");
        }
    }
}
