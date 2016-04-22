using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;

namespace SMSOA.Areas.Contacts.Controllers
{
    public class DepartmentController : Controller
    {
        IP_DepartmentInfoBLL departmentBLL { get; set; }

        #region 1 共用属性
        /// <summary>
        /// 执行删除操作的url地址
        /// </summary>
        private string del_url
        {
            get
            { return "/Contacts/Department/DelSoftDepartmentInfos"; }
        }

        private string showAddPerson_url
        {
            get
            {
                return "/Contacts/ContactPerson/ShowAddPersonInfo";
            }
        }

        /// <summary>
        /// 执行展示修改操作的url地址
        /// </summary>
        private string showEdit_url
        {
            get
            {
                return "/Contacts/Department/ShowEditDepartmentInfo";
            }
        }

        /// <summary>
        /// 执行展示添加操作的url地址
        /// </summary>
        private string showAdd_url
        {
            get
            {
                return "/Contacts/Department/ShowAddDepartmentInfo";
            }
        }

        /// <summary>
        /// 执行查询全部部门信息操作的url地址
        /// </summary>
        private string getInfo_url
        {
            get
            { return "/Contacts/Department/GetDepartmentInfo"; }
        }

        private string getInfobyComboTree_rul
        {
            get
            { return "/Contacts/Department/GetDepartmentInfobyComboTree"; }
        }

        /// <summary>
        /// 回调函数——执行添加url地址
        /// </summary>
        private string backDoAdd_url
        {
            get
            {
                return "/Contacts/Department/DoAddDepartmentInfo";
            }
        }

        /// <summary>
        /// 回调函数——执行修改url地址
        /// </summary>
        private string backDoEdit_url
        {
            get
            {
                return "/Contacts/Department/DoEditDepartmentInfo";
            }
        }
        #endregion


        // GET: Contacts/Derpartment
        public ActionResult Index()
        {
            ViewBag.Del_url = del_url;
            ViewBag.ShowEdit = showEdit_url;
            ViewBag.ShowAdd = showAdd_url;
            ViewBag.GetInfo = getInfo_url;
            ViewBag.ShowAddPerson = showAddPerson_url;

            return View();
        }

        /// <summary>
        /// 获取全部群组数据
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentInfobyComboTree()
        {
            //使用ref声明时需要在传入之前为其赋值
            var list_department = departmentBLL.GetListBy(d => d.isDel == false, d => d.DID).ToList();
            //将当前分页查询的转为treegrid集合
            List<Models.EasyUIComboTree_Department> list_comboTree =Models.Department_ViewModel.ToEasyUIComboTree(list_department);
            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(list_comboTree));
        }

        /// <summary>
        /// 获取全部群组数据
        /// json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentInfo()
        {
            //注意此处不做分页
            //int pageSize = int.Parse(Request.Form["rows"]);
            //int pageIndex = int.Parse(Request.Form["page"]);
            //int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_department = departmentBLL.GetListBy(d => d.isDel == false, d => d.DID).ToList();
            //var list_department = departmentBLL.GetPageList(pageIndex, pageSize, ref rowCount, d => d.isDel == false,d=>d.DepartmentName, true).ToList();

            

            //将当前分页查询的转为treegrid集合
            List<Models.EasyUITreeGrid_Department> list_treegrid = Models.Department_ViewModel.ToEasyUITreeGrid(list_department);

            //不做分页
            //PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            //{
            //    total = rowCount,
            //    rows = list_treegrid,
            //    footer = null
            //};


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(list_treegrid));
        }

        public ActionResult ShowEditDepartmentInfo()
        {
            int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id != 0)
            {
                //1 找到指定id的action对象
                var model = departmentBLL.GetListBy(g => g.DID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 
                ViewBag.GetInfo = getInfobyComboTree_rul;
                //ViewBag.Data = model;
                ViewBag.AreaId = model.Area;
                ViewBag.PDID = model.PDID;
                ViewBag.DID = model.DID;
                ViewBag.Name = model.DepartmentName;
                ViewBag.Remark = model.Remark;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction_jqSub = backDoEdit_url;

                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View("ShowAddDepartmentInfo");
            }
            return Content("no");
        }

        public ActionResult ShowAddDepartmentInfo()
        {

            ViewBag.backAction_jqSub = backDoAdd_url;
            ViewBag.GetInfo = getInfobyComboTree_rul;
            return View();
        }



        public ActionResult DoAddDepartmentInfo(P_DepartmentInfo departmentModel)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            departmentModel.isDel = false;
            
            try
            {
                departmentBLL.Create(departmentModel);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        public ActionResult DoEditDepartmentInfo(P_DepartmentInfo departmentModel)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            departmentModel.isDel = false;
            //departmentModel.ModifiedOnTime = DateTime.Now;

            try
            {
                departmentBLL.Update(departmentModel);
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
        public ActionResult DelSoftDepartmentInfos(string ids)
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
            string state = departmentBLL.DelSoftRoleInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        ///<summary>
        ///得到选中任务所包含的群组
        ///</summary>
        ///<returns></returns>
        public ActionResult GetGroupBySMSMission()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int smid = int.Parse(Request["smid"]);
            int rowCount = 0;

            var list_department = departmentBLL.GetPageList(pageIndex, pageSize, ref rowCount, p => p.isDel == false && p.R_Department_Mission.Where(g => g.MissionID == smid).Count() > 0, p => p.DepartmentName, true).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_department,
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));

        }

    }
}