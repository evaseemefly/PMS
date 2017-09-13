using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HttpHelper
{
    /// <summary>
    /// session帮助类
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// cookie中保存的session的名字
        /// </summary>
        protected static string cookie_sessionId = null;

        static SessionHelper()
        {
            var config = new Common.Config.HttpConfig();
            cookie_sessionId = config.Cookie_SessionId;
        }

        /// <summary>
        /// 将id存入memcached（作为value）中，并返回在memcached中存储时用到的key（随机生成的）
        /// </summary>
        /// <param name="id">返回guid</param>
        /// <returns></returns>
        public static string SetMemcached(string id)
        {
            //(1)生成session ID
            string sessionId = Guid.NewGuid().ToString();//创建Session的id，作为memcache的key
            //(2)将session id与userinfo对象存入memcache中
            //注意需要将userinfo序列化
            //第一个参数 Session中的key
            //第二个参数 序列化后的UserInfo对象
            //第三个参数 缓存过期时间
            MemcacheHelper.Set(sessionId, SerializerHelper.SerializerToString(id), DateTime.Now.AddHours(3));
            return sessionId;

            //(3)将创建的sessionId以cookie的形式返回给浏览器
            //cookie中保存的的为
            //sms_Session:123hfhks2344123
            //System.Web.HttpCookie cookie = new HttpCookie();
            //是为请求创建的cookie
            //if (isRequest)
            //{
            //    System.Net.Cookie cookie=new System.Net.Cookie()
            //}
            
            //HttpCookie cookie_SessionId = new HttpCookie(cookie_sessionId, sessionId);
            ////设置失效时间
            //cookie_SessionId.Expires = DateTime.Now.AddHours(3);
            //return cookie_SessionId;
        }
    }
}
