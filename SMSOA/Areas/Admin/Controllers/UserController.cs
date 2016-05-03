
using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using SMSOA.Filters;

namespace SMSOA.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserInfoBLL userInfoBLL { get; set; }
        IActionInfoBLL actionInfoBLL { get; set; }
        IRoleInfoBLL roleInfoBLL { get; set; }


        //[Common.Attributes.ViewAttribute]
        //[LoginValidate]
        public ActionResult Index()
        {
            ViewBag.ShowAssignRoleInfo = "/Admin/User/ShowAssignRoleInfo";
            ViewBag.DoAssignRoleInfo = "/Admin/User/DoAssignRoleInfo";
            ViewBag.ShowAssignActionInfo = "/Admin/User/ShowAssignActionInfo";
            ViewBag.DoAssignActionInfo = "/Admin/User/DoAssignActionInfo";
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
            //model.Remark = "";
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
            var list_user = userInfoBLL.GetPageList(pageIndex, pageSize, a => a.DelFlag == false, a => a.Sort, true).ToList().Select(u=>u.ToMiddleModel()).ToList();
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

                //1 找到指定id的action对象
                var model = userInfoBLL.GetListBy(a => a.ID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 

                //提供显示页面提交时跳转到的用户名称
                ViewData.Model = model;
                //修改即跳转至修改方法
                @ViewBag.backAction = "DoEditUserInfo";
                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View("ShowEditInfo");

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


        ///<summary>
        ///显示用户权限分配视图
        ///</summary>
        ///<return></return>
        public ActionResult ShowAssignActionInfo()
        {
            //1.从id中获取选中的用户数据
            int userInfoID = int.Parse(Request.QueryString["id"]);
            var userInfo = userInfoBLL.GetListBy(a => a.ID == userInfoID).FirstOrDefault();
            if (userInfo != null)
            {
                //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
                var list_actionByID = (
                    from r in userInfo.RoleInfo //linq
                    from a in r.ActionInfo
                    select a).ToList();
                var list_R_User_Action = userInfo.R_UserInfo_ActionInfo;
                //3 取出userInfo id为2的用户所对应的Action集合（路线一的方式）
                //var temp = (
                //    from r in list_R_User_Action
                //    select r.ActionInfo
                //    ).ToList();
                //4.1 取出isPass为true的所有集合
                var list_action_isPass = (
                   from r in list_R_User_Action
                   where r.isPass == true
                   select r.ActionInfo
                    ).ToList();
                //4 将路线一与路线二取出的ActionInfo集合合并
                list_actionByID.AddRange(list_action_isPass);
                //5 此时的集合中可能存在重复，去重
                list_actionByID = list_actionByID.Distinct(new PMS.Model.EqualCompare.ActionEqualCompare()).ToList();
                // IEqualityComparer<ActionInfo>
                //list_action.Distinct()

                //6 取出isPass为false的集合
                var list_action_isNotPass = (
                  from r in list_R_User_Action
                  where r.isPass == false
                  select r.ActionInfo
                   ).ToList();

                //7 将现有集合中去掉isPass为false的ActionInfo
                list_actionByID = list_actionByID.Where(a => !list_action_isNotPass.Contains(a)).ToList();
                //8 按照Sort字段进行排序
                list_actionByID.OrderBy(a => a.Sort);

                //9 得到所有未被删除的权限集合
                var list_allAction = actionInfoBLL.GetListBy(u => u.DelFlag == false);
                //10 排序
                list_allAction.OrderBy(a => a.Sort);

                //11 调整顺序，使已拥有的集合在集合的前面
                List<ActionInfo> list_showAction = new List<ActionInfo>();
                foreach (var item in list_actionByID)
                {
                    item.Checked = true;
                    //12 得到改角色未拥有的权限集合
                    list_allAction = list_allAction.Where(a => a.ID != item.ID);
                    list_showAction.Add(item);
                }
                //13 加到列表的末尾
                list_showAction.AddRange(list_allAction);


                var list_Combobox = (
                         from r in list_showAction
                         select new PMS.Model.EasyUIModel.EasyUICombobox()
                         {
                             id = r.ID,
                             text = r.ActionInfoName,
                             selected = r.Checked
                         }).ToList();

                return Content(Common.SerializerHelper.SerializerToString(list_Combobox));
            }
            return null;

        }
        ///<summary>
        ///用户权限分配
        ///</summary>
        ///<return></return>
        public ActionResult DoAssignActionInfo(ActionInfo model)
        {
            //1 从URL获取选中的用户ID,以及所添加的权限ID
            int userID = int.Parse(Request.QueryString["UserID"]);
            string a_actionIDs = Request.QueryString["ids"];

            //2 用逗号分隔每个权限ID
            string[] acionIDs = a_actionIDs.Split(',');
            List<int> list_actionIDs = new List<int>();
            foreach(var item in acionIDs)
            {
                if (item != "")
                {
                    list_actionIDs.Add(int.Parse(item));

                }
            }
            //3 更改选中用户与其权限的关系表
            userInfoBLL.SetUser4Action(userID, list_actionIDs);

            return Content("ok");
        }
        ///<summary>
        ///显示用户角色分配视图
        ///</summary>
        ///<return></return>
        public ActionResult ShowAssignRoleInfo()
        {
            //1 从ID得到用户数据
            int userInfoID = int.Parse(Request.QueryString["id"]);
            var userInfo = userInfoBLL.GetListBy(a => a.ID == userInfoID).FirstOrDefault();
            //2 判断用户是否为空
            if (userInfo != null)
            {
                //3 得到该用户的未被删除的角色数据
                var list_role = (
                    from r in userInfo.RoleInfo
                    where r.DelFlag == false
                    select r).ToList();
                //4 排序
                //Combobox有可能按照ID排序，下面方法暂时保留
                list_role.OrderBy(a => a.Sort);

                //5 得到所有未被删除的角色集合
                var list_allRole = roleInfoBLL.GetListBy(u => u.DelFlag == false);
                list_allRole.OrderBy(a => a.Sort);

                //7 调整顺序，使已拥有的集合在集合的前面
                List<RoleInfo> list_showRole = new List<RoleInfo>();
                foreach (var item in list_role)
                {
                    item.Checked = true;
                    list_allRole = list_allRole.Where(a => a.ID != item.ID);
                    list_showRole.Add(item);
                }
                //8 加到列表的末尾
                list_showRole.AddRange(list_allRole);


                var list_Combobox = (
                        from r in list_showRole
                        select new PMS.Model.EasyUIModel.EasyUICombobox()
                        {
                            id = r.ID,
                            text = r.RoleName,
                            selected = r.Checked
                    }).ToList();

                return Content(Common.SerializerHelper.SerializerToString(list_Combobox));
            }
            return null;
        }
        ///<summary>
        ///用户角色分配
        ///</summary>
        ///<return></return>
        public ActionResult DoAssignRoleInfo()
        {
            //1 从URL获取选中的用户ID,以及所添加的角色ID
            int userID = int.Parse(Request.QueryString["UserID"]);
            string a_roleIDs = Request.QueryString["ids"];
       
                //2 用逗号分隔每个角色ID
               string[] roleIDs = a_roleIDs.Split(',');
                List<int> list_roleIDs = new List<int>();
                foreach(var item in roleIDs)
                {
                    if(item != "")
                    {
                    list_roleIDs.Add(int.Parse(item));

                    }
                }
                //3 更改选中用户与其角色的关系表
                userInfoBLL.SetUser4Role(userID, list_roleIDs);

                return Content("ok");
        }

    }
}