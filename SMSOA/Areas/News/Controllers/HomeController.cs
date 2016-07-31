using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.News.Controllers
{
    public class HomeController : Admin.Controllers.BaseController
    {
        IN_NewsBLL newsBLL;
        // GET: News/News
        public ActionResult Index()
        {
            ViewBag.GetAllNewsList = "GetAllNewsList";
            return View();
        }

        public ActionResult GetAllNewsList()
        {

           var list= newsBLL.GetAllNewsListByUser(this.LoginUser.ID, 5);

            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            var httpModel = new ViewModel_MyHttpContext()
            {
                Area = "News",
                Controller = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString(),
                Action = RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString(),
                Url = Request.Url.ToString()
            };
            return httpModel;
        }
    }
}