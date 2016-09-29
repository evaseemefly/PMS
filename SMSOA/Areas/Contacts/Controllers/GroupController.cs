using PMS.IBLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.EasyUIFormat;
using SMSOA.Areas.Admin.Controllers;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.Contacts.Controllers
{
    public class GroupController : BaseController
    {
        IP_GroupBLL groupBLL { get; set; }

        // GET: Contacts/Group
        public ActionResult Index()
        {
            //ViewBag.Del_url = "/Admin/Role/DelSoftRoleInfos";
            //操作群组
            ViewBag.DelGroup_url = "/Contacts/Group/DelSoftGroupInfos";
            ViewBag.ShowEditGroup = "/Contacts/Group/ShowEditGroupInfo";
            ViewBag.ShowAddGroup = "/Contacts/Group/ShowAddGroupInfo";
            //操作联系人
            ViewBag.ShowAddPerson = "/Contacts/ContactPerson/ShowAddPersonInfo";
            ViewBag.ShowEditPerson= "/Contacts/ContactPerson/ShowEditPersonInfo";
            ViewBag.DelPerson_url = "/Contacts/Group/DoDelPersonInfobyGID";
            //6月15日
            ViewBag.DelPersonByAll_url = "/Contacts/ContactPerson/DoDelPersonInfo_All";
            ViewBag.GetInfo = "/Contacts/Group/GetGroupInfo";
            ViewBag.GetPersonUrl= "/Contacts/ContactPerson/GetPersonByGroup";
            ViewBag.GetGroup_combobox = "/Contacts/Group/GetComboGrid4GroupInfo";
            ViewBag.GetDepartment_combotree = "/Contacts/Department/GetDepartmentInfo4ComboTree";
            ViewBag.GetDepartmentIdByPid = "/Contacts/Department/GetDepartmentIdInfoByPid";
            ViewBag.PersonAssignProperty = "/Contacts/ContactPerson/GetPersonDepartmentGroup";
            ViewBag.ShowGroupToolbar = base.CheckContactCommonToolBar() == true ? 1 : 0;
            ViewBag.ShowPersonToolbar = base.CheckPersonToolBar() == true ? 1 : 0;
            return View();
        }

        /// <summary>
        /// 根据匹配条件查询符合条件的群组列表
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroupInfo(ViewModel_Group_QueryInfo queryModel)
        {
            //不使用分页查询
            var list_group = groupBLL.GetListBy(g => g.isDel == false, g => g.Sort).ToList().Select(g => g.ToMiddleModel()).ToList();

            if (queryModel != null)
            {
                if(queryModel.GroupName!=null)
                list_group= list_group.Where(g => g.GroupName.Contains(queryModel.GroupName)).ToList();
            }
            
            return Content(Common.SerializerHelper.SerializerToString(list_group));

        }

        ///// <summary>
        ///// 获取全部群组数据
        ///// json格式
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult GetGroupInfo()
        //{
        //    //int pageSize = int.Parse(Request.Form["rows"]);
        //    //int pageIndex = int.Parse(Request.Form["page"]);
        //    //int rowCount = 0;

        //    //查询所有的权限
        //    //使用ref声明时需要在传入之前为其赋值
        //    //var list_person = groupBLL.GetPageList(pageIndex, pageSize, ref rowCount, g => g.isDel == false, g => g.GroupName, true).ToList();
        //    //PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
        //    //{
        //    //    total = rowCount,
        //    //    rows = list_person,
        //    //    footer = null
        //    //};


        //    //将权限转换为对应的
        //    //return Content(Common.SerializerHelper.SerializerToString(dgModel));

        //    //不使用分页查询
        //     var list_group = groupBLL.GetListBy(g => g.isDel == false, g => g.Sort).ToList().Select(g=>g.ToMiddleModel()).ToList();

        //    //5月2日 解决使用Netjson序列化时会内存溢出的问题
        //    //方式（一）
        //    //var content = from r in list_group
        //    //              select r.ToMiddleModel();

        //    //return Json(list_group, JsonRequestBehavior.AllowGet);
        //    return Content(Common.SerializerHelper.SerializerToString(list_group));

        //}

        /// <summary>
        /// 6月13日家添加
        /// 获取全部的群组并以ComboGrid的方式返回
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComboGridAllGroupInfo()
        {
            //查询全部的群组
            var list_allgroup = groupBLL.GetListBy(g => g.isDel == false, g => g.Sort).ToList().Select(r => r.ToMiddleModel()).ToList();

            var list_combobox_allgroup= ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_allgroup, false);

            return Content(Common.SerializerHelper.SerializerToString(list_combobox_allgroup));
        }

        public ActionResult GetCombobox4AllGroupInfo()
        {
            //查询全部的群组
            var list_allgroup= groupBLL.GetListBy(g => g.isDel == false).ToList().Select(r=>r.ToMiddleModel()).ToList();
            
            var list_combobox_allgroup = P_Group.ToEasyUICombobox(ref list_allgroup, false);

            return Content(Common.SerializerHelper.SerializerToString(list_combobox_allgroup));
        }

        /// <summary>
        /// 在某一群组中点击添加联系人时，传入该群组的gid
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public ActionResult GetCombobox4GroupInfoByGid(int gid)
        {
            //1 根据指定的gid查询对应的group对象
            var groupTemp= groupBLL.GetListBy(g => g.GID == gid).FirstOrDefault();
            //2 查询全部group 
            var list_groupAll = groupBLL.GetListBy(g => g.isDel == false).ToList();
            //3 将已经拥有的群组从全部群组集合中剔除
            list_groupAll = list_groupAll.Where(g => g.GID != groupTemp.GID).ToList();
            //4.1 已经拥有的群组集合
            List<P_Group> list_groupOwned = new List<P_Group>();
            list_groupOwned.Add(groupTemp);
            //5月3日添加实体改为中间实体的方法
            list_groupOwned = list_groupOwned.Select(p => p.ToMiddleModel()).ToList();
            //转成Combobox
            var list_combobox_ownedgroup = P_Group.ToEasyUICombobox(ref list_groupOwned, true);

            //4.2将全部群组集合中的选中按钮设置为false
            var list_combobox_allgroup = P_Group.ToEasyUICombobox(ref list_groupAll, false);

            list_combobox_ownedgroup.AddRange(list_combobox_allgroup);
            
            string temp = Common.SerializerHelper.SerializerToString(list_combobox_ownedgroup);
            //暂时先不用替换
            //temp = temp.Replace("Checked", "selected");
            return Content(temp);
        }


        /// <summary>
        /// 6月12日修改
        /// 将全部的分组集合对象转换为easyui中的ComboGrid解析的json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComboGrid4GroupInfo(int pid)
        {
            if (pid == -1)
            {

            }
            //1 查询指定pid对应的group群组集合
            List<P_Group> list_groupbyPid = groupBLL.GetListByPerson(pid);

            //2 查询全部group 
            var list_groupAll = groupBLL.GetListBy(g => g.isDel == false).ToList();

            //3 遍历指定pid所拥有的群组集合
            foreach (var item in list_groupbyPid)
            {

                //3.1 将已经拥有的群组从全部群组集合中剔除
                list_groupAll = list_groupAll.Where(g => g.GID != item.GID).ToList();
            }

            //4.2将group集合转换为对应的combobox集合
            //****5月3日添加实体改为中间实体的方法
            var list_combobox_groupByPid = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_groupbyPid, true);
           
            //4.2将全部群组集合中的选中按钮设置为false
            //****5月3日添加实体改为中间实体的方法
            var list_combobox_allgroup = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_groupAll, false);

            //5 将全部群组集合加到指定pid所拥有的群组集合中（不用再去重）
            list_groupbyPid.AddRange(list_groupAll);
            list_combobox_groupByPid.AddRange(list_combobox_allgroup);
            //4去重
 
            //6将Checked替换为checked
            string temp = Common.SerializerHelper.SerializerToString(list_combobox_groupByPid);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }


        /// <summary>
        /// 将全部的分组集合对象转换为easyui中的Combobox解析的json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCombobox4GroupInfo(int pid)
        {
            if (pid == -1)
            {

            }
            //1 查询指定pid对应的group群组集合
           List<P_Group> list_groupbyPid= groupBLL.GetListByPerson(pid);
                 
            //2 查询全部group 
            var list_groupAll= groupBLL.GetListBy(g => g.isDel == false).ToList();
            
            //3 遍历指定pid所拥有的群组集合
            foreach (var item in list_groupbyPid)
            {

                //3.1 将已经拥有的群组从全部群组集合中剔除
                list_groupAll = list_groupAll.Where(g => g.GID != item.GID).ToList();
            }

            //4.2将group集合转换为对应的combobox集合
            //****5月3日添加实体改为中间实体的方法
            var list_combobox_groupByPid = P_Group.ToEasyUICombobox(ref list_groupbyPid, true);
            //4.2将全部群组集合中的选中按钮设置为false
            //****5月3日添加实体改为中间实体的方法
            var list_combobox_allgroup = P_Group.ToEasyUICombobox(ref list_groupAll, false);
            //获取全部group的id集合
            //List<int> list_allGroupIds = new List<int>();
            //list_groupbyPid.ForEach(a => list_allGroupIds.Add(a.GID));
             
            //5 将全部群组集合加到指定pid所拥有的群组集合中（不用再去重）
            list_groupbyPid.AddRange(list_groupAll);
            list_combobox_groupByPid.AddRange(list_combobox_allgroup);
            //4去重
            //使用此种方式可以去重
            //list_groupbyPid = list_groupbyPid.Distinct(new PMS.Model.EqualCompare.P_GroupEqualCompare()).ToList();
            //这么去重有问题，不知道怎么解决
            //list_combobox_groupByPid = list_combobox_groupByPid.Distinct(new PMS.Model.EqualCompare.EasyUIComboboxEqualCompare()).ToList();
            
            //6将Checked替换为checked
            string temp= Common.SerializerHelper.SerializerToString(list_combobox_groupByPid);
            temp = temp.Replace("Checked", "selected");
            return Content(temp);
        }

        public ActionResult ShowEditGroupInfo()
        {
            int id= int.Parse(Request["id"]);
            //若有传入的id
            if (id != 0)
            {
                //1 找到指定id的action对象
                var model = groupBLL.GetListBy(g => g.GID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 
                                                                                     //为分布式图中的下拉框添加要请求的地址
                                                                                     // ViewBag.data = GetOption();//先不用easyui的控件
                                                                                     //2 获取
                                                                                     //4 将指定id的action对象传给视图数据字典中的实体
                //ViewData.Model = model;
                //ViewBag.Data = model;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = "/Contacts/Group/DoEditGroupInfo";
                ViewBag.GID = model.GID;
                ViewBag.SubTime= model.SubTime;
                ViewBag.GroupName = model.GroupName;
                ViewBag.Remark= model.Remark;
                ViewBag.Sort= model.Sort;
                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View();
            }
            return Content("no");
        }

        public ActionResult ShowAddGroupInfo()
        {
           
            ViewBag.backAction_jqSub = "/Contacts/Group/DoAddGroupInfo";
            //ViewBag.backAction = "DoAddGroupInfo";
            return View("ShowEditGroupInfo");
        }



        public ActionResult DoAddGroupInfo(P_Group groupModel)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            //数据验证
            if (groupBLL.AddValidation(groupModel.GroupName)) { return Content("validation fails"); }
            groupModel.isDel = false;
            groupModel.SubTime = DateTime.Now;
            groupModel.ModifiedOnTime = DateTime.Now;

            try
            {
                groupBLL.Create(groupModel);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }



        public ActionResult DoEditGroupInfo(P_Group groupModel)
        {
            if(groupBLL.EditValidation(groupModel.GID, groupModel.GroupName)) { return Content("validation fails"); }
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            groupModel.isDel = false;            
            groupModel.ModifiedOnTime = DateTime.Now;

            try
            {
                groupBLL.Update(groupModel);
                return Content("ok");
            }
            catch
            {
                    return Content("error");
             }
        }

        public ActionResult DoDelPersonInfobyGID()
        {
            //1 获取联系人id以及群组id
            int pid =int.Parse(Request.QueryString["pid"]);
            int gid =int.Parse(Request.QueryString["gid"]);

           bool state= groupBLL.DelPersonInfoByGID(gid, pid);

            //3 返回结果          
            return Content( state  == true ?  "ok" :  "error");
        }

        //public ActionResult DoDelPersonInfoByGID_All()
        //{

        //}

        /// <summary>
        /// 执行软删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelSoftGroupInfos(string ids)
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
            //注意在删除某个群组时，不仅要删除该群组，还要将与该群组有关联的人员也同时删除掉
            
            string state = groupBLL.DelSoftRoleInfos(list) == true ? state = "ok" : state = "error";
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

        ///<summary>
        ///得到选中任务所包含的群组
        ///</summary>
        ///<returns></returns>
        //public ActionResult GetCombogrid4GroupInfoBySmid()
        //{
        //    int smid = int.Parse(Request["smid"]);

        //        List<P_Group> list_ShowGroup = new List<P_Group>();
        //        //1.获取当前任务已有的群组
        //        var list_groupbySmid = groupBLL.GetListBy(p => p.isDel == false && p.R_Group_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.GroupName).ToList();
        //        //2.获取所有的群组
        //        var list_ALLGroup = groupBLL.GetListBy(p => p.isDel == false).ToList();
        //        //3.将已有的群组从所有群组中剔除，已拥有的群组排在前面
        //        foreach (var item in list_groupbySmid)
        //        {

        //            item.Checked = true;
        //            list_ALLGroup = list_ALLGroup.Where(p => p.GID != item.GID).ToList();
        //            list_ShowGroup.Add(item);
        //        }

        //        //4.未拥有的群组排在后面
        //        list_ShowGroup.AddRange(list_ALLGroup);
        //        string temp =  Common.SerializerHelper.SerializerToString(list_ShowGroup);
        //        temp = temp.Replace("Checked", "checked");
        //        return Content(temp);
        //}
    }
}