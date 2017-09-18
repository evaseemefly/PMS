using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HttpHelper
{
    /// <summary>
    /// Cookie对应类
    /// </summary>
    public class HttpCookieType
    {

        //public System.Web.HttpCookie
        /// <summary>
        /// cookie集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        /// <summary>
        /// Cookie字符串
        /// </summary>
        public string CookieString { get; set; }
    }
}
