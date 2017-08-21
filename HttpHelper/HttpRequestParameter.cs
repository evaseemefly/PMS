using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    /// <summary>
    /// 请求参数类
    /// </summary>
    public class HttpRequestParameter
    {
        public HttpRequestParameter()
        {
            Encoding = Encoding.UTF8;
        }
        /// <summary>
        /// 请求方式：true表示post,false表示get
        /// </summary>
        public bool IsPost { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 请求Cookie对象
        /// </summary>
        public HttpCookieType Cookie { get; set; }
        /// <summary>
        /// 请求编码
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        public string JsonData { get; set; }
        /// <summary>
        /// 引用页
        /// </summary>
        public string RefererUrl { get; set; }
    }
}
