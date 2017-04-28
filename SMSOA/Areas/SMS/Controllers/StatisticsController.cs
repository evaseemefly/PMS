using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSOA.Areas.SMS.Models;
using PMS.Model;
using PMS.Model.ViewModel;
using Common.EasyUIFormat;
using PMS.Model.Dictionary;

namespace SMSOA.Areas.SMS.Controllers
{
    public class StatisticsController : Admin.Controllers.BaseController
    {
        IUserInfoBLL userBLL { get; set; }

        IS_SMSContentBLL smsContentBLL { get; set; }

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
            ViewBag.LoadSearchData = "/SMS/Statistics/LoadSearchData";
            ViewBag.LoadSearchRecordData = "/SMS/Statistics/LoadSearchRecordData";
            ViewBag.GetRecordByCID = "/SMS/Statistics/GetRecordByCID";
            ViewBag.GetUserInfo = "GetUserInfo";
            ViewBag.GetMessageType = "GetMessageType";
            return View();
        }

        /// <summary>
        /// 根据smsContent ID 查询对应的记录
        /// 注意此处使用分页查询
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ActionResult GetRecordByCID(int cid)
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            //1 根据SMSContent的id查询该短信内容所发送的短信记录列表
            //返回的有CID，PName，PhoneNum，StatusCode状态码
            var smsContent= smsContentBLL.GetListBy(c => c.ID == cid).FirstOrDefault();
            //2 找到其的发送记录
            var list_record = smsContent.S_SMSRecord_Current.ToList().Select(r => r.ToMiddleModel());
            //2.0 排序，将VIP,未成功的记录放在列表前面
            list_record=list_record.OrderByDescending(p=>p.StatusCode).ThenByDescending(p => p.isVIP);
            //2.1 获取当总行数
            rowCount = list_record.Count();
            //2.2 分页返回记录
            var list_record_pagelist= list_record.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();

            //3 转成datagrid识别的json格式数据            
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_record_pagelist,
                footer = null
            };
            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
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
                //1.得到发送人姓名
                var userName = userBLL.GetListBy(p => p.ID == item.UID && p.DelFlag == false).FirstOrDefault().UName;
                list_statistics.Add(
                    new ViewModel_StatisticsLast10()
                    {
                        UserName = userName,
                        ContentID = item.ID,
                        Content = item.SMSContent,
                        MessageType = item.isMMS,
                        MissionName = item.S_SMSMission.SMSMissionName,
                        SendDateTime = item.SendDateTime,
                        TotalOfReceiveNum = item.S_SMSRecord_Current.Count(),
                        //找到未收到的（收到的状态码初步约定为100）
                        NotReceiveNum = item.S_SMSRecord_Current.Where(r => r.StatusCode != 0).Count()
                    });
            }
            //2.3 按照发送时间排序，需讨论
            list_statistics.OrderBy(p => p.SendDateTime);
        }

        public ActionResult LoadSearchRecordData(ViewModel_RecordQueryInfo model)
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
          var list_record=  smsContentBLL.GetSMSRecordListByQuery(pageIndex, pageSize, ref rowCount, model, model.CID, true, true);
            //3 转成datagrid识别的json格式数据            
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_record,
                footer = null
            };
            //4 序列化
            return Content(Common.SerializerHelper.SerializerToString(dgModel));

        }

        /// <summary>
        /// 根据任务及时间查询发送短信内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult LoadSearchData(PMS.Model.ViewModel.ViewModel_QueryInfo model)
        {

            #region 不用此种方式转换时间
            //不用以下的方法
            //2016 /10 /31
            //0123 456 789

            //2016 /5 /31
            //0123 45 678
            // int index_year = query.Dt_target.IndexOf('/');    //4
            // int year = int.Parse(query.Dt_target.Substring(0, index_year));//2016
            //int index_month = query.Dt_target.IndexOf('/', index_year+1);//7
            // int month = int.Parse(query.Dt_target.Substring(index_year+1, index_month-index_year-1));//5

            // int day = int.Parse(query.Dt_target.Substring(index_month , query.Dt_target.Length-index_month-1));
            #endregion

            //使用这种方式转换时间
            DateTime dt = new DateTime();
            DateTime.TryParse(model.Dt_target, out dt);


            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            //1 进行过滤
            var list_SMSContent = userBLL.GetSMSContentListByQuery_ExpNamePhone(pageIndex, pageSize, ref rowCount,model, base.LoginUser.ID, false, false);

            //1 分页查询当前登录用户的的发送短信内容集合
            //var list_SMSContent = userBLL.GetSMSContentListByUID(pageIndex, pageSize, ref rowCount, base.LoginUser.ID, true, false);

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

        public ActionResult GetPageStatisticList_DataGrid()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //1 分页查询当前登录用户的的发送短信内容集合
           var list_SMSContent= userBLL.GetSMSContentListByUID(pageIndex, pageSize,ref rowCount, base.LoginUser.ID,false, false);

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
            var list_currentDay = userTemp.S_SMSContent.OrderByDescending(c => c.SendDateTime).Where(s => s.SendDateTime.ToShortDateString() == currentDate).ToList();

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
            var list_last10 = userTemp.S_SMSContent.OrderByDescending(c => c.SendDateTime).Take(10).ToList();

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
            var list_last10 = userTemp.S_SMSContent.OrderByDescending(c => c.SendDateTime).Take(10).ToList();

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
            var list_currentDay = userTemp.S_SMSContent.OrderByDescending(c => c.SendDateTime).Where(s => s.SendDateTime.ToShortDateString() == currentDate).ToList();

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

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            var httpModel = new ViewModel_MyHttpContext()
            {
                Area = "SMS",
                Controller = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString(),
                Action = RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString(),
                Url = Request.Url.ToString()
            };
            return httpModel;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            //int userId = int.Parse(Request["uid"]);
            //1 获取回收站字典
            var dic = SMSUserDictionary.GetResponseCode();
            //2 将回收站字典转换为easyUI的Combogrid
            var list = ToEasyUICombogrid_Common.ToEasyUIDataGrid(dic,false);
            //3 将combogrid集合序列化并返回
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }

        public ActionResult GetMessageType()
        {
            List<PMS.Model.EasyUIModel.MessageType_ViewModel> list = new List<PMS.Model.EasyUIModel.MessageType_ViewModel>();
            //短信：
            list.Add(new PMS.Model.EasyUIModel.MessageType_ViewModel() { TypeID = 0, TypeName = "短信" });
            //彩信：
            list.Add(new PMS.Model.EasyUIModel.MessageType_ViewModel() { TypeID = 1, TypeName = "彩信" });

            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                footer = null,
                total = 0,
                rows = list
            };
            return Content(Common.SerializerHelper.SerializerToString(model));
        } 
    }
}