using PMS.Model.ApiMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMS.Model.ViewModel;
using HttpHelper;
using System.Text;
using Common;
using PMS.Model.ApiMessage;
using PMS.IBLL;
using PMS.Model;
using PMS.BLL;

namespace SMSSendApi.Controllers.api
{
    public class SMSSendApiController : ApiController
    {
        /// <summary>
        /// 通过spring实现Ioc
        /// </summary>
        PMS.IBLL.IUserInfoBLL userBLL;
        PMS.IBLL.IS_SMSMissionBLL smsMissionBLL;
        PMS.IBLL.IP_GroupBLL groupBLL;

        string cookie_sessionId = null;

        public SMSSendApiController()
        {
            //读取http配置类
           var config =new Common.Config.HttpConfig();
            //读取cookie_session id值
            this.cookie_sessionId = config.Cookie_SessionId;

        }

        [HttpGet]
        public string Index()
        {
            return "测试api";
        }

        protected void Insert2Cookie(string id)
        {

        }

        /// <summary>
        /// 将userid存入memcached中，并返回在memcached中的key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string  Set2Memcached(string id)
        {
            //将userid存入memcached，并写入cookie，将cookie返回
            var session_guid =  HttpHelper.SessionHelper.SetMemcached(id);
            var temp = string.Format("memcached写入|{0}", session_guid);
            Common.LogHelper.WriteError(temp);
            return session_guid;
        }

        [HttpPost]
        public SendResponseModel DoSend(SendResultModel sendModel)
        {
            //return null;
            //模拟一个post请求
            SendResponseModel sendResponseModel = new SendResponseModel { ResponseDate = DateTime.Now };
            
            #region 各种判断
            //1 判断传入的SendResultModel是否包含必须的内容—Q
            //1.1 短信内容为空或字数超过800不执行发送
            if (sendModel.Content == null && sendModel.Content.Length + 9 >= 800)
            {
                sendResponseModel.ResultCode = Convert.ToString(PMS.Model.Enum.ResultCodeEnum_SendAPI.contentError);
                return sendResponseModel;

            }
            //1.2 传入的任务为空或任务不存在
            else if (!smsMissionBLL.AddValidation(sendModel.SMSMissionNames))
            {
                sendResponseModel.ResultCode = Convert.ToString(PMS.Model.Enum.ResultCodeEnum_SendAPI.missionError);
                return sendResponseModel;
            }
            //1.3 传入的群组不为空但群组不存在
            if (sendModel.GroupNames != null)
            {
                string[] groupname = sendModel.GroupNames.Split(';');
                foreach (var item in groupname)
                {
                    if (item == "" && !groupBLL.AddValidation(item))
                    {
                        sendResponseModel.ResultCode = Convert.ToString(PMS.Model.Enum.ResultCodeEnum_SendAPI.groupError);
                        return sendResponseModel;
                    }
                }
            }
            // 1.4 根据传入的SendResultModel的账号及密码（md5）判断是否拥有权限（先写在这里以后通过过滤器实现）—Q
            UserInfo userInfo = userBLL.GetListBy(u => u.UName == sendModel.Account && u.DelFlag == false).FirstOrDefault();

            if (userInfo == null && userInfo.UPwd != Encryption.MD5Encryption(sendModel.Pwd))
            {
                sendResponseModel.ResultCode = Convert.ToString(PMS.Model.Enum.ResultCodeEnum_SendAPI.accountError);
                return sendResponseModel;
            }
            #endregion

            //根据user获取id
            var userid = userInfo.ID;

            var session_id= this.Set2Memcached(userid.ToString());

            CookieCollection cookies = new CookieCollection();
            cookies.Add(
                        new Cookie()
                        {
                            Name = cookie_sessionId,
                            Value = session_id,
                            Expires = DateTime.Now.AddHours(3),
                            Domain = "nmefc"
                        });

            var temp_smsmission= smsMissionBLL.GetListBy(s => s.SMSMissionName == sendModel.SMSMissionNames).FirstOrDefault();

            //***测试用，之后用传入的参数替代***
            //测试-2，只传入任务及内容
            var sendObj = new ViewModel_Message()
            {
                Content = sendModel.Content,
                SMSMissionID = temp_smsmission.SMID.ToString()  
            };
            IHttpProvider httpProvider = new HttpProvider();

            //2 请求短信发送action url
            HttpResponseParameter responseParameter = httpProvider.Excute(new HttpRequestParameter
            {
                Url = "128.5.10.57/SMS/Send/DoSend/",
                IsPost = true,
                Encoding = Encoding.UTF8,
                JsonData = Common.SerializerHelper.SerializerToString(sendObj),
                Cookie = new HttpCookieType()
                {
                    CookieCollection = cookies
                }
            });
            var response_content =string.Format("responseParameter|{0}",Common.SerializerHelper.SerializerToString(responseParameter));
            Common.LogHelper.WriteError(response_content); 
            //3 将返执行发送后的结果转换为SendResponseModel，序列化后返回
            //未完成
            return new SendResponseModel() { };
        }
    }
}