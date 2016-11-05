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

namespace SMSOA.Areas.SMS.Controllers
{
    public class SendController : Admin.Controllers.BaseController
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

            var list_person = smsMissionBLL.GetPersonByMission(mid, true);
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
                list_dids_temp.ForEach(g => list_gids.Add(int.Parse(g)));
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
            smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault().R_Group_Mission.Where(r => r.isPass == true).ToList().ForEach(r => list_owned_group.Add(r.P_Group));
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

        /// <summary>
        /// 根据传入的 联系人id数组 以及 短信内容进行短信发送
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoSend(ViewModel_Message model)
        {
            //1 有效性判断
            //1.1 联系人名单为空，不执行发送操作，返回
            //if (model.PersonIds == null||model.PersonIds== "undefined") { return Content("empty contact list"); }
            //1.2 短信内容为空，不执行发送操作，返回
             if (model.Content == null) { return Content("empty content"); }
            //1.3 超出300字，不执行发送操作，返回
            if (model.Content.Length + 9 >= 300) { return Content("out of range"); }



            //1.1 获取要去除的 联系人id 数组
            var ids= model.PersonId_Int;

            //1.2 获取临时联系人的电话数组
            var phoneNums = model.PhoneNum_Str;

            int count = 0;
            string dids_str = null;
            string gids_str = null;
            if (model.GroupIds == null)
            {
                gids_str = "";
            }

            if (model.DepartmentIds == null)
            {
                dids_str = "";
            }
            
            if(model.GroupIds != null)
            {
                foreach (var item in model.GroupIds)
                {
                    gids_str += item.ToString() + ",";
                }
            }

            if (model.DepartmentIds != null)
            {
                foreach (var item in model.DepartmentIds)
                {
                    dids_str += item.ToString() + ",";
                }
            }

            //1.3 根据传入的群组及部门id获取对应的联系人
            var list_person= GetPersonListByGroupDepartment(dids_str, gids_str, out count);

            //2.1 去除不需要的联系人，获得最终联系人集合
            list_person = (from p in list_person
                               where !ids.Contains(p.PID)
                               select p).ToList();



            //1.1 根据联系人id数组获取指定的联系人
            //var list_person= personBLL.GetListByIds(ids.ToList());

            //2.2 获取联系人集合中的电话生成电话集合
            List < string > list_phones = new List<string>(); 
            list_person.ForEach(p => list_phones.Add(p.PhoneNum.ToString()));


            //1.3 调用personBLL中的添加联系人方法，将临时联系人写入数据库（qu）
            string PName_Temp = "临时联系人";

            //1.4 目前默认只添加到全部联系人群组中
            int groupID_AllContacts = groupBLL.GetListBy(a => a.GroupName.Equals("全部联系人")).FirstOrDefault().GID;

            List<int> groupIds = new List<int>();
            groupIds.Add(groupID_AllContacts);
            //1.5 循环写入数据库
            bool isSaveTempPersonOk = false;
            if(phoneNums!=null&&phoneNums.Length != 0)
            {
                foreach (var item in phoneNums)
                {
                    //1.6 判断输入的联系人在是否存在在数据库中

                    if (!personBLL.AddValidation(item))
                    {
                        //1.7 不存在在数据库中，则将临时联系人添加进数据库
                        isSaveTempPersonOk = personBLL.DoAddTempPerson(PName_Temp, item, true, groupIds);
                        if (!isSaveTempPersonOk)
                        {
                            return Content("服务器错误");
                        }
                    }      
                        //1.7 存在在数据库中，且已经在发送列表中，这种情况需讨论
                    
                }

                list_phones.AddRange(phoneNums.ToList());
            }

            //2 获取短信内容
            var content = model.Content;


            //2.1 设置发送对象相关参数
            string account= "dh74381"; //账号"dh74381";
            string passWord= "uAvb3Qey";//密码 = "uAvb3Qey";
            string subCode="";//短信子码"74431"，接收回馈信息用
            string sign= "【国家海洋预报台】"; //短信签名，！仅在！发送短信时用= "【国家海洋预报台】";
                         //短信发送与查询所需参数
            string phones="";//电话号码
            string smsContent= content;//短信内容
            string sendTime;//计划发送时间，为空则立即发送
                            //3 对短信内容进行校验——先暂时不做

            //6月27日新增将List电话集合转成用,拼接的字符串
            //查询时不需要联系人电话
           // phones = string.Join(",", list_person.Select(p => p.PhoneNum));
           // phones = phones.Substring(0, phones.Length);
            PMS.Model.SMSModel.SMSModel_Send sendMsg = new PMS.Model.SMSModel.SMSModel_Send()
            {
                account = account,
                password = passWord,
                content = smsContent,
                phones= list_phones.ToArray(),
                 sendtime=DateTime.Now
            };
            //4 短信发送
            PMS.Model.SMSModel.SMSModel_Receive receive;
            //注意：desc:定时时间格式错误;
            //      result:定时时间格式错误
            smsSendBLL.SendMsg(sendMsg, out receive);
            //5 将发送的短信以及提交响应存入SMSContent
            var mid = model.SMSMissionID;
            var uid = base.LoginUser.ID;
            bool isSaveMsgOk = smsContentBLL.SaveMsg(receive,smsContent, mid, uid);

            //6 在current表中存入发送信息，在query之前，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
            //7月28日 注意此处已修改方法为：CreateReceieveMsg！！！
            if (!smsRecord_CurrentBLL.CreateReceieveMsg(receive.msgid, list_phones))
            {
                return Content("服务器错误");
            }

            ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(list_id);

            StringRedisHelper redisStrhelper = new StringRedisHelper();
            redisStrhelper.Set(receive.msgid, "1", DateTime.Now.AddHours(72));

            //10月19日 注释掉此处，此时发送后将msgid写入Redis中的string类型中，不使用List对象了
            //redisListhelper.Add<PMS.Model.QueryModel.Redis_SMSContent>(new PMS.Model.QueryModel.Redis_SMSContent() {
            //    msgid = receive.msgid,
            //    Dt = DateTime.Now,
            //    PersonCount=list_phones.Count//7月28日添加：在redis中保存的缓存对象集合中记录该次发送共发送的人数
            //   // PhoneNums=phones
            //});
            if (!isSaveMsgOk)
            {
                return Content("服务器错误");
            }

            if ("0".Equals(receive.result))
            {
                //6 查询发送状态(是否加入等待时间？)
                return Content("ok");
                //PMS.Model.SMSModel.SMSModel_Query queryMsg = new PMS.Model.SMSModel.SMSModel_Query()
                //{
                //    account = account,
                //    password = passWord,
                //    smsId = receive.msgid
                //};
                //List<PMS.Model.SMSModel.SMSModel_QueryReceive> list_QueryReceive;
                //bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg,out list_QueryReceive);
                //if (!isGetReturnMsg)
                //{
                //    return Content("服务器错误");
                //}
                ////7 获取改次发送的SMSContent的ID
                //int scid = smsContentBLL.GetListBy(p => p.msgId.Equals(receive.msgid)).FirstOrDefault().ID;
                //bool isSaveCurrnetMsgOk = smsRecord_CurrentBLL.SaveReceieveMsg(list_QueryReceive,scid);
                //if (!isSaveCurrnetMsgOk)
                //{
                //    return Content("服务器错误");
                //}

                //PMS.Model.SMSModel.SMSModel_MsgResult msgResult = new PMS.Model.SMSModel.SMSModel_MsgResult();
                ////7 返回blacklist中的电话号码
                //smsContentBLL.getResult(receive, msgResult);
                ////8 返回查询结果中的失败的电话号码
                //smsRecord_CurrentBLL.getResult(list_QueryReceive,msgResult);
                //var result = Common.SerializerHelper.SerializerToString(msgResult);
                //return Content(result);
            }
            else
            {
                return Content("error");
            }
        }


        
        /// <summary>
        /// 根据 短信任务id 查询对应的部门实体，并转成ComboTree对象
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetDepartmentInfo4ComboTree(int mid)
        {
            //根据短信任务找到与该任务对应的所属部门
           var mission= smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            List<int> list_id = new List<int>();
            mission.R_Department_Mission.ToList().ForEach(r => list_id.Add(r.DepartmentID));
           var list_alldepartment= departmentBLL.GetListBy(d => d.isDel == false).ToList().Select(d=>d.ToMiddleModel()).ToList();
            //8月31日
            //备份如下
            //List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, list_id.ToArray());
            List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, null);

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
    }
}