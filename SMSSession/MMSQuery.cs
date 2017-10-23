using ISMS;
using PMS.Model.Enum;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMSFactory
{
    public class MMSQuery:SMSQuery,IMMSQuery
    {
        /// <summary>
        /// 根据彩信实体判断短信实体是否符合标准
        /// 符合返回true，
        /// 不符合返回false
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        public bool SendBeforeCheck(MMSModel_Query queryModel)
        {
            //有可能会为空
            if (queryModel == null)
            {
                return false;
            }
            if(queryModel.account.Length<1 & queryModel.password.Length < 1 & queryModel.cmdid != "004")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 根据刚刚查询所返回的回执集合
        /// 获取本次查询状态——是否已经查询完毕（若是第一个线程，则说明当前查询后，本次线程中所有用户已经查询完毕；
        /// 若是第二个线程，则还需要做相关操作
        /// </summary>
        /// <param name="list">刚刚查询所返回的回执集合</param>
        /// <returns></returns>
        public override QueryState_Enum GetQueryState(List</*MMSModel_QueryReceive*/SMSModel_QueryReceive> list)
        {
            //2017-04-24
            //此处需要修改
            /*
             * 注意彩信与短信返回结果不一样
             * eg：
             * desc="??"
             * msgid="0864d176f4644edeb9d6e6da53545de0"
             * phoneNumber="18610819818"
             * smsCount=0
             * status="0"
             * time=null
             * wgcode=null
             */
            if (list.Count == 1)
            {
                //判断该集合中的唯一的对象的desc是否为成功
                
                if (list.Count() == 1 && list.FirstOrDefault().desc == "成功" && list.FirstOrDefault().phoneNumber == null)
                {
                    //1:未有未被查询到的用户
                    return QueryState_Enum.finish;
                }
                //else
                //{
                //    //99：原因未知
                //    return QueryState_Enum.unknown;
                //}
            }
            if (list.Count == 0)
            {
                return QueryState_Enum.error;
            }
            if(list.Count>0)
            {
                //大于1时
                return QueryState_Enum.remnant;
            }
            return QueryState_Enum.unknown;
        }

        /// <summary>
        /// 根据传入的信息进行短信发送状态的查询
        /// （不在此处判断是否包含指定的msgid——9月26日添加对返回的集合中是否存在指定msgid的对象的判断）
        /// 若存在则返回true，不存在则返回false
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool QueryMsg(PMS.IModel.SMSModel.IQuerySign smsdata, out List</*MMSModel_QueryReceive*/SMSModel_QueryReceive> list_receiveModel)
        {
            String _data = null;//XML文本
            String _serverURL = "http://mms.3tong.net/http/mms";//服务器地址
            string returnMsg;

            PMS.Model.SMSModel.MMSModel_Query sgin_mms = new MMSModel_Query()
            {
                account = (smsdata as SMSModel_Query).account,
                password = (smsdata as SMSModel_Query).password
            };

            //1 判断参数是否足够
            if (!SendBeforeCheck(sgin_mms))
            {
                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            sgin_mms.cmdid = "004";
            _data = ObjTransform.Model2Xml_FormatQuery_MMS(sgin_mms);
            returnMsg = DoRquest(_serverURL, "POST", "UTF-8", _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {

                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            //2.2 将接收到的短信发送回执转换为对象
            //此处有问题    
            //将返回的str转为彩信联系人集合，若cmdid=804或result=0，才会有联系人集合
            //若不满足以上条件则返回集合为null       
            list_receiveModel = ObjTransform.Xml2Model_queryReceiveMsg(returnMsg, sgin_mms);
            //注意此时传入的smsid为null，注意！！
            if (list_receiveModel == null)
            {
                return false;
            }
            if (/*this.CheckQueryReceiveLegal(sgin_mms.smsId, list_receiveModel)*/list_receiveModel.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// 从传入的查询返回集合中判断是否有指定的msgid，若存在则返回true，若不存在则返回false
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="list_receive"></param>
        /// <returns></returns>
        private bool CheckQueryReceiveLegal(string msgid, List<MMSModel_QueryReceive> list_receive)
        {
            //根据传入的msgid遍历集合中的全部对象
            if (list_receive.Where(q => q.msgId == msgid).Count() >0)
            {
                return true;
            }
            return false;
        }
        //发送程序
        /// <summary>
        /// 大汉三通提供的发送程序
        /// </summary>
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
