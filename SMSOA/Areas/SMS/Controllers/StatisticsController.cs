using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSOA.Areas.SMS.Models;

namespace SMSOA.Areas.SMS.Controllers
{
    public class StatisticsController : Admin.Controllers.BaseController
    {
        IUserInfoBLL userBLL { get; set; }

        // GET: SMS/Statistics
        public ActionResult Index()
        {
            ViewBag.GetStatisticLast10 = "/SMS/Statistics/GetStatisticLast10_DataGrid";
            return View();
        }

        /// <summary>
        /// 查询当前用户的短信发送情况
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStatisticLast10_DataGrid()
        {
            //1 获取当前登录的用户
            var userInfo = base.LoginUser;
            var userTemp= userBLL.GetListBy(u => u.ID == userInfo.ID).FirstOrDefault();

            //2 获取该用户所发送的短信内容——只获取当日的发送的短信（或发送最近的前十条短信）
            var list_last10 = userTemp.S_SMSContent.OrderBy(c => c.SendDateTime).Take(10).ToList();

            List<ViewModel_StatisticsLast10> list_statisticslast10 = new List<ViewModel_StatisticsLast10>();
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            foreach (var item in list_last10)
            {
                list_statisticslast10.Add(
                    new ViewModel_StatisticsLast10()
                    {
                        ContentID = item.ID,
                        Content = item.SMSContent,
                        MissionName = item.S_SMSMission.SMSMissionName,
                        SendDateTime = item.SendDateTime,
                        TotalOfReceiveNum = item.S_SMSRecord_Current.Count(),
                        //找到未收到的（收到的状态码初步约定为100）
                        NotReceiveNum = item.S_SMSRecord_Current.Where(r => r.ResultCode != 100).Count()
                    });
            }


            //3 转成datagrid识别的json格式数据            
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list_statisticslast10,
                footer = null
            };
            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));

        }
    }
}