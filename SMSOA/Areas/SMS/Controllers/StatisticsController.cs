using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSOA.Areas.SMS.Models;
using PMS.Model;

namespace SMSOA.Areas.SMS.Controllers
{
    public class StatisticsController : Admin.Controllers.BaseController
    {
        IUserInfoBLL userBLL { get; set; }

        // GET: SMS/Statistics
        public ActionResult Index()
        {
            ViewBag.GetStatisticLast10 = "/SMS/Statistics/GetStatisticLast10_DataGrid";
            ViewBag.GetStatisticLast10_Chart = "/SMS/Statistics/GetStatisticLast10_Chart";
            ViewBag.GetStatisticCurrentDay_Chart = "/SMS/Statistics/GetStatisticCurrentDay_Chart";
            ViewBag.GetStatisticCurrentDay = "/SMS/Statistics/GetStatisticCurrentDay_DataGrid";            
            return View();
        }
        /// <summary>
        /// 高级搜索首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index_AdvancedSearch()
        {
            ViewBag.GetPageStatisticList = "/SMS/Statistics/GetPageStatisticList_DataGrid";
            ViewBag.GetAllMission = "/SMS/Send/GetAllMissionByPID";
            return View();
        }

        private void GetStatistic_Model_Chart(int count,  List<ViewModel_StatisticsLast10> list_statistics,out ViewModel_Statistics_Chart viewModel_chart)
        {
            int[] array_total = new int[count];
            int[] array_receive = new int[count];
            DateTime[] array_datetime = new DateTime[count];
            for (int i = 0; i < count; i++)
            {
                //if (list_statistics.Count > i)
                //{
                    array_total[i] = list_statistics[i].TotalOfReceiveNum;
                    array_receive[i] = list_statistics[i].TotalOfReceiveNum - list_statistics[i].NotReceiveNum;
                    array_datetime[i] = list_statistics[i].SendDateTime;
                //}
                //else
                //{
                //    array_total[i] = 0;
                //    array_receive[i] = 0;
                //    array_datetime[i] = DateTime.Now;
                //}

            }
            //3 转成datagrid识别的json格式数据   
            viewModel_chart = new ViewModel_Statistics_Chart()
            {
                Array_total = array_total,
                Array_revice = array_receive,
                Arrat_DataTime = array_datetime
            };
        }

        private void GetStatisticList(List<S_SMSContent> listsource,ref List<ViewModel_StatisticsLast10> list_statistics)
        {
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            foreach (var item in listsource)
            {
                list_statistics.Add(
                    new ViewModel_StatisticsLast10()
                    {
                        ContentID = item.ID,
                        Content = item.SMSContent,
                        MissionName = item.S_SMSMission.SMSMissionName,
                        SendDateTime = item.SendDateTime,
                        TotalOfReceiveNum = item.S_SMSRecord_Current.Count(),
                        //找到未收到的（收到的状态码初步约定为100）
                        NotReceiveNum = item.S_SMSRecord_Current.Where(r => r.StatusCode != 0).Count()
                    });
            }
        }

        public ActionResult GetPageStatisticList_DataGrid()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //1 分页查询当前登录用户的的发送短信内容集合
           var list_SMSContent= userBLL.GetSMSContentListByUID(pageIndex, pageSize,ref rowCount, base.LoginUser.ID, true, false);

            List<ViewModel_StatisticsLast10> list_statisticsFinal = new List<ViewModel_StatisticsLast10>();
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            GetStatisticList(list_SMSContent, ref list_statisticsFinal);


            //3 转成datagrid识别的json格式数据            
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_statisticsFinal,
                footer = null
            };
            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        /// <summary>
        /// 获取当日的该用户的发送短信统计对象（使用图表的方式）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStatisticCurrentDay_Chart()
        {
            //1 获取当前登录的用户4
            var userInfo = base.LoginUser;
            var userTemp = userBLL.GetListBy(u => u.ID == userInfo.ID).FirstOrDefault();

            //2 获取该用户所发送的短信内容——只获取当日的发送的短信
            var currentDate = DateTime.Now.ToShortDateString();
            var list_currentDay = userTemp.S_SMSContent.OrderBy(c => c.SendDateTime).Where(s => s.SendDateTime.ToShortDateString() == currentDate).ToList();

            List<ViewModel_StatisticsLast10> list_statisticslast10 = new List<ViewModel_StatisticsLast10>();
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            GetStatisticList(list_currentDay,ref list_statisticslast10);
            var model = new ViewModel_Statistics_Chart();
            GetStatistic_Model_Chart(list_statisticslast10.Count, list_statisticslast10,out model);

            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(model));

        }

        /// <summary>
        /// 获取该用户的发送的最后10条短信统计对象（使用图表的方式）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStatisticLast10_Chart()
        {
            //1 获取当前登录的用户4
            var userInfo = base.LoginUser;
            var userTemp = userBLL.GetListBy(u => u.ID == userInfo.ID).FirstOrDefault();

            //2 获取该用户所发送的短信内容——只获取发送最近的前十条短信
            var list_last10 = userTemp.S_SMSContent.OrderBy(c => c.SendDateTime).Take(10).ToList();

            List<ViewModel_StatisticsLast10> list_statisticslast10 = new List<ViewModel_StatisticsLast10>();
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            GetStatisticList(list_last10, ref list_statisticslast10);

            var model = new ViewModel_Statistics_Chart();
            GetStatistic_Model_Chart(list_statisticslast10.Count, list_statisticslast10, out model);   

            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(model));

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
            GetStatisticList(list_last10, ref list_statisticslast10);


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

        public ActionResult GetStatisticCurrentDay_DataGrid()
        {
            //1 获取当前登录的用户
            var userInfo = base.LoginUser;
            var userTemp = userBLL.GetListBy(u => u.ID == userInfo.ID).FirstOrDefault();

            //2 获取该用户所发送的短信内容——只获取当日的发送的短信（或发送最近的前十条短信）
            //2 获取该用户所发送的短信内容——只获取当日的发送的短信
            var currentDate = DateTime.Now.ToShortDateString();
            var list_currentDay = userTemp.S_SMSContent.OrderBy(c => c.SendDateTime).Where(s => s.SendDateTime.ToShortDateString() == currentDate).ToList();

            List<ViewModel_StatisticsLast10> list_statisticslast10 = new List<ViewModel_StatisticsLast10>();
            //2.1 将短信内容实体对象集合转成要在datagrid中显示的统计对象集合
            //2.2 需要统计该短信发送的人员个数以及未收到的人员个数
            GetStatisticList(list_currentDay, ref list_statisticslast10);


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