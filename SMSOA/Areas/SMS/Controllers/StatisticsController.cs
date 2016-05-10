using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSOA.Areas.SMS.Controllers
{
    public class StatisticsController : Admin.Controllers.BaseController
    {
        IUserInfoBLL userBLL { get; set; }

        // GET: SMS/Statistics
        public ActionResult Index()
        {
            ViewBag.GetStatistic = "";
            return View();
        }

        /// <summary>
        /// 查询当前用户的短信发送情况
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStatistic_DataGrid()
        {
            //1 获取当前登录的用户
            var userInfo = base.LoginUser;
            var userTemp= userBLL.GetListBy(u => u.ID == userInfo.ID).FirstOrDefault();

            //2 获取该用户所发送的短信内容——只获取当日的发送的短信（或发送最近的前十条短信）
            var list_last10 = userTemp.S_SMSContent.OrderBy(c => c.SendDateTime).Take(10).ToList();



        }
    }
}