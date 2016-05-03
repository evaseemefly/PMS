using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;
using SMSOA.Areas.Contacts.Models;

namespace SMSOA.Areas.Contacts.Controllers
{
    public class SMSMissionController : Controller
    {
        /*
        在BLL层创建S_SMSMissionBLL的拓展类
        实现：（1）创建根据id集合查询的方法
              （2）根据id软删除方法
        注：方法命名规范参照别的拓展类
        */
        //通过 spring.net 创建IS_SMSMissionBLL

        IS_SMSMissionBLL smsmissionBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        #region 1 共用属性
        /// <summary>
        /// 执行删除操作的url地址
        /// </summary>
        private string del_url
        {
            get
            { return "/Contacts/SMSMission/DelSoftSMSMissionInfos"; }
        }

        /// <summary>
        /// 执行展示修改操作的url地址
        /// </summary>
        private string showEdit_url
        {
            get
            {
                return "/Contacts/SMSMission/ShowEditSMSMissionInfo";
            }
        }

        /// <summary>
        /// 执行展示添加操作的url地址
        /// </summary>
        private string showAdd_url
        {
            get
            {
                return "/Contacts/SMSMission/ShowAddSMSMissionInfo";
            }
        }

        /// <summary>
        /// 执行查询全部部门信息操作的url地址
        /// </summary>
        private string getInfo_url
        {
            get
            { return "/Contacts/SMSMission/GetSMSMissionInfo"; }
        }

        /// <summary>
        /// 执行获取联系人操作的url地址
        /// </summary>
        private string getPerson_url
        {
            get
            { return "/Contacts/SMSMission/GetPersons2Datagrid"; }
        }


        /// <summary>
        /// 回调函数——执行添加url地址
        /// </summary>
        private string backDoAdd_url
        {
            get
            {
                return "/Contacts/SMSMission/DoAddSMSMissionInfo";
            }
        }

        ///<sumarry>
        ///获取相应部门的url地址
        ///</sumarry>
        private string getDepartment_url
        {
            get
            {
                return "/Contacts/SMSMission/GetDepartment2Treegrid";
            }
        }

        ///<sumarry>
        ///获取相应集合的url地址
        ///</sumarry>
        private string getGroup_url
        {
            get
            {
                return "/Contacts/SMSMission/GetGroup2Datagrid";
            }
        }

        ///<summary>
        ///为当前选中任务分配群组的url地址
        ///</summary>
        ///<returns></returns>
        private string doAssignGroup2SMSMission_url
        {
            get
            {
                return "/Contacts/SMSMission/DoAssignGroup2SMSMission";
            }
        }

        /// <summary>
        /// 回调函数——执行修改url地址
        /// </summary>
        private string backDoEdit_url
        {
            get
            {
                return "/Contacts/SMSMission/DoEditSMSMissionInfo";
            }
        }
        #endregion

        #region 2 返回视图的方法
        /// <summary>
        /// 以datagrid的方式创建SMSMission视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Del_url = del_url;
            ViewBag.ShowEdit = showEdit_url;
            ViewBag.ShowAdd = showAdd_url;
            ViewBag.GetInfo = getInfo_url;
            ViewBag.GetGroup_datagrid = getGroup_url;
            ViewBag.GetDepartment_treegrid = getDepartment_url;
            ViewBag.GetPerson = getPerson_url;
            ViewBag.DoAssignGroup2SMSMission = doAssignGroup2SMSMission_url;
            return View();
        }

        /// <summary>
        /// 显示修改界面（返回的视图可以与添加界面的视图相同）
        /// 可以显示修改时间以及创建时间但不可修改（若为了与添加共用视图可以不显示这两个时间）
        /// 显示isMMS标记
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditSMSMissionInfo()
        {
            int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id != 0)
            {
                //1 找到指定id的action对象
                var model = smsmissionBLL.GetListBy(g => g.SMID == id).FirstOrDefault();

                ViewBag.Name = model.SMSMissionName;
                ViewBag.Remark = model.Remark;
                ViewBag.ModifiedOnTime = model.ModifiedOnTime;
                ViewBag.SubTime = model.SubTime;
                ViewBag.SMID = model.SMID;
                ViewBag.isMMS = model.isMMS;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = backDoEdit_url;

                return View("ShowAddSMSMissionInfo");
            }
            return Content("no");
        }

        /// <summary>
        /// 显示添加界面（返回的视图可以与修改界面的视图相同）
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddSMSMissionInfo()
        {
            ViewBag.backAction_jqSub = backDoAdd_url;
            return View();
        }

        #endregion

        #region 3 执行提交的操作返回Content的方法
        /// <summary>
        /// 获取全部以datagrid的方式创建SMSMission视图数据（以分页的方式查询）
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSMSMissionInfo()
        {

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_smsission = smsmissionBLL.GetListBy(p => p.isDel == false, p => p.SMSMissionName).ToList();


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(list_smsission));
        }

        /// <summary>
        /// 执行添加操作
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public ActionResult DoAddSMSMissionInfo(S_SMSMission mission)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            mission.isDel = false;
            mission.isMMS = false;
            mission.SubTime = DateTime.Now;
            mission.ModifiedOnTime = DateTime.Now;
            try
            {
                smsmissionBLL.Create(mission);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 执行修改操作
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public ActionResult DoEditSMSMissionInfo(S_SMSMission mission)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            mission.isDel = false;
            mission.isMMS = false;
            mission.ModifiedOnTime = DateTime.Now;

            try
            {
                smsmissionBLL.Update(mission);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        ///<summary>
        ///通过短信任务得到联系人,并转换为Datagrid
        ///</summary>
        ///<returns></returns>
        public ActionResult GetPersons2Datagrid()
        {
            //1.获取所选的短信任务实体
                int pageSize = int.Parse(Request.Form["rows"]);
                int pageIndex = int.Parse(Request.Form["page"]);

                int rowCount = 0;
                int smid = int.Parse(Request["smid"]);
                var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();
                //2.根据路线2得到isPass为true群组集合
                bool isPass = true;
                var list_group = GetGroups(isPass, SMSMission);
                List<P_PersonInfo> list_personFromGroup = new List<P_PersonInfo>();
                list_group.ForEach(g => list_personFromGroup.AddRange(g.P_PersonInfo.ToList()));
                //3 根据路线一查询  SMSMission对应的部门，并得到部门中包含的联系人
                //取出isPass为true的所有集合
                var list_department = GetDepartmemts(isPass, SMSMission);
                List<P_PersonInfo> list_personFromDep = new List<P_PersonInfo>();
                list_department.ForEach(g => list_personFromDep.AddRange(g.P_PersonInfo.ToList()));

                //4 将路线一与路线二取出的Person集合合并
                list_personFromGroup.AddRange(list_personFromDep);
                //5 此时的集合中可能存在重复，去重
                list_personFromGroup = list_personFromGroup.Distinct(new PMS.Model.EqualCompare.P_PersonInfoEqualCompare()).ToList();

                //6 取出组群中isPass为false的集合
                isPass = false;
                var list_group_isNotPass = GetGroups(isPass, SMSMission);
                List<P_PersonInfo> list_personFromGroup_isNotPass = new List<P_PersonInfo>();
                list_group_isNotPass.ForEach(g => list_personFromGroup_isNotPass.AddRange(g.P_PersonInfo.ToList()));

                //7 将现有集合中去掉isPass为false的ActionInfo
                list_personFromGroup = list_personFromGroup.Where(a => !list_personFromGroup_isNotPass.Contains(a)).ToList();

                //8 取出组织机构中isPass为false的集合
                var list_department_isNotPass = GetDepartmemts(isPass, SMSMission);
                List<P_PersonInfo> list_personFromDep_isNotPass = new List<P_PersonInfo>();
                list_department_isNotPass.ForEach(g => list_personFromDep_isNotPass.AddRange(g.P_PersonInfo.ToList()));


                //9 将现有集合中去掉isPass为false,isDel为true的
                list_personFromGroup = list_personFromGroup.Where(a => !list_personFromDep_isNotPass.Contains(a)).ToList();
                list_personFromGroup = list_personFromGroup.Where(a => a.isDel == false).ToList();
                //10 分页
                list_personFromGroup = list_personFromGroup.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();


                PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
                {
                    total = rowCount,
                    rows = list_personFromGroup,
                    footer = null
                };
                return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }
        ///<summary>
        ///得到选中任务所包含的群组,并转换为Combogrid
        ///</summary>
        ///<returns></returns>
        //public ActionResult GetGroup2Combogrid()
        //{
        //    int smid = int.Parse(Request["smid"]);
        //    var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

        //    //1.获取当前任务已有的群组(未禁用)
        //    bool isPass = true;
        //    var list_group = GetGroups(isPass, SMSMission);
        //    //2.获取当前任务已有的群组(已禁用)
        //    var list_group_isNotPass = GetGroups(isPass = false, SMSMission);
        //    //var list_groupbySmid = groupBLL.GetListBy(p => p.isDel == false && p.R_Group_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.GroupName).ToList();
            
        //    //2.获取所有的群组
        //    var list_ALLGroup = groupBLL.GetListBy(p => p.isDel == false).ToList();
        //    List<EasyUICombogrid_Group> list_EasyUICombogrid_Group = new List<EasyUICombogrid_Group>();
        //    //3.将已有的群组从所有群组中剔除，已拥有的群组（未禁用）排在前面
        //    foreach (var item in list_group)
        //    {
                
        //        EasyUICombogrid_Group combogrid_Group = new EasyUICombogrid_Group()
        //        {
        //            selected = true,
        //            Checked = true,
        //            GID = item.GID,
        //            GroupName = item.GroupName,
        //            Remark = item.Remark,
        //            IsPass = true,
        //            Text = "启用"
        //        };
        //        list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
        //        list_EasyUICombogrid_Group.Add(combogrid_Group);
        //    }
        //    //4.将已有的群组从所有群组中剔除，已拥有的群组（已禁用）排在前面
        //    foreach (var item in list_group_isNotPass)
        //    {
                
        //        EasyUICombogrid_Group combogrid_Group = new EasyUICombogrid_Group()
        //        {
        //            selected = true,
        //            Checked = true,
        //            GID = item.GID,
        //            GroupName = item.GroupName,
        //            Remark = item.Remark
        //        };
        //        list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
        //        list_EasyUICombogrid_Group.Add(combogrid_Group);
        //    }
        //    //5.未拥有的群组
        //    foreach (var item in list_ALLGroup)
        //    {
        //        EasyUICombogrid_Group combogrid_Group = new EasyUICombogrid_Group()
        //        {
        //            GID = item.GID,
        //            GroupName = item.GroupName,
        //            Remark = item.Remark,
        //            IsPass = true,
        //            Text = "启用"
        //        };
        //        list_EasyUICombogrid_Group.Add(combogrid_Group);
        //    }
        //    //6.序列化

        //    string temp = Common.SerializerHelper.SerializerToString(list_EasyUICombogrid_Group);
        //    temp = temp.Replace("Checked", "checked");
        //    return Content(temp);

        //}


        public ActionResult GetGroup2Datagrid()
        {
            int smid = int.Parse(Request["smid"]);
            var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

            //1.获取当前任务已有的群组(未禁用)
            bool isPass = true;
            var list_group = GetGroups(isPass, SMSMission);
            //2.获取当前任务已有的群组(已禁用)
            var list_group_isNotPass = GetGroups(isPass = false, SMSMission);
            //var list_groupbySmid = groupBLL.GetListBy(p => p.isDel == false && p.R_Group_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.GroupName).ToList();

            //2.获取所有的群组
            var list_ALLGroup = groupBLL.GetListBy(p => p.isDel == false).ToList();
            List<EasyUIDataGrid_Group> list_EasyUIDatagrid_Group = new List<EasyUIDataGrid_Group>();
            //3.将已有的群组从所有群组中剔除，已拥有的群组（未禁用）排在前面
            foreach (var item in list_group)
            {

                EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
                {
                    selected = true,
                    Checked = true,
                    GID = item.GID,
                    GroupName = item.GroupName,
                    Remark = item.Remark,
                    IsPass = true,
                    Text = "启用"
                };
                list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
                list_EasyUIDatagrid_Group.Add(datagrid_Group);
            }
            //4.将已有的群组从所有群组中剔除，已拥有的群组（已禁用）排在前面
            foreach (var item in list_group_isNotPass)
            {

                EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
                {
                    selected = true,
                    Checked = true,
                    GID = item.GID,
                    GroupName = item.GroupName,
                    Remark = item.Remark
                };
                list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
                list_EasyUIDatagrid_Group.Add(datagrid_Group);
            }
            //5.未拥有的群组
            foreach (var item in list_ALLGroup)
            {
                EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
                {
                    GID = item.GID,
                    GroupName = item.GroupName,
                    Remark = item.Remark,
                    IsPass = true,
                    Text = "启用"
                };
                list_EasyUIDatagrid_Group.Add(datagrid_Group);
            }
            //6.序列化

            string temp = Common.SerializerHelper.SerializerToString(list_EasyUIDatagrid_Group);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);

        }








        ///<summary>
        ///得到选中任务所包含的群组,并转换为Combogrid
        ///</summary>
        ///<returns></returns>
        public ActionResult GetDepartment2Treegrid()
        {
            int smid = int.Parse(Request["smid"]);
            var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

            //1.获取当前任务已有的部门(未禁用)
            bool isPass = true;
            var list_departments = GetDepartmemts(isPass, SMSMission);
            //2.获取当前任务已有的部门(已禁用)
            var list_department_isNotPass = GetDepartmemts(isPass = false, SMSMission);
            //var list_groupbySmid = groupBLL.GetListBy(p => p.isDel == false && p.R_Group_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.GroupName).ToList();

            //2.获取所有的部门
            var list_ALLDepartment = departmentBLL.GetListBy(p => p.isDel == false).ToList();
            List<EasyUITreeGrid_Department> list_EasyUITreeGrid_Department = new List<EasyUITreeGrid_Department>();

            //3.将已有的部门从所有部门中剔除，已拥有的部门（未禁用）排在前面
            foreach (var item in list_departments)
            {
                item.Checked = true;
                item.selected = true;
                item.IsPass = true;
                item.Text = "启用";
                list_ALLDepartment = list_ALLDepartment.Where(p => p.DID != item.DID).ToList();
            }
            //4.将已有的群组从所有群组中剔除，已拥有的群组（已禁用）排在前面
            foreach (var item in list_department_isNotPass)
            {
                item.Checked = true;
                item.selected = true;
                list_ALLDepartment = list_ALLDepartment.Where(p => p.DID != item.DID).ToList();
            }
            //5.未拥有的群组
            foreach (var item in list_ALLDepartment)
            {
                item.IsPass = true;
                item.Text = "启用";
            }

            list_departments.AddRange(list_department_isNotPass);
            list_departments.AddRange(list_ALLDepartment);
            List<Models.EasyUITreeGrid_Department> list_treegrid= Models.Department_ViewModel.ToEasyUITreeGrid(list_departments);
            string temp = Common.SerializerHelper.SerializerToString(list_treegrid);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }


        ///<summary>
        ///根据选中任务获得群组
        ///</summary>
        ///<returns></returns>
        public List<P_Group> GetGroups(bool isPass, S_SMSMission SMSMission)
        {
            if (SMSMission != null)
            {
                var list_R_Group_Mission = SMSMission.R_Group_Mission;
                var list_group = (
                   from r in list_R_Group_Mission
                   where r.isPass == isPass
                   select r.P_Group
                    ).ToList();
                return list_group;
            }
            return null;
          }
        ///<summary>
        ///根据选中任务获得部门
        ///</summary>
        ///<returns></returns>
        public List<P_DepartmentInfo> GetDepartmemts(bool isPass, S_SMSMission SMSMission)
        {
            if(SMSMission != null)
            {
            var list_R_Department_Mission = SMSMission.R_Department_Mission;
            var list_department = (
               from r in list_R_Department_Mission
               where r.isPass == isPass
               select r.P_DepartmentInfo
                ).ToList();
                return list_department;
            }
            return null;
        }



        ///<summary>
        ///为所选的任务分配群组
        ///</summary>
        ///<returns></returns>
        public ActionResult DoAssignGroup2SMSMission(Models.ViewModel_SMSMissionDepartmentGroup model)
        {
            bool isGroupOk = false;
            bool isDepartmentOk = false;
            if (model.SMSMissionID != null)
            {
                    //1.得到所选的任务
                    var smid = int.Parse(model.SMSMissionID);
                    //var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

                //2.分配群组
                if (model.groupIds == null)
                {   //2.1 当为没有选中任何群组时，移除当前任务拥有的所有群组
                    var g_result = this.smsmissionBLL.RemoveAllGroup(smid);
                    if (g_result)
                    {
                        isGroupOk = true;
                    }
                }
                else
                {
                    //2.2 分配群组操作
                    List<int> list_groupIDs = new List<int>();
                    string[] groupIDs = model.groupIds.Split(',');
                    List<bool> list_isPass = new List<bool>();
                    string[] g_isPasses = model.g_isPasses.Split(',');
                    //2.2.1修改禁用功能
                    foreach (var item in g_isPasses)
                    {
                        if (item.Equals("启用"))
                        {
                            list_isPass.Add(true);
                        }
                        else if (item.Equals("禁用"))
                        {
                            list_isPass.Add(false);
                        }
                    }
                    groupIDs.ToList().ForEach(a => list_groupIDs.Add(int.Parse(a)));
                    var g_result = this.smsmissionBLL.SetSMSMission4Group(smid, list_groupIDs, list_isPass);

                    if (g_result)
                    {
                        isGroupOk = true;
                    }
                }



                //3.分配部门
                if (model.departmentIds == null)
                {   //3.1 当为没有选中任何部门时，移除当前任务拥有的所有部门
                    var d_result = this.smsmissionBLL.RemoveAllDepartment(smid);
                    if (d_result)
                    {
                        isDepartmentOk = true;
                    }
                }
                else
                {
                    //3.2 分配部门操作
                    List<int> list_departmentIDs = new List<int>();
                    string[] departmentIDs = model.departmentIds.Split(',');
                    List<bool> list_disPass = new List<bool>();
                    string[] d_isPasses = model.d_isPasses.Split(',');
                    //3.2.1修改禁用功能  
                    foreach (var item in d_isPasses)
                    {
                        if (item.Equals("true"))
                        {
                            list_disPass.Add(true);
                        }
                        else if (item.Equals("false"))
                        {
                            list_disPass.Add(false);
                        }
                    }
                    departmentIDs.ToList().ForEach(a => list_departmentIDs.Add(int.Parse(a)));
                    var d_result = this.smsmissionBLL.SetSMSMission4Department(smid, list_departmentIDs, list_disPass);
                    if (d_result)
                    {
                        isDepartmentOk = true;
                    }
                    }
                }

            if (isGroupOk && isDepartmentOk)
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }

        }



        /// <summary>
        /// 执行软删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelSoftSMSMissionInfos(string ids)
        {
            //获取请求的id 字符串
            //string strId = Request["strId"];
            //将字符串数组
            string[] strIds = ids.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            //删除状态
            string state = smsmissionBLL.DelSoftRoleInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }
        #endregion





    }
}
