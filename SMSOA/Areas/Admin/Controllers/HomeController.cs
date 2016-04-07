using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using SMSOA.Filters;


namespace SMSOA.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        IUserInfoBLL userInfoBLL { get; set; }

        [LoginValidate]
        // GET: Admin/Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        //[LoginValidate]
        public ActionResult GetMenuItem()
        {
            int userId = 3;
            //1 从数据库中读取指定的用户对象
            var userInfo = userInfoBLL.GetListBy(u => u.ID == userId).FirstOrDefault();
            if (userInfo != null)
            {


                //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
                var list_action = (
                    from r in userInfo.RoleInfo //linq
                    from a in r.ActionInfo
                    select a).ToList();

                //from r in userInfo.RoleInfo
                //select r.ActionInfo

                //3 获取该用户对象对应的R_UserInfo_ActionInfo导航属性集合
                //list_R_User_Action存储的是userInfoId为1的R_User_Action对象的集合
                var list_R_User_Action = userInfo.R_UserInfo_ActionInfo;
                //4 取出userInfo id为2的用户所对应的Action集合（路线一的方式）
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

                //4.2 将路线一与路线二取出的ActionInfo集合合并
                list_action.AddRange(list_action_isPass);
                //4.3 此时的集合中可能存在重复，去重
                list_action = list_action.Distinct(new PMS.Model.EqualCompare.ActionEqualCompare()).ToList();
                // IEqualityComparer<ActionInfo>
                //list_action.Distinct()

                //4.4 取出isPass为false的集合
                var list_action_isNotPass = (
                  from r in list_R_User_Action
                  where r.isPass == false
                  select r.ActionInfo
                   ).ToList();

                //4.5 将现有集合中去掉isPass为false的ActionInfo
                list_action = list_action.Where(a => !list_action_isNotPass.Contains(a)).ToList();
                

                //4.6 将action集合转换为树节点集合
                List<PMS.Model.EasyUIModel.EasyUITreeNode> list_easyUITreeNode = ActionInfo.ToEasyUITreeNode(list_action);

                //4.7 将树节点集合转换为json格式并返回
                return Content(Common.SerializerHelper.SerializerToString(list_easyUITreeNode));
            }
            return null;


        }




    }
}