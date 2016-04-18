using PMS.IBLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SMSOA.Areas.Contacts.Controllers
{
    public class GroupController : Controller
    {
        IP_GroupBLL groupBLL { get; set; }

        // GET: Contacts/Group
        public ActionResult Index()
        {
            //ViewBag.Del_url = "/Admin/Role/DelSoftRoleInfos";
            ViewBag.Del_url = "/Contacts/Group/DelSoftGroupInfos";
            ViewBag.ShowEdit = "/Contacts/Group/ShowEditGroupInfo";
            ViewBag.ShowAdd = "/Contacts/Group/ShowAddGroupInfo";           
            ViewBag.GetInfo = "/Contacts/Group/GetGroupInfo";
            ViewBag.GetPersonUrl= "/Contacts/ContactPerson/GetPersonByGroup";
            ViewBag.GetGroup_combobox = "/Contacts/Group/GetCombobox4GroupInfo";
            ViewBag.GetDepartment_combotree = "/Contacts/Department/GetDepartmentInfobyComboTree";
            return View();
        }


        
        /// <summary>
        /// 获取全部群组数据
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroupInfo()
        {
            //int pageSize = int.Parse(Request.Form["rows"]);
            //int pageIndex = int.Parse(Request.Form["page"]);
            //int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            //var list_person = groupBLL.GetPageList(pageIndex, pageSize, ref rowCount, g => g.isDel == false, g => g.GroupName, true).ToList();
            //PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            //{
            //    total = rowCount,
            //    rows = list_person,
            //    footer = null
            //};


            //将权限转换为对应的
            //return Content(Common.SerializerHelper.SerializerToString(dgModel));

            //不使用分页查询
            var list_group = groupBLL.GetListBy(g => g.isDel == false, g => g.GroupName).ToList();

            return Content(Common.SerializerHelper.SerializerToString(list_group));

        }

        /// <summary>
        /// 将全部的分组集合对象转换为easyui中的Combobox解析的json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCombobox4GroupInfo()
        {
            //查询全部group
            var list_group = groupBLL.GetListBy(g => g.isDel == false, g => g.GroupName).ToList();
            //将group集合转换为对应的combobox集合
            List<PMS.Model.EasyUIModel.EasyUICombobox> list_combobox = P_Group.ToEasyUICombobox(list_group);

            return Content(Common.SerializerHelper.SerializerToString(list_combobox));
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
                ViewBag.Data = model;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = "/Contacts/Group/DoEditGroupInfo";
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
            return View();
        }



        public ActionResult DoAddGroupInfo(P_Group groupModel)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
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
            string state = groupBLL.DelSoftRoleInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }

    }
}