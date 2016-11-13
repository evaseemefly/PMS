using System;
using System.Text;
using System.Collections.Specialized;
using PMS.Model.SMSModel;
using ISMS;
using PMS.Model.Dictionary;
using JobManagement;
using System.Collections.Generic;
using PMS.Model;
using System.Linq;
using PMS.IBLL;
using PMS.BLL;
using PMS.Model.EqualCompare;

namespace SMSFactory
{
    /// <summary>
    /// 1 获取传入的群组及部门获取对应联系人
    /// 2 获取要删除的联系人id
    /// 3 从联系人集合中去除要删除的联系人获得最终要发送的联系人
    /// </summary>
    /// <param name="dids"></param>
    /// <param name="gids"></param>
    /// <param name="rowCount"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    public delegate List<P_PersonInfo> delegate_GetPersonListByGroupDepartment(string dids, string gids, out int rowCount, int pageSize = -1, int pageIndex = -1);

    public class SMSSend: ISMSSend
    {
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IP_PersonInfoBLL personBLL { get; set; } 
        public SMSSend()
        {
            departmentBLL = new P_DepartmentInfoBLL();
            groupBLL = new P_GroupBLL();
            personBLL = new P_PersonInfoBLL();
        }

        /// <summary>
        /// 根据短信实体判断短信实体是否符合标准
        /// 符合返回true，
        /// 不符合返回false
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public bool SendBeforeCheck(SMSModel_Send smsdata)
        {
            if (smsdata.account.Length < 1 & smsdata.account.Length < 1 & smsdata.sign.Length < 1 & smsdata.phones.Length < 1 & smsdata.content.Length < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region 10月12日——短信发送方法暂时注释掉——使用调用WCF的方式
        ///// <summary>
        ///// 短信发送
        ///// </summary>
        ///// <param name="smsdata"></param>
        ///// <returns></returns>
        //public bool SendMsg(SMSModel_Send smsdata,out SMSModel_Receive receiveModel)
        //{
        //    String _data = null;//XML文本
        //    String _serverURL = "http://wt.3tong.net/http/sms/Submit";//服务器地址
        //    string returnMsg;

        //    //1 判断参数是否足够
        //    if (!SendBeforeCheck(smsdata))
        //    {
        //        receiveModel = new SMSModel_Receive()
        //        {
        //            desc = "参数不全",
        //            msgid = smsdata.msgid,
        //            failPhones = smsdata.phones,
        //            result = SMSDictionary.GetResponseCode()[101]
        //        };

        //        return false;
        //    }
        //    _data=ObjTransform.Model2Xml_FormatSend(smsdata);
        //    //2.1 http方式发送
        //    returnMsg = httpInvoke(_serverURL, _data);
        //    //解析服务器反馈信息
        //    if (returnMsg.Length < 1)
        //    {

        //        returnMsg = "未收到服务器返回信息";
        //        receiveModel = new SMSModel_Receive()
        //        {
        //            desc = returnMsg,
        //            msgid = smsdata.msgid,
        //            failPhones = smsdata.phones,
        //            result = SMSDictionary.GetResponseCode()[101]
        //        };
        //        return false;
        //    }
        //    //2.2 将接收到的短信发送回执转换为对象
        //    receiveModel = ObjTransform.Xml2Model_ReceiveMsg(returnMsg);




        //    //等待信息发送完成后
        //    //System.Threading.Thread.Sleep(10000);//10秒
        //    ////自动重发
        //    //vipResend();
        //    return true;
        //}
        #endregion



        /// <summary>
        /// 步骤一 获取传入的群组及部门获取对应联系人
        ///获取要删除的联系人id
        ///从联系人集合中去除要删除的联系人获得最终要发送的联系人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="delegateGetPersonList"></param>
        /// <returns></returns>
        public List<string> GetFinalPersonPhoneList(PMS.Model.ViewModel.ViewModel_Message model,DelegateSMS.delegate_GetPersonListByGroupDepartment delegateGetPersonList)
        {
            //List<P_PersonInfo> delegate_GetPersonListByGroupDepartment(string dids, string gids, out int rowCount, int pageSize = -1, int pageIndex = -1);
           // Func<string,string,int,int,int,List<P_PersonInfo>>
            //Func<string,string,>
            //Action<string,string>
            //Action<int, int, string> act = (a, b, c) =>
            //  {

            //  };
            //重新梳理并做抽象
            /*步骤一：
                获取传入的群组及部门获取对应联系人
                获取要删除的联系人id
                从联系人集合中去除要删除的联系人获得最终要发送的联系人
            */
            //1 获取要去除的 联系人id 数组
            var ids = model.PersonId_Int;
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

            if (model.GroupIds != null)
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

            //2 根据传入的群组及部门id获取对应的联系人
            List<P_PersonInfo> list_person = delegateGetPersonList(dids_str, gids_str, out count);

            //3 去除不需要的联系人，获得最终联系人集合
            list_person = (from p in list_person
                           where !ids.Contains(p.PID)
                           select p).ToList();

            //4 获取联系人集合中的电话生成电话集合
            List<string> list_phones = new List<string>();
            list_person.ForEach(p => list_phones.Add(p.PhoneNum.ToString()));

            return list_phones;
        }

        /// <summary>
        /// 步骤二 获取添加的临时联系人
        /// 向数据库中写入这些临时联系人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="personBLL"></param>
        /// <param name="groupBLL"></param>
        /// <returns></returns>
        public List<string> AddAndGetTempPersons(PMS.Model.ViewModel.ViewModel_Message model,IP_PersonInfoBLL personBLL,IP_GroupBLL groupBLL)
        {
            /*步骤二：
                    获取添加的临时联系人
                    向数据库中写入这些临时联系人
            */
            //1.2 获取临时联系人的电话数组
            var phoneNums = model.PhoneNum_Str;
            //1.3 调用personBLL中的添加联系人方法，将临时联系人写入数据库（qu）
            string PName_Temp = "临时联系人";

            //1.4 目前默认只添加到全部联系人群组中
            int groupID_AllContacts = groupBLL.GetListBy(a => a.GroupName.Equals("全部联系人")).FirstOrDefault().GID;

            List<int> groupIds = new List<int>();
            groupIds.Add(groupID_AllContacts);
            //1.5 循环写入数据库
            bool isSaveTempPersonOk = false;
            if (phoneNums != null && phoneNums.Length != 0)
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
                           // return false;
                        }
                    }
                    //1.7 存在在数据库中，且已经在发送列表中，这种情况需讨论

                }
               
            }
            return phoneNums.ToList();
        }

        /// <summary>
        /// 步骤三 获取短信内容
        /// 封装要提交至联通接口的发送对象（含联系人电话号码）
        /// </summary>
        /// <param name="model">短信对象</param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        public SMSModel_Send ToSendModel(PMS.Model.ViewModel.ViewModel_Message model,List<string> list_phones)
        {
            /*步骤三                    
                    获取短信内容
                    封装要提交至联通接口的发送对象
                    （含联系人电话号码）
            */
            //2 获取短信内容
            var content = model.Content;


            //2.1 设置发送对象相关参数
            string subCode = "";//短信子码"74431"，接收回馈信息用
            string sign = "【国家海洋预报台】"; //短信签名，！仅在！发送短信时用= "【国家海洋预报台】";
                                       //短信发送与查询所需参数
            string smsContent = content;//短信内容
            string sendTime;//计划发送时间，为空则立即发送
                            //3 对短信内容进行校验——先暂时不做

            //6月27日新增将List电话集合转成用,拼接的字符串
            //查询时不需要联系人电话
            SMSModel_Send sendMsg = new SMSModel_Send()
            {
                account = "dh74381",
                password = "uAvb3Qey",
                content = content,
                phones = list_phones.ToArray(),
                sendtime = DateTime.Now
            };
            return sendMsg;
        }



        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public bool SendMsg(PMS.Model.CombineModel.SendAndMessage_Model model, out PMS.Model.Message.BaseResponse response)
        {
            SendJobManagement jobManagement = new SendJobManagement();
            //判断是否开启定时发送功能
            if (model.Model_Message.isTiming)
            {
                //绑定定时发送功能
                //使用作业调度
                jobManagement.DoSendJobs += SendMsgbyDelayed;
            }
            else
            {
                //绑定立刻发送功能
                jobManagement.DoSendJobs += SendMsgbyNow;
            }
            //不管具体绑定的是哪个方法，调用该发送方法
            SMSModel_Receive receive = new SMSModel_Receive();
            jobManagement.JobsRun(model, receive);
            response = new PMS.Model.Message.BaseResponse() { Success = true };
            return false;
        }

        

        /// <summary>
        /// 延时发送
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMsgbyDelayed(PMS.Model.CombineModel.SendAndMessage_Model model, SMSModel_Receive response)
        {
            //response = new PMS.Model.Message.BaseResponse();
            return true;
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

        /// <summary>
        /// 立刻发送
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMsgbyNow(PMS.Model.CombineModel.SendAndMessage_Model model, SMSModel_Receive receiveModel)
        {
            //SMSModel_Receive receiveModel = new SMSModel_Receive();
            ServiceReference1.SMSServiceClient client = new ServiceReference1.SMSServiceClient();

            //重新梳理并做抽象
            //1 根据选定的群组及部门获取相应的联系人
            var list_PersonPhonesByGroupAndDepartment = GetFinalPersonPhoneList(model.Model_Message, GetPersonListByGroupDepartment);

            //2 获取临时联系人电话集合
           
            var list_tempPersonPhones = AddAndGetTempPersons(model.Model_Message, personBLL, groupBLL);

            //2.2 获取最终的联系人电话集合
            list_PersonPhonesByGroupAndDepartment.AddRange(list_tempPersonPhones);
            var list_phones = list_PersonPhonesByGroupAndDepartment;

            //3 转成发送对象
            var sendMsg = ToSendModel(model.Model_Message, list_phones);

            /*步骤四
                    生成提交对象及短信及作业对象
                    由SMSFactory进行短信提交操作（并选择延时/立刻发送）
            */
            //4 短信发送
            //注意：desc:定时时间格式错误;
            //      result:定时时间格式错误
            //PMS.Model.CombineModel.SendAndMessage_Model sendandMsgModel = new PMS.Model.CombineModel.SendAndMessage_Model() { Model_Message = model, Model_Send = sendMsg };
            model.Model_Send = sendMsg;
            PMS.Model.Message.BaseResponse response = new PMS.Model.Message.BaseResponse();
            SendMsg(model, out response);
            return true;
        }

        //发送程序
        /// <summary>
        /// 大汉三通提供的发送程序
        /// </summary>
        /// <param name="iServerURL"></param>
        /// <param name="iMessage"></param>
        /// <returns></returns>
        private String httpInvoke(String iServerURL, String iMessage)
        {
            String responseText = null;//接收联通服务器反馈的信息
            String msgText = null;//
            try
            {
                CTCWebClient _webClient = new CTCWebClient();
                NameValueCollection _postValues = new NameValueCollection();
                _postValues.Add("message", iMessage);
                byte[] _responseArray = _webClient.UploadValues(iServerURL, _postValues);
                //向服务器发送POST数据
                responseText = Encoding.UTF8.GetString(_responseArray);
            }
            catch (Exception e)//不懂？？？？？？？？？
            {
                msgText = e.Message + "调用异常" + "（。报错位置：UnicomPorts.httpInvoke）";
                //MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msgText;
            }

            return responseText;
        }

    }
}
