using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PMS.Model.SMSModel;
using System.IO;
using PMS.Model.Dictionary;
using SMSFactory;
using System.Collections.Specialized;
using System.Net;

namespace MMSFactoryServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MMSService”。
    public class MMSService : IMMSService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        /// <summary>
        /// 发送彩信
        /// </summary>
        /// <param name="sendModel">彩信发送模型</param>
        /// <param name="receiveModel">服务器响应模型</param>
        /// <returns></returns>
        public bool SendMsg(MMSModel_Send sendModel, out MMSModel_Receive receiveModel)
        {
            String _data = null;
            String _serverURL = "http://mms.3tong.net/http/mms";
            string returnMsg;
            try
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            }
            catch (Exception ex)
            {
                //通过Log4net写在日志文件中（写在其他日志文件中）
                throw new NotImplementedException();
            }
           
            
            int responseCode = SendBeforeCheck(sendModel);
            //1.发送前判断参数是否足够
            if (responseCode != 100)
            {
                receiveModel = new MMSModel_Receive()
                {
                    desc = MMSDictionary.GetResponseCode()[responseCode],
                    msgid = sendModel.msgid,
                    failPhones = sendModel.phones,
                    result = responseCode.ToString()
                    
                };

                return false;
            }

            //2 发送彩信
            //2.1 将接收到的短信发送回执转换为对象
            _data = ObjTransform.Model2Xml_FormatSend(sendModel);
            Common.LogHelper.WriteLog(_data);
            //2.2 http方式发送
            returnMsg = DoRquest(_serverURL, "POST", "UTF-8", _data);
            //2.3 解析服务器的返回信息
            if (returnMsg.Length<1)
            {
                receiveModel = new MMSModel_Receive()
                {
                    desc = "未收到服务器返回信息",
                    msgid = sendModel.msgid,
                    failPhones = sendModel.phones,
                    result = MMSDictionary.GetResponseCode()[101]
                };

                return false;
            }
            receiveModel = ObjTransform.Xml2Model_ReceiveMsg(returnMsg, sendModel);
            return true;
        }
        private int SendBeforeCheck(MMSModel_Send sendModel)
        {
            //if (sendModel.password.Length < 1 & sendModel.account.Length < 1) { return 99; }
            //if (sendModel.phones.Length < 1) { return 98; }
            //if (sendModel.content.Length < 1) { return 7; }
            if (sendModel.MMSTitle.Length < 1) { return 6; }
            if (sendModel.ZipUrl.Length < 1) { return 97; }
            return 100;
        }
        /// <summary>
        /// 大汉三通提供的发送程序
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="encodestr"></param>
        /// <param name="postparamers"></param>
        /// <returns></returns>
        public static string DoRquest(string uri, string method, string encodestr, string postparamers)
        {
            HttpWebResponse result = null;
            Stream ReceiveStream = null;
            try
            {
                while (true)
                {
                    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(uri);
                    wr.Method = method;
                    wr.Timeout = 10000;
                    wr.AllowWriteStreamBuffering = false;

                    Encoding encode = System.Text.Encoding.GetEncoding(encodestr);

                    if (method == "POST" && postparamers != null)
                    {
                        wr.ContentType = "application/x-www-form-urlencoded";
                        byte[] bytes = encode.GetBytes(postparamers);
                        wr.ContentLength = bytes.Length;
                        Stream requestStream = wr.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }

                    result = (HttpWebResponse)wr.GetResponse();
                    {
                        ReceiveStream = result.GetResponseStream();
                        StreamReader sr = new StreamReader(ReceiveStream, encode);
                        string data = sr.ReadToEnd();
                        sr.Close();
                        return data;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (result != null)
                    result.Close();
                if (ReceiveStream != null)
                    ReceiveStream.Close();
            }
        }
    }
 }


