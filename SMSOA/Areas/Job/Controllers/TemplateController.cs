using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.BLL;

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
            jobTemplateBLL = new J_JobTemplateBLL();
           var list= jobTemplateBLL.GetListBy(j => j.isDel==false).ToList();
            return View();
        }

        /// <summary>
        /// 获取全部的模板
        /// </summary>
        /// <returns></returns>
        public ContentResult GetAllJobTemplate()
        {
            return Content("");
        }

        /// <summary>
        /// 根据传入的uid查询该uid拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ContentResult GetJobTemplateByUser(int uid)
        {
            return Content("");
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ContentResult GetJobTemplateByRole(int rid)
        {
            return Content("");
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            return null;
        }

        /// <summary>
        /// 编辑模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            return null;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public ActionResult DelJobTemplate(int JTID)
        {
            return null;
        }
    }
}