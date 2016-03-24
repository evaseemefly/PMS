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

        public ActionResult Index()
        {
            return View();
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
        public ActionResult GetOption()
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
            return Content(Common.SerializerHelper.SerializerToString(list_option));
        }

        
    }
}