using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.BLL;
using PMS.Model.EasyUIModel;
using PMS.Model.ViewModel;
using QuartzJobFactory;

namespace SMSOA.Areas.Job.Controllers
{
    public class InstanceController : Admin.Controllers.BaseController
    {
        IJ_JobInfoBLL jobInfoBLL { get; set; }
        IJ_JobTemplateBLL jobTemplateBLL { get; set; }

        IJobService jobService { get; set; }

        //IJ_JobInfoBLL jobBLL = new J_JobInfoBLL();
        //IJ_JobTemplateBLL jobTemplateBLL = new J_JobTemplateBLL();
        // GET: Job/Instance

        public ViewResult Index()
        {
            ViewBag.LoginUserID = GetUserId();
            ViewBag.GetJobInfoByUser = "GetJobInfoByUser";
            ViewBag.ShowCreateWin = "ShowAddInstance";
            ViewBag.ShowEditWin = "ShowEditInstance";
            return View();
        }

        /// <summary>
        /// 显示添加界面
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ViewResult ShowAddInstance(int uid)
        {
            ViewBag.LoginUserID = uid;
            ViewBag.backAction = "DoAddJobInfo";
            ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
            ViewBag.GetJobTemplate4Combo = "/Job/Instance/GetJobTemplate4Combo";
            return View("ShowEditInstance");
        }

        /// <summary>
        /// 获取当前的登录用户
        /// </summary>
        /// <returns></returns>
        private int GetUserId()
        {
           int LoginUserID = -999;
            //若父控制器中的登录用户不为空
            if (base.LoginUser != null)
            {
                //获取登录用户的id
                LoginUserID = base.LoginUser.ID;
            }
            return LoginUserID;
        }

        /// <summary>
        /// 显示修改界面
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ViewResult ShowEditInstance(int uid)
        {
            #region 获取当前的登录用户——封装为一个方法——以下注释掉
            //ViewBag.LoginUserID = -999;
            ////若父控制器中的登录用户不为空
            //if (base.LoginUser != null)
            //{
            //    //获取登录用户的id
            //    ViewBag.LoginUserID = base.LoginUser.ID;
            //}
            #endregion

            ViewBag.LoginUserID= GetUserId();
            ViewBag.backAction = "DoEditJobInfo";
            ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
            ViewBag.GetJobTemplate4Combo = "/Job/Instance/GetJobTemplate4Combo";
            return View();
        }

        /// <summary>
        /// 执行添加作业方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoAddJobInfo(PMS.Model.J_JobInfo model)
        {
            //if (jobInfoBLL.EditValidation(model.JID, model.JobName)) { return Content("validation fails"); }
            //1 将状态写入数据库
            if (model.NextRunTime <= DateTime.MinValue)
            {
                model.NextRunTime = DateTime.Now;
            }
            
            model.EndRunTime = model.StartRunTime.AddMinutes(1);
            model.CreateTime = DateTime.Now;
            model.JobState = Convert.ToInt32(PMS.Model.Enum.JobState_Enum.running);

            if (jobInfoBLL.Create(model))
            {
                //注意：
                //在创建之后此model中的JID已经有值了，可以直接获取该JID的值
                //2 操作Quartz操作类
                jobService.AddScheduleJob(model);
                return Content("ok");
            }
            
            else
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 执行修改作业方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoEditJobInfo(PMS.Model.J_JobInfo model)
        {
            if (jobInfoBLL.EditValidation(model.JID, model.JobName)) { return Content("validation fails"); }
            
            if (jobInfoBLL.Update(model))
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }

        /// <summary>
        /// 根据传入的uid获取作业集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetJobInfoByUser(int uid)
        {
            //string uid_str = Request.Form["uid"];
            //string uid_str = uid;
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            //分页查询全部用户
            //使用三元运算符判断当前请求中是否包含了uid
            //var list = jobInfoBLL.GetJobInfoByPage(pageIndex, pageSize,ref rowCount, true, true,uid_str!=null?int.Parse(uid_str):-1);
            var list = jobInfoBLL.GetJobInfoByPage(pageIndex, pageSize, ref rowCount, true, true, uid);

            EasyUIDataGrid dgModel = new EasyUIDataGrid()
            {
                total = rowCount,
                rows = list,
                footer = null
            };

            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        /// <summary>
        /// 根据选中的作业模板id获取作业模板中的数据
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public ActionResult GetJobTemplateDataByTemplate(int JTID)
        {
            //获取对应的作业模板
            var data = jobTemplateBLL.GetListBy(t => t.JTID == JTID).FirstOrDefault();
           // var data_midlle= data.ToMiddleModel();
           //此处不转为中间变量转为ViewModel中间对象
           ViewModel_JobTemplate data_vm = new ViewModel_JobTemplate()
            {
                CronStr = data.CronStr,
                JobClassName = data.JobClassName,
                JobType = data.JobType
            };
            return Content(Common.SerializerHelper.SerializerToString(data_vm)); 
        }

        /// <summary>
        /// 根据用户id获取作业模板下拉框中的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetJobTemplate4Combo(int uid)
        {

            //1 查询当前用户所拥有的作业模板（作业种类）
           var list_jobTemplateByUser =jobTemplateBLL.GetJobTemplateByUser(uid);
           
            List<EasyUICombobox> list_combox = new List<EasyUICombobox>();
            //2 转成combox集合
            list_combox = (from d in list_jobTemplateByUser
                           select new EasyUICombobox()
                           {
                               id = d.JTID,
                               text = d.JTName
                           }).ToList();
            //3 序列化返回
            return Content(Common.SerializerHelper.SerializerToString(list_combox));
            
        }

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            throw new NotImplementedException();
        }
    }
}