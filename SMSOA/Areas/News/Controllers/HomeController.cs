using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model.ViewModel;
using PMS.Model;

namespace SMSOA.Areas.News.Controllers
{
    public class HomeController : Admin.Controllers.BaseController
    {
        IN_NewsBLL newsBLL;
        // GET: News/News
        public ActionResult Index()
        {
            ViewBag.GetAllNewsList = "GetNewsByTypeList";
            ViewBag.ShowMsg= "/News/Home/ShowMsg";
           
            return View();
        }

        public ActionResult ShowMsg(int snid)
        {
            //根据传入的snid查找对应的消息具体内容
            var news = newsBLL.GetNewsBySNID(snid, true);
            //ViewBag.Title = news.Title;
            ViewBag.NewsTitle = news.Title;
            //ViewBag.CreateUser=news.
            ViewBag.NewsContent = news.NewsContent;
            //ViewData["news"] = news;
            //ViewData.Model = news;
            return View();
        }

        public ActionResult NewsListShow()
        {
            ViewBag.ShowAdd = "/News/Home/ShowAddMsg";
            ViewBag.ShowMsg= "/News/Home/ShowMsg";
            ViewBag.GetNewsList= "GetAllNewsList";
            ViewBag.ShowEdit = "/News/Home/ShowEditMsg";
            @ViewBag.DoDel = "/News/Home/DoDelMsg";
            return View();
        }
        #region 添加/编辑/删除消息
        /// <summary>
        /// 添加公告的前台展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddMsg()
        {
            ViewBag.backAction = "DoAddMsg";
            ViewBag.SubDateTime = DateTime.Now;
            return View("ShowEditMsg");
        }

        /// <summary>
        /// 添加公告的功能实现
        /// </summary>
        /// <returns></returns>
        public ActionResult DoAddMsg(N_News model)
        {
            model.UID = base.LoginUser.ID;
            model.isDel = false;
            model.SubDateTime = DateTime.Now;
            try
            {
                newsBLL.Create(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 编辑公告的前台展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditMsg()
        {

            //1. 得到前台返回的消息id
            int id = int.Parse(Request["id"]);
            //2. 得到消息对象
            var model = newsBLL.GetListBy(p => p.SNID == id).FirstOrDefault();
            ViewBag.SNID = model.SNID;
            ViewBag.NewsTitle = model.Title;
            ViewBag.NewsType = model.NewsType;
            ViewBag.NewsContent = model.NewsContent;
            ViewBag.SubDateTime = model.SubDateTime;
            ViewBag.backAction = "DoEditMsg";
            return View();
        }
        /// <summary>
        /// 编辑公告的功能实现
        /// </summary>
        /// <returns></returns>
        public ActionResult DoEditMsg(N_News model)
        {
            model.isDel = false;
            model.SubDateTime = DateTime.Now;
            model.UID = base.LoginUser.ID;
            try
            {
                newsBLL.Update(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        /// <summary>
        /// 软删除公告
        /// </summary>
        /// <returns></returns>
        public ActionResult DoDelMsg(string ids)
        {
            string[] strIds = ids.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            string state = newsBLL.DelSoftNews(list) == true? state="ok":state = "error";
            return Content(state);
        }

        /// <summary>
        /// 获取公告种类：不查数据库（可不写此方法）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNewsType()
        {
            //从字典中取出
            return Content("");
        }

        #endregion
        public ActionResult GetAllNewsList()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int count = 0;
            //根据登录用户查询其接收到的全部消息
            var list = newsBLL.GetAllNewsPageListByUser(this.LoginUser.ID,ref count, true,pageIndex, pageSize);
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = count,
                rows = list,
                footer = null
            };
            //序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public ActionResult GetNewsByTypeList(int type)
        {

           //获取登录用户可以查看的全部新消息
           var list= newsBLL.GetTargetTypeNewsPageListByUser(this.LoginUser.ID,1,true,type,5);

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