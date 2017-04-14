using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;
using SMSOA.Areas.Contacts.Models;
using SMSOA.Areas.Admin.Controllers;
using PMS.Model.EqualCompare;
using PMS.Model.ViewModel;


namespace SMSOA.Areas.Contacts.Controllers
{
    public class SMSMissionController : BaseController
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
            //ViewBag.Url_SearchPerson = getPerson_url;
            ViewBag.ShowMissionToolbar = base.CheckContactCommonToolBar() == true ? 1 : 0;
            ViewBag.ShowPersonToolbar = base.CheckPersonToolBar() == true ? 1 : 0;
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
               // ViewBag.ModifiedOnTime = model.ModifiedOnTime;
                ViewBag.SubTime = model.SubTime;
                ViewBag.Sort = model.Sort;
                ViewBag.SMID = model.SMID;
                ViewBag.isMMS = model.isMMS;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = backDoEdit_url;

                return View("ShowEditSMSMissionInfo");
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
            ViewBag.SubTime = DateTime.Now;
            return View("ShowEditSMSMissionInfo");
        }

        #endregion

        #region 3 执行提交的操作返回Content的方法
        /// <summary>
        /// 获取全部以datagrid的方式创建SMSMission视图数据（以分页的方式查询）
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSMSMissionInfo(PMS.Model.ViewModel.ViewModel_Mission_QueryInfo queryModel)
        {

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_smsission = smsmissionBLL.GetListBy(p => p.isDel == false, p => p.SMSMissionName).ToList().Select(m=>m.ToMiddleModel()).ToList();

            if (queryModel != null)
            {
                if (queryModel.MissionName != null)
                    list_smsission = list_smsission.Where(s => s.SMSMissionName.Contains(queryModel.MissionName)).ToList();
            }

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
            //数据验证
            if (smsmissionBLL.AddValidation(mission.SMSMissionName)) { return Content("validation fails"); }
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            mission.isDel = false;
            mission.isMMS = false;
            //mission.SubTime = DateTime.Now;
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
            if (smsmissionBLL.EditValidation(mission.SMID, mission.SMSMissionName)) { return Content("validation fails"); }
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
        ///
        ///</summary>
        ///<returns></returns>
        public ActionResult GetPersons2Datagrid(ViewModel_Person_QueryInfo queryModel)
        {
            //1.获取所选的短信任务实体
                int pageSize = int.Parse(Request.Form["rows"]);
                int pageIndex = int.Parse(Request.Form["page"]);

                int rowCount = 0;
            //int smid = int.Parse(Request["smid"]);
            //var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();
            #region 7月8日注释掉的部分
            //    //2.根据路线2得到isPass为true群组集合
            //    bool isPass = true;
            //    var list_group = GetGroups(isPass, SMSMission);
            //    List<P_PersonInfo> list_personFromGroup = new List<P_PersonInfo>();
            //    list_group.ForEach(g => list_personFromGroup.AddRange(g.P_PersonInfo.ToList()));
            //    //3 根据路线一查询  SMSMission对应的部门，并得到部门中包含的联系人
            //    //取出isPass为true的所有集合
            //    var list_department = GetDepartmemts(isPass, SMSMission);
            //    List<P_PersonInfo> list_personFromDep = new List<P_PersonInfo>();
            //    list_department.ForEach(g => list_personFromDep.AddRange(g.P_PersonInfo.ToList()));

            //    //4 将路线一与路线二取出的Person集合合并
            //    list_personFromGroup.AddRange(list_personFromDep);
            //    //5 此时的集合中可能存在重复，去重
            //    list_personFromGroup = list_personFromGroup.Distinct(new PMS.Model.EqualCompare.P_PersonEqualCompare()).ToList();

            //    //6 取出组群中isPass为false的集合
            //    isPass = false;
            //    var list_group_isNotPass = GetGroups(isPass, SMSMission);
            //    List<P_PersonInfo> list_personFromGroup_isNotPass = new List<P_PersonInfo>();
            //    list_group_isNotPass.ForEach(g => list_personFromGroup_isNotPass.AddRange(g.P_PersonInfo.ToList()));

            //    //7 将现有集合中去掉isPass为false的ActionInfo
            //    list_personFromGroup = list_personFromGroup.Where(a => !list_personFromGroup_isNotPass.Contains(a)).ToList();

            //    //8 取出组织机构中isPass为false的集合
            //    var list_department_isNotPass = GetDepartmemts(isPass, SMSMission);
            //    List<P_PersonInfo> list_personFromDep_isNotPass = new List<P_PersonInfo>();
            //    list_department_isNotPass.ForEach(g => list_personFromDep_isNotPass.AddRange(g.P_PersonInfo.ToList()));


            //    //9 将现有集合中去掉isPass为false,isDel为true的
            //    list_personFromGroup = list_personFromGroup.Where(a => !list_personFromDep_isNotPass.Contains(a)).ToList();
            //    list_personFromGroup = list_personFromGroup.Where(a => a.isDel == false).ToList();
            //rowCount = list_personFromGroup.Count();
            #endregion

            //7月8日修改
            //使用Send/GetPersonByMission这个方法替换上面注释掉的方法

            #region 8月16日 临时注释掉
            ////1 根据mid获取指定任务对象
            //var mission = smsmissionBLL.GetListBy(s => s.SMID == smid).FirstOrDefault();
            ////2 根据短信任务查找对应的群组
            //var group = mission.R_Group_Mission.ToList();
            ////2.1 创建该任务所拥有的群组对象集合
            //List<P_Group> list_group = new List<P_Group>();
            ////2.2 添加至群组对象集合中
            //group.ForEach(g => list_group.Add(g.P_Group));
            ////2.3 根据群组对象集合获取该群组集合中所共有的联系人
            //List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            //list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            ////3 根据短信任务查找对应的部门
            //var department = mission.R_Department_Mission.ToList();
            ////3.1 创建该任务所拥有的部门对象集合
            //List<P_DepartmentInfo> list_department = new List<P_DepartmentInfo>();
            ////3.2 添加至部门对象集合中
            //department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            ////3.3 根据部门对象集合获取该群组集合中所共有的联系人
            //list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));

            ////4 将联系人集合去重
            //list_person = list_person.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).Select(p => p.ToMiddleModel()).ToList();
            #endregion
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            if (queryModel.SMID != null)
            {
                list_person= smsmissionBLL.GetPersonByMission(queryModel.SMID,(PMS.Model.Enum.MMS_Enum)queryModel.IsMMS, true);
            }
            //筛选
            if (queryModel.PersonName != null)
            {
                list_person = list_person.Where(p => p.PName.Contains(queryModel.PersonName)).ToList();
            }

            if (queryModel.PhoneNum != null)
            {
                list_person = list_person.Where(p => p.PhoneNum.Contains(queryModel.PhoneNum)).ToList();
            }


            rowCount = list_person.Count();
            //10 分页
            list_person = list_person.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(m => m.ToMiddleModel()).ToList();

            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
                {
                    total = rowCount,
                    rows = list_person,
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

        
        
        private List<P_Group> GetGroupFactory(PMS.Model.Enum.MMS_Enum isMMs,S_SMSMission mission, bool isPass)
        {
            List<P_Group> list_group = null;
            switch (isMMs)
            {
                case PMS.Model.Enum.MMS_Enum.sms:
                    return smsmissionBLL.GetSMSGroups(isPass, mission);
                    //return this.GetSMSGroups(isPass, mission);
                    //break;
                case PMS.Model.Enum.MMS_Enum.mms:
                   return smsmissionBLL.GetMMSGroups(isPass, mission);
                //break;
                default:
                    return list_group;
                    //break;
            }
            

        }

        /// <summary>
        /// 根据启用、禁用的群组集合从全部群组集合中过滤返回easyui支持的DataGrid类型集合
        /// </summary>
        /// <param name="list_group">已有的群组集合</param>
        /// <param name="list_group_isNotPass">禁用的群组集合</param>
        /// <param name="list_ALLGroup">全部群组集合</param>
        /// <returns></returns>
        private List<EasyUIDataGrid_Group> FilterGroupList2DataGrid(List<P_Group> list_group,List<P_Group> list_group_isNotPass,List<P_Group> list_ALLGroup)
        {
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
                    Text = "请选择"
                };
                list_EasyUIDatagrid_Group.Add(datagrid_Group);
            }

            return list_EasyUIDatagrid_Group;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroup2Datagrid()
        {
            //1月5日添加彩信功能
            /*
             * 功能描述：
             * 根据传入的短彩信标记符判断是否需要加载彩信群组还是短信群组
             */
            int smid = int.Parse(Request["smid"]);
            int index_mms = int.Parse(Request["ismms"]);
            var enum_mms = (PMS.Model.Enum.MMS_Enum)index_mms;

            var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

            //1.获取当前任务已有的群组(未禁用)
            bool isPass = true;

            var list_group = this.GetGroupFactory(enum_mms, SMSMission, isPass);
            //2017年1月7日 修改 注释掉以下部分由以上替换
            //var list_group = GetSMSGroups(isPass, SMSMission);

            //2.获取当前任务已有的群组(已禁用)
            //var list_group_isNotPass = GetSMSGroups(isPass = false, SMSMission);
            var list_group_isNotPass = this.GetGroupFactory(enum_mms, SMSMission,isPass = false);
            //var list_groupbySmid = groupBLL.GetListBy(p => p.isDel == false && p.R_Group_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.GroupName).ToList();

            //3.获取所有的群组
            var list_ALLGroup = groupBLL.GetListBy(p => p.isDel == false).ToList();

            //4.对启用、禁用、全部群组过滤为 easyui datagrid group 集合 
           var list_EasyUIDatagrid_Group= this.FilterGroupList2DataGrid(list_group, list_group_isNotPass, list_ALLGroup);
            #region 2017年1月7日 此部分注释掉 由 FilterGroupList2DataGrid 方法封装
            //List<EasyUIDataGrid_Group> list_EasyUIDatagrid_Group = new List<EasyUIDataGrid_Group>();
            ////3.将已有的群组从所有群组中剔除，已拥有的群组（未禁用）排在前面
            //foreach (var item in list_group)
            //{

            //    EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
            //    {
            //        selected = true,
            //        Checked = true,
            //        GID = item.GID,
            //        GroupName = item.GroupName,
            //        Remark = item.Remark,
            //        IsPass = true,
            //        Text = "启用"
            //    };
            //    list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
            //    list_EasyUIDatagrid_Group.Add(datagrid_Group);
            //}
            ////4.将已有的群组从所有群组中剔除，已拥有的群组（已禁用）排在前面
            //foreach (var item in list_group_isNotPass)
            //{

            //    EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
            //    {
            //        selected = true,
            //        Checked = true,
            //        GID = item.GID,
            //        GroupName = item.GroupName,
            //        Remark = item.Remark
            //    };
            //    list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
            //    list_EasyUIDatagrid_Group.Add(datagrid_Group);
            //}
            ////5.未拥有的群组
            //foreach (var item in list_ALLGroup)
            //{
            //    EasyUIDataGrid_Group datagrid_Group = new EasyUIDataGrid_Group()
            //    {
            //        GID = item.GID,
            //        GroupName = item.GroupName,
            //        Remark = item.Remark,
            //        IsPass = true,
            //        Text = "请选择"
            //    };
            //    list_EasyUIDatagrid_Group.Add(datagrid_Group);
            //}
            #endregion

            //5.序列化
            string temp = Common.SerializerHelper.SerializerToString(list_EasyUIDatagrid_Group);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);

        }

        /// <summary>
        /// 根据传入的短信任务种类id以及是否为彩信标记取到指定的彩信群组的datagrid
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMMSGroup2Datagrid()
        {
            //1月5日添加彩信功能
            /*
             * 功能描述：
             * 根据传入的短彩信标记符判断是否需要加载彩信群组还是短信群组
             */
            int smid = int.Parse(Request["smid"]);
            var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

            //1.获取当前任务已有的群组(未禁用)
            bool isPass = true;

            var list_group = this.GetGroupFactory(PMS.Model.Enum.MMS_Enum.mms, SMSMission, isPass);

            //2.获取当前任务已有的群组(已禁用)
            var list_group_isNotPass = this.GetGroupFactory(PMS.Model.Enum.MMS_Enum.mms, SMSMission, isPass = false);

            //3.获取所有的群组
            var list_ALLGroup = groupBLL.GetListBy(p => p.isDel == false).ToList();

            //4.对启用、禁用、全部群组过滤为 easyui datagrid group 集合 
            var list_EasyUIDatagrid_Group = this.FilterGroupList2DataGrid(list_group, list_group_isNotPass, list_ALLGroup);

            //5.序列化
            string temp = Common.SerializerHelper.SerializerToString(list_EasyUIDatagrid_Group);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);

        }

        ///<summary>
        ///得到选中任务所包含的群组,并转换为Combogrid
        /// 6月20日 此处有错误
        /// 6月23日 修改完成
        ///</summary>
        ///<returns></returns>
        public ActionResult GetDepartment2Treegrid()
        {
            int smid = int.Parse(Request["smid"]);
            var str_ismms = Request["ismms"];
            var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();


            //1.获取当前任务已有的部门(启用)
            //bool isPass = true;
            /*2017-04-14
              bug:
              list_departments_isPass集合中存在对象
              isPass=true
              Text="禁用"
              （实际是启用状态）
              casablanca
            */
            var list_departments_isPass = GetDepartmemts(true, SMSMission,(str_ismms=="mms"?true:false));
            //2.获取当前任务已有的部门(禁用)
            var list_department_isNotPass = GetDepartmemts(false, SMSMission, (str_ismms == "mms" ? true : false));

            //2.获取所有的部门
            var list_ALLDepartment = departmentBLL.GetListBy(p => p.isDel == false).ToList();           

            //3 6月22日第二版            
            List<P_DepartmentInfo> list_isPass = new List<P_DepartmentInfo>();
            List<P_DepartmentInfo> list_notPass = new List<P_DepartmentInfo>();
            //3.1 从全部部门中查询已经启用的部门，并保存该集合
            if (list_departments_isPass.Count != 0)
            {
                list_isPass = (from all in list_ALLDepartment
                               join pass in list_departments_isPass
                               on all.DID equals pass.DID
                               select all
                             ).ToList();
            }
            else if (list_departments_isPass.Count == 0)
            {
                list_isPass = new List<P_DepartmentInfo>();
            }
            //3.2 从全部部门中查询禁用的部门，并保存该集合
            list_notPass = (from all in list_ALLDepartment
                            join not in list_department_isNotPass
                            on all.DID equals not.DID
                            select all
                          ).ToList();

            //3.3 从全部部门集合中去除掉 刚才查询到的 禁用 和 启用 的部门集合
            //此时全部部门集合中只保留 除去 禁用 和 启用 的部门外的集合
            list_ALLDepartment.RemoveAll(p => list_isPass.Contains(p));
            list_ALLDepartment.RemoveAll(p => list_notPass.Contains(p));

            #region 6月23日 不使用以下这种方式
            //list_ALLDepartment.RemoveAll(p => list_isPass.Contains(p));
            //从全部部门中找到不通过的集合
            //list_notPass = (from all in list_ALLDepartment
            //                from notPass in list_department_isNotPass
            //                where list_department_isNotPass.Count == 0 ? true : all.DID != notPass.DID
            //                select all).ToList();
            ////并从全部部门集合中去掉
            //list_ALLDepartment.RemoveAll(p => list_notPass.Contains(p));
            #endregion

            /*4 创建最终返回的部门集合
             （此集合中包含 
                            启用的部门集合（含selected、checked等标记）
                            禁用的部门集合（。。。）
                            以及 去除以上两个集合后的部门集合
            */
            List<P_DepartmentInfo> list_other = new List<P_DepartmentInfo>();
            list_other.AddRange(list_departments_isPass);
            list_other.AddRange(list_department_isNotPass);
            list_other.AddRange(list_ALLDepartment);
            #region 6月23日  查询暂时注释掉的部分
            //var list_isOwned = (from all in list_ALLDepartment
            //                 join pass in list_departments_isPass 
            //                 on all.DID equals pass.DID
            //                where all.DID != pass.DID
            //                select all).ToList();

            //3.2 继续从已经剔除启用的部门集合中继续剔除禁用的部门
            //var temp2=  from a in list_ALLDepartment
            //  from b in list_department_isNotPass
            //  where true
            //  select a;

            //var temp3 = (from a in list_ALLDepartment
            //             join b in list_department_isNotPass
            //             on a.DID equals b.DID
            //             where list_department_isNotPass.Count!=0               
            //             select a).ToList();



            //list_temp.AddRange(list_departments_isPass);
            //list_temp.AddRange(list_department_isNotPass);


            //list_other.AddRange(
            //    from ispass in list_departments_isPass
            //    from all in list_ALLDepartment
            //    where all.DID != ispass.DID && list_departments_isPass.Count != 0
            //    select all);
            //list_other = (
            //from all in list_ALLDepartment
            //join ispass in list_departments_isPass on all.DID equals ispass.DID select all
            //}
            //if (list_department_isNotPass.Count != 0)
            //{
            //    list_other.AddRange(from ispass in list_department_isNotPass
            //                        from all in list_ALLDepartment
            //                        where ispass.DID != all.DID
            //                        select all);
            //}
            //else
            //{
            //    list_other.AddRange(list_ALLDepartment);
            //}
            //}
            //else
            //{
            //    list_other = list_ALLDepartment;
            //}
            #endregion

            //6月22日注意此处不能去重，因为使用此方式去重只判断DID与DepartmentName是否不同， 若相同的话会去掉重复的对象，但此时可能第二个被去掉的对象selected、chekced等为true而第一个对象保留的为false
            List< EasyUITreeGrid_Department > list_EasyUITreeGrid_Department = new List<EasyUITreeGrid_Department>();

            #region 6月20日 注释掉用上面的方法代替
            ////3.将已有的部门从所有部门中剔除，已拥有的部门（未禁用）排在前面
            //foreach (var item in list_departments)
            //{
            //    item.Checked = true;
            //    item.selected = true;
            //    item.IsPass = true;
            //    item.Text = "启用";
            //    list_ALLDepartment = list_ALLDepartment.Where(p => p.DID != item.DID).ToList();
            //}
            ////4.将已有的群组从所有群组中剔除，已拥有的群组（已禁用）排在前面
            //foreach (var item in list_department_isNotPass)
            //{
            //    item.Checked = true;
            //    item.selected = true;
            //    list_ALLDepartment = list_ALLDepartment.Where(p => p.DID != item.DID).ToList();
            //}
            ////5.未拥有的群组
            //foreach (var item in list_ALLDepartment)
            //{
            //    item.IsPass = true;
            //    item.Text = "启用";
            //}

            //list_departments.AddRange(list_department_isNotPass);
            //list_departments.AddRange(list_ALLDepartment);
            #endregion

            //5 将最终的集合转换成要返回的TreeGrid集合
            List<Models.EasyUITreeGrid_Department> list_treegrid= Models.Department_ViewModel.ToEasyUITreeGrid(list_other,true);
            string temp = Common.SerializerHelper.SerializerToString(list_treegrid);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }           

        ///<summary>
        ///根据选中任务获得部门
        ///</summary>
        ///<returns></returns>
        public List<P_DepartmentInfo> GetDepartmemts(bool isPass, S_SMSMission SMSMission,bool ismms)
        {
            if(SMSMission != null)
            {
                //6月20日对查询进行修改
            var list_R_Department_Mission = SMSMission.R_Department_Mission;
                var list_department = (
                   from r in list_R_Department_Mission
                   where r.isPass == isPass&&r.isMMS== ((ismms) ? 1 : 0)
                   select r.P_DepartmentInfo
                    ).Select(r => r = new P_DepartmentInfo
                    {
                        Area = r.Area,
                        DepartmentName = r.DepartmentName,
                        DID = r.DID,
                        isDel = r.isDel,
                        PDID = r.PDID,
                        Remark = r.Remark,
                        Text = r.Text,
                        selected = true,
                        Checked = true,
                        IsPass = isPass
                    }).ToList();

                return list_department;
            }
            return null;
        }


        #region 2017-04-12 备份——测试通过时可删除
        ///<summary>
        ///为所选的任务分配群组
        ///</summary>
        ///<returns></returns>
        //public ActionResult DoAssignGroup2SMSMission(Models.ViewModel_SMSMissionDepartmentGroup model)
        //{
        //    bool isGroupOk = false;
        //    bool isDepartmentOk = false;
        //    if (model.SMSMissionID != null)
        //    {
        //            //1.得到所选的任务
        //            var smid = int.Parse(model.SMSMissionID);
        //            //var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

        //        //2.分配群组
        //        if (model.groupIds == null)
        //        {   //2.1 当为没有选中任何群组时，移除当前任务拥有的所有群组
        //            var g_result = this.smsmissionBLL.RemoveAllGroup(smid);
        //            if (g_result)
        //            {
        //                isGroupOk = true;
        //            }
        //        }
        //        else
        //        {
        //            //2.2 分配群组操作
        //           // List<int> list_groupIDs = new List<int>();
        //            string[] groupIDs = model.groupIds.Split(',');
        //            //List<bool> list_isPass = new List<bool>();
        //            string[] g_isPasses = model.g_isPasses.Split(',');
        //            //7月28日
        //            //现准备将传入的对象转换为ViewModel_isPass_xxxx对象
        //            //2.2先转换群组   
        //            List<ViewModel_isPass_Group> list_group_isPass = new List<ViewModel_isPass_Group>();                 
        //            //2.2.1 转换群组为ViewModel对象集合
        //            if (groupIDs.Count() == g_isPasses.Count())
        //            {
        //                for (int i = 0; i < g_isPasses.Count(); i++)
        //                {
        //                    switch (g_isPasses[i])
        //                    {
        //                        case "启用":
        //                            list_group_isPass.Add(new ViewModel_isPass_Group()
        //                            {
        //                                gid = int.Parse(groupIDs[i]),
        //                                isPass = true
        //                            });
        //                            break;
        //                        case "禁用":
        //                            list_group_isPass.Add(new ViewModel_isPass_Group()
        //                            {
        //                                gid = int.Parse(groupIDs[i]),
        //                                isPass = false
        //                            });
        //                            break;
        //                    }
        //                }
        //                //foreach (var item in g_isPasses)
        //                //{

        //                //}
        //            }


        //            //2.2.1修改禁用功能
        //            #region 7月28日——使用上面的方式替换
        //            //foreach (var item in g_isPasses)
        //            //{
        //            //    if (item.Equals("启用"))
        //            //    {
        //            //        list_isPass.Add(true);
        //            //    }
        //            //    else if (item.Equals("禁用"))
        //            //    {
        //            //        list_isPass.Add(false);
        //            //    }
        //            //}
        //            //groupIDs.ToList().ForEach(a => list_groupIDs.Add(int.Parse(a)));
        //            #endregion


        //            var g_result = this.smsmissionBLL.SetSMSMission4Group(smid, list_group_isPass);

        //            if (g_result)
        //            {
        //                isGroupOk = true;
        //            }
        //        }



        //        //3.分配部门
        //        if (model.departmentIds == null)
        //        {   //3.1 当为没有选中任何部门时，移除当前任务拥有的所有部门
        //            var d_result = this.smsmissionBLL.RemoveAllDepartment(smid);
        //            if (d_result)
        //            {
        //                isDepartmentOk = true;
        //            }
        //        }
        //        else
        //        {
        //            //3.2 分配部门操作
        //           // List<int> list_departmentIDs = new List<int>();
        //            string[] departmentIDs = model.departmentIds.Split(',');
        //            //List<bool> list_disPass = new List<bool>();
        //            string[] d_isPasses = model.d_isPasses.Split(',');

        //            List<ViewModel_isPass_Department> list_department_isPass = new List<ViewModel_isPass_Department>();
        //            //2.2.1 转换群组为ViewModel对象集合
        //            if (departmentIDs.Count() == d_isPasses.Count())
        //            {
        //                for (int i = 0; i < d_isPasses.Count(); i++)
        //                {
        //                    switch (d_isPasses[i])
        //                    {
        //                        case "true":
        //                            list_department_isPass.Add(new ViewModel_isPass_Department()
        //                            {
        //                                did = int.Parse(departmentIDs[i]),
        //                                isPass = true
        //                            });
        //                            break;
        //                        case "false":
        //                            list_department_isPass.Add(new ViewModel_isPass_Department()
        //                            {
        //                                did = int.Parse(departmentIDs[i]),
        //                                isPass = false
        //                            });
        //                            break;
        //                    }
        //                }
        //                //foreach (var item in g_isPasses)
        //                //{

        //                //}
        //            }
        //            var d_result = this.smsmissionBLL.SetSMSMission4Department(smid, list_department_isPass);

        //            if (d_result)
        //            {
        //                isDepartmentOk = true;
        //            }
        //            //3.2.1修改禁用功能  
        //            //foreach (var item in d_isPasses)
        //            //{
        //            //    if (item.Equals("true"))
        //            //    {
        //            //        list_disPass.Add(true);
        //            //    }
        //            //    else if (item.Equals("false"))
        //            //    {
        //            //        list_disPass.Add(false);
        //            //    }
        //            //}
        //            //departmentIDs.ToList().ForEach(a => list_departmentIDs.Add(int.Parse(a)));
        //            //var d_result = this.smsmissionBLL.SetSMSMission4Department(smid, list_departmentIDs, list_disPass);
        //            //if (d_result)
        //            //{
        //            //    isDepartmentOk = true;
        //            //}
        //        }
        //        }

        //    if (isGroupOk && isDepartmentOk)
        //    {
        //        return Content("ok");
        //    }
        //    else
        //    {
        //        return Content("error");
        //    }

        //}
        #endregion



        //为所选的任务分配群组    
        public ActionResult DoAssignGroup2SMSMission(Models.ViewModel_SMSMissionDepartmentGroup model)
        {
            //2017-04-12
            /*
             * 修改：
             * 视图实体中多了isMMS标记
             * 短信：sms；彩信：mms
             * 需要判断是短信还是彩信
             * casablanca
             */
            bool isGroupOk = false;
            bool isDepartmentOk = false;
            //若是彩信则为true，不是则为false
            var ismms = model.isMMS.ToLower() == "mms" ? true : false;
            if (model.SMSMissionID != null)
            {
                //1.得到所选的任务
                var smid = int.Parse(model.SMSMissionID);
                //var SMSMission = smsmissionBLL.GetListBy(a => a.SMID == smid).FirstOrDefault();

                //2.分配群组
                if (model.groupIds == null)
                {   //2.1 当为没有选中任何群组时，移除当前任务拥有的所有群组
                    var g_result = this.smsmissionBLL.RemoveAllGroup(smid, ismms);
                    if (g_result)
                    {
                        isGroupOk = true;
                    }
                }
                else
                {
                    //2.2 分配群组操作
                    // List<int> list_groupIDs = new List<int>();
                    string[] groupIDs = model.groupIds.Split(',');
                    //List<bool> list_isPass = new List<bool>();
                    string[] g_isPasses = model.g_isPasses.Split(',');
                    //7月28日
                    //现准备将传入的对象转换为ViewModel_isPass_xxxx对象
                    //2.2先转换群组   
                    List<ViewModel_isPass_Group> list_group_isPass = new List<ViewModel_isPass_Group>();
                    //2.2.1 转换群组为ViewModel对象集合
                    if (groupIDs.Count() == g_isPasses.Count())
                    {
                        for (int i = 0; i < g_isPasses.Count(); i++)
                        {
                            switch (g_isPasses[i])
                            {
                                case "启用":
                                    list_group_isPass.Add(new ViewModel_isPass_Group()
                                    {
                                        gid = int.Parse(groupIDs[i]),
                                        isPass = true
                                    });
                                    break;
                                case "禁用":
                                    list_group_isPass.Add(new ViewModel_isPass_Group()
                                    {
                                        gid = int.Parse(groupIDs[i]),
                                        isPass = false
                                    });
                                    break;
                            }
                        }                        
                    }


                    //2.2.1修改禁用功能
                    #region 7月28日——使用上面的方式替换
                    //foreach (var item in g_isPasses)
                    //{
                    //    if (item.Equals("启用"))
                    //    {
                    //        list_isPass.Add(true);
                    //    }
                    //    else if (item.Equals("禁用"))
                    //    {
                    //        list_isPass.Add(false);
                    //    }
                    //}
                    //groupIDs.ToList().ForEach(a => list_groupIDs.Add(int.Parse(a)));
                    #endregion
                    
                    var g_result = this.smsmissionBLL.SetSMSMission4Group(smid, list_group_isPass, ismms);

                    if (g_result)
                    {
                        isGroupOk = true;
                    }
                }



                //3.分配部门
                if (model.departmentIds == null)
                {   //3.1 当为没有选中任何部门时，移除当前任务拥有的所有部门
                    var d_result = this.smsmissionBLL.RemoveAllDepartment(smid, ismms);
                    if (d_result)
                    {
                        isDepartmentOk = true;
                    }
                }
                else
                {
                    //3.2 分配部门操作
                    // List<int> list_departmentIDs = new List<int>();
                    string[] departmentIDs = model.departmentIds.Split(',');
                    //List<bool> list_disPass = new List<bool>();
                    string[] d_isPasses = model.d_isPasses.Split(',');

                    List<ViewModel_isPass_Department> list_department_isPass = new List<ViewModel_isPass_Department>();
                    //2.2.1 转换群组为ViewModel对象集合
                    if (departmentIDs.Count() == d_isPasses.Count())
                    {
                        for (int i = 0; i < d_isPasses.Count(); i++)
                        {
                            switch (d_isPasses[i])
                            {
                                case "true":
                                    list_department_isPass.Add(new ViewModel_isPass_Department()
                                    {
                                        did = int.Parse(departmentIDs[i]),
                                        isPass = true
                                    });
                                    break;
                                case "false":
                                    list_department_isPass.Add(new ViewModel_isPass_Department()
                                    {
                                        did = int.Parse(departmentIDs[i]),
                                        isPass = false
                                    });
                                    break;
                            }
                        }
                        //foreach (var item in g_isPasses)
                        //{

                        //}
                    }
                    var d_result = this.smsmissionBLL.SetSMSMission4Department(smid, list_department_isPass, ismms);

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

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            var httpModel = new ViewModel_MyHttpContext()
            {
                Area = "Contacts",
                Controller = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString(),
                Action = RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString(),
                Url = Request.Url.ToString()
            };
            return httpModel;
        }
        #endregion





    }
}
