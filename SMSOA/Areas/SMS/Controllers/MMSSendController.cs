using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.ViewModel;
using PMS.IBLL;
using Common.EasyUIFormat;
using PMS.Model.SMSModel;
using ISMS;
using PMS.Model;
using PMS.Model.EqualCompare;
using Fdfs.IBLL;
using System.IO;

namespace SMSOA.Areas.SMS.Controllers
{
    public class MMSSendController: Admin.Controllers.BaseController
    {
        IP_PersonInfoBLL personBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IUserInfoBLL userBLL { get; set; }
        IMMSSend mmsSendBLL { get; set; }
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        IS_SMSContentBLL smsContentBLL { get; set; }
        //IUserInfoBLL userInfoBLL { get; set; }
        // GET: SMS/Send
        IMMSQuery mmsQuery { get; set; }
        IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL { get; set; }

        IFdfsUploadBLL uploadBLL { get; set; }

        IFdfsStorageBLL fdfsStorageBLL { get; set; }

        IFdfsTrackerBLL fdfsTrackerBLL { get; set; }

        IFdfsContentBLL fdfsContentBLL { get; set; }

        public int imgMaxSize { get;private set; }

    private string list_id = "mylist";
        //public ActionResult SetFiles()
        //{

        //    this.files = System.Web.HttpContext.Current.Request.Files;
        //    return Content("ok");
        //}


        
        // GET: SMS/MMSSend
        public ActionResult Index()
        {
            //定义Razor标签
            this.imgMaxSize = 2;
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetMissionByUID = "/SMS/Send/GetMissionByUID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/MMSSend/GetGroupByMID";
            ViewBag.GetDepartment_combotree = "/SMS/Send/GetDepartmentInfo4ComboTree";
            ViewBag.GetPersonByMission = "/SMS/Send/GetPersonByMission";
            ViewBag.GetPersonByGroupDepartment = "/SMS/Send/GetPersonByGroupDepartment";
            ViewBag.DoSend_MMS = "/SMS/MMSSend/DoSend";

            ViewBag.GetTemplateByUidAndMission = "/SMS/MsgTemplate/GetTemplateByUserIdAndMission";
            //注意不在此处传获取任务的方法
            ViewBag.ShowSetOftenMissionAndGroup = "/SMS/Send/ShowSetWindow";
            ViewBag.UploadFiles = "/SMS/MMSSend/SetFiles";
            ViewBag.LoginUser = -999;
            ViewBag.Content = "";
            ViewBag.Smid = -1;
            ViewBag.Redirect = 0;
            //若父控制器中的登录用户不为空
            if (base.LoginUser != null)
            {
                //获取登录用户的id
                ViewBag.LoginUserID = base.LoginUser.ID;
            }
            var content  = Request.QueryString["content"];
            if (null != content)
            {
                var smid_string = Request.QueryString["smid"];
                if(null != smid_string)
                {
                    ViewBag.Content = content;
                    ViewBag.Redirect = 1;
                    ViewBag.Smid = int.Parse(smid_string);

                }
            }
            return View();
        }

        public ActionResult GetGroupByMID(int mid)
        {
            int userId = int.Parse(Request["uid"]);
           // int mid = int.Parse(Request["mid"]);
            var mission = smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            //1.根据任务ID获取彩信群组的ID集合
            var list_MMS_group = smsMissionBLL.GetMMSGroups(true, mission);
            list_MMS_group = list_MMS_group.Select(m => m.ToMiddleModel()).ToList();
            var list_MMS_group_ids = list_MMS_group.Select(m => m.GID).ToList();

            //1.1 转换为easyUI的格式
            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_MMS_group, true);
            //var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, false);
            //2 从所有的群组中删除该任务所拥有的群组集合
            //2.1 获取当前用户所拥有的常用群组(通过User查询对应的Group）
            var list_excludeOwned_group = userBLL.GetRestGroupListByIds(list_MMS_group_ids, userId, true);
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
        public ActionResult DoSend()
        {
            //1 有效性判断,获取FormData传过来的值
            ViewModel_MMSMessage model = new ViewModel_MMSMessage();
            HttpFileCollection files;
                files = System.Web.HttpContext.Current.Request.Files;
            //取消选中的联系人
                model.PersonIds  = System.Web.HttpContext.Current.Request.Params.GetValues("formData_PersonIds")[0];
            //临时发送联系人
                model.PhoneNums = System.Web.HttpContext.Current.Request.Params.GetValues("formData_PhoneNums")[0];
                model.Content = System.Web.HttpContext.Current.Request.Params.GetValues("formData_Content")[0];
                model.SMSMissionID = System.Web.HttpContext.Current.Request.Params.GetValues("formData_SMSMissionID")[0];
            var Groups= System.Web.HttpContext.Current.Request.Params.GetValues("formData_GroupIds")[0].Split(',');
            if (Groups[0] != "")
            {
                model.GroupIds = Array.ConvertAll<string, int>(Groups, s => int.Parse(s));
            }
            var DepartmentIdsa = System.Web.HttpContext.Current.Request.Params.GetValues("formData_DepartmentIds")[0].Split(new char[] { ','});
                if (DepartmentIdsa[0] != "") {
                    model.DepartmentIds = Array.ConvertAll<string, int>(DepartmentIdsa, s => int.Parse(s));
                }

                model.isTiming  = bool.Parse(System.Web.HttpContext.Current.Request.Params.GetValues("formData_isTiming")[0]);
                model.MMSTitle = System.Web.HttpContext.Current.Request.Params.GetValues("formData_MMSTitle")[0];
                model.UID = int.Parse(System.Web.HttpContext.Current.Request.Params.GetValues("formData_UID")[0]);

            //1.1 联系人名单为空，不执行发送操作，返回
            //if (model.PersonIds == null||model.PersonIds== "undefined") { return Content("empty contact list"); }
            //1.2 短信内容为空，不执行发送操作，返回
            if (model.Content == null) { return Content("empty content"); }
            if (model.Content.Length + 9 >= 800) { return Content("out of range"); }
            if(model.MMSTitle.Length >= 15) { return Content("title out of range"); }

            //1.3 判断是否获取到获取图片


            HttpPostedFile file = files[0];


            if (!CheckFile(file)) { return Content("file error"); }
            //2 图片处理
            //var file_stream = file.InputStream;
            //BinaryReader reader = new BinaryReader(file_stream);
            //var file_content = reader.ReadBytes((int)file_stream.Length);
            using (var file_stream = file.InputStream)
            {
                //2.1 读取文件流后需要先转换为二进制数组
                BinaryReader reader = new BinaryReader(file_stream);
                // 读取流，转为二进制数组
                //****注意流读取结束后游标会移至读取的位置，所以以后需要使用流的地方再将二进制数组转为memoryStream即可
                var content = reader.ReadBytes((int)file_stream.Length);
                string fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/");
                //保存的图片的：文件名+拓展名
                string fileNameIncludeExt;
                //2.1最终在项目目录下创建Zip包,并获取路径
                var path_zip = mmsSendBLL.CreateZip(new MemoryStream(content), fileDirectory, model.Content, out fileNameIncludeExt);

                //2.2 将路径封装进实体模型
                model.ZipUrl = path_zip;

                PMS.Model.CombineModel.MMSSendAndMsg_Model combine_model = new PMS.Model.CombineModel.MMSSendAndMsg_Model();

                MMSModel_Send send = new MMSModel_Send();
                send.content = model.Content;
                //send.account=
                send.ZipUrl = path_zip;
                send.MMSTitle = System.Web.HttpContext.Current.Request.Params.GetValues("formData_MMSTitle")[0];
                //combine_model.Model_MMS.ZipUrl = path;
                //combine_model.Model_MMS.MMSTitle= System.Web.HttpContext.Current.Request.Params.GetValues("formData_MMSTitle")[0];
                combine_model.Model_Message = model;
                combine_model.Model_MMS = send;

                //SMSModel_Receive receive = new SMSModel_Receive();
                PMS.IModel.ISMSModel_Receive receive = new MMSModel_Receive();
                //3 执行发送操作
                var isOk_Send = DoSendNow(combine_model, out receive);
                //3.1联系人列表为空时跳出
                if ("empty list".Equals(isOk_Send)){return Content("list error");}

                var receive_temp = receive as MMSModel_Receive;

                var result_In2Db = mmsSendBLL.AfterSend(model, receive_temp /*testModel*/, combine_model.Model_MMS.phones.ToList());
                if (result_In2Db)
                {
                    var imgParam = new PMS.Model.FdfsParam.ImageUploadParameter(new MemoryStream(content), fileNameIncludeExt, this.imgMaxSize);
                    this.Save2Fdfs(imgParam, receive_temp.msgid);

                }

                if ("0".Equals((receive as MMSModel_Receive).result))
                {
                    //6 查询发送状态(是否加入等待时间？)
                    return Content("ok");

                }
                else
                {
                    //未知错误，需要开发人员进行调试
                    return Content("error");
                }
            }
            
            

            
            }
        /// <summary>
        /// 发送彩信方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="receive"></param>
        /// <returns></returns>
        private string DoSendNow(PMS.Model.CombineModel.MMSSendAndMsg_Model model, out /*SMSModel_Receive*/PMS.IModel.ISMSModel_Receive receive)
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
            var list_PersonPhonesByGroupAndDepartment = mmsSendBLL.GetFinalPersonPhoneList(model.Model_Message, GetPersonListByGroupDepartment);

            //2 获取临时联系人电话集合
            var list_tempPersonPhones = mmsSendBLL.AddAndGetTempPersons(model.Model_Message, personBLL, groupBLL);

            //2.2 获取最终的联系人电话集合
            list_PersonPhonesByGroupAndDepartment.AddRange(list_tempPersonPhones);

            var list_phones = list_PersonPhonesByGroupAndDepartment;
            if (list_phones.Count < 1) {
                receive = new SMSModel_Receive();
                return "empty list";
            }
            //3 转成发送对象
            var sendMsg = mmsSendBLL.ToSendModel(model.Model_MMS, list_phones);

            /*步骤四
                    生成提交对象及短信及作业对象
                    由SMSFactory进行短信提交操作（并选择延时/立刻发送）
            */
            //4 短信发送
            //注意：desc:定时时间格式错误;
            //      result:定时时间格式错误
            //PMS.Model.CombineModel.SendAndMessage_Model sendandMsgModel = new PMS.Model.CombineModel.SendAndMessage_Model() { Model_Message = model, Model_Send = sendMsg };
            model.Model_MMS = sendMsg;
            //PMS.Model.Message.BaseResponse response = new PMS.Model.Message.BaseResponse();
           var result= mmsSendBLL.SendMsg(model, out /*response*/receive,true);
            if (result)
            {

            }
            //receive = new SMSModel_Receive();
            
            return "ok";
        }

        /// <summary>
        /// 将图片上传至fdfs中
        /// </summary>
        /// <param name="uploadParam"></param>
        /// <param name="msgid"></param>
        private void Save2Fdfs(PMS.Model.FdfsParam.ImageUploadParameter uploadParam, string msgid)
        {
            //1 上传图片
            /*
            ExtName:jpg
            FileName:"wKgBaFjOLt-ATu3XAAAAAAAAAAA319"
            FileNameIncludeExt:"wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            FileNameIncludeScroll:"M00/00/00/wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            FullFilePath:"http://192.168.1.104/group1/M00/00/00/wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            GroupName:"group1"

            TrackerGroup:"group1"
            TrackerPort:"23000"
            TrackerUrl:"192.168.1.104"
            */
            var result = uploadBLL.UploadImage(uploadParam);


            //2 根据结果写回FdfsStorage
            //***** 注意先不往storage表中写回数据，上传成功后，并不会返回storage节点的信息 *****
            //2.1 先判断表中是否存在指定的对象
            // var storage_model= fdfsStorageBLL.GetListBy(fs => (fs.GroupName == result.GroupName) && (fs.URL == result.StorageUrl) && (fs.Port == result.StoragePort)).FirstOrDefault();
            FdfsStorage storage_model = null;
            //2.2 没有则创建
            //if (storage_model == null)
            //{
            //    fdfsStorageBLL.Create(new FdfsStorage()
            //    {
            //        GroupName = result.GroupName,
            //        //URL = result.StorageUrl,
            //        //Port = result.StoragePort
            //    });
            //}
            ////2.3 有则取出
            //else
            //{

            //}

            //3 写回FdfsTracker
            //3.1 先判断表中是否存在指定的对象            
            var tracker_model = fdfsTrackerBLL.GetListBy(ft => (ft.URL == result.TrackerUrl) && (ft.GroupName == result.TrackerGroup) && (ft.Port == result.TrackerPort)).FirstOrDefault();
            //3.2 没有则创建

            if (tracker_model == null)
            {
                tracker_model = new FdfsTracker()
                {
                    GroupName = result.GroupName,
                    URL = result.TrackerUrl,
                    Port = result.TrackerPort,
                    StorePathIndex = 0
                };
                fdfsTrackerBLL.Create(tracker_model);
            }
            //3.3 有则取出
            else
            {

            }

            //4 写回FdfsContent
            int tid = tracker_model.TID;
            int sid = 1;
            //4.1 先判断表中是否存在指定的对象            
            var content_model = fdfsContentBLL.GetListBy(fc => /*(fc.TID == tid) && (fc.SID == sid) && */(fc.FileName == result.FileName)).FirstOrDefault();
            //4.2 没有则创建
            if (content_model == null)
            {
                //4.2.1 找到SMSContent短信内容表中对应的内容
                var smsContent = smsContentBLL.GetListBy(c => c.msgId == msgid).FirstOrDefault();
                var fdfsContent = new FdfsContent()
                {
                    TID = tid,
                    SID = sid,
                    FileName = result.FileName,
                    ScrollName = result.Scroll,
                    Ext = (int)result.ExtName,

                };
                fdfsContent.S_SMSContent.Add(smsContent);
                fdfsContentBLL.Create(fdfsContent);
            }
            //4.3 有则取出
            else
            {

            }
        }

        protected List<P_PersonInfo> GetPersonListByGroupDepartment(string dids, string gids, out int rowCount, int pageSize = -1, int pageIndex = -1)
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

        public override ViewModel_MyHttpContext GetHttpContext()
        {
            throw new NotImplementedException();
        }
        private bool CheckFile(HttpPostedFile file)
        {
            bool isPass = false;
            if (file.ContentLength > 1 && file.FileName.Length > 1)
            {
                if (("image/jpeg".Equals(file.ContentType)) || ("image/png".Equals(file.ContentType)))
                {
                    isPass = true;
                }
            }
            return isPass;

        }
    }
}