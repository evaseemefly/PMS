using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using Spring.Context;
using PMS.IBLL;
using Spring.Context.Support;

namespace SMSOA.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public UserInfo LoginUser { get; set; }
        string strSession = "sms_Session";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if(filterContext.HttpContext.Request.Cookies[strSession]==null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login/Index");
            }
            else
            {
                //1.1 从传入的请求中获取SessionId的值
                string sessionId = filterContext.HttpContext.Request.Cookies[strSession].Value;
                //1.2 从缓存中查询是否包含此Id的缓存对象           
                object userId_temp = Common.MemcacheHelper.Get(sessionId);
                bool isExt = false;
                if (userId_temp != null)
                {
                    int userId = Common.SerializerHelper.DeSerializerToObject<int>(userId_temp.ToString());
                    //1.3 根据该id查询指定的用户对象
                    isExt = true;
                    //
                    IApplicationContext appContext = ContextRegistry.GetContext();
                    //使用spring.net创建 userInfoBLL
                    IUserInfoBLL userInfoBLL = (IUserInfoBLL)appContext.GetObject("userInfoService");

                    var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
                    LoginUser = userInfo;
                    if (userInfo != null)
                    {
                        ViewBag.UserInfo = userInfo.UName;

                    }
                    else
                    {
                        ViewBag.UserInfo = "";
                    }
                }
                else
                {
                    ViewBag.UserInfo = null;
                }
            }
            
            
            base.OnActionExecuting(filterContext);
        }

        
    }
}