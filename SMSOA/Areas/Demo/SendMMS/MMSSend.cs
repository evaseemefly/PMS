using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using SMSOA.Areas.Demo.Models.Enum;
using System.Net;

namespace SMSOA.Areas.Demo.SendMMS
{
    internal class MMSSend
    {
        #region 测试用,原方法为给出图片路径，读取图片，暂时不用此方法
        /// <summary>
        /// 测试是否能够发送彩信
        /// </summary>
        /// <returns></returns>
        //public static String test(String path)
        //{

        //    String fileUrl = path;
        //    String postUrl = "http://mms.3tong.net/http/mms";
        //    String phoneNum = "13681211480,18610819818,13811104406";
        //    String title = "测试彩信";
        //    String account = "dh74381";
        //    String password = md5("uAvb3Qey");

        //    return sendMMS(postUrl, phoneNum, title, account, password, fileUrl);
        //}
        #endregion
        public static String test(string content)
        {

            String postUrl = "http://mms.3tong.net/http/mms";
            String phoneNum = "13681211480,18610819818,13811104406";
            String title = "测试彩信";
            String account = "dh74381";
            String password = md5("uAvb3Qey");

            return sendMMS(postUrl, phoneNum, title, account, password,content);
        }
        #region 测试用,原方法为给出图片路径，读取图片，暂时不用此方法
        /// <summary>
        /// 发送彩信
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="phoneNum"></param>
        /// <param name="title"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        //private static String sendMMS(String postUrl, String phoneNum, String title, String account, String password, String fileUrl)
        //{
        //    String res = "";
        //    var commandCode = ((int)MMSRequestType_Enum.MMS_Submit).ToString().PadLeft(3, '0');
        //    try
        //    { 
        //        String content = ToBase64(ReadFile(fileUrl));
        //        String message = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
        //                              + "<cmdId>" + commandCode + "</cmdId>"
        //                              + "<account>" + account + "</account>" + "<password>"
        //                              + password + "</password></head>"
        //                              + "<body><submitMsg>"
        //                              + "<msgid></msgid>"
        //                              + "<phone>" + phoneNum + "</phone><content>"
        //                              + content + "</content><title>"
        //                              + title + "</title>"
        //                              + "<subCode></subCode></submitMsg></body>"
        //                              + "</root>";
        //        res = DoRquest(postUrl, "POST", "UTF-8", message);
        //   }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return res;
        //}

        #endregion

        private static String sendMMS(String postUrl, String phoneNum, String title, String account, String password, String content)
        {
            String res = "";
            var commandCode = ((int)MMSRequestType_Enum.MMS_Submit).ToString().PadLeft(3, '0');
            try
            {
               
                String message = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                      + "<cmdId>" + commandCode + "</cmdId>"
                                      + "<account>" + account + "</account>" + "<password>"
                                      + password + "</password></head>"
                                      + "<body><submitMsg>"
                                      + "<msgid></msgid>"
                                      + "<phone>" + phoneNum + "</phone><content>"
                                      + content + "</content><title>"
                                      + title + "</title>"
                                      + "<subCode></subCode></submitMsg></body>"
                                      + "</root>";
                res = DoRquest(postUrl, "POST", "UTF-8", message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return res;
        }

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
        #region 暂时不使用从本地读取文件的方法
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //private static byte[] ReadFile(String path)
        //{
        //    if (File.Exists(path))
        //    {
        //        FileStream file = null;
        //        try
        //        {
        //            file = File.OpenRead(path);
        //            byte[] pictureContent = new byte[file.Length];
        //            file.Read(pictureContent, 0, pictureContent.Length);

        //            return pictureContent;

        //        }
        //        catch(FileNotFoundException e)
        //        {
        //            throw new FileNotFoundException(e.Message);
        //        }
        //        finally
        //        {
        //            file.Close();
        //        }

        //    }
        //    return null;
        #endregion
        //}
        /// <summary>
        /// 加密程序
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }

        #region 此为飞飞单独写 固注释掉
        /// <summary>
        /// 图片转base64函数
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        //private static string ToBase64(byte[] binaryData)       
        //{
        //    try
        //    {
        //        string buffer1 = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
        //        return buffer1;
        //    }
        //    catch (System.ArgumentNullException exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }
        //}
        #endregion

        public String getReport(String url, String account, String password) //获取状态
        {
            String res = "";
            var commandCode = ((int)MMSRequestType_Enum.MMS_Report).ToString().PadLeft(3, '0');
            try
            {               
                String message = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                  + "<cmdId>004</cmdId>"
                                  + "<account>" + account + "</account>" + "<password>"
                                  + password + "</password></head>"
                                  + "</root>";
                res = DoRquest(url, "POST", "UTF-8", message);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return res;
        }
      

    }
}