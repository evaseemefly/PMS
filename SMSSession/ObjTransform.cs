using Common;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Dictionary;
using PMS.Model.Enum;

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
        public static MMSModel_Receive Xml2Model_ReceiveMsg(string result, MMSModel_Send sendModel)
        {
            //1. 获取结果，解析头标签
            result = result.ToLower();
            var resultCode = Xml2StrHelper.Xml2Str(result, "root/head/result");
            //当不等于0时，响应包中不会有body标签
            if(int.Parse(resultCode)!= 0)
            {
                MMSModel_Receive receive = new MMSModel_Receive()
                {
                    msgid = sendModel.msgid,
                    result = resultCode.ToString(),
                    desc = MMSDictionary.GetResponseCode()[int.Parse(resultCode)],
                    failPhones = sendModel.phones
                };
                return receive;
            }


            //2.解析body标签的子标签
            var msgid = Xml2StrHelper.xml2strList(result, "root/body/submitresult/response/msgid");
            var status = Xml2StrHelper.xml2strList(result, "root/body/submitresult/response/status");
            var phoneNum = Xml2StrHelper.xml2strList(result, "root/body/submitresult/response/phone");
            //3. 存入响应对象
            MMSModel_Receive model_receive = new MMSModel_Receive()
            {
                msgid = msgid[0],
                result = resultCode,
                desc = MMSDictionary.GetResponseCode()[int.Parse(resultCode)],
            };


            //4.存入失败的号码

            for(int i = 0; i < phoneNum.Length; i++)
            {
                if (int.Parse(status[i]) != 0)
                {

                    MMSModel_Receive_Failphones failphones = new MMSModel_Receive_Failphones()
                    {
                        phoneNum = phoneNum[i],
                        status_failPhone = status[i],
                        desc_failPhone = MMSDictionary.GetResponseCode()[int.Parse(status[i])]
                    };
                    model_receive.list.Add(failphones);
                 }
   
                }
            if(model_receive.list != null)
            {

                string[] failphone = new string[model_receive.list.Count()];
                int j = 0;
                foreach (var data in model_receive.list)
                {
                    failphone[j] = data.phoneNum;
                    j++;

                }
            //5.将所有提交不成功的号码存入返回模型
            model_receive.failPhones = failphone;
            }

            return model_receive;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="returnMsg"></param>
        /// <returns></returns>
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
                var _msgid = Xml2StrHelper.xml2strList(returnMsg, "response/report/msgid");
                var _phone = Xml2StrHelper.xml2strList(returnMsg, "response/report/phone");
                var _desc = Xml2StrHelper.xml2strList(returnMsg, "response/report/desc");
                var _wgcode = Xml2StrHelper.xml2strList(returnMsg, "response/report/wgcode");
                var _time = Xml2StrHelper.xml2strList(returnMsg, "response/report/time");
                var _smsCount = Xml2StrHelper.xml2strList(returnMsg, "response/report/smsCount");
                var _smsIndex = Xml2StrHelper.xml2strList(returnMsg, "response/report/smsIndex");

                for (int i = 0; i < _status.Length; i++)
                {
                    if (int.Parse(_smsIndex[i]) == 1)
                    {
                        SMSModel_QueryReceive r = new SMSModel_QueryReceive()
                        //封装语句
                        {
                            msgId = _msgid[i],
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
            }
            //9月7日
            //若response/report/status节点中没有元素
            else
            {
                //则说明返回的是ok等状态，对其进行封装
                SMSModel_QueryReceive r = new SMSModel_QueryReceive()
                //封装语句
                {
                    desc = desc,
                };
                list_r.Add(r);
            }
            return list_r;
        }
        /// <summary>
        /// 10-13：此方法需要重写
        /// 彩信
        /// </summary>
        /// <param name="returnMsg"></param>
        /// <returns></returns>
        public static List</*MMSModel_QueryReceive*/SMSModel_QueryReceive> Xml2Model_queryReceiveMsg(string returnMsg,MMSModel_Query smsdata)
        {
            List</*MMSModel_QueryReceive*/SMSModel_QueryReceive> list_r = new List</*MMSModel_QueryReceive*/SMSModel_QueryReceive>();
            //将返回结果都转换为小写
            returnMsg = returnMsg.ToLower();
            //1.解析前一部分(head)
            var result = Xml2StrHelper.Xml2Str(returnMsg, "root/head/result");
            var cmdid = Xml2StrHelper.Xml2Str(returnMsg, "root/head/cmdid");
            //如果result不为0，则没有body标签
            if (result != "0") { return null; }            
            //2.解析前二部分(body)
            //此处需要同时满足result=4且cmdid=804才会有联系人列表
            if(result=="0"&&(cmdid=="804"||cmdid=="704"))
            {
                var _status = Xml2StrHelper.xml2strList(returnMsg, "root/body/reportmsg/status");

                if (_status != null)
                {
                    var _msgid = Xml2StrHelper.xml2strList(returnMsg, "root/body/reportmsg/msgid");
                    var _phone = Xml2StrHelper.xml2strList(returnMsg, "root/body/reportmsg/phone");
                    var _desc = Xml2StrHelper.xml2strList(returnMsg, "root/body/reportmsg/statusdesp");

                    for (int i = 0; i < _status.Length; i++)
                    {

                        SMSModel_QueryReceive r = new SMSModel_QueryReceive()
                        //封装语句
                        {
                            msgId = _msgid[i],
                            phoneNumber = _phone[i],
                            status = _status[i],
                            desc = _desc[i],
                        };
                        list_r.Add(r);

                    }
                }
                return list_r;
            }
            return null;
           
        }
        /// <summary>
        /// 
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
        /// 将彩信发送对象转成xml格式--重载
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public static string Model2Xml_FormatSend(MMSModel_Send smsdata)
        {
            String content = Encryption.ToBase64(FileHelper.ReadFile(smsdata.ZipUrl));
            var commandCode = ((int)MMSRequestType_Enum.MMS_Submit).ToString().PadLeft(3, '0');
            //合成请求信息
            var _data = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                       + "<cmdId>" + commandCode + "</cmdId>"
                                       + "<account>" + smsdata.account + "</account>" + "<password>"
                                       + Encryption.MD5Encryption(smsdata.password) + "</password></head>"
                                       + "<body><submitMsg>"
                                       + "<msgid></msgid>"
                                       + "<phone>" + string.Join(",", smsdata.phones) + "</phone><content>"
                                       + content + "</content><title>"
                                       + smsdata.MMSTitle + "</title>"
                                       + "<subCode>"+ smsdata.subcode + "</subCode></submitMsg></body>"
                                       + "</root>";
            return _data;
        }
        /// <summary>
        /// 短信
        /// 将查询请求对象转换成xml格式
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public static string Model2Xml_FormatQuery_SMS(SMSModel_Query smsdata)
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
        /// <summary>
        /// 彩信
        /// 将查询请求对象转换成xml格式 重载
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public static string Model2Xml_FormatQuery_MMS(MMSModel_Query smsdata)
        {
            var _data = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                  + "<cmdId>"+smsdata.cmdid+"</cmdId>"
                                  + "<account>" + smsdata.account + "</account>" + "<password>"
                                  +Common.Encryption.MD5Encryption(smsdata.password) + "</password></head>"
                                  + "</root>";
            return _data;
        }
    }
}
