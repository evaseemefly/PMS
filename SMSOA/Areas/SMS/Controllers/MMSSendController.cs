using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.ViewModel;
using PMS.IBLL;
using Common.EasyUIFormat;

namespace SMSOA.Areas.SMS.Controllers
{
    public class MMSSendController : Admin.Controllers.BaseController
    {
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IUserInfoBLL userBLL { get; set; }
        public override ViewModel_MyHttpContext GetHttpContext()
        {
            throw new NotImplementedException();
        }

        // GET: SMS/MMSSend
        public ActionResult Index()
        {
            //定义Razor标签
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetMissionByUID = "/SMS/Send/GetMissionByUID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/MMSSend/GetGroupByMID";
            ViewBag.GetDepartment_combotree = "/SMS/Send/GetDepartmentInfo4ComboTree";
            ViewBag.GetPersonByMission = "/SMS/Send/GetPersonByMission";
            ViewBag.GetPersonByGroupDepartment = "/SMS/Send/GetPersonByGroupDepartment";
            ViewBag.DoSend = "/SMS/Send/DoSend";
            ViewBag.GetTemplateByUidAndMission = "/SMS/MsgTemplate/GetTemplateByUserIdAndMission";
            //注意不在此处传获取任务的方法
            ViewBag.ShowSetOftenMissionAndGroup = "/SMS/Send/ShowSetWindow";
            ViewBag.LoginUser = -999;
            //若父控制器中的登录用户不为空
            if (base.LoginUser != null)
            {
                //获取登录用户的id
                ViewBag.LoginUserID = base.LoginUser.ID;
            }
            return View();
        }

        public ActionResult GetGroupByMID(int mid)
        {
            int userId = int.Parse(Request["uid"]);
           // int mid = int.Parse(Request["mid"]);
            var mission = smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            //1.根据任务ID获取彩信群组的ID集合
            var list_MMS_group = smsMissionBLL.GetMMSGroups(true, mission);
            list_MMS_group = list_MMS_group.Select(m => m.ToMiddleModel()).ToList();
            var list_MMS_group_ids = list_MMS_group.Select(m => m.GID).ToList();

            //1.1 转换为easyUI的格式
            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_MMS_group, true);
            //var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, false);
            //2 从所有的群组中删除该任务所拥有的群组集合
            //2.1 获取当前用户所拥有的常用群组(通过User查询对应的Group）
            var list_excludeOwned_group = userBLL.GetRestGroupListByIds(list_MMS_group_ids, userId, true);
            //var list_excludeOwned_group = groupBLL.GetListBy(g => g.isDel == false).ToList().Where(g => !list_owned_group.Contains(g)).Select(g=>g.ToMiddleModel()).ToList();
            list.AddRange(ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_excludeOwned_group, false));
            //将该任务拥有的群组设置为选中状态
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }
    }
}