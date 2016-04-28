using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using Common;
using Common.EasyUIFormat;

namespace SMSOA.Areas.SMS.Controllers
{
    public class SendController : Controller
    {
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        //IUserInfoBLL userInfoBLL { get; set; }
        // GET: SMS/Send
        public ActionResult Index()
        {
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/Send/GetGroupByMID";
            return View();
        }

        public ActionResult GetGroupByMID(int mid)
        {
            //1获取传入的任务id
            //1.1根据任务id查找对应的任务对象并查找对应的群组集合
            List<PMS.Model.P_Group> list_owned_group = new List<PMS.Model.P_Group>();
           var list= ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, true);
            smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault().R_Group_Mission.ToList().ForEach(r=>list_owned_group.Add(r.P_Group));

            //2 从所有的群组中删除该任务所拥有的群组集合
            var list_excludeOwned_group = groupBLL.GetListBy(g => g.isDel == false).ToList().Where(g => list_owned_group.Contains(g)).ToList();
            list.AddRange(ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_excludeOwned_group, false));
            //将该任务拥有的群组设置为选中状态
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            return Content(Common.SerializerHelper.SerializerToString(model));
        }

        public ActionResult GetAllMissionByPID()
        {
            //int userId=3;
            //userInfoBLL.GetListBy(p=>p.ID==userId).FirstOrDefault().R_UserInfo_SMSMission.
            //获取全部的短信种类集合
            var list_allmission= smsMissionBLL.GetAllList();
            
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list_allmission,
                footer = null
            };
            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(model));
        }
    }
}