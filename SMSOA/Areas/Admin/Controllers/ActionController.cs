using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;

namespace SMSOA.Areas.Admin.Controllers
{
    public class ActionController : Controller
    {
        IActionInfoBLL actionInfoBLL { get; set; }

        public ActionResult Create(ActionInfo model)
        {
            model.Url = "1";
            model.DelFlag = false;
            model.SubTime = DateTime.Now;
            model.ModifiedOnTime = DateTime.Now;
            actionInfoBLL.Create(model);
            return Content("ok");
        }


        public ActionResult Test()
        {
            //若有传入的id
            int id = int.Parse(Request["id"]);
                //找到指定id的action对象
                var model = actionInfoBLL.GetListBy(a => a.ID == id);
                //为分布式图中的下拉框添加要请求的地址
                ViewBag.Url = "/Admin/Action/GetOption";
                //return PartialView("EditActionWindow");
                return View();
        
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据传入的id生成编辑窗体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditActionInfo(int id)
        {
            //若有传入的id
            //int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id!=null)
            {
                //找到指定id的action对象
               var model=  actionInfoBLL.GetListBy(a => a.ID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 
                //为分布式图中的下拉框添加要请求的地址
                ViewBag.data = GetOption();
                //将指定id的action对象传给视图数据字典中的实体
                ViewData.Model = model;
                //return PartialView("EditActionWindow");
                return View();
            }
            return Content("no");
           
        }

        // GET: Admin/Action
        /// <summary>
        /// 获取权限集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetActionInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //查询所有的权限
            var list_action = actionInfoBLL.GetPageList(pageIndex, pageSize, a => a.DelFlag == false, a => a.Sort,true).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_action,
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        /// <summary>
        /// 获取权限下拉菜单中的每一个项
        /// </summary>
        /// <returns></returns>
        public string GetOption()
        {
            //查询所有的权限
            var list_action = actionInfoBLL.GetListBy( a => a.DelFlag == false).ToList();

            //将权限集合遍历，创建Option集合
            var list_option = (from a in list_action
                               select new PMS.Model.EasyUIModel.EasyUIOption()
                               {
                                   id = a.ID,
                                   text = a.ActionInfoName
                               }).ToList();
            //将Option集合序列化
            return Common.SerializerHelper.SerializerToString(list_option);
        }

        /// <summary>
        /// 执行软删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelSoftActionInfos()
        {
            //获取请求的id 字符串
            string strId = Request["strId"];
            //将字符串数组
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            //删除状态
            string state = actionInfoBLL.DelSoftActionInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        /// <summary>
        /// 执行逻辑删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelLogicActionInfos()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            string state =
            actionInfoBLL.DeleteLogicActionInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }



    }
}