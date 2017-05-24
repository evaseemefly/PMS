using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.ViewModel;
using SMSOA.Filters;
using PMS.Model.ViewModel;


namespace SMSOA.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        IUserInfoBLL userInfoBLL { get; set; }

        string cookie_sessionId = "sms_Session";

        //[LoginValidate]
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.UserId = base.LoginUser.ID;
            ViewBag.ResetPwd = "/Admin/User/ResetPwd";
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public /*JsonResult*/ActionResult GetMenuFatherNode()
        {
            int parentId = 0;
            int userId = base.LoginUser.ID;

            //1 从数据库中读取指定的用户对象
            var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
            if (userInfo != null)
            {


                //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
                var list_action = (
                    from r in userInfo.RoleInfo //linq
                    from a in r.ActionInfo
                    select a).ToList();

                //3 获取该用户对象对应的R_UserInfo_ActionInfo导航属性集合
                //list_R_User_Action存储的是userInfoId为1的R_User_Action对象的集合
                var list_R_User_Action = userInfo.R_UserInfo_ActionInfo;
                //4 取出userInfo id为2的用户所对应的Action集合（路线一的方式）

                //4.1 取出isPass为true的所有集合
                var list_action_isPass = (
                   from r in list_R_User_Action
                   where r.isPass == true
                   select r.ActionInfo
                    ).ToList();

                //4.2 将路线一与路线二取出的ActionInfo集合合并
                list_action.AddRange(list_action_isPass);
                //4.3 此时的集合中可能存在重复，去重
                list_action = list_action.Distinct(new PMS.Model.EqualCompare.ActionEqualCompare()).ToList();

                //4.4 取出isPass为false的集合
                var list_action_isNotPass = (
                  from r in list_R_User_Action
                  where r.isPass == false
                  select r.ActionInfo
                   ).ToList();

                //4.5 将现有集合中去掉isPass为false的ActionInfo
                list_action = list_action.Where(a => !list_action_isNotPass.Contains(a)).ToList();

                var list_final = list_action.Where(a => a.ParentID == 0).ToList();
                List<PMS.Model.EasyUIModel.EasyUITreeNode> list_tree = new List<PMS.Model.EasyUIModel.EasyUITreeNode>();
                list_final.ForEach(a => list_tree.Add(new PMS.Model.EasyUIModel.EasyUITreeNode() { id = a.ID, text = a.ActionInfoName }));
                return Content(Common.SerializerHelper.SerializerToString(list_tree));
                //return Json(list_tree);
                
            }
            return Content("0");
            //return Json("0", JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoginOut()
        {
            //1 判断当前请求中的cookies中是否包含了sessionid
            if(Request.Cookies[cookie_sessionId]!=null)
            {
                //1.1 若存在则取出该sessionId中的值
                string key = Request.Cookies[cookie_sessionId].Value;
                //1.2 将该sessionId的缓存从服务器端删除
                Common.MemcacheHelper.Delete(key);
                //1.3 删除响应中的cookie（注意此处不能删除请求中的cookie，而是删除响应中的cookie）
                //2 删除当前cookie中保存的用户名与密码（设置失效时间为负值）
                Response.Cookies["sms_UserName"].Expires = DateTime.Now.AddHours(-1);
                Response.Cookies["sms_UserPwd"].Expires = DateTime.Now.AddHours(-1);

            }
            //3 重定向回登录界面
            return Redirect("/Login/Login/Index");
        }

        public ActionResult GetTopMenuItem(int userId)
        {
            //获取该用户的顶部权限集合
           var list= userInfoBLL.GetActionListByTopBtn(userId).Select(a=>a.ToMiddleModel());

            return PartialView("_Parital_Home_Top_BtnView", list);
        }

        //[LoginValidate]
        public ActionResult GetMenuItem()
        {
            int userId = base.LoginUser.ID;
            //1 从数据库中读取指定的用户对象
            //7月17日重新修改 此方法封装值UserBLL中
            #region 
            //var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
            //if (userInfo != null)
            //{


            //    //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
            //    var list_action = (
            //        from r in userInfo.RoleInfo //linq
            //        from a in r.ActionInfo
            //        select a).ToList();

            //    //from r in userInfo.RoleInfo
            //    //select r.ActionInfo

            //    //3 获取该用户对象对应的R_UserInfo_ActionInfo导航属性集合
            //    //list_R_User_Action存储的是userInfoId为1的R_User_Action对象的集合
            //    var list_R_User_Action = userInfo.R_UserInfo_ActionInfo;
            //    //4 取出userInfo id为2的用户所对应的Action集合（路线一的方式）
            //    //var temp = (
            //    //    from r in list_R_User_Action
            //    //    select r.ActionInfo
            //    //    ).ToList();
            //    //4.1 取出isPass为true的所有集合
            //    var list_action_isPass = (
            //       from r in list_R_User_Action
            //       where r.isPass == true
            //       select r.ActionInfo
            //        ).ToList();

            //    //4.2 将路线一与路线二取出的ActionInfo集合合并
            //    list_action.AddRange(list_action_isPass);
            //    //4.3 此时的集合中可能存在重复，去重
            //    list_action = list_action.Distinct(new PMS.Model.EqualCompare.ActionEqualCompare()).ToList();
            //    // IEqualityComparer<ActionInfo>
            //    //list_action.Distinct()

            //    //4.4 取出isPass为false的集合
            //    var list_action_isNotPass = (
            //      from r in list_R_User_Action
            //      where r.isPass == false
            //      select r.ActionInfo
            //       ).ToList();

            //    //4.5 将现有集合中去掉isPass为false的ActionInfo
            //    list_action = list_action.Where(a => !list_action_isNotPass.Contains(a)).ToList();


            //    //4.6 将action集合转换为树节点集合
            //    List<PMS.Model.EasyUIModel.EasyUITreeNode> list_easyUITreeNode = ActionInfo.ToEasyUITreeNode(list_action);

            //    //4.7 将树节点集合转换为json格式并返回
            //    return Content(Common.SerializerHelper.SerializerToString(list_easyUITreeNode));
            //}
            #endregion
            //封装后写法如下：
            var list= userInfoBLL.GetActionListByUID(userId,false, true);
            //新加入找到默认选中的对象并设置其为选中状态,若没有则返回null
            var action_default = userInfoBLL.GetDefaultActionByUID(userId, true, true);
            //4.6 将action集合转换为树节点集合
            List<PMS.Model.EasyUIModel.EasyUITreeNode> list_easyUITreeNode = ActionInfo.ToEasyUITreeNode(list,action_default);
            #region 不使用以下方式修改节点的选中状态
            ////从集合中取出对应的treenode机器父节点对象
            //var treenode = list_easyUITreeNode.Where(a => a.id == action_default.ID).FirstOrDefault();
            //var treenode_parent = list_easyUITreeNode.Where(a => a.id == action_default.ParentID).FirstOrDefault();
            ////找到其在集合中的位置
            //var index = list_easyUITreeNode.IndexOf(treenode);
            //var index_parent = list_easyUITreeNode.IndexOf(treenode_parent);
            ////修改checked为true
            //treenode.Checked = true;
            //treenode_parent.Checked = true;
            ////替换
            //list_easyUITreeNode[index] = treenode;
            //list_easyUITreeNode[index_parent] = treenode_parent;
            #endregion
            //4.7 将树节点集合转换为json格式并返回
            return Content(Common.SerializerHelper.SerializerToString(list_easyUITreeNode));
            //return null;


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