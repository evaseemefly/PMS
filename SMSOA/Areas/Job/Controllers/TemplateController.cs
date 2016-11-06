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
            ViewBag.ShowAdd = "ShowAddJobTemplate";
            ViewBag.ShowEdit = "ShowEditJobTemplate";
           
            ViewBag.ShowALL = "GetAllJobTemplate";
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
            list_jobTemplate.Select(j => j.ToMiddleModel()).ToList();
            return Content(Common.SerializerHelper.SerializerToString(list_jobTemplate));
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
        public ActionResult ShowAddJobTemplate()
        {
            ViewBag.backAction = "AddJobTemplate";
            //此处需要添加返回的视图！
            return View("");
        }
        /// <summary>
        /// 编辑模板的前台展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditJobTemplate()
        {
            ViewBag.backAction = "EditJobTemplate";
            //此处需要添加返回的视图！
            return View("");
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
            if (JTIDs.Length == 0)
            {
                return Content("ok");
            }
            else
            {


                string[] ids = JTIDs.Split(',');
                List<int> list_JTID = new List<int>();
                foreach (var item in ids)
                {
                    list_JTID.Add(int.Parse(item));
                }
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
        }

#endregion
    }
}