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
            return View();
        }

        /// <summary>
        /// 展示验证码并将验证码中的字符串保存至Session中
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);//创建长度为4个字母的图片
            Session["validateCode"] = code; //将验证码保存至Session（未保存至分布式缓存）
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "imge.jepg");

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

            //只要验证码不为空，则先清除session中的验证码
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

                //取出当前的用户名与密码
                //取出当前的用户名所对应的用户对象
                UserInfo userInfo = userInfoBLL.GetListBy(u => u.UName == userName ).FirstOrDefault();
                //对输入的密码进行md5加密，判断其是否与当前userInfo对象的密码相同
                //若存在当前用户
                if(userInfo!=null)
                {
                    if (userInfo.UPwd == Encryption.MD5Encryption(userPwd))
                    {
                        //已将保存userInfo的保存至Session中，并将对应的sessionId返回给浏览器保存
                        Model2Memecahe(userInfo);

                        //（4）判断是否选中记住我
                        //若未选中则为null，若选中则为1
                        if (!string.IsNullOrEmpty(Request["checkMe"]))
                        {
                            //选中则将用户名与密码存入cookie中
                            HttpCookie cookie1 = new HttpCookie("cp1", userInfo.UName);
                            //使用md5的方式将查询到的用户密码加密
                            HttpCookie cookie2 = new HttpCookie("cp2", Encryption.MD5Encryption(userInfo.UPwd));
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
                    return Content("no:用户名错误");
                }
              
            }

        }

        protected void Model2Memecahe(UserInfo model)
        {
            //(1)生成session ID
            string sessionId = Guid.NewGuid().ToString();//创建Session的id，作为memcache的key
            //(2)将session id与userinfo对象存入memcache中
            //注意需要将userinfo序列化
            MemecacheHelper.Set(sessionId, SerializerHelper.SerializerToString(model), DateTime.Now.AddMinutes(60));
            //(3)将创建的sessionId以cookie的形式返回给浏览器
            Response.Cookies["sessionId"].Value = sessionId;
        }
    }
}