using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.BLL;
using PMS.Model;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.Job.Controllers
{
    public class TemplateController : Controller
    {
        IJ_JobTemplateBLL jobTemplateBLL;
        IUserInfoBLL userInfoBLL;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Job/Template
        public ActionResult Index()
        {
            //测试用
            //jobTemplateBLL = new J_JobTemplateBLL();
            //var list= jobTemplateBLL.GetListBy(j => j.isDel==false).ToList();
            //return View();
            ViewBag.ShowAdd = "ShowAddTemplate";
            ViewBag.ShowEdit = "ShowEditTemplate";
            ViewBag.Del_url = "DelJobTemplate";
            ViewBag.GetInfo = "GetAllJobTemplate";
            ViewBag.ShowByUser = "GetJobTemplateByUser";
            ViewBag.ShowByRole = "GetJobTemplateByRole";
            ViewBag.ShowSetTemplate = "ShowSetTemplate4User";
            ViewBag.DoSetTemplate = "DoSetTemplate";
            return View();

        }
        #region 返回给前台的显示
        /// <summary>
        /// 获取全部的模板
        /// </summary>
        /// <returns></returns>
        public ContentResult GetAllJobTemplate()
        {

            //1.得到所有模板
            var list_jobTemplate = jobTemplateBLL.GetAllJobTemplate();
            //此处注释掉，因为如果BLL返回的模板为null，这个语句会出现空指针异常错误
            //var list_jobTemplate = jobTemplateBLL.GetAllJobTemplate().Select(j => j.ToMiddleModel()).ToList(); ;
            if (list_jobTemplate == null) { return Content("error"); }
            //2.转为中间件
            var list_Middle_model = list_jobTemplate.Select(j => j.ToMiddleModel()).ToList();

            //3.序列化
            return Content(Common.SerializerHelper.SerializerToString(list_Middle_model));
        }

        /// <summary>
        /// 根据传入的uid查询该uid拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ContentResult GetJobTemplateByUser(int uid)
        {
            var list_jobTemplate = jobTemplateBLL.GetJobTemplateByUser(uid);
            if (list_jobTemplate == null) { return Content("error"); }
            list_jobTemplate.Select(p => p.ToMiddleModel()).ToList();
            return Content(Common.SerializerHelper.SerializerToString(list_jobTemplate));
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ContentResult GetJobTemplateByRole(int rid)
        {
            var list_jobTemplate = jobTemplateBLL.GetJobTemplateByRole(rid);
            if (list_jobTemplate == null) { return Content("error"); }
            list_jobTemplate.Select(p => p.ToMiddleModel()).ToList();
            return Content(Common.SerializerHelper.SerializerToString(list_jobTemplate));
        }

        /// <summary>
        /// 添加模板的前台展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddTemplate()
        {
            ViewBag.backAction_jqSub = "AddJobTemplate";
            //此处需要添加返回的视图！
            return View("ShowEditTemplate");
        }
        /// <summary>
        /// 编辑模板的前台展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditTemplate(int id)
        {
            var model = jobTemplateBLL.GetListBy(j => j.JTID.Equals(id)).FirstOrDefault();
            ViewBag.JTID = model.JTID;
            ViewBag.JTName = model.JTName;
            ViewBag.JobClassName = model.JobClassName;
            ViewBag.CronStr = model.CronStr;
            ViewBag.JobType = model.JobType;
            ViewBag.Remark = model.Remark;
            ViewBag.JobGroup = model.JobGroup;
            ViewBag.backAction_jqSub = "EditJobTemplate";

            //此处需要添加返回的视图！
            return View();
        }
        #endregion

        #region 增删改执行方法
        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddJobTemplate(ViewModel_JobTemplate model)
        {
            //1. 数据验证
            if (jobTemplateBLL.AddValidation(model.JobClassName)) { return Content("validation fails"); }
            //2. 默认为default
            if(model.JobGroup == null) { model.JobGroup = "defalut"; }

            //3. 添加模板
            try
            {
                jobTemplateBLL.AddJobTemplate(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
            
        }

        /// <summary>
        /// 编辑模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            //1. 数据验证
            if (jobTemplateBLL.EditValidation(model.JTID, model.JobClassName)) { return Content("validation fails"); }
            //2. 编辑模板

            try
            {
                jobTemplateBLL.EditJobTemplate(model);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public ActionResult DelJobTemplate(string JTIDs)
        {
            string ids = Request.QueryString["ids"];
            var list_JTID = ids.Split(',').Select(t => int.Parse(t)).ToList();
            try
            {
                jobTemplateBLL.DelJobTemplate(list_JTID);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
            
        }

        #endregion


        #region 分配模板
        /// <summary>
        /// 为用户分配模板-------加载时显示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowSetTemplate4User()
        {
            int JTID = int.Parse(Request.QueryString["id"]);
            int rowCount = 0;

            if(JTID > 0)
            {
                //1. 查出指定id的作业模板
                var jobTemplate = jobTemplateBLL.GetListBy(j => j.isDel == false && j.JTID.Equals(JTID)).FirstOrDefault();
                //2. 得到该模板已经分配的用户列表
                var list_UserInfo = jobTemplate.UserInfoes.ToList();
                //3. 得到所有用户列表
                var list_All_UserInfo = userInfoBLL.GetListBy(u => u.DelFlag == false);
                //4. 获取总条数
                rowCount = list_All_UserInfo.Count();
                List<UserInfo> list = new List<UserInfo>();
                foreach(var item in list_UserInfo)
                {
                    item.Checked = true;
                    //5. 剔除该模板已有的用户
                    list_All_UserInfo = list_All_UserInfo.Where(u => u.ID != item.ID);
                    list.Add(item);
                }

                list.AddRange(list_All_UserInfo);
                //6. 转为中间件
                list = list.Select(u => u.ToMiddleModel()).ToList();
                string temp = Common.SerializerHelper.SerializerToString(list);
                temp = temp.Replace("Checked", "checked");
                return Content(temp);
            }
            return null;
        }

        /// <summary>
        /// 执行分配模板操作
        /// </summary>
        /// <returns></returns>
        public ActionResult DoSetTemplate()
        {
            //1. 得到传回的作业模板ID
            int JTID = int.Parse(Request.QueryString["UserId"]);
            //2. 得到选中的用户ID
            string aIds = Request.QueryString["ids"];
            //3. 变为ID列表
            string[] user_Ids = aIds.Split(',');
            List<int> list_userIds = new List<int>();
            foreach (var item in user_Ids)
            {
                if (item != "")
                {
                    list_userIds.Add(int.Parse(item));
                }
            }
            //4 调用分配模板的方法
            if (jobTemplateBLL.SetTemplate4UserInfo(JTID, list_userIds))
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }
        #endregion
    }
}