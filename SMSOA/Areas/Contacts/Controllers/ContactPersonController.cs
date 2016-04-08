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
            //ViewBag.AddContact = "/Contacts/ContactPerson/ShowAddPersonInfo";
            //ViewBag.GetContactInfo = "/Contacts/ContactPerson/GetPersonInfo";
            //ViewBag.GetGroupInfo = "/Contacts/ContactPerson/GetGroupInfo";
            
            return View();
        }

        //public ActionResult Test()
        //{

        //}

        public ActionResult ShowAddPersonInfo()
        {
            ViewBag.backAction = "DoAddPersonInfo";
            return View();
        }

        public ActionResult DoAddPersonInfo(P_PersonInfo personModel)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            personModel.isDel = false;
            personModel.isVIP = false;
            
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

    }
}