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
            ViewBag.ShowMenuButton_Add = "GetJobTemplate4MenuButton";
            ViewBag.DoRecovery = "DoRecoveryJob";
            ViewBag.DoPause = "DoPauseJob";
            ViewBag.DoEndJob = "DoEndJob";
            return View();
        }

        /// <summary>
        /// 根据用户ID获取该用户拥有的模板
        /// </summary>
        /// <returns></returns>
        public ActionResult GetJobTemplate4MenuButton(int uid)
        {
                //1. 得到当前用户拥有的模板
                var list_jobTemplate = jobTemplateBLL.GetJobTemplateByUser(uid);
                //2. 去掉其中设置为不显示的模板
                var list_jobTemplate4MenuButton = list_jobTemplate.Where(j => j.isBtn == true).Select(j=>j.ToMiddleModel());
                
                
                return PartialView("_Partial_JobIns_MenuButtonView", list_jobTemplate4MenuButton);
        }


        public ViewResult DoEditTest()
        {
            var targetJob = jobInfoBLL.GetListBy(j => j.JID == 36).FirstOrDefault();
            if (targetJob != null)
            {
                targetJob.JobState = 2;

            }
            jobInfoBLL.Update(targetJob);
            return null;
        }

        /// <summary>
        /// 显示添加界面
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ViewResult ShowAddInstance()
        {
            int uid = GetUserId();
            //1.获取类型
            var jopType = int.Parse(Request.QueryString["jopType"]);
            //var jopType = Int32.Parse(Request.QueryString["jopType"]);
            ViewBag.LoginUserID = uid;
            ViewBag.jobType = jopType;
            ViewBag.backAction = "DoAddJobInfo";
            ViewBag.isMMs = (jopType == (int)PMS.Model.Enum.JobType_Enum.mmsqueryJob) ? "mms" : "sms";
            ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
           // ViewBag.GetJobTemplate4Combo = "/Job/Instance/GetJobTemplate4Combo";
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
        public ViewResult ShowEditInstance()
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
            int uid = GetUserId();
            //1.获取类型
            var jopType = int.Parse(Request.QueryString["jopType"]);
			//需要修改为根据枚举判断
            switch(jopType)
            {
                case 0:
                    ViewBag.backAction = "DoEditJobInfo";
                    ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
                    break;
                case 1:
                ViewBag.backAction = "DoEditJobInfo";
                ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
                    break;
                case 2:
                ViewBag.backAction = "DoEditJobInfo";
                ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
                    break;
                case 99:
                    ViewBag.backAction = "DoEditJobInfo";
                    ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
                    break;
            }

            
            ViewBag.backAction = "DoEditJobInfo";
            ViewBag.GetJobTemplateData = "/Job/Instance/GetJobTemplateDataByTemplate";
            //ViewBag.GetJobTemplate4Combo = "/Job/Instance/GetJobTemplate4Combo";
            return View("ShowEditInstance");
        }

        /// <summary>
        /// 执行添加作业方法
        /// 1 先向数据库中的JobInfo表中写入相应数据（手动赋予JobState属性为running）
        /// 2 执行Quartz的新添作业方法
        /// 3 之前未注意到：
        /// 需要获取发送信息的内容，以及查询时保存的一些参数（先实现发送信息的内容）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ContentResult DoAddJobInfo(PMS.Model.J_JobInfo/*ViewModel_JobInfo*/ model)
        {

            //***此时传入的model中已经包含了uid的值了
            string ismms = Request["isMMS"].ToString();
           // string ismms = "sms";
            if (model.NextRunTime <= DateTime.MinValue)
            {
                model.NextRunTime = DateTime.Now;
            }
            if (model.EndRunTime <= DateTime.MinValue)
            {
                model.EndRunTime = DateTime.MaxValue;
            }

           // model.EndRunTime = model.StartRunTime.AddMinutes(1);
            model.CreateTime = DateTime.Now;
            //创建时手动添加该作业的状态
            model.JobState = Convert.ToInt32(PMS.Model.Enum.JobState_Enum.running);
            model.Interval_quartz = Common.Config.QueryQuartzConfigHelper.GetIntervalQueryAgain();
            //注意需要修改此bll中实现的方法，不仅创建J_JobInfo还要创建与UserInfo的关联关系
            //***注意此时的顺序是先向数据库中的JobInfo表写入再执行Quartz操作（向数据库中写入后model中会有JID）——但应该先执行Quartz的添加作业操作****
            //1 将状态写入数据库
            //测试彩信查询

            //2017-04-26 casablanca
            //将是否为短信的标记符放在该JobDataModel中
            var mmsModel = new PMS.Model.JobDataModel.QueryJobDataModel()
            {
                JobDataValue = ismms/* model.isMMS*/

            };
            var response = jobInfoBLL.AddJobInfo(model,mmsModel);
            return this.ToResponse(response);

            //11月20日 备注掉
            #region 
            //if (jobInfoBLL.AddJobInfo(model).Success)
            //{
            //    //注意：
            //    //在创建之后此model中的JID已经有值了，可以直接获取该JID的值
            //    //2 操作Quartz操作类
            //    //PMS.Model.SMSModel.SMSModel_Send data_temp = new PMS.Model.SMSModel.SMSModel_Send();

            //    //jobService.AddScheduleJob(model, data_temp);
            //    return Content("ok");
            //}

            //else
            //{
            //    return Content("error");
            //}
            #endregion

        }

        /// <summary>
        /// 暂停作业
        /// </summary>
        /// <returns></returns>
        public ContentResult DoPauseJob(int jid)
        {
            //1 执行暂停作业操作
           var response= jobInfoBLL.PauseJob(jid);
            return this.ToResponse(response);
        }

        /// <summary>
        /// 恢复指定作业
        /// </summary>
        /// <returns></returns>
        public ContentResult DoRecoveryJob(int jid)
        {
            //1 执行恢复指定作业的操作
            var response= jobInfoBLL.ResumeJob(jid);
            return this.ToResponse(response);
        }

        

        /// <summary>
        /// 结束作业
        /// </summary>
        /// <returns></returns>
        public ContentResult DoEndJob(int jid)
        {
            //jobInfoBLL
            var response= jobInfoBLL.RemoveJob(jid);
            return this.ToResponse(response);          
        }

        /// <summary>
        /// 执行修改作业方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ContentResult DoEditJobInfo(PMS.Model.J_JobInfo model)
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
        public ContentResult GetJobInfoByUser(int uid)
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
        public ActionResult GetJobTemplateDataByTemplate(int JobType)
        {
            //获取对应的作业模板
            var data = jobTemplateBLL.GetListBy(t => t.JobType == JobType).FirstOrDefault();
            // var data_midlle= data.ToMiddleModel();
            //此处不转为中间变量转为ViewModel中间对象
            ViewModel_JobTemplate data_vm = new ViewModel_JobTemplate()
            {
                CronStr = data.CronStr,
                JobClassName = data.JobClassName,
                JobType = data.JobType,
                JobGroup = data.JobGroup
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

        /// <summary>
        /// 转成Content最终的返回结果
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ContentResult ToResponse(PMS.Model.Message.IBaseResponse response)
        {
            if (response.Success)
            {
                return Content("ok");
            }
            return Content("error");
        }

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            throw new NotImplementedException();
        }
    }
}