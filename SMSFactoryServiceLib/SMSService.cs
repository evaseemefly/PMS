using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PMS.Model.SMSModel;
using PMS.Model.Dictionary;
using SMSFactory;
using System.Collections.Specialized;
using System.IO;

namespace SMSFactoryServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class SMSService: ISMSService
    {
        

        public bool SendMsg(SMSModel_Send smsdata, out SMSModel_Receive receiveModel)
        {
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Submit";//服务器地址
            string returnMsg;

            //1 判断参数是否足够
            if (!SendBeforeCheck(smsdata))
            {
                receiveModel = new SMSModel_Receive()
                {
                    desc = "参数不全",
                    msgid = smsdata.msgid,
                    failPhones = smsdata.phones,
                    result = SMSDictionary.GetResponseCode()[101]
                };

                return false;
            }
            _data = ObjTransform.Model2Xml_FormatSend(smsdata);
            Common.LogHelper.WriteLog(_data);
            //2.1 http方式发送
            returnMsg = httpInvoke(_serverURL, _data);
            Common.LogHelper.WriteLog(returnMsg);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {

                returnMsg = "未收到服务器返回信息";
                receiveModel = new SMSModel_Receive()
                {
                    desc = returnMsg,
                    msgid = smsdata.msgid,
                    failPhones = smsdata.phones,
                    result = SMSDictionary.GetResponseCode()[101]
                };
                return false;
            }
            //2.2 将接收到的短信发送回执转换为对象
            receiveModel = ObjTransform.Xml2Model_ReceiveMsg(returnMsg);




            //等待信息发送完成后
            //System.Threading.Thread.Sleep(10000);//10秒
            ////自动重发
            //vipResend();
            return true;
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
            if (smsdata.account.Length < 1 & smsdata.password.Length < 1 & smsdata.sign.Length < 1 & smsdata.phones.Length < 1 & smsdata.content.Length < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
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
