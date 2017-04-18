using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using Common.EasyUIFormat;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.SMS.Controllers
{
    /// <summary>
    /// 短信模板
    /// </summary>
    public class MsgTemplateController : Admin.Controllers.BaseController
    {
       IS_SMSMsgContentBLL smsMsgContentBLL { get; set; }

        IS_SMSMissionBLL smsMissionBLL { get; set; }
        // GET: SMS/MsgTemplate
        public ActionResult Index()
        {
            ViewBag.GetInfo = "/SMS/MsgTemplate/GetAllMsgContent";
            
            ViewBag.ShowAdd = "/SMS/MsgTemplate/ShowAddTemplate";
            ViewBag.ShowEdit= "/SMS/MsgTemplate/ShowEditTemplate";
            ViewBag.Del_url = "/SMS/MsgTemplate/DoDelTemplate";
            //ViewBag.ShowEdit = "/Admin/Action/ShowEditActionInfo";
            //ViewBag.GetInfo = "/Admin/Action/GetActionInfo";
            return View();
        }



        public ActionResult ShowEditTemplate(int id)
        {
            //int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id != 0)
            {
                //1 找到指定id的action对象
                var model = smsMsgContentBLL.GetListBy(t => t.TID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 
                ViewBag.LoginUserID = -999;
                //若父控制器中的登录用户不为空
                if (base.LoginUser != null)
                {
                    //获取登录用户的id
                    ViewBag.LoginUserID = base.LoginUser.ID;
                }
                ViewBag.TID = model.TID;
                ViewBag.GetAllMission_combogrid = "/SMS/MsgTemplate/GetMissionByUser";
                ViewBag.MsgName = model.MsgName;
                ViewBag.SMID = model.SMID;
                ViewBag.MsgContent = model.MsgContent;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = "/SMS/MsgTemplate/DoEditTemplate";
                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View();
            }
            return Content("no");
        }

        public ActionResult ShowAddTemplate()
        {
            ViewBag.LoginUserID = -999;
            //若父控制器中的登录用户不为空
            if (base.LoginUser != null)
            {
                //获取登录用户的id
                ViewBag.LoginUserID = base.LoginUser.ID;
            }
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetMissionByUserUnChecked";
            ViewBag.backAction_jqSub = "/SMS/MsgTemplate/DoAddTemplate";
            return View("ShowEditTemplate");
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
           
            
            var userId = base.LoginUser.ID;
            //1 查询全部的短信内容模板，并根据sort进行排序
            var list_allMsgContent = smsMsgContentBLL.GetPageList(pageIndex, pageSize, ref rowCount, m => m.isDel == false&&m.UID==userId, m => m.Sort, true).ToList().Select(m => m.ToMiddleModel()).ToList();

            //1.1 排序，按照创建时间 17年4月18日修改 By QuYuan
            #region 以下几种方法均可使用，有待研究效率
            //1.1.1 第一种排序，按照与当前时间的差值
            var list_allMsgContent_SortBySubTime =  list_allMsgContent.OrderBy(x =>DateTime.Now.Subtract(new DateTime(x.SubTime.Year, x.SubTime.Month, x.SubTime.Day,x.SubTime.Hour,x.SubTime.Minute,x.SubTime.Second)).TotalSeconds).ToList();

            //1.1.2 第二种排序，使用间隔数
            //Date.SubTime.Ticks单位是 100 毫微秒。表示自 0001 年 1 月 1 日午夜 12:00:00 以来已经过的时间的以 100 毫微秒为间隔的间隔数
            //list_allMsgContent.OrderBy(p => p.SubTime.Ticks);
            //list_allMsgContent.OrderBy(p => p.SubTime.ToFileTime);

            //1.1.3 第三种排序，按照年月日依次排序
            //list_allMsgContent.OrderByDescending(p => p.SubTime.Year).ThenByDescending(p => p.SubTime.Month).ThenByDescending(p => p.SubTime.Day).ThenByDescending(p => p.SubTime.Hour).ThenByDescending(p => p.SubTime.Month).ThenByDescending(p => p.SubTime.Second);
            #endregion


            //2 转成easyui DataGrid
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_allMsgContent_SortBySubTime,
                footer = null
            };
            //3 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public ActionResult DoAddTemplate(S_SMSMsgContent templateModel)
        {
                //获取登录用户的id
            var userID = base.LoginUser.ID;
            //数据验证：是否存在同名的模板
            if (smsMsgContentBLL.AddValidation(userID, templateModel.SMID)) { return Content("validation fails"); }
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            templateModel.isDel = false;
            templateModel.SubTime = DateTime.Now;
            
            //departmentModel.ModifiedOnTime = DateTime.Now;
            
            try
            {
                smsMsgContentBLL.Create(templateModel);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        public ActionResult DoEditTemplate(S_SMSMsgContent templateModel)
        {
            var userID = base.LoginUser.ID;
            //数据验证：是否存在同名的模板
            if (smsMsgContentBLL.EditValidation(userID, templateModel.SMID, templateModel.TID)) { return Content("validation fails"); }
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            templateModel.isDel = false;
           
            templateModel.SubTime = DateTime.Now;
            try
            {
                smsMsgContentBLL.Update(templateModel);
                return Content("ok");
            }
            catch(Exception ex)
            {
                return Content("error");
            }
        }

        public ActionResult DoDelTemplate(S_SMSMsgContent templateModel)
        {
            string ids=Request.QueryString["ids"];
            //获取传过来的要批量删除的id数组
            var list_tid= ids.Split(',').Select(t=>int.Parse(t)).ToList();
            //8月24日：
            //删除模板时采用物理删除
            //var state = smsMsgContentBLL.DelSoftTemplate(list_tid);
            var state = smsMsgContentBLL.PhysicsDel(list_tid);
            return Content(state == true ? "ok" : "error");
        }

        public ActionResult GetTemplateByUserIdAndMission(int userId,int SMId)
        {

            //8月31日修改
            //删选条件改为根据用户id以及短信任务id获取未被删除的第一个模板
            var templateModel= smsMsgContentBLL.GetListBy(t => t.UID == userId && t.SMID == SMId&&t.isDel==false).FirstOrDefault();
            if(templateModel!=null)
            {
               return Content(templateModel.MsgContent);
            }
            else
            {
                return Content("");
            }
            
        }

        protected string GetMissionByUser(int userId,int tid, bool isChecked)
        {

            //1 获取当前短信模板中SMID对应的短信群组类型           
            var list_owned_mission=smsMsgContentBLL.GetListBy(c => c.UID == userId && c.TID == tid).Select(c => c.S_SMSMission).ToList();
            var missionIdsbyUser = list_owned_mission.Select(m => m.SMID).ToList();
            //2 获取剩余的未拥有的全部短信任务
            var list_Ext_mission = smsMissionBLL.GetMissionExt(missionIdsbyUser,false);
            var list = ToEasyUICombogrid_Mission.ToEasyUIDataGrid(list_owned_mission, isChecked);
            //2 从所有的群组中删除该任务所拥有的群组集合
            var list_excludeOwned_group = ToEasyUICombogrid_Mission.ToEasyUIDataGrid(list_Ext_mission, false);
            list.AddRange(list_excludeOwned_group);
            //将该任务拥有的群组设置为选中状态
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            return temp = temp.Replace("Checked", "checked");

        }

        /// <summary>
        /// 根据传入的用户id查询全部的短信任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult GetMissionByUser()
        {
            int userId = int.Parse(Request["userId"]);
            int tid = int.Parse(Request["tid"]);
            var temp = GetMissionByUser(userId, tid, true);
            return Content(temp);
        }

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            var httpModel = new ViewModel_MyHttpContext()
            {
                Area = "SMS",
                Controller = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString(),
                Action = RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString(),
                Url = Request.Url.ToString()
            };
            return httpModel;
        }
    }
}