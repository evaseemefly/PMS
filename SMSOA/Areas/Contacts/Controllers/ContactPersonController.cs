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

        // GET: Contacts/ContactPerson
        public ActionResult Index()
        {
            ViewBag.AddContact = "/Contacts/ContactPerson/ShowAddPersonInfo";
            ViewBag.GetContactInfo = "/Contacts/ContactPerson/GetPersonInfo";
            //ViewBag.GetGroupInfo = "/Contacts/ContactPerson/GetGroupInfo";
            ViewBag.Del_url = "/Contacts/ContactPerson/DoDelPersonInfo";
            ViewBag.ShowEdit = "/Contacts/ContactPerson/ShowEditPersonInfo";

            return View();
        }

        //public ActionResult Test()
        //{

        //}

        public ActionResult ShowAddPersonInfo()
        {
            ViewBag.backAction = "DoAddPersonInfo";
            return View("ShowAddPersonInfo");
        }

        public ActionResult DoAddPersonInfo(P_PersonInfo personModel)
        {
            try
            {
                personInfoBLL.Create(personModel);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }


        public ActionResult GetPersonInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_person = personInfoBLL.GetPageList(pageIndex, pageSize, ref rowCount, p => p.isDel == false, p => p.PName, true).ToList();
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

        ///<summary>
        ///编辑联系人视图
        ///</summary>
        ///<return></return>
        public ActionResult ShowEditPersonInfo()
        {
            //1 获取选中的联系人
            int id = int.Parse(Request.QueryString["id"]);
            var model = personInfoBLL.GetListBy(a => a.PID == id).FirstOrDefault();
            //提供显示页面提交时跳转到的用户名称
            ViewBag.Model = model;
            //修改即跳转至修改方法
            @ViewBag.backAction = "DoEditPersonInfo";
            return View("ShowEditPersonInfo");
        }

        ///<summary>
        ///编辑联系人操作
        ///</summary>
        ///<return></return>
        public ActionResult DoEditPersonInfo(P_PersonInfo model)
        {

            if (personInfoBLL.Update(model))
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }

    }
}