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

        //若没有登录重定向的页面
        string url_noLogin = "/Login/Login/Index";

        string url_noAuthorization = "/Admin/Home/Index";
        //IUserInfoBLL userInfoBLL { get; set; }

        public UserInfo LoginUser { get; set; }

        //public UserInfo LoginUser_Select { get; set; }


        /// <summary>
        /// 检查是否已经登录
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
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
                //4月1日 注意此处已修改为将用户的Id存入缓存中，而不是将用户实体对象存入缓存中
                object userId_temp = Common.MemcacheHelper.Get(sessionId);
               
                if (userId_temp != null)
                {
                    int userId = Common.SerializerHelper.DeSerializerToObject<int>(userId_temp.ToString());
                    //1.3 根据该id查询指定的用户对象


                    //1.3 若存在反序列化
                    //反序列化
                    //获取用户对象
                    //取出userInfo Id
                    //***注意查看一下此处是否含导航属性——包含导航属性，不用再查询
                    
                    //int UserId = LoginUser.ID; 
                    isExt = true;
                    //
                    IApplicationContext appContext = ContextRegistry.GetContext();
                    //使用spring.net创建 userInfoBLL
                    IUserInfoBLL userInfoBLL = (IUserInfoBLL)appContext.GetObject("userInfoService");

                    var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
                    LoginUser = userInfo;
                    if (userInfo != null)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                    #region 4月1日注释掉
                    ////2 判断用户是否登录
                    ////留一个后门为dundundun
                    //if (LoginUser.UName == "dundundun")
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    if (LoginUser != null)
                    //    {
                    //        //2.1从数据库中查询是否包含此用户
                    //        //若包含此用户说明该用户已经登录
                    //        //查找该用户对象是否存在                            
                    //        var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
                    //        LoginUser_Select = userInfo;
                    //        if (userInfo!=null)
                    //        {
                    //            return true;
                    //        }
                    //        else
                    //        {

                    //            return false; }
                    //    }

                    //}
                    #endregion
                                }
                //根据指定sessionId无法找到缓存中的value
                else
                {

                }
            }
            //若传入的Cookie中不含SessionId
            
            return false;
            
            
        }

        /// <summary>
        /// 判断是否拥有权限
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public bool CheckOwnAction(AuthorizationContext filterContext)
        {
            //分别获取当前url的区域，控制器，以及方法名
            //1 获取区域名称
            string strArea = filterContext.RouteData.DataTokens.Keys.Contains("area") ? filterContext.RouteData.DataTokens["area"].ToString().ToLower() : "";
            string strController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string strAction = filterContext.ActionDescriptor.ActionName.ToLower();
            string strHttpMethod = filterContext.HttpContext.Request.HttpMethod;
            int intHttpMethod = 0;

            if (strHttpMethod.ToLower() == "post")
            {
                intHttpMethod = 1;
            }
            else if (strHttpMethod.ToLower() == "get")
            {
                intHttpMethod = 2;
            }
            else
            {
                intHttpMethod = 3;
            }

            //判断与数据库中的该用户权限是否一致
            //1.1 通过路线一去查询该用户所拥有的权限
            var action_R = LoginUser.R_UserInfo_ActionInfo.Where(r => r.ActionInfoID == LoginUser.ID).ToList();
            //1.2 判断该权限集合中是否满足上面的判断方法
            foreach (var item in action_R)
            {
                //当区域、控制器、方法名都相等（且是允许关系）
                if (item.ActionInfo.AreaName == strArea && item.ActionInfo.ControllerName == strController && item.ActionInfo.ActionMethodName == strAction && item.ActionInfo.ActionTypeEnum == intHttpMethod/*&&item.isPass==true*/)
                {
                    if (item.isPass == true)
                    { return true; }
                    //禁用该权限
                    //且当前用户已经登录则跳转至首页
                    else if (item.isPass == false)
                    {//若登录则跳转至首页
                        //filterContext.HttpContext.Response.Redirect("/Admin/Home/Index");
                        return false;
                    }
                }
            }

            //2.1 通过路线二 查询 该用户拥有的所有权限
            //查询该用户所拥有的所有角色（路线2）
            var userRoles = LoginUser.RoleInfo;
            //查询该用户对应的所有角色所对应的所有权限
            foreach (var item in userRoles)
            {
                var actionList = item.ActionInfo.Where(a => a.ActionMethodName.ToLower() == strAction && a.AreaName.ToLower() == strArea && a.ControllerName.ToLower() == strController && a.ActionTypeEnum == intHttpMethod).ToList();
                if (actionList.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            //filterContext.HttpContext.Response.Redirect("/Admin/Home/Index");
            //return;
            return false;
        }

        public string CheckPermissionReturnData(AuthorizationContext filterContext)
        {
            //判断当前的请求是否拥有权限
            if(this.CheckOwnAction(filterContext))
            {
                return null;
            }
            return null;
            
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //bool isExt = false;
            //var user= filterContext.HttpContext.User;
            //filterContext.Result = new HttpUnauthorizedResult();


            List<string> listAreaLimite = new List<string> { "admin" };
            //if(!string.IsNullOrEmpty(strArea)&&listAreaLimite.Contains(strArea))
            //{
                //1.1 判断是否要跳过登录以及权限验证
                if(!SkipValidate<Common.Attributes.SkipAttribute>(filterContext))
                {
                    bool isLogin = false;
                    //1.2 判断是否要跳过登录验证
                    if (!SkipValidate<Common.Attributes.SkipLoginAttribute>(filterContext))
                    {
                        //2.1 判断是否登录
                        isLogin = CheckIsLogin(filterContext);
                    /*2.2 根据请求类型提供不同的跳转方式
                    （Url请求数据：返回ok，error,nologin,noPermission
                      post提交请求：ok,error,nologin,noPermission
                      返回试图：跳转到错误页面   

                未登录跳转至登录页面



                    */
                    if (!isLogin)
                        {
                           
                            filterContext.HttpContext.Response.Redirect(url_noLogin);
                        //filterContext.HttpContext.Response
                        return;
                        }                   
                       
                    }
                    //若已经登录，则判断是否要跳过权限验证
                    if(isLogin&&!SkipValidate<Common.Attributes.SkipPemissionAttribute>(filterContext))
                    {
                    bool isOwnAction = false;
                    //判断
                   isOwnAction= CheckOwnAction(filterContext);
                  
                        //若是ajax请求
                        #region 请求类型为ajax请求
                        if (SkipValidate<Common.Attributes.AjaxAttribute>(filterContext))
                        {
                            if (isOwnAction)
                            {
                                return;

                            }
                            else
                            {
                                //返回ajax类型的数据
                                PMS.Model.FormatModel.MyAjaxModel ajaxModel = new PMS.Model.FormatModel.MyAjaxModel()
                                {
                                    BackUrl = "",
                                    Data = "",
                                    Msg = "未拥有该权限",
                                    Statu = "noPermission"        //ok,error,noLogin,noPermission
                                };
                                filterContext.HttpContext.Response.Write(ajaxModel);
                            }

                        }
                        #endregion

                        //若为url请求数据
                        #region 若请求类型为url获取数据请求
                        else if (SkipValidate<Common.Attributes.DataByUrlAttribute>(filterContext))
                        {
                            //若拥有该权限
                            if(isOwnAction)
                            {
                                return;
                            }
                            else
                            {
                                filterContext.HttpContext.Response.Write("noPermission");
                            }
                        }
                        #endregion

                        //若为返回视图
                        #region 若为返回视图
                        else if (SkipValidate<Common.Attributes.ViewAttribute>(filterContext))
                        {
                            if(isOwnAction)
                            {
                                return;
                            }
                            else
                            {
                                //若不拥有该权限则跳转至错误页面
                                filterContext.HttpContext.Response.Redirect(url_noAuthorization);

                            filterContext.Result = new RedirectResult(url_noAuthorization);
                            }
                        }
                    #endregion

                    return;
                    
                }
                }
                
            
            //base.OnAuthorization(filterContext);
        }


        public void MyRedirect(string url, AuthorizationContext filterContext)
        {
            //判断是否为ajax请求，若为ajax请求直接返回ajax信息
           if(SkipValidate<Common.Attributes.AjaxAttribute>(filterContext))
            {
                //return filterContext.HttpContext.Response()
            }
        }

        /// <summary>
        /// 以json格式返回
        /// </summary>
        /// <param name="statu">ok,error,noLogin,noPermission</param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="backurl"></param>
        /// <returns></returns>
        public ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        {
            PMS.Model.FormatModel.MyAjaxModel ajax = new PMS.Model.FormatModel.MyAjaxModel()
            {
                Statu = statu,
                Msg = msg,
                Data = data,
                BackUrl = backurl
            };
            JsonResult res = new JsonResult();
            
            res.Data = ajax;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
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