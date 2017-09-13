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

namespace SMSOA.Services.Api
{
    public class SMSSendApiController : ApiController
    {
        /// <summary>
        /// 通过unity实现Ioc（待完成）
        /// </summary>
        PMS.IBLL.IUserInfoBLL userBLL;
        PMS.IBLL.IS_SMSMissionBLL smsMissionBLL;
        PMS.IBLL.IP_GroupBLL groupBLL;      

        public string Get(int id = 0)
        {
            return null;
        }

        public SendResponseModel DoSend(SendResultModel sendModel)
        {
            //模拟一个post请求

            SendResponseModel sendResponseModel = new SendResponseModel { ResponseDate = DateTime.Now };
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
                foreach(var item in groupname)
                {
                    if(item == "" && !groupBLL.AddValidation(item))
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


            //***测试用，之后用传入的参数替代***
            var sendObj = new ViewModel_Message()
            {
                PersonIds = new string[] { "101", "102" }.ToString(),
                GroupIds = new int[] { 101, 102 },
                Content = "测试测试",
                SMSMissionID = "102"
            };
            IHttpProvider httpProvider = new HttpProvider();

            //2 请求短信发送action url
            HttpResponseParameter responseParameter = httpProvider.Excute(new HttpRequestParameter
            {
                Url = "128.5.6.57/SMS/Send/DoSend/",
                IsPost = true,
                Encoding = Encoding.UTF8,
                JsonData = Common.SerializerHelper.SerializerToString(sendObj)
            });

            //3 将返执行发送后的结果转换为SendResponseModel，序列化后返回
            //未完成
            return new SendResponseModel() { };
        }
    }
}
