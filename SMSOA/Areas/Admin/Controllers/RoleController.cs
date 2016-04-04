using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;
using PMS.IBLL;
using SMSOA.Filters;

namespace SMSOA.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        IRoleInfoBLL roleInfoBLL { get; set; }

        IActionInfoBLL actionInfoBLL { get; set; }

        

        void SetDropDonwList()
        {
            //准备请求方式下拉框数据
            ViewBag.httpMethodList = new List<SelectListItem>() {
             new SelectListItem(){ Text="Get",Value="1"},
             new SelectListItem(){ Text="Post",Value="2"},
             new SelectListItem(){ Text="Both",Value="3"}
            };

            /*
             0-无操作 1-easyui连接 2-打开新窗体
             */
            //ViewBag.operationList = new List<SelectListItem>() {
            // new SelectListItem(){ Text="无操作",Value="0"},
            // new SelectListItem(){ Text="easyui连接",Value="1"},
            // new SelectListItem(){ Text="打开新窗体",Value="2"}
            //};
        }

        [Common.Attributes.ViewAttribute]
        [LoginValidate]
        public ActionResult Index()
        {
            ViewBag.Action_GetOption = "/Admin/Action/GetOption";
            ViewBag.Del_url = "/Admin/Role/DelSoftRoleInfos";
            ViewBag.ShowAdd = "/Admin/Role/ShowAddRoleInfo";
            ViewBag.ShowEdit = "/Admin/Role/ShowEditRoleInfo";
            ViewBag.GetInfo = "/Admin/Role/GetRoleInfo";
            ViewBag.SetRole4Action = "/Admin/Role/SetRole4Action";
            return View();
        }

        //为Role-Action  赋值
        /*
            传过来的是Action ID  数组
            还需要传过来一个Role ID 
            即某个权限对应的Action
        */
        public ActionResult SetRole4Action()
        {
            
            //int pageSize = int.Parse(Request.Form["rows"]);
            //int pageIndex = int.Parse(Request.Form["page"]);
            int rid = int.Parse(Request.QueryString["RoleId"]);
            string aIds = Request.QueryString["ids"];
            //if (aIds != null)
            //{
                //2.1根据','分割为数组
                string[] action_Ids = aIds.Split(',');
                List<int> list_actionIds = new List<int>();
                
                foreach (var item in action_Ids)
                {
                if(item!="")
                {
                    list_actionIds.Add(int.Parse(item));
                }                    
                }
                //try
                //{
                    //roleInfoBLL.Update(role);
                    roleInfoBLL.SetRole4Action(rid, list_actionIds);
                    return Content("ok");
                //}
                

                //2.2 修改Role与Action的关系
                //(1)根据RId找到对应的RoleInfo
              // var role= roleInfoBLL.GetListBy(r => r.ID == rid).FirstOrDefault();

              //  role.ActionInfo.Clear();

              //  //(2)根据AId查询对应的ActionInfo
              //var list_action=  actionInfoBLL.GetListBy(a => aIds.Contains(a.ID.ToString())).ToList();
              //  //(3)向查找到的RoleInfo对象写入指定的ActionInfo

              //  foreach (var item in list_action)
              //  {
              //      role.ActionInfo.Add(item);
              //  }

                //list_action.ForEach(a => role.ActionInfo.Add(a));
                
                //catch
                //{
                    //return Content("error");
                //}
                
            //}
            return Content("error");
            
        }



        /// <summary>
        /// 根据传入的Role Id
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult SetRoleAction(string rid)
        {
            //int rid = int.Parse(Request.Form["rid"]);
            
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            if (rid != null)
            {
                //查询被选中的Action
                //1 根据RoleID查询该Role所对应的Action权限
                //1.1查出未删除的role中指定ID的Role
                var role = roleInfoBLL.GetListBy(r => r.DelFlag == false && r.ID == int.Parse(rid)).FirstOrDefault();
                //1.2查出该role中对应的action(ICollection)
                var actions = role.ActionInfo.ToList();
                //2 需要对actions进行分页
                actions = actions.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                //3 将action返回给视图页面，需要添加一个check标签
                List<ActionInfo> list = new List<ActionInfo>();
                foreach (var item in actions)
                {
                    item.Checked = true;
                    list.Add(item);
                }

                //4 
                PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
                {
                    total = rowCount,
                    rows = list,
                    footer = null
                };
                return Content(Common.SerializerHelper.SerializerToString(dgModel));

            }
            return null;
        }

        public ActionResult DoEditRoleInfo(RoleInfo model)
        {
            model.SubTime = DateTime.Now;
            
            if (roleInfoBLL.Update(model))
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }



        public ActionResult DoAddRoleInfo(RoleInfo model)
        {
            //创建一个新的Action方法，需要对未提交的属性进行初始化赋值
            model.DelFlag = false;
            model.SubTime = DateTime.Now;
            model.ModifiedOnTime = DateTime.Now;
           
            try
            {
                roleInfoBLL.Create(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 显示添加权限试图
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddRoleInfo()
        {
            //1 为分布式图中的下拉框添加要请求的地址
            //ViewBag.data = GetOption();
            SetDropDonwList();
            //2 从数据库中获取现有的可选的父级权限
            SetDefualtOptions();
            //提供显示页面提交时跳转到的权限名称
            //新增即跳转至新增页面
            ViewBag.backAction = "DoAddRoleInfo";
            ViewBag.SubTime = DateTime.Now;
            ViewBag.ModityTime = DateTime.Now;
            //将与修改共用的试图页面返回
            return View("ShowEditInfo");
        }

        /// <summary>
        /// 显示编辑当前权限试图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ShowEditRoleInfo(int id)
        {
            //若有传入的id
            //int id = int.Parse(Request["id"]);
            //若有传入的id
            if (id != null)
            {
                //1 找到指定id的action对象
                var model = roleInfoBLL.GetListBy(a => a.ID == id).FirstOrDefault();   //注意记得加FirstOrDefault否则model就是一个集合 
                                                                                         //为分布式图中的下拉框添加要请求的地址
                                                                                         // ViewBag.data = GetOption();//先不用easyui的控件
                                                                                         //2 获取下拉请求类型的列表
                SetDropDonwList();
                //3 获取可选的父级权限列表
                SetDefualtOptions();
                //4 将指定id的action对象传给视图数据字典中的实体
                ViewData.Model = model;
                //5 提供显示页面提交时跳转到的权限名称
                //修改即跳转至修改方法
                ViewBag.backAction = "DoEditRoleInfo";
                //ViewData["actionInfo"] = model;
                //return PartialView("EditActionWindow");
                return View("ShowEditInfo");
            }
            return Content("no");

        }
        // GET: Admin/Action
        /// <summary>
        /// 获取权限集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //查询所有的权限
            //使用ref声明时需要在传入之前为其赋值
            var list_role = roleInfoBLL.GetPageList(pageIndex, pageSize, ref rowCount, a => a.DelFlag == false, a => a.Sort, true).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_role,
                footer = null
            };


            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        public void SetDefualtOptions()
        {
            //查询所有的权限
            var list_role = roleInfoBLL.GetListBy(a => a.DelFlag == false).ToList();

            //将权限集合遍历，创建Option集合
            var list_options = (from a in list_role
                                select new SelectListItem()
                                {
                                    Value = a.ID.ToString(),
                                    Text = a.RoleName
                                }).ToList();
            ViewBag.operationList = list_options;
        }

        /// <summary>
        /// 获取权限下拉菜单中的每一个项
        /// </summary>
        /// <returns></returns>
        public string GetEasyUIOptions()
        {
            //查询所有的权限
            var list_role = roleInfoBLL.GetListBy(a => a.DelFlag == false).ToList();

            //将权限集合遍历，创建Option集合
            var list_option = (from a in list_role
                               select new PMS.Model.EasyUIModel.EasyUIOption()
                               {
                                   id = a.ID,
                                   text = a.RoleName
                               }).ToList();
            //将Option集合序列化
            return Common.SerializerHelper.SerializerToString(list_option);
        }

        /// <summary>
        /// 执行软删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelSoftRoleInfos(string ids)
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
            string state = roleInfoBLL.DelSoftRoleInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }

        /// <summary>
        /// 执行逻辑删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DelLogicRoleInfos()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            string state =
            roleInfoBLL.DeleteLogicRoleInfos(list) == true ? state = "ok" : state = "error";
            return Content(state);
        }
    }
}