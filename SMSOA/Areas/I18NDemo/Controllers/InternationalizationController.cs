using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.I18NDemo.Controllers
{
    public class InternationalizationController : Controller
    {
        // GET: I18NDemo/Internationalization
        public ActionResult Index()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("SMSOA.Areas.I18NDemo.zh-cn", assembly);
            ViewBag.Name = rm.GetString("Name");
            ViewBag.Department = rm.GetString("Department");
            ViewBag.Title = rm.GetString("Title");
            return View();
        }
    }
}