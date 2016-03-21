using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;

namespace SMSOA.Controllers
{
    public class HomeController : Controller
    {
        
        IUserInfoBLL userInfoBLL { get; set; }
        
        public ActionResult Index()
        {
            
            var userInfoList = userInfoBLL.GetListBy(u =>true).ToList();
            ViewData.Model = userInfoList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}