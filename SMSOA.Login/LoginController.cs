using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Login
{
    public class LoginController:Controller
    {
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
    }
}