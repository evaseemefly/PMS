using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.Recycled.Controllers
{
    public class HomeController : Controller
    {
        // GET: Recycled/Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 读取字典
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRecycledType()
        {
            //根据下拉框选中的id获取该id对应的回收站中内容的种类
            return View();
        }

        /// <summary>
        /// 获取下拉框中应该显示的内容
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllRecycled()
        {
            return View();
        }
    }
}