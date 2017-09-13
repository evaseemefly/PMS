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
using PMS.Model.Enum;

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
            if (smsdata.account.Length < 1 &/* smsdata.smsId.Length < 1 & */smsdata.password.Length < 1)
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
        public virtual QueryState_Enum GetQueryState(List<SMSModel_QueryReceive> list)
        {
            if (list.Count == 1)
            {
                //判断该集合中的唯一的对象的desc是否为成功
                if(list.Count()==1&& list.FirstOrDefault().desc=="成功"&&list.FirstOrDefault().phoneNumber==null)
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
            if(list.Count==0)
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
        /// 9月26日添加对返回的集合中是否存在指定msgid的对象的判断
        /// 若存在则返回true，不存在则返回false
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual bool QueryMsg(PMS.IModel.SMSModel.IQuerySign smsdata, out List<SMSModel_QueryReceive> list_receiveModel)
        {
            
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Report";//服务器地址
            string returnMsg;
            var sgin_sms = smsdata as SMSModel_Query;
            //1 判断参数是否足够
            if (!SendBeforeCheck(sgin_sms))
            {
                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            _data = ObjTransform.Model2Xml_FormatQuery_SMS(sgin_sms);
            returnMsg = httpInvoke(_serverURL, _data);

            //记录查询结果回执
            Common.LogHelper.WriteLog("查询返回结果为" + returnMsg);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {

                list_receiveModel = new List<SMSModel_QueryReceive>();
                return false;
            }
            //2.2 将接收到的短信发送回执转换为对象
            //此处有问题           
            list_receiveModel = ObjTransform.Xml2Model_queryReceiveMsg(returnMsg);
            //注意此时传入的smsid为null，注意！！
            if (/*this.CheckQueryReceiveLegal(sgin_sms.smsId, list_receiveModel)*/list_receiveModel.Count>0)
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
        private bool CheckQueryReceiveLegal(string msgid, List<SMSModel_QueryReceive> list_receive)
        {
            //根据传入的msgid遍历集合中的全部对象
            if(list_receive.Where(q=>q.msgId==msgid).Count()==0)
            {
                return true;
            }
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
