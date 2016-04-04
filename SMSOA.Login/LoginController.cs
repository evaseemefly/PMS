using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;
using Common;

namespace SMSOA.Login
{
    public class LoginController:Controller
    {
        IUserInfoBLL userInfoBLL { get; set; }

        public ActionResult Index()
        {
            CheckCookieInfo();
            return View();
        }

        string cookie_sessionId = "sms_Session";

        /// <summary>
        /// 展示验证码并将验证码中的字符串保存至Session中
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            //1 创建自定义验证码类
            Common.ValidateCode validateCode = new Common.ValidateCode();
            //2 调用该类中的创建验证码的方法，给我们返回验证码对应的字符串（4个数字）
            string code = validateCode.CreateValidateCode(4);//创建长度为4个字母的图片


            Session["validateCode"] = code; //将验证码保存至Session（未保存至分布式缓存）

            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "imge.jpg");

        }

        public ActionResult CheckLogin()
        {
            //1 从Session中读取验证码
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();

            //2 判断验证码
            //2.1 验证码若为空则说明session中没有验证码
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:服务器错误");
            }

            //2.2只要验证码不为空，则先清除session中的验证码
            Session["validateCode"] = null;
            //2.2 获取前台页面提交请求中包含验证码的Name属性
            string requestCode = Request["vCode"];
            //2.2.1 判断服务器session中保存的验证码与服务器发送的验证码是否相同            
            if (!requestCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))   //忽略大小写
            {
                return Content("no:验证码错误");
            }

            else
            {
                //2.2.2 拿到浏览器传过来的用户名与密码
                string userName = Request["LoginCode"];
                string userPwd = Request["LoginPwd"];

                
                //2.2.3 取出当前的用户名所对应的用户对象
                UserInfo userInfo = userInfoBLL.GetListBy(u => u.UName == userName ).FirstOrDefault();
                //userInfoBLL.GetListBy(u => true).First();
                //对输入的密码进行md5加密，判断其是否与当前userInfo对象的密码相同
                //2.2.4 若存在当前用户
                if(userInfo!=null)
                {
                    //(1)将请求中（Request）中的LoginPwd用md5进行加密，并与从数据库中查询到的具体用户对象的密码（已经通过md5加密后的）
                    if (userInfo.UPwd == Encryption.MD5Encryption(userPwd))
                    {
                        //（2）已将保存userInfo的保存至Session中，并将对应的sessionId返回给浏览器保存
                        //4月1日 修改 ：
                        //*****注意此处存在问题：需要将userInfo对象序列化后再存入Memcache
                        //从Memcache中取出时一样需要先进行反序列化！！
                        //在model2Memecahe中对其进行序列化，但无法取出对应的对象
                        Model2Memecahe(userInfo);

                        //（3）判断是否选中记住我
                        //若未选中则为null，若选中则为1
                        if (!string.IsNullOrEmpty(Request["checkMe"]))
                        {
                            /*
                            1 创建HttpCookie类型的缓存对象（浏览器缓存）
                            2 并将Name及Pwd（通过md5加密）放入其中
                            3 为其设置失效时间
                            4 将添加的两个cookie（HtppCookie）存入Response.Cookies 集合中
                            */
                            //选中则将用户名与密码存入cookie中
                            HttpCookie cookie1 = new HttpCookie("sms_UserName", userInfo.UName);
                            //使用md5的方式将查询到的用户密码加密
                            HttpCookie cookie2 = new HttpCookie("sms_UserPwd", userInfo.UPwd);
                            //cookie设置失效时间
                            cookie1.Expires = DateTime.Now.AddHours(3);
                            cookie2.Expires = DateTime.Now.AddHours(3);
                            //将cookie添加至响应 的cookie集合中
                            Response.Cookies.Add(cookie1);
                            Response.Cookies.Add(cookie2);
                        }
                        return Content("ok:登录成功");
                    }
                    else
                    {
                        return Content("no:密码错误");
                    }
                }
                else
                {
                    //return Json(new object()
                    //{
                    //    "statu"

                    //})
                    return Content("no:用户名错误");
                }
              
            }

        }

        public void CheckCookieInfo()
        {
            //1 判断当前的请求中是否包含用户名以及密码的cookie
            if(Request.Cookies["sms_UserName"] !=null&&Request.Cookies["sms_UserPwd"] !=null)
            {
                //2 取出两个cookie
                string userName = Request.Cookies["sms_UserName"].Value;
                string userPwd = Request.Cookies["sms_UserPwd"].Value;

                //3 从数据库中查询指定用户名的对象
              var userInfo=  userInfoBLL.GetListBy(u => u.UName == userName).FirstOrDefault();
                if(userInfo!=null)
                {
                    //判断当前cookie中传入的密码与数据库中的密码是否相同
                    if (userInfo.UPwd== userPwd)
                    {
                        Response.Redirect("/Admin/Home/Index");
                    }
                    
                }
            }
        }

        protected void Model2Memecahe(UserInfo model)
        {
            //(1)生成session ID
            string sessionId = Guid.NewGuid().ToString();//创建Session的id，作为memcache的key
            //(2)将session id与userinfo对象存入memcache中
            //注意需要将userinfo序列化
            //第一个参数 Session中的key
            //第二个参数 序列化后的UserInfo对象
            //第三个参数 缓存过期时间
            MemcacheHelper.Set(sessionId, SerializerHelper.SerializerToString(model.ID), DateTime.Now.AddHours(3));
            //(3)将创建的sessionId以cookie的形式返回给浏览器
            //cookie中保存的的为
            //sms_Session:123hfhks2344123
            HttpCookie cookie_SessionId = new HttpCookie(cookie_sessionId, sessionId);
            //设置失效时间
           cookie_SessionId.Expires= DateTime.Now.AddHours(3);

            Response.Cookies.Add(cookie_SessionId);
        }
    }
}