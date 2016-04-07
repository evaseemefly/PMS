using SMSOA.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        [Common.Attributes.ViewAttribute]
        [LoginValidate]
        public ActionResult Index()
        {
            return View();
        }
    }
}