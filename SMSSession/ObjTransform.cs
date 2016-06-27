using Common;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Dictionary;

namespace SMSFactory
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
            //6月1日新增
            var resultCode = SMSDictionary.GetResponseCode().Where(d=>d.Value==smsresult).Select(d=>d.Key).FirstOrDefault();
            SMSModel_Receive model_receive = new SMSModel_Receive()
            {
                msgid = msgid,
                result =resultCode.ToString(),
                desc = desc,
                failPhones = blacklist.Split(',')
            };
            return model_receive;
        }
        public static List<SMSModel_QueryReceive> Xml2Model_queryReceiveMsg(string returnMsg)
        {
            List<SMSModel_QueryReceive> list_r = new List<SMSModel_QueryReceive>();
            //解析前一部分
            var result = Xml2StrHelper.Xml2Str(returnMsg, "response/result");
            var desc = Xml2StrHelper.Xml2Str(returnMsg, "response/desc");

            //前一部分没有问题再解析后一部分
            //先尝试解析第一个值
            //6月27日 此方法无法取出xml节点中的值
            var _status = Xml2StrHelper.xml2strList(returnMsg, "response/report/status");

            //如果第一个值有内容则继续，否则说明没有后续内容
            if (_status != null)
            {
                var _phone = Xml2StrHelper.xml2strList(returnMsg, "response/report/phone");
                var _desc = Xml2StrHelper.xml2strList(returnMsg, "response/report/desc");
                var _wgcode = Xml2StrHelper.xml2strList(returnMsg, "response/report/wgcode");
                var _time = Xml2StrHelper.xml2strList(returnMsg, "response/report/time");
                var _smsCount = Xml2StrHelper.xml2strList(returnMsg, "response/report/smsCount");

                for (int i = 0; i < _status.Length; i++)
                {
                    SMSModel_QueryReceive r = new SMSModel_QueryReceive()
                    //封装语句
                    {

                        phoneNumber = _phone[i],
                        status = _status[i],
                        desc = _desc[i],
                        wgcode = _wgcode[i],
                        time = _time[i],
                        smsCount = int.Parse(_smsCount[i])
                    };
                    list_r.Add(r);

                }
            }
            return list_r;
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
                              + "<sendtime>" + smsdata.sendtime.ToString("yyyyMMddHHmm") + "</sendtime>"
                          + "</message>";
            return _data;
        }
        /// <summary>
        /// 将查询请求对象转换成xml格式
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public static string Model2Xml_FormatQuery(SMSModel_Query smsdata)
        {
            var _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                          + "<message>"
                              + "<account>" + smsdata.account + "</account>"
                              + "<password>" + Encryption.MD5Encryption(smsdata.password) + "</password>"
                              + "<msgid>" + smsdata.smsId + "</msgid>"
                              + "<phone>" +""/*smsdata.phoneNums*/+ "</phone>"
                          + "</message>";
            return _data;
        }
    }
}
