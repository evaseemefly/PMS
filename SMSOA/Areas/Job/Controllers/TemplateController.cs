using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.BLL;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.Job.Controllers
{
    public class TemplateController : Controller
    {
        IJ_JobTemplateBLL jobTemplateBLL;
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
            ViewBag.JobClassName = model.JobClassName;
            ViewBag.CronStr = model.CronStr;
            ViewBag.JobType = model.JobType;
            ViewBag.Remark = model.Remark;
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
            //2. 添加模板

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
    }
}