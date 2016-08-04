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
            ViewBag.ShowMsg= "/News/Home/ShowMsg";
            return View();
        }

        public ActionResult ShowMsg(int snid)
        {
            //根据传入的snid查找对应的消息具体内容
            var news= newsBLL.GetNewsBySNID(snid, true);
            //ViewBag.Title = news.Title;
            ViewBag.NewsTitle = news.Title;
            //ViewBag.CreateUser=news.
            ViewBag.NewsContent = news.NewsContent;
            //ViewData["news"] = news;
            //ViewData.Model = news;
            return View();
        }
        public ActionResult GetAllNewsList()
        {
           //获取登录用户可以查看的全部新消息
           var list= newsBLL.GetAllNewsPageListByUser(this.LoginUser.ID,1,true,5);

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