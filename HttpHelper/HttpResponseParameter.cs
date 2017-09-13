using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    /// <summary>
    /// 响应参数类
    /// </summary>
    public class HttpResponseParameter
    {
        public HttpResponseParameter()
        {
            Cookie = new HttpCookieType();
        }
        /// <summary>
        /// 响应资源标识符
        /// </summary>
        public Uri Uri { get; set; }
        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 响应Cookie对象
        /// </summary>
        public HttpCookieType Cookie { get; set; }
        /// <summary>
        /// 响应体
        /// </summary>
        public string Body { get; set; }
    }
}
