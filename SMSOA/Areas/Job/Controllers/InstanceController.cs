using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.BLL;

namespace SMSOA.Areas.Job.Controllers
{
    public class InstanceController : Controller
    {
        IJ_JobInfoBLL jobBLL = new J_JobInfoBLL();
        // GET: Job/Instance

        public ActionResult Index()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            var list= jobBLL.GetAllNullDelJobInfo();
            return Content(Common.SerializerHelper.SerializerToString(list));
        }
    }
}