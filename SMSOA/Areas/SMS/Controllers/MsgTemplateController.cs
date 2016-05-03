using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.SMS.Controllers
{
    /// <summary>
    /// 短信模板
    /// </summary>
    public class MsgTemplateController : Controller
    {
        // GET: SMS/MsgTemplate
        public ActionResult Index()
        {
            return View();
        }
    }
}