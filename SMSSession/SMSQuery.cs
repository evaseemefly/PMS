using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using ISMS;
using PMS.Model.SMSModel;
using PMS.Model.Dictionary;
using System.Collections.Specialized;

namespace SMSFactory
{
    public class SMSQuery:ISMSQuery
    {
        /// <summary>
        /// 根据短信实体判断短信实体是否符合标准
        /// 符合返回true，
        /// 不符合返回false
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public bool SendBeforeCheck(SMSModel_Query smsdata)
        {
            if (smsdata.account.Length < 1 & smsdata.smsId.Length < 1 & smsdata.password.Length < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 根据传入的信息进行短信发送状态的查询
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool QueryMsg(SMSModel_Query smsdata, out List<SMSModel_QueryReceive> list_receiveModel)
        {
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Submit";//服务器地址
            string returnMsg;
            //1 判断参数是否足够
            if (SendBeforeCheck(smsdata))
            {
                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            _data = ObjTransform.Model2Xml_FormatQuery(smsdata);
            returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {

                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            //2.2 将接收到的短信发送回执转换为对象
            list_receiveModel = ObjTransform.Xml2Model_queryReceiveMsg(returnMsg);
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
