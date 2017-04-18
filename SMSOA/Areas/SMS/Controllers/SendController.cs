using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using Common;
using Common.EasyUIFormat;
using PMS.Model.EqualCompare;
using ISMS;
using SMSOA.Areas.SMS.Models;
using Common.Redis;
using PMS.Model.ViewModel;
using PMS.Model.SMSModel;
using JobManagement;


namespace SMSOA.Areas.SMS.Controllers
{
    public class SendController : /*Admin.Controllers.BaseController*/SMSBaseController
    {
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        IP_PersonInfoBLL personBLL { get; set; }
        ISMSSend smsSendBLL { get; set; }
        IUserInfoBLL userBLL { get; set; }
        IS_SMSContentBLL smsContentBLL { get; set; }
        //IUserInfoBLL userInfoBLL { get; set; }
        // GET: SMS/Send
        ISMSQuery smsQuery { get; set; }
        IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL { get; set; }

        private string list_id = "mylist";

        public ActionResult Index()
        {
            //17年4月12日 新增：在发送完成后跳转到彩信发送页面的url
            ViewBag.GetIframe_MMS = "/SMS/MMSSend/Index";

            //17年4月12日 新增：在发送完成后跳转到彩信发送页面的title。注意！！！此处的title为彩信发送，需要与数据库中权限表的彩信发送的Name一致（暂时写死，需要从权限表中读取）。
            
            ViewBag.MMS_Name = Resources.Language.SendMMS;

            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetMissionByUID = "/SMS/Send/GetMissionByUID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/Send/GetGroupByMID";
            ViewBag.GetDepartment_combotree = "/SMS/Send/GetDepartmentInfo4ComboTree";
            ViewBag.GetPersonByMission = "/SMS/Send/GetPersonByMission";
            ViewBag.GetPersonByGroupDepartment = "/SMS/Send/GetPersonByGroupDepartment";
            ViewBag.DoSend = "/SMS/Send/DoSend";
            ViewBag.GetTemplateByUidAndMission = "/SMS/MsgTemplate/GetTemplateByUserIdAndMission";
            //注意不在此处传获取任务的方法
            ViewBag.ShowSetOftenMissionAndGroup = "/SMS/Send/ShowSetWindow";
            ViewBag.LoginUserID = -999;
            //若父控制器中的登录用户不为空
            if (base.LoginUser!=null)
            {
                //获取登录用户的id
                ViewBag.LoginUserID = base.LoginUser.ID;
            }
            
            return View();
        }
        
        public ActionResult ShowSetWindow()
        {
            ViewBag.LoginUserID = -999;
            //若父控制器中的登录用户不为空
            if (base.LoginUser != null)
            {
                //获取登录用户的id
                ViewBag.LoginUserID = base.LoginUser.ID;
            }
            ViewBag.GetMissionByUserId_combogrid= "/SMS/Send/GetMissionByUser";
            ViewBag.GetGroupByUser_combogrid= "/SMS/Send/GetGroupByUser";
            ViewBag.DoSave= "/SMS/Send/DoSave";
            return View();
        }

        protected string GetMissionByUser(int userId,bool isChecked)
        {
            
            //1 获取该用户所拥有的短信任务（常用短信任务）
            var list_owned_mission = userBLL.GetMissionListByUID(userId, true,false);
            
            var missionIdsbyUser = list_owned_mission.Select(m => m.SMID).ToList();
            //2 获取剩余的未拥有的全部短信任务
            var list_Ext_mission = smsMissionBLL.GetMissionExt(missionIdsbyUser,false);
            var list = ToEasyUICombogrid_Mission.ToEasyUIDataGrid(list_owned_mission, isChecked);
            //2 从所有的群组中删除该任务所拥有的群组集合
            var list_excludeOwned_group = ToEasyUICombogrid_Mission.ToEasyUIDataGrid(list_Ext_mission, false);
            list.AddRange(list_excludeOwned_group);
            //将该任务拥有的群组设置为选中状态
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            return temp = temp.Replace("Checked", "checked");
           
        }

        /// <summary>
        /// 根据传入的用户id查询全部的短信任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult GetMissionByUser()
        {
            int userId = int.Parse(Request["userId"]);
           var temp= GetMissionByUser(userId, true);
            return Content(temp);
        }

        /// <summary>
        /// 根据传入的用户id查询全部的短信任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult GetMissionByUserUnChecked()
        {
            int userId = int.Parse(Request["userId"]);
            var temp = GetMissionByUser(userId, false);
            return Content(temp);
        }

        /// <summary>
        /// 根据短信任务id查询该短信任务所拥有的联系人并返回
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetPersonByMission(int mid)
        {

            var list_person = smsMissionBLL.GetPersonByMission(mid,PMS.Model.Enum.MMS_Enum.sms, true);
            #region 8月16日 注释掉
            ////1 根据mid获取指定任务对象
            //var mission = smsMissionBLL.GetListBy(s => s.SMID == mid).FirstOrDefault();
            ////2 根据短信任务查找对应的群组
            //var group = mission.R_Group_Mission.ToList();
            ////2.1 创建该任务所拥有的群组对象集合
            //List<P_Group> list_group = new List<P_Group>();
            ////2.2 添加至群组对象集合中
            //group.ForEach(g => list_group.Add(g.P_Group));
            ////2.3 根据群组对象集合获取该群组集合中所共有的联系人
            //List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            //list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            ////3 根据短信任务查找对应的部门
            //var department = mission.R_Department_Mission.ToList();
            ////3.1 创建该任务所拥有的部门对象集合
            //List<P_DepartmentInfo> list_department = new List<P_DepartmentInfo>();
            ////3.2 添加至部门对象集合中
            //department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            ////3.3 根据部门对象集合获取该群组集合中所共有的联系人
            //list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));

            ////4 将联系人集合去重
            //list_person= list_person.Distinct(new P_PersonEqualCompare()).ToList().Select(p=>p.ToMiddleModel()).Select(p=>p.ToMiddleModel()).ToList();
            #endregion
            list_person = list_person.OrderByDescending(a => a.isVIP).ToList();
            return Content(Common.SerializerHelper.SerializerToString(list_person));
        }

        /// <summary>
        /// 根据请求中的 部门id 以及 群组id 查询对应的联系人
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPersonByGroupDepartment()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            

            string dids_str= Request.QueryString["dids"];
            string gids_str = Request.QueryString["gids"];

            //int[] dids= Array.ConvertAll<string, int>(strArray, s => int.Parse(s));

            int rowCount = 0;

           var list_person= GetPersonListByGroupDepartment(dids_str, gids_str, out rowCount, pageSize, pageIndex);

            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_person,
                footer = null
            };

            //4 序列化后返回
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dids"></param>
        /// <param name="gids"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        protected List<P_PersonInfo> GetPersonListByGroupDepartment(string dids, string gids,out int rowCount, int pageSize=-1,int pageIndex=-1)
        {

            List<int> list_dids = new List<int>();
            List<int> list_gids = new List<int>();
            if (dids != "")
            {                
                var list_dids_temp = (from g in dids.Split(',')
                                      where g != ""
                                      select g).ToList();
                list_dids_temp.ForEach(g => list_dids.Add(int.Parse(g)));
            }
            if (gids != "")
            {
                var list_gids_temp = (from g in gids.Split(',')
                                 where g != ""
                                 select g).ToList();
                list_gids_temp.ForEach(g => list_gids.Add(int.Parse(g)));
            }


            //2 根据department以及group的id查询其对应的Person对象集合
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            var list_department = departmentBLL.GetListByIds(list_dids);
            list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));
            var list_group = groupBLL.GetListByIds(list_gids);
            list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            //3 将联系人集合去重
            list_person = list_person.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).ToList();
            list_person = list_person.OrderByDescending(a => a.isVIP).ToList();
            rowCount = list_person.Count();

            if (pageIndex != -1 && pageSize != -1)
            {
                //分页
                list_person = list_person.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return list_person;
        }

        protected string GetGroupByUser(int userId,bool isChecked)
        {
            //1 获取该用户所拥有的权限集合
            var list_owned_group = userBLL.GetGroupListByUID(userId, true,false);
            //List<int> list_group = new List<int>();
            var list_owned_Ids = list_owned_group.Select(g => g.GID).ToList();
            //2 获取该用户剩余可以拥有的权限集合
            var list_RestOwned_group = groupBLL.GetRestGroupListByIds(list_owned_Ids, true);
            //var list_RestOwned_group = userBLL.GetGroupListByUID(userId, true);


            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, isChecked);
            list.AddRange(ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_RestOwned_group, false));

            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            temp = temp.Replace("Checked", "checked");
            return temp;
        }

        /// <summary>
        /// 根据传入的userId获取该用户拥有的群组以及可以拥有的群组下拉框
        /// 设置用户的常用群组
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroupByUser()
        {
            int userId = int.Parse(Request["userId"]);
           var temp= GetGroupByUser(userId, true);
            return Content(temp);
        }

        public ActionResult GetGroupByUserUnChecked()
        {
            int userId = int.Parse(Request["userId"]);
            var temp = GetGroupByUser(userId, false);
            return Content(temp);
        }

        /// <summary>
        /// 根据 短信任务id 查询对应的群组列表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetGroupByMID(int mid/*, int userid*/)
        {
            int userId = int.Parse(Request["uid"]);
            //1获取传入的任务id
            //1.1根据任务id查找对应的任务对象并查找对应的群组集合
            List<PMS.Model.P_Group> list_owned_group = new List<PMS.Model.P_Group>();


            //根据短信任务查找短信任务所拥有的群组（在R_Group_Mission表中），并只拿取isPass为true的所对应的群组
            //17.4.17修改 By屈远 加入
            smsMissionBLL.
                GetListBy(m => m.SMID == mid).
                FirstOrDefault().
                R_Group_Mission.
                Where(r => r.isPass == true & r.isMMS == 0).
                ToList().
                ForEach(r => list_owned_group.Add(r.P_Group));

            list_owned_group = list_owned_group.Select(g => g.ToMiddleModel()).ToList();
            var list_owned_Ids = list_owned_group.Select(g => g.GID).ToList();

            //8月31日
            //之前的备份
            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, true);
            //var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, false);
            //2 从所有的群组中删除该任务所拥有的群组集合
            //2.1 获取当前用户所拥有的常用群组(通过User查询对应的Group）
            var list_excludeOwned_group = userBLL.GetRestGroupListByIds(list_owned_Ids, userId, true);
            //var list_excludeOwned_group = groupBLL.GetListBy(g => g.isDel == false).ToList().Where(g => !list_owned_group.Contains(g)).Select(g=>g.ToMiddleModel()).ToList();
            list.AddRange(ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_excludeOwned_group, false));
            //将该任务拥有的群组设置为选中状态
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

        /// <summary>
        /// 发送模块中保存设置的 常用任务 及 常用群组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoSave(Models.ViewModel_GroupMission model)
        {
            //获取提交的群组id以及任务id数组
            //可能为提交群组
            int[] group_ids;
            if (model.group_Ids == null)
            {
                group_ids = null;
            }
            else
            {
                group_ids = model.GroupId_Int;
            }

            var mission_ids = model.MissionId_Int;

            //获取当前登录的userId
            var userId = base.LoginUser.ID;

            //修改当前用户所拥有的任务
           var mission_isSuccess= userBLL.SetUser4Mission(userId, mission_ids.ToList());
            //修改当前用户所拥有的群组
            bool group_isSuccess = true;
            if (group_ids != null)
            {
                 group_isSuccess = userBLL.SetUser4Group(userId, group_ids.ToList());
            }
            else if (group_ids == null)
            {
                //执行清空操作
                group_isSuccess = userBLL.SetUser4Group(userId, new List<int>());
            }
            if (mission_isSuccess && group_isSuccess)
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }
        }

        public bool DoSendTiming(PMS.Model.ViewModel.ViewModel_Message model, ref SMSModel_Receive receive)
        {
            return true;
        }



        private bool DoSendNow(PMS.Model.CombineModel.SendAndMessage_Model model,out /*SMSModel_Receive*/ PMS.IModel.ISMSModel_Receive receive)
        {
            //重新梳理并做抽象
            #region 暂时注释掉
            ///*步骤一：
            //    获取传入的群组及部门获取对应联系人
            //    获取要删除的联系人id
            //    从联系人集合中去除要删除的联系人获得最终要发送的联系人
            //*/
            ////1.1 获取要去除的 联系人id 数组
            //var ids = model.PersonId_Int;    
            //int count = 0;
            //string dids_str = null;
            //string gids_str = null;
            //if (model.GroupIds == null)
            //{
            //    gids_str = "";
            //}

            //if (model.DepartmentIds == null)
            //{
            //    dids_str = "";
            //}

            //if (model.GroupIds != null)
            //{
            //    foreach (var item in model.GroupIds)
            //    {
            //        gids_str += item.ToString() + ",";
            //    }
            //}

            //if (model.DepartmentIds != null)
            //{
            //    foreach (var item in model.DepartmentIds)
            //    {
            //        dids_str += item.ToString() + ",";
            //    }
            //}

            ////1.3 根据传入的群组及部门id获取对应的联系人
            //var list_person = GetPersonListByGroupDepartment(dids_str, gids_str, out count);

            ////2.1 去除不需要的联系人，获得最终联系人集合
            //list_person = (from p in list_person
            //               where !ids.Contains(p.PID)
            //               select p).ToList();

            ////2.2 获取联系人集合中的电话生成电话集合
            //List<string> list_phones = new List<string>();
            //list_person.ForEach(p => list_phones.Add(p.PhoneNum.ToString()));

            ///*步骤二：
            //        获取添加的临时联系人
            //        向数据库中写入这些临时联系人
            //*/
            ////1.2 获取临时联系人的电话数组
            //var phoneNums = model.PhoneNum_Str;
            ////1.3 调用personBLL中的添加联系人方法，将临时联系人写入数据库（qu）
            //string PName_Temp = "临时联系人";

            ////1.4 目前默认只添加到全部联系人群组中
            //int groupID_AllContacts = groupBLL.GetListBy(a => a.GroupName.Equals("全部联系人")).FirstOrDefault().GID;

            //List<int> groupIds = new List<int>();
            //groupIds.Add(groupID_AllContacts);
            ////1.5 循环写入数据库
            //bool isSaveTempPersonOk = false;
            //if (phoneNums != null && phoneNums.Length != 0)
            //{
            //    foreach (var item in phoneNums)
            //    {
            //        //1.6 判断输入的联系人在是否存在在数据库中

            //        if (!personBLL.AddValidation(item))
            //        {
            //            //1.7 不存在在数据库中，则将临时联系人添加进数据库
            //            isSaveTempPersonOk = personBLL.DoAddTempPerson(PName_Temp, item, true, groupIds);
            //            if (!isSaveTempPersonOk)
            //            {
            //                return false;
            //            }
            //        }
            //        //1.7 存在在数据库中，且已经在发送列表中，这种情况需讨论

            //    }

            //    list_phones.AddRange(phoneNums.ToList());
            //}

            ///*步骤三                    
            //        获取短信内容
            //        封装要提交至联通接口的发送对象
            //        （含联系人电话号码）
            //*/
            ////2 获取短信内容
            //var content = model.Content;


            ////2.1 设置发送对象相关参数
            //string subCode = "";//短信子码"74431"，接收回馈信息用
            //string sign = "【国家海洋预报台】"; //短信签名，！仅在！发送短信时用= "【国家海洋预报台】";
            //                           //短信发送与查询所需参数
            //string smsContent = content;//短信内容
            //string sendTime;//计划发送时间，为空则立即发送
            //                //3 对短信内容进行校验——先暂时不做

            ////6月27日新增将List电话集合转成用,拼接的字符串
            ////查询时不需要联系人电话
            //SMSModel_Send sendMsg = new SMSModel_Send()
            //{
            //    account = "dh74381",
            //    password = "uAvb3Qey",
            //    content = content,
            //    phones = list_phones.ToArray(),
            //    sendtime = DateTime.Now,

            //};
            #endregion
            //1 根据选定的群组及部门获取相应的联系人
           var list_PersonPhonesByGroupAndDepartment= smsSendBLL.GetFinalPersonPhoneList(model.Model_Message, GetPersonListByGroupDepartment);

            //2 获取临时联系人电话集合
            var list_tempPersonPhones= smsSendBLL.AddAndGetTempPersons(model.Model_Message, personBLL, groupBLL);

            //2.2 获取最终的联系人电话集合
            list_PersonPhonesByGroupAndDepartment.AddRange(list_tempPersonPhones);

            var list_phones = list_PersonPhonesByGroupAndDepartment;
           var isEmpty= list_phones.Count() == 0 ? true : false;
            if (isEmpty)
            {
                receive = new SMSModel_Receive();
                return false;
            }
            //3 转成发送对象
            var sendMsg= smsSendBLL.ToSendModel(model.Model_Message, list_phones);

            /*步骤四
                    生成提交对象及短信及作业对象
                    由SMSFactory进行短信提交操作（并选择延时/立刻发送）
            */
            //4 短信发送
            //注意：desc:定时时间格式错误;
            //      result:定时时间格式错误
            //PMS.Model.CombineModel.SendAndMessage_Model sendandMsgModel = new PMS.Model.CombineModel.SendAndMessage_Model() { Model_Message = model, Model_Send = sendMsg };
            model.Model_Send = sendMsg;
            //PMS.Model.Message.BaseResponse response = new PMS.Model.Message.BaseResponse();
             smsSendBLL.SendMsg(model, out /*response*/receive,false);
            //receive = new SMSModel_Receive();
            return true;
        }

        /// <summary>
        /// 在发送短信之后执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="receive"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        public bool AfterSend(PMS.Model.ViewModel.ViewModel_Message model,SMSModel_Receive receive,List<string> list_phones)
        {
            /*步骤五：
                    创建短信内容至数据库
                    创建发送记录至数据库
                    （此处应放在SMSFactory.SendMsg或写在JobInstance中的SendJob.Exceuted）
             */
            //5 将发送的短信以及提交响应存入SMSContent
            var mid = model.SMSMissionID;
            var uid = base.LoginUser.ID;
            bool isSaveMsgOk = smsContentBLL.SaveMsg(receive, model.Content, mid, uid);

            //在current表中存入发送信息，在query之前，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
            //7月28日 注意此处已修改方法为：CreateReceieveMsg！！！
            if (!smsRecord_CurrentBLL.CreateReceieveMsg(receive.msgid, list_phones))
            {
                return false;
            }

            /*步骤六：
                    写入redis缓存中
                    （此处应放在SMSFactory.SendMsg中或写在JobInstance中的SendJob.Exceuted）
            */
            ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(list_id);

            StringRedisHelper redisStrhelper = new StringRedisHelper();
            redisStrhelper.Set(receive.msgid, "1", DateTime.Now.AddHours(72));
            //2017年2月4日 添加释放资源
            redisStrhelper.Dispose();
            return true;
        }

        /// <summary>
        /// 根据传入的 联系人id数组 以及 短信内容进行短信发送
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoSend(PMS.Model.ViewModel.ViewModel_Message model)
        {
            //1 有效性判断
            //1.1 联系人名单为空，不执行发送操作，返回
            //if (model.PersonIds == null||model.PersonIds== "undefined") { return Content("empty contact list"); }
            //1.2 短信内容为空，不执行发送操作，返回
            if (model.Content == null) { return Content("empty content"); }
            //1.3 超出300字，不执行发送操作，返回
            if (model.Content.Length + 9 >= 300) { return Content("out of range"); }
            //SMSModel_Receive receive = new SMSModel_Receive();
            PMS.IModel.ISMSModel_Receive receive = new SMSModel_Receive();
            #region 11月14日已做修改，判断是定时还是实时发送在SMSFactory中的SMSSend中判断，此处暂时注释掉
            //SendJobManagement sendjobManagement = new SendJobManagement();
            //if (model.isTiming)
            //{
            //    //延时发送

            //}
            //else
            //{
            //    //立刻发送
            //    sendjobManagement.DoSendJobs += DoSendNow;
            //    //smsSendBLL.SendMsg()
            //}

            //// var isSaveMsgOk = DoSendNow(model,ref receive);


            ////var isSaveMsgOk = DoSendNow(Combine_model, receive);
            //sendjobManagement.JobsRun(Combine_model, receive);
            #endregion
            PMS.Model.CombineModel.SendAndMessage_Model combine_model = new PMS.Model.CombineModel.SendAndMessage_Model();
            combine_model.Model_Message = model;
            //smsSendBLL.SendMsg(Combine_model, out response);


            //****注意此处还未实现向前台向后台传递对象时应加上uid，并向combin_model中加入uid（以包含此属性）
            var isOk_Send= DoSendNow(combine_model, out receive);
            //var isOk_Send = "0";
            #region 测试批量写入时间时的测试返回对象
            //测试批量写入时间时的测试返回对象——现注释掉
            //SMSModel_Receive testModel = new SMSModel_Receive()
            //{
            //    desc = "提交成功",
            //    failPhones = new string[] { },
            //    msgid = "b14deff1f6ef45bb8e357e961f5c17ab",
            //    result = "0"
            //};
            #endregion
            var receive_model = receive as SMSModel_Receive;

            //if (receive_model.msgid != null)
            //{
            //    AfterSend(combine_model.Model_Message, receive_model /*testModel*/, combine_model.Model_Send.phones.ToList());
            //}

            //if (!isSaveMsgOk)
            //{
            //    return Content("服务器错误");
            //}
            
            if ("0".Equals((receive as SMSModel_Receive).result)&&isOk_Send)
            {
                //6 查询发送状态(是否加入等待时间？)
                //7 检查是否还要发彩信
                if (isIncludeMMSGroups(int.Parse(model.SMSMissionID))) { return Content("ok_nextMMS"); }
                return Content("ok");
                
            }
            if (!isOk_Send)
            {
                return Content("send_error");
            }
            else
            {
                return Content("error");
            }
        }

        protected List<P_DepartmentInfo> GetSelectedDepartmentInfo2List(int mid)
        {
            //根据短信任务找到与该任务对应的所属部门
            var mission = smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            List<int> list_id = new List<int>();

            List<P_DepartmentInfo> list_department = new List<P_DepartmentInfo>();
            //from d in mission.R_Department_Mission
            //where 1==1
            //list_department.Add(d.P_DepartmentInfo.ToMiddleModel());

            //mission.R_Department_Mission.ToList().ForEach(r => list_department.Add(r.P_DepartmentInfo.ToMiddleModel()));
            
            return list_department;
        }
        
        /// <summary>
        /// 根据 短信任务id 查询对应的部门实体，并转成ComboTree对象
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetDepartmentInfo4ComboTree(int mid)
        {

            int index_isMMs = 0;
            index_isMMs=int.Parse(Request["isMMS"]);
            //根据短信任务找到与该任务对应的所属部门
           var mission= smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            List<int> list_id = new List<int>();
            
            //2017-04-17 casablanca
            mission.
                R_Department_Mission.
                Where(r=>r.isMMS== index_isMMs).
                ToList().
                ForEach(r => list_id.Add(r.DepartmentID));

           var list_alldepartment= departmentBLL.GetListBy(d => d.isDel == false).ToList().Select(d=>d.ToMiddleModel()).ToList();
            //8月31日
            //备份如下
            List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, list_id.ToArray());

            //11月29日 备注以下，使用以上此种方式
            //List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, null);

            var temp= Common.SerializerHelper.SerializerToString(list_combotree);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }

        public ActionResult GetMissionByUID()
        {
            int uid = int.Parse(Request["userId"]);
            //1 根据传入的userId查询该User所拥有的短信任务
            var list_mission= userBLL.GetMissionListByUID(uid, true,false);

            //2 
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list_mission,
                footer = null
            };
            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(model));
        }

        /// <summary>
        /// 查询所有 短信任务对象集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMissionByPID()
        {
            
            //int userId=3;
            //userInfoBLL.GetListBy(p=>p.ID==userId).FirstOrDefault().R_UserInfo_SMSMission.
            //获取全部的短信种类集合
            var list_allmission= smsMissionBLL.GetAllList().ToList().Select(m=>m.ToMiddleModel()).ToList();
            
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list_allmission,
                footer = null
            };
            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(model));
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
        /// 检查是否有彩信群组
        /// </summary>
        /// <returns></returns>
        private bool isIncludeMMSGroups(int mid)
        {
            var mission = smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            bool isMMS = false;
            if (mission != null)
            {
                var list  = smsMissionBLL.GetMMSGroups(true, mission);
                if(0 < list.Count)
                {
                    isMMS = true;
                }    
            }
            return isMMS;
        }
    }
}