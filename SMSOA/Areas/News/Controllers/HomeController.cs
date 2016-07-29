using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.News.Controllers
{
    public class HomeController : Controller
    {
        // GET: News/News
        public ActionResult Index()
        {
            return View();
        }
    }
}