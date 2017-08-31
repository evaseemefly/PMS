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

namespace SMSOA.Services.Api
{
    public class SMSSendApiController : ApiController
    {
        /// <summary>
        /// 通过unity实现Ioc（待完成）
        /// </summary>
        PMS.IBLL.IUserInfoBLL userInfoBLL;        

        public SendResponseModel DoSend(SendResultModel sendModel)
        {
            //模拟一个post请求
            
            
            //1 判断传入的SendResultModel是否包含必须的内容—Q
                
            /*
             * 1.2 根据传入的SendResultModel的账号及密码（md5）判断是否拥有权限
             * （先写在这里以后通过过滤器实现）—Q
            */

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
