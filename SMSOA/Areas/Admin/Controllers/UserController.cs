
using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using Common;
using SMSOA.Filters;
using SMSOA.Areas.Admin.Models;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.Admin.Controllers
{
    public class UserController : BaseController
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
            if (userInfoBLL.AddValidation(model.UName)) { return Content("validation fails"); }
                model.DelFlag = false;
                model.SubTime = DateTime.Now;
                model.ModifiedOnTime = DateTime.Now;
                //5月25日补充，对传入的密码进行md5加密
                model.UPwd = Encryption.MD5Encryption(model.UPwd);
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
            var list_user = userInfoBLL.GetPageList(pageIndex, pageSize,ref rowCount, a => a.DelFlag == false, a => a.Sort, true).ToList().Select(u=>u.ToMiddleModel()).ToList();
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
            //数据验证
            if (userInfoBLL.EditValidation(model.ID, model.UName)) { return Content("validation fails"); }

                model.ModifiedOnTime = DateTime.Now;

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
            ViewBag.ID = model.ID;
            ViewBag.SubTime= model.SubTime;
            ViewBag.UName = model.UName;
            ViewBag.UPWd = model.UPwd;
            ViewBag.Remark = model.Remark;
            ViewBag.Sort= model.Sort;
                //修改即跳转至修改方法
                ViewBag.backAction = "DoEditUserInfo";
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
            List<EasyUIDataGrid_Action> list_Datagrid_action = new List<EasyUIDataGrid_Action>();
            int userInfoID = int.Parse(Request.QueryString["id"]);
            var userInfo = userInfoBLL.GetListBy(a => a.ID == userInfoID).FirstOrDefault();
            if (userInfo != null)
            {
                //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
                var list_actionByID = (
                    from r in userInfo.RoleInfo //linq
                    from a in r.ActionInfo
                    select a).ToList();
                //标识出此权限由角色赋予
                foreach(var item in list_actionByID) { item.byRole = true; }

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

                //放入EasyUIDataGrid实体类

                //6 取出isPass为false的集合
                var list_action_isNotPass = (
                  from r in list_R_User_Action
                  where r.isPass == false
                  select r.ActionInfo
                   ).ToList();

                //7 将现有集合中去掉isPass为false的ActionInfo
                list_actionByID = list_actionByID.Where(a => !list_action_isNotPass.Contains(a)).ToList();
                list_actionByID = list_actionByID.Where(a => a.DelFlag == false).ToList();
                list_action_isNotPass = list_action_isNotPass.Where(a => a.DelFlag == false).ToList();
                //8 按照Sort字段进行排序
                list_actionByID.OrderBy(a => a.Sort);
                list_action_isNotPass.OrderBy(a => a.Sort);
                //9. 将所有该用户拥有的（禁用/未禁用）的权限都封装进EasyUI模板类，并加入集合
                foreach (var item in list_actionByID)
                {
                    EasyUIDataGrid_Action datagrid_Action = new EasyUIDataGrid_Action()
                    {
                        AID = item.ID,
                        ActionName = item.ActionInfoName,
                        SubTime = item.SubTime,
                        ModifiedTime = item.ModifiedOnTime,
                        Remark = item.Remark,
                        selected = true,
                        Checked = true,
                        IsPass = true,
                        Text = "启用",
                        byRole = item.byRole
                        
                    };
                    
                    list_Datagrid_action.Add(datagrid_Action);
                }
                //已禁用的
                foreach(var item in list_action_isNotPass)
                {
                    EasyUIDataGrid_Action datagrid_Action = new EasyUIDataGrid_Action()
                    {
                        AID = item.ID,
                        ActionName = item.ActionInfoName,
                        SubTime = item.SubTime,
                        ModifiedTime = item.ModifiedOnTime,
                        Remark = item.Remark,
                        selected = true,
                        Checked = true,
                        IsPass = false,
                        Text = "禁用",
                        byRole = item.byRole
                    };

                    list_Datagrid_action.Add(datagrid_Action);
                }



                //10 得到所有未被删除的权限集合
                var list_allAction = actionInfoBLL.GetListBy(u => u.DelFlag == false);
                //12 排序
                list_allAction.OrderBy(a => a.Sort);

                //14 得到所有的已拥有的权限（包括禁用与启用）
                list_actionByID.AddRange(list_action_isNotPass);

                foreach (var item in list_actionByID)
                {
                    //12 得到改角色未拥有的权限集合
                    list_allAction = list_allAction.Where(a => a.ID != item.ID);
                }

                //13 将所有该用户未拥有的的权限都封装进EasyUI模板类，并加入集合
                foreach (var item in list_allAction)
                {
                    EasyUIDataGrid_Action datagrid_Action = new EasyUIDataGrid_Action()
                    {
                        AID = item.ID,
                        ActionName = item.ActionInfoName,
                        SubTime = item.SubTime,
                        ModifiedTime = item.ModifiedOnTime,
                        Remark = item.Remark,
                        selected = false,
                        Checked = false,
                        IsPass = true,
                        Text = "请选择",
                        byRole = item.byRole
                    };

                    list_Datagrid_action.Add(datagrid_Action);
                }

                string temp = Common.SerializerHelper.SerializerToString(list_Datagrid_action);
                temp = temp.Replace("Checked", "checked");
                return Content(temp);
            }
            return null;

        }
        ///<summary>
        ///用户权限分配
        ///</summary>
        ///<return></return>
        public ActionResult DoAssignActionInfo(Models.ViewModel_UserAction model)
        {
            //1 从URL获取选中的用户ID,以及所添加的权限ID
            var userID = int.Parse(model.UserId);
            var a_actionIDs = model.ActionID;
            var isPassSubmit = model.A_isPasses;

            //2 用逗号分隔每个权限ID和isPass
            List<int> list_actionIDs = new List<int>();
            List<string> list_actionIsPass = new List<string>();
            if(a_actionIDs != null)
            {
                string[] acionIDs = a_actionIDs.Split(',');
                string[] isPassSubmits = isPassSubmit.Split(',');
                foreach (var item in acionIDs)
                {
                    if (item != "")
                    {
                        list_actionIDs.Add(int.Parse(item));

                    }
                }
                foreach (var item in isPassSubmits)
                {
                    if (item != "")
                    {
                        list_actionIsPass.Add(item);

                    }
                }

            }
            //3 更改选中用户与其权限的关系表
            userInfoBLL.SetUser4Action(userID, list_actionIDs, list_actionIsPass);

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


                var list_DataGrid = (
                        from r in list_showRole
                        select new EasyUIDataGrid_Role()
                        {
                            RID = r.ID,
                            RoleName = r.RoleName,
                            SubTime = r.SubTime,
                            ModifiedTime = r.ModifiedOnTime,
                            Remark = r.Remark,
                            Sort = r.Sort,
                            selected = r.Checked,
                            Checked = r.Checked
                    }).ToList();

                string temp = Common.SerializerHelper.SerializerToString(list_DataGrid);
                temp = temp.Replace("Checked", "checked");
                return Content(temp);
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

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            var httpModel = new ViewModel_MyHttpContext()
            {
                Area = "Admin",
                Controller = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString(),
                Action = RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString(),
                Url = Request.Url.ToString()
            };
            return httpModel;
        }
    }
}