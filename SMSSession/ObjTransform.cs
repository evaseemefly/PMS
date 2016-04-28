using Common;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Dictionary;

namespace SMSSession
{
   public static class ObjTransform
    {
        /// <summary>
        /// 将返回结果的xml字符串解析为实体对象
        /// </summary>
        /// <param name="result">返回结果的xml字符串</param>
        /// <returns></returns>
        public static SMSModel_Receive Xml2Model_ReceiveMsg(string result)
        {
            //将xml解析
            var msgid = Xml2StrHelper.Xml2Str(result, "response/msgid");
            var smsresult = Xml2StrHelper.Xml2Str(result, "response/result");
            var desc = Xml2StrHelper.Xml2Str(result, "response/desc");
            var blacklist = Xml2StrHelper.Xml2Str(result, "response/blacklist");
            SMSModel_Receive model_receive = new SMSModel_Receive()
            {
                msgid = msgid,
                result = SMSDictionary.GetResponseCode()[int.Parse(smsresult)],
                desc = desc,
                failPhones = blacklist.Split(',')
            };
            return model_receive;
        }

        /// <summary>
        /// 将短信发送对象转成xml格式
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public static string Model2Xml_FormatSend(SMSModel_Send smsdata)
        {
            //合成请求信息
            var _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                          + "<message>"
                              + "<account>" + smsdata.account + "</account>"
                              + "<password>" + Encryption.MD5Encryption(smsdata.password) + "</password>"
                              + "<msgid>" + smsdata.msgid + "</msgid>"
                              + "<phones>" + string.Join(",", smsdata.phones) + "</phones>"
                              + "<content>" + smsdata.content + "</content>"
                              + "<sign>" + smsdata.sign + "</sign>"
                              + "<subcode>" + smsdata.subcode + "</subcode>"
                              + "<sendtime>" + smsdata.sendtime.ToString() + "</sendtime>"
                          + "</message>";
            return _data;
        }
    }
}
