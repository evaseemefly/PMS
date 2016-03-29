
using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;

namespace SMSOA.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserInfoBLL userInfoBLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        ///<summary>
        ///创建用户
        ///</summary>
        ///<return></return>
        public ActionResult DoAddUserInfo(UserInfo model)
        {
            model.DelFlag = false;
            model.SubTime = DateTime.Now;
            model.ModifiedOnTime = DateTime.Now;
            try
            {
                userInfoBLL.Create(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }

        }
        ///<summary>
        /// 显示添加用户
        ///</summary>
        ///<return></return>
        public ActionResult ShowAddUserInfo()
        {
            ViewBag.backAction = "DoAddUserInfo";
            ViewBag.SubTime = DateTime.Now;
            ViewBag.ModityTime = DateTime.Now;
            return View("ShowEditInfo");
        }
        







        ///<summary>
        ///获取用户集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //查询所有用户
            var list_user = userInfoBLL.GetPageList(pageIndex, pageSize, a => a.DelFlag == false, a => a.Sort, true).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_user,
                footer = null
            };

            //将用户列表转换为Json格式
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        ///<summary>
        ///编辑用户
        ///</summary>
        ///<return></return>
        public ActionResult DoEditUserInfo(UserInfo model)
        {
            model.SubTime = DateTime.Now;

            if (userInfoBLL.Update(model))
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }
        ///<summary>
        ///显示编辑用户视图
        ///</summary>
        ///<pargram name="id"></pargram>
        ///<return></return>
        public ActionResult ShowEditUserInfo(int id)
        {
            //若有传入的id
            //int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id != null)
            {
                //1 找到指定id的action对象
                var model = userInfoBLL.GetListBy(a => a.ID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 

                ViewData.Model = model;
                //提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                @ViewBag.backAction = "DoEditUserInfo";
                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View("ShowEditInfo");
            }
            return Content("no");

        }
        ///<summary>
        ///软删除用户
        ///</summary>
        ///<return></return>
        public ActionResult DelSoftUserInfos(string ids)
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
            string state = 
                userInfoBLL.DelSoftUserInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }


        ///<summary>
        ///逻辑删除用户
        ///</summary>
        ///<return></return>
        public ActionResult DelLogicUserInfos()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            string state =
            userInfoBLL.DeleteLogicUserInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }
    }
}