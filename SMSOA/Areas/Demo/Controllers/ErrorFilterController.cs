using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.Demo.Controllers
{
    public class ErrorFilterController : Controller
    {
        // GET: Demo/ErrorFilter
        public ActionResult Index()
        {
            int a = 10;
            int b = 0;
            int result = a / b;
            return View();
        }
    }
}