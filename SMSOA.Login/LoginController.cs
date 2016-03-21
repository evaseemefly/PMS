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

        public ActionResult ValidateCode()
        {

        }
    }
}