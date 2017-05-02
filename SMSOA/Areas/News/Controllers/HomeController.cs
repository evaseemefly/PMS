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
        IUserInfoBLL userBLL;
        // GET: News/News
        
        public ActionResult Index()
        {
            ViewBag.GetAllNewsList = "GetNewsByTypeList";
            ViewBag.RecentAllNews = "GetRecentAllNews";
            ViewBag.RecentUnReadNew = "GetRecentUnReadNews";
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
            ViewBag.UID = base.LoginUser.ID;
            ViewBag.NID = news.SNID;
            ViewBag.IsReadUrl = "IsRead";
            //ViewData["news"] = news;
            //ViewData.Model = news;
            return View();
        }

        /// <summary>
        /// 已阅
        /// </summary>
        /// <returns></returns>
        public ActionResult IsRead()
        {
            //获取传入的用户id以及消息id
            int uid = int.Parse(Request["uid"]);
            int nid  = int.Parse(Request["nid"]);
            //将该用户的打开的当前消息设置为已阅
            //修改R_UserInfo_News表中的isCheck字段
            //已封装至NewsBLL层中
            return newsBLL.IsRead(uid, nid) == true ? Content("ok") : Content("error");

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
        [ValidateInput(false)]
        public ActionResult DoAddMsg(N_News model)
        {
            model.UID = base.LoginUser.ID;
            model.isDel = false;
            model.SubDateTime = DateTime.Now;
            //model.NewsContent = Server.HtmlEncode(model.NewsContent);
            try
            {
                //8月12日修改：此处不仅需要在N_News中添加一个消息对象，还需要添加该消息与全部用户之前的关系
                //1 查询所有用户
               var users= userBLL.GetListBy(u => u.DelFlag == false).Select(u => u.ID);
                //2 遍历用户数组，并添加要创建的news与user的关系
                foreach (var item in users)
                {
                    R_UserInfo_News r_user_news = new R_UserInfo_News()
                    {
                        NID = model.SNID,
                        UID = item
                    };
                    model.R_UserInfo_News.Add(r_user_news);
                }
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

        [ValidateInput(false)]
        public ActionResult DoEditMsg(N_News model)
        {
            model.isDel = false;
            model.SubDateTime = DateTime.Now;
            model.UID = base.LoginUser.ID;
            model.NewsContent = model.NewsContent;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">1 全部消息 2 最近（5条）未读消息（不分种类） 3 最近（5条）消息</param>
        /// <returns></returns>
        private ActionResult BaseGetNewsList(int type)
        {
            int pageSize = 0;
            int pageIndex = 0;
            if (Request.Form["rows"]==null|| Request.Form["page"] == null)
            {
                
            }
            else
            {
            pageSize = int.Parse(Request.Form["rows"]);
            pageIndex = int.Parse(Request.Form["page"]);
            }

            int count = 0;
            //根据登录用户查询其接收到的全部消息
            var list = GetAllKindsOfNewsFactory(type, ref count, pageIndex, pageSize);
            //list.ForEach(p => p.NewsContent = Server.HtmlDecode(p.NewsContent));
            list = list.Where(p => p.isDel == false).ToList();
            //var list = newsBLL.GetAllNewsPageListByUser(this.LoginUser.ID, ref count, true, pageIndex, pageSize);
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = count,
                rows = list,
                footer = null
            };
            //序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

       

        public List<N_News> GetAllKindsOfNewsFactory(int type,ref int count,int pageIndex,int pageSize)
        {
            List<N_News> list_news = new List<N_News>();
            switch (type)
            {
                //获取该用户的全部消息
                case 1:
                    list_news= newsBLL.GetAllNewsPageListByUser(this.LoginUser.ID, ref count, true, pageIndex, pageSize);
                    break;
                //获取当前登录用户的最近（5条）未读消息（不分种类）
                case 2:
                    list_news = newsBLL.GetRecentUnReadNewsPageListByUser(this.LoginUser.ID,  true);
                    break;
                //获取当前登录用户的最近（5条）消息
                case 3:
                    list_news = newsBLL.GetRecentAllNewsPageListByUser(this.LoginUser.ID, true);
                    break;
                default:
                    break;
            }
            return list_news;

        }

        public ActionResult GetAllNewsList()
        {
            #region 已抽象
            //int pageSize = int.Parse(Request.Form["rows"]);
            //int pageIndex = int.Parse(Request.Form["page"]);
            //int count = 0;
            ////根据登录用户查询其接收到的全部消息
            //var list = newsBLL.GetAllNewsPageListByUser(this.LoginUser.ID,ref count, true,pageIndex, pageSize);
            //PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            //{
            //    total = count,
            //    rows = list,
            //    footer = null
            //};
            ////序列化
            //return Content(Common.SerializerHelper.SerializerToString(dgModel));
            #endregion
           return BaseGetNewsList(1);
        }

        public ActionResult GetAllUnReadNewsList()
        {
            return BaseGetNewsList(4);
        }

        public ActionResult GetRecentUnReadNews()
        {
            return BaseGetNewsList(2);
        }

        public ActionResult GetRecentAllNews()
        {
            return BaseGetNewsList(3);
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