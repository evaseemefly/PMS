using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;
using Spring.Context;
using Spring.Context.Support;

namespace SMSOA.Filters
{
    public class LoginValidateAttribute:System.Web.Mvc.AuthorizeAttribute
    {
        //在执行动作之前进行认证
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    base.OnActionExecuting(filterContext);
        //}

        bool isExt = false;

        bool isCheked = false;

        string strSession = "sms_Session";


        //IUserInfoBLL userInfoBLL { get; set; }

        public UserInfo LoginUser { get; set; }

        public UserInfo LoginUser_Select { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //获取区域名称
            
            return base.AuthorizeCore(httpContext);
        }

        protected bool CheckIsLogin(AuthorizationContext filterContext)
        {
            //判断用户是否登录
            //1 根据请求中的Cookies中是否包含SessionId
            //取出userInfo Id
            if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains(strSession))
            {
                //1.1 从传入的请求中获取SessionId的值
                string sessionId = filterContext.HttpContext.Request.Cookies[strSession].Value;
                //1.2 从缓存中查询是否包含此Id的缓存对象
                //从memecache中查找指定对象
                object user = Common.MemcacheHelper.Get(sessionId);
                if (user != null)
                {
                    //1.3 若存在反序列化
                    //反序列化
                    //获取用户对象
                    //取出userInfo Id
                    //***注意查看一下此处是否含导航属性
                    LoginUser = Common.SerializerHelper.DeSerializerToObject<UserInfo>(user.ToString());
                    int UserId = LoginUser.ID; 
                    isExt = true;
                    //
                    IApplicationContext appContext = ContextRegistry.GetContext();
                    //使用spring.net创建 userInfoBLL
                    IUserInfoBLL userInfoBLL = (IUserInfoBLL)appContext.GetObject("userInfoService");

                    //2 判断用户是否登录
                    if (LoginUser.UName == "dundundun")
                    {
                        return true;
                    }
                    else
                    {
                        if (LoginUser != null)
                        {
                            //从数据库中查询是否包含此用户
                            //若包含此用户说明该用户已经登录
                            //查找该用户对象是否存在
                            
                            var userInfo = userInfoBLL.GetListBy(u => u.ID == UserId).FirstOrDefault();
                            LoginUser_Select = userInfo;
                            if (userInfo!=null)
                            {
                                return true;
                            }
                            else
                            {
                                
                                return false; }
                        }

                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //bool isExt = false;
            

            List<string> listAreaLimite = new List<string> { "admin" };
            //if(!string.IsNullOrEmpty(strArea)&&listAreaLimite.Contains(strArea))
            //{
                //判断是否要跳过登录以及权限验证
                if(!SkipValidate<Common.Attributes.SkipAttribute>(filterContext))
                {
                    bool isLogin = false;
                    //2 判断是否要跳过登录验证
                    if (!SkipValidate<Common.Attributes.SkipLoginAttribute>(filterContext))
                    {
                        //判断是否登录
                        isLogin = CheckIsLogin(filterContext);
                    //未登录跳转至登录页面
                        if(!isLogin)
                        {
                           
                            filterContext.HttpContext.Response.Redirect("/Login/Login/Index");
                        }
                       
                    }
                    //若已经登录，则判断是否要跳过权限验证
                    if(isLogin&&!SkipValidate<Common.Attributes.SkipPemissionAttribute>(filterContext))
                    {
                        //分别获取当前url的区域，控制器，以及方法名
                        //1 获取区域名称
                        string strArea = filterContext.RouteData.DataTokens.Keys.Contains("area") ? filterContext.RouteData.DataTokens["area"].ToString().ToLower() : "";
                        string strController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                        string strAction = filterContext.ActionDescriptor.ActionName.ToLower();

                        string strHttpMethod = filterContext.HttpContext.Request.HttpMethod;
                    int intHttpMethod = 0;
                    
                    if(strHttpMethod.ToLower()=="post")
                    {
                        intHttpMethod = 1;
                    }
                    else if(strHttpMethod.ToLower()=="get")
                    {
                        intHttpMethod = 2;
                    }
                    else
                    {
                        intHttpMethod = 3;
                    }
                    
                    //判断与数据库中的该用户权限是否一致
                    //1.1 通过路线一去查询该用户所拥有的权限
                   var action_R= LoginUser_Select.R_UserInfo_ActionInfo.Where(r => r.ActionInfoID == LoginUser.ID).ToList();
                    //1.2 判断该权限集合中是否满足上面的判断方法
                    foreach (var item in action_R)
                    {
                        //当区域、控制器、方法名都相等（且是允许关系）
                        if (item.ActionInfo.AreaName==strArea&&item.ActionInfo.ControllerName==strController&&item.ActionInfo.ActionMethodName==strAction&&item.ActionInfo.ActionTypeEnum==intHttpMethod/*&&item.isPass==true*/)
                        {
                            if(item.isPass==true)
                            { return; }
                            //禁用该权限
                            //且当前用户已经登录则跳转至首页
                            else if(item.isPass==false)
                            {//若登录则跳转至首页
                                filterContext.HttpContext.Response.Redirect("/Admin/Home/Index");
                                return;
                            }
                        }
                    }

                    //2.1 通过路线二 查询 该用户拥有的所有权限
                    //查询该用户所拥有的所有角色（路线2）
                    var userRoles= LoginUser_Select.RoleInfo;
                    //查询该用户对应的所有角色所对应的所有权限
                    foreach (var item in userRoles)
                    {
                       var actionList= item.ActionInfo.Where(a => a.ActionMethodName.ToLower() == strAction && a.AreaName.ToLower() == strArea && a.ControllerName.ToLower() == strController && a.ActionTypeEnum == intHttpMethod).ToList();
                        if(actionList.Count>0)
                        {
                            return;
                        }

                    }
                    filterContext.HttpContext.Response.Redirect("/Admin/Home/Index");
                    return;
                }
                }
                
            
            //base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        bool SkipValidate<T>(System.Web.Mvc.AuthorizationContext filterContext) where T:Attribute
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(T), false) &&
                   !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(T), false))
            {
                return false;
            }
            return true;
        }
    }
}