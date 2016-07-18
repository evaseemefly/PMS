using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using Spring.Context;
using PMS.IBLL;
using Spring.Context.Support;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.Admin.Controllers
{
    public abstract class BaseController : Controller
    {
        //7月17日新添加
        IUserInfoBLL userInfoBLL { get; set; }
       // IActionInfoBLL actionInfoBLL { get; set; }

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
                    userInfoBLL = (IUserInfoBLL)appContext.GetObject("userInfoService");

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

        protected List<ActionInfo> GetAllActionByLgoinUser(bool isMiddle)
        {
            //获取当前登录用户的权限
            if (LoginUser != null)
            {
               return userInfoBLL.GetActionListByUID(LoginUser.ID,true, isMiddle);
            }
            else
            {
                return null;
            }
        }

        //获取当前方法的area、controller、action名称
        /// <summary>
        /// 获取当前方法的area、controller、action、url名称
        /// </summary>
        /// <returns></returns>
        public abstract ViewModel_MyHttpContext GetHttpContext();

        /// <summary>
        /// 获取不显示的权限集合且符合当前上下文要求的权限集合
        /// </summary>
        /// <returns></returns>
        protected List<ActionInfo> GetNotShowAction()
        {
            //1 获取该用户拥有的全部权限集合
            var list_allAction= GetAllActionByLgoinUser(true);
            //2 从该权限中筛选出所有isShow为false的权限
           var list_notShow=(from a in list_allAction
                            where a.isShow == false
                            select a).ToList();

            //3 获取符合当前上下文的权限集合
            var httpContext= GetHttpContext();
            var list = from a in list_notShow
                       where a.AreaName == httpContext.Area
                       where a.ControllerName == httpContext.Controller
                       where a.ActionMethodName == httpContext.Action
                       select a;
            return list.ToList();
        }

        public bool CheckPersonToolBar()
        {
            //检查该登录用户是否拥有显示toolbar的权限
            var userId = LoginUser.ID;
            //取得符合当前上下文（area,controller,action）的权限集合
            var list_notShowAction = GetNotShowAction();
            var codes = from d in PMS.Model.Dictionary.MethodTypeDictonary.GetMethodTypeCode()
                        where d.Value == "编辑联系人toolbar权限"
                        select d.Key;
            var list_toolbarAction = from a in list_notShowAction
                                     where a.MethodTypeEnum == codes.ToList().FirstOrDefault()
                                     select a;
            if (list_toolbarAction.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckContactCommonToolBar()
        {
            //检查该登录用户是否拥有显示toolbar的权限
            var userId = LoginUser.ID;
            //取得符合当前上下文（area,controller,action）的权限集合
            var list_notShowAction = GetNotShowAction();
            var codes = from d in PMS.Model.Dictionary.MethodTypeDictonary.GetMethodTypeCode()
                        where d.Value == "编辑当前toolbar权限"
                        select d.Key;
            var list_toolbarAction = from a in list_notShowAction
                                     where a.MethodTypeEnum == codes.ToList().FirstOrDefault()
                                     select a;
            if (list_toolbarAction.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}