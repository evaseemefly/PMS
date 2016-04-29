using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using Common;
using Common.EasyUIFormat;
using PMS.Model.EqualCompare;

namespace SMSOA.Areas.SMS.Controllers
{
    public class SendController : Controller
    {
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        //IUserInfoBLL userInfoBLL { get; set; }
        // GET: SMS/Send
        public ActionResult Index()
        {
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/Send/GetGroupByMID";
            ViewBag.GetDepartment_combotree = "/SMS/Send/GetDepartmentInfo4ComboTree";
            ViewBag.GetPersonByMission = "/SMS/Send/GetPersonByMission";
            return View();
        }
        public ActionResult GetPersonByMission(int mid)
        {
            //1 根据mid获取指定任务对象
            var mission = smsMissionBLL.GetListBy(s => s.SMID == mid).FirstOrDefault();
            //2 根据短信任务查找对应的群组
            var group = mission.R_Group_Mission.ToList();
            //2.1 创建该任务所拥有的群组对象集合
            List<P_Group> list_group = new List<P_Group>();
            //2.2 添加至群组对象集合中
            group.ForEach(g => list_group.Add(g.P_Group));
            //2.3 根据群组对象集合获取该群组集合中所共有的联系人
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            //3 根据短信任务查找对应的部门
            var department = mission.R_Department_Mission.ToList();
            //3.1 创建该任务所拥有的部门对象集合
            List<P_DepartmentInfo> list_department = new List<P_DepartmentInfo>();
            //3.2 添加至部门对象集合中
            department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));

            //4 将联系人集合去重
            list_person= list_person.Distinct(new P_PersonEqualCompare()).ToList();

            return Content(Common.SerializerHelper.SerializerToString(list_person));
        }

        public ActionResult GetGroupByMID(int mid)
        {
            //1获取传入的任务id
            //1.1根据任务id查找对应的任务对象并查找对应的群组集合
            List<PMS.Model.P_Group> list_owned_group = new List<PMS.Model.P_Group>();
           
            //根据短信任务查找短信任务所拥有的群组（在R_Group_Mission表中），并只拿取isPass为true的所对应的群组
            smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault().R_Group_Mission.Where(r=>r.isPass==true).ToList().ForEach(r=>list_owned_group.Add(r.P_Group));

            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, true);
            //2 从所有的群组中删除该任务所拥有的群组集合
            var list_excludeOwned_group = groupBLL.GetListBy(g => g.isDel == false).ToList().Where(g => !list_owned_group.Contains(g)).ToList();
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

        public ActionResult GetDepartmentInfo4ComboTree(int mid)
        {
            //根据短信任务找到与该任务对应的所属部门
           var mission= smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            List<int> list_id = new List<int>();
            mission.R_Department_Mission.ToList().ForEach(r => list_id.Add(r.DepartmentID));
           var list_alldepartment= departmentBLL.GetListBy(d => d.isDel == false).ToList();
            List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, list_id.ToArray());

            var temp= Common.SerializerHelper.SerializerToString(list_combotree);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
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