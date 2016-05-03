using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;

namespace SMSOA.Areas.SMS.Controllers
{
    /// <summary>
    /// 短信模板
    /// </summary>
    public class MsgTemplateController : Controller
    {
       IS_SMSMsgContentBLL smsMsgContentBLL { get; set; }

        // GET: SMS/MsgTemplate
        public ActionResult Index()
        {
            ViewBag.GetInfo = "/SMS/MsgTemplate/GetAllMsgContent";
            
            ViewBag.ShowAdd = "/SMS/MsgTemplate/ShowAddTemplate";
            //ViewBag.ShowEdit = "/Admin/Action/ShowEditActionInfo";
            //ViewBag.GetInfo = "/Admin/Action/GetActionInfo";
            return View();
        }

        public ActionResult ShowAddTemplate()
        {
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            return View("ShowEditInfo");
        }

        /// <summary>
        /// 分页查询全部短信模板
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMsgContent()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            //1 查询全部的短信内容模板，并根据sort进行排序
            var list_allMsgContent = smsMsgContentBLL.GetPageList(pageIndex,pageSize,ref rowCount,m => m.isDel == false,m=>m.Sort,true).ToList().Select(m => m.ToMiddleModel()).ToList();
            //2 转成easyui DataGrid
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_allMsgContent,
                footer = null
            };
            //3 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }
    }
}