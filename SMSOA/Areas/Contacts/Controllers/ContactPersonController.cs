using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;


namespace SMSOA.Areas.Contacts.Controllers
{
    public class ContactPersonController : Controller
    {
        IP_PersonInfoBLL personInfoBLL { get; set; }
        //IP_GroupBLL groupBLL { get; set; }

        IP_GroupBLL groupBLL { get; set; }

        IP_DepartmentInfoBLL departmentBLL { get; set; }

        // GET: Contacts/ContactPerson
        public ActionResult Index()
        {
            ViewBag.AddContact = "/Contacts/ContactPerson/ShowAddPersonInfo";
            ViewBag.GetContactInfo = "/Contacts/ContactPerson/GetPersonInfo";
            ViewBag.GetGroup_combobox = "/Contacts/Group/GetCombobox4AllGroupInfo";
            //ViewBag.GetGroupInfo = "/Contacts/ContactPerson/GetGroupInfo";
            ViewBag.Del_url = "/Contacts/ContactPerson/DoDelPersonInfo";
            ViewBag.ShowEdit = "/Contacts/ContactPerson/ShowEditPersonInfo";
            ViewBag.Url_Search= "/Contacts/ContactPerson/GetPersonByCondition";
            return View();
        }

        //public ActionResult Test()
        //{

        //}

        

       

        /// <summary>
        /// 为指定的
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult GetPersonDepartmentGroup(Models.ViewModel_PersonDepartmentGroup model)
        {
            bool isOk = false;
            if (model.userId!=null)
            {
                if (model.departmentId != null)
                {
                    //1为该用户赋予所属部门
                    //1.1 根据，分割为数组
                    string[] department_Ids = model.departmentId.Split(',');
                    List<int> list_departmentIdsbyInt = new List<int>();
                    //1.2 将string类型集合转为int类型集合
                    department_Ids.ToList().ForEach(a => list_departmentIdsbyInt.Add(int.Parse(a)));
                    //1.3 为该用户赋予所属部门
                  var result= this.personInfoBLL.SetPerson4Department(int.Parse(model.userId), list_departmentIdsbyInt);
                    if(result)
                    {
                        isOk = true;
                    }
                    else
                    {
                        isOk = false;
                    }
                }
                if(model.groupIds!=null)
                {
                    // 1为该用户赋予所属群组
                    //1.1 根据，分割为数组
                    string[] group_Ids = model.groupIds;
                    List<int> list_groupIdsbyInt = new List<int>();
                    //1.2 将string类型集合转为int类型集合
                    group_Ids.ToList().ForEach(a => list_groupIdsbyInt.Add(int.Parse(a)));
                    //1.3 为该用户赋予所属群组
                    var result = this.personInfoBLL.SetPerson4Group(int.Parse(model.userId), list_groupIdsbyInt);
                    if (result)
                    {
                        isOk = true;
                    }
                    else
                    {
                        isOk = false;
                    }
                }
            }
            
            if(isOk)
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
            
        }

        public ActionResult GetPersonByCondition(PMS.Model.ViewModel.ViewModel_Person_QueryInfo queryModel)
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            
            int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            //判断传入的判断条件
            IQueryable<P_PersonInfo> list_person = null;

            if (queryModel.DID != 0)
            {
                list_person= personInfoBLL.GetListBy(p =>  p.isDel == false && p.P_DepartmentInfo.Where(d => d.DID == queryModel.DID).Count() > 0, p => p.PID);
            }
            if (queryModel.GID != 0)
            {
                list_person = personInfoBLL.GetListBy(p => p.isDel == false && p.P_Group.Where(g => g.GID== queryModel.GID).Count() > 0, p => p.PID);
            }

            if (queryModel.PersonName != null)
            {
                list_person = list_person.Where(p => p.PName.Contains(queryModel.PersonName));
            }

            if (queryModel.PhoneNum != null)
            {
                list_person = list_person.Where(p => p.PhoneNum.Contains(queryModel.PhoneNum));
            }
            //获取筛选后的联系人集合的总数
            rowCount = list_person.Count();
            list_person = list_person.OrderByDescending(a => a.isVIP);
           //list_person.ToList();
           // list_person = list_person.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                //rows = list_person.Select(p => p.ToMiddleModel()).ToList(),
                //rows = list_person.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(p=>p.ToMiddleModel()).ToList() ,
                rows = list_person.ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(p => p.ToMiddleModel()).ToList(),
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }


        public ActionResult GetPersonByGroup()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int gid = int.Parse(Request["gid"]);
            int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            
            var list_person = personInfoBLL.GetPageList(pageIndex, pageSize, ref rowCount, p => p.isDel == false&&p.P_Group.Where(g=>g.GID==gid).Count()>0, p => p.PName, true).ToList().Select(p=>p.ToMiddleModel()).ToList();
            //var content = from p in list_person
            //              select new
            //              {
            //                  PID = p.PID,
            //                  PName = p.PName,
            //                  Remark = p.Remark,
            //                  PhoneNum = p.PhoneNum,

            //              };
            //在分页查询时如何排序，需要讨论
            list_person = list_person.OrderByDescending(a => a.isVIP).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_person,
                footer = null
            };


            //将权限转换为对应的
            return Json(dgModel,JsonRequestBehavior.AllowGet);
            //return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public ActionResult GetPersonByDepartment()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int did = int.Parse(Request["did"]);
            int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值

            var list_person = personInfoBLL.GetPageList(pageIndex, pageSize, ref rowCount, p => p.isDel == false && p.P_DepartmentInfo.Where(d => d.DID == did).Count() > 0, p => p.PName, true).ToList().Select(p=>p.ToMiddleModel()).ToList();
            list_person = list_person.OrderByDescending(a => a.isVIP).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_person,
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public ActionResult GetPersonInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            
            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_person = personInfoBLL.GetPageList(pageIndex, pageSize, ref rowCount, p => p.isDel == false, p => p.PName, true).ToList().Select(p=>p.ToMiddleModel()).ToList();
            //排序，VIP联系人放在前面
            list_person = list_person.OrderByDescending(a => a.isVIP).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_person,
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        //public ActionResult GetGroupInfo()
        //{
        //    int pageSize = int.Parse(Request.Form["rows"]);
        //    int pageIndex = int.Parse(Request.Form["page"]);
        //    int rowCount = 0;

        //    //查询所有的权限
        //    //使用ref声明时需要在传入之前为其赋值
        //    var list_person = groupBLL.GetPageList(pageIndex, pageSize, ref rowCount, g => g.isDel == false, g => g.GroupName, true).ToList();
        //    PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
        //    {
        //        total = rowCount,
        //        rows = list_person,
        //        footer = null
        //    };


        //    //将权限转换为对应的
        //    return Content(Common.SerializerHelper.SerializerToString(dgModel));
        //}

        ///<summary>
        ///编辑联系人操作
        ///</summary>
        ///<return></return>
        public ActionResult DoEditPersonInfo(Models.ViewModel_Person personModel)

        {
            var isVIP = false;
            if(personModel.isVIP == 1) { isVIP = true; }
            if (personInfoBLL.EditValidation(personModel.PID, personModel.PhoneNum)) { return Content("validation fails"); }
                if (personInfoBLL.DoEditPerson(personModel.PID, personModel.PName, personModel.PhoneNum, personModel.Remark, isVIP, false, personModel.GID.ToList(), personModel.DID))
                {
                    return Content("ok");
                }
                else
                {
                    return Content("error");
                }
        }

        public ActionResult DoAddPersonInfo(Models.ViewModel_Person personModel)
        {
            //1 将传入的对象转换为Person对象

            //2 需要根据 传入的联系人对象中所带的部门ID（DID)以及群组ID（数组）获取对应的部门集合以及群组集合
            //6月15日 第一次修改 问题仍无法解决
            // List<int> list_groupIds = personModel.GID.ToList();
            // List<int> list_departmentIds = new List<int>();
            // list_departmentIds.Add(personModel.DID);
            //var list_Group= groupBLL.GetListByIds(list_groupIds);
            // var list_department = departmentBLL.GetListByIds(list_departmentIds);
            // PMS.Model.P_PersonInfo model = new P_PersonInfo()
            // {
            //     PName = personModel.PName,
            //     PID = personModel.PID,
            //     isVIP = false,
            //     isDel = false,
            //     PhoneNum = personModel.PhoneNum,
            //     P_DepartmentInfo = list_department,
            //     P_Group =list_Group
            // };
            var isVIP = false;
            if(personModel.isVIP == 1) { isVIP = true; }
            if (personInfoBLL.AddValidation(personModel.PhoneNum)) { return Content("validation fails"); }
                try
                {
                    //6月15日修改方式二 
                    personInfoBLL.DoAddPerson(personModel.PName, personModel.PhoneNum, personModel.Remark, isVIP, personModel.GID.ToList(), personModel.DID);
                    //personInfoBLL.Create(model);
                    return Content("ok");
                }
                catch
                {
                    return Content("error");
                }
        }

        ///<summary>
        ///删除联系人操作
        ///</summary>
        ///<return></return>
        public ActionResult DoDelPersonInfo()
        {
            //1 获取选中的id集合
            string ids = Request.QueryString["ids"];
            string[] a_id = ids.Split(',');
            List<int> list_PersonIDs = new List<int>();

            foreach (var item in a_id)
            {
                
                list_PersonIDs.Add(int.Parse(item));
               
            }

            //2 软删除操作
            string state =
                personInfoBLL.DelSoftPersonInfos(list_PersonIDs) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        public ActionResult DoDelPersonInfo_All()
        {
            int pid = int.Parse(Request.QueryString["pid"]);
            List<int> list_ids = new List<int>();
            list_ids.Add(pid);
            string state = personInfoBLL.DelSoftPersonAndOtherRelation(list_ids) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        ///<summary>
        ///逻辑删除用户
        ///</summary>
        ///<return></return>
        public ActionResult DelLogicPersonInfos()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            string state =
            personInfoBLL.DeleteLogicPersonInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        /// <summary>
        /// 添加联系人视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddPersonInfo()
        {
            //若传入的是gid（group）群组，说明向指定群组下添加该联系人
            //返回的群组下拉框位选中某一个gid
            string gid = Request["gid"];//若为传入则为null
            //若传入的did（department）部门，说明向指定部门下添加该联系人
            //返回的部门下拉框为选中某一个did
            string did = Request["did"];

            ViewBag.backAction_jqSub = "DoAddPersonInfo";
            //注意获取群组及部门的下拉框对象（json格式）在各自控制器类中
            ViewBag.GID = gid==null?"":gid;
            ViewBag.DID = did == null ? "" : did;
            
            ViewBag.GetAllGroup_combobox = "/Contacts/Group/GetCombobox4AllGroupInfo";
            ViewBag.GetAllGroup_combogrid = "/Contacts/Group/GetComboGridAllGroupInfo";
            ViewBag.GetGroupByGID_combobox = "/Contacts/Group/GetCombobox4GroupInfoByGid";
            ViewBag.GetDepartment_combotree= "/Contacts/Department/GetDepartmentInfo4ComboTree";
            ViewBag.GetDepartmentIdByPid = "/Contacts/Department/GetDepartmentIdInfoByPid";
            ViewBag.GetDepartmentByDID_combotree = "/Contacts/Department/GetCombobox4GroupInfoByDID";
            return View("ShowEditPersonInfo");
        }

        ///<summary>
        ///编辑联系人视图
        ///</summary>
        ///<return></return>
        public ActionResult ShowEditPersonInfo()
        {
            //1 获取选中的联系人
            int id = int.Parse(Request.QueryString["id"]);
            //若传入的是gid（group）群组，说明向指定群组下添加该联系人
            //返回的群组下拉框位选中某一个gid
            string gid = Request["gid"];//若为传入则为null
            //若传入的did（department）部门，说明向指定部门下添加该联系人
            //返回的部门下拉框为选中某一个did
            string did = Request["did"];



            ViewBag.backAction_jqSub = "DoEditPersonInfo";
           
            var model = personInfoBLL.GetListBy(a => a.PID == id).FirstOrDefault();

            did= model.P_DepartmentInfo.FirstOrDefault().DID.ToString();
            //查找当前联系人所属的群组
            var groups = model.P_Group.ToList().Select(g => g.ToMiddleModel());
            string groups_str = "";
            //遍历群组对象
            foreach (var item in groups)
            {                
                groups_str = item.GID + "," + groups_str;
            }
            gid = groups_str;
            //提供显示页面提交时跳转到的用户名称
            //ViewBag.Model = model;
            ViewBag.PID = model.PID;
            ViewBag.PName = model.PName;
            ViewBag.PhoneNum = model.PhoneNum;
            //注意获取群组及部门的下拉框对象（json格式）在各自控制器类中
            ViewBag.GID = gid == null ? "" : gid;
            ViewBag.DID = did == null ? "" : did;
            ViewBag.Remark = model.Remark;
            if (model.isVIP)
            {

                ViewBag.isVIP = 1;
            }
            else
            {
                ViewBag.isVIP = 0;
            }
            ViewBag.GetAllGroup_combobox = "/Contacts/Group/GetCombobox4AllGroupInfo";
            ViewBag.GetAllGroup_combogrid = "/Contacts/Group/GetComboGridAllGroupInfo";
            ViewBag.GetGroupByGID_combobox = "/Contacts/Group/GetCombobox4GroupInfoByGid";
            ViewBag.GetDepartment_combotree = "/Contacts/Department/GetDepartmentInfo4ComboTree";
            ViewBag.GetDepartmentIdByPid = "/Contacts/Department/GetDepartmentIdInfoByPid";
            ViewBag.GetDepartmentByDID_combotree = "/Contacts/Department/GetCombobox4GroupInfoByDID";
            //修改即跳转至修改方法
            ViewBag.backAction = "DoEditPersonInfo";
            return View("ShowEditPersonInfo");
        }



    }
}