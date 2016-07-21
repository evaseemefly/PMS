using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.BLL
{
    public partial class S_SMSRecord_CurrentBLL:BaseBLL<S_SMSRecord_Current>,IS_SMSRecord_CurrentBLL
    {
        /// <summary>
        /// 将查询结果写入数据库
        /// </summary>
        /// <param name="list_queryReceive"></param>
        /// <param name="scid"></param>
        /// <returns></returns>
        public bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive,int scid)
        {
            if (list_QueryReceive != null)
            {
                //1.取得长短信条数-------------------已经在S_SMSContentBLL的saveMsg方法中实现，不需要在这里实现了
                //6月1日此处为空
                //var s_smsContent = this.CurrentDBSession.S_SMSContentDAL.GetListBy(r => r.ID == scid).FirstOrDefault();
                //将长短信条数存入S_SMSContent
                // s_smsContent.smsCount = list_QueryReceive.FirstOrDefault().smsCount;

                //1. 得到该次短信的所有的Record_Current列表
                S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
                var list_smsRecord_Current = smscontentBLL.GetListBy(p => p.ID == scid).FirstOrDefault().S_SMSRecord_Current.ToList();
                //2. 遍历查询返回的集合
                foreach (var item in list_QueryReceive)
                {
                    //3.得到该条记录的电话号码对应的联系人
                    var personID = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum .Equals (item.phoneNumber)).FirstOrDefault().PID;

                    var smsRecord_Current = list_smsRecord_Current.Find(p => p.PID == personID);
                    smsRecord_Current.StatusCode = int.Parse(item.status);
                    smsRecord_Current.DescContent = item.desc;
                    this.CurrentDBSession.S_SMSRecord_CurrentDAL.Update(smsRecord_Current);
                }
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }

        ///<summary>
        ///在current表中存入发送信息，在query之前，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        ///</summary>
        ///<param name="list_phones"></param>
        ///<param name="scid"></param>
        public bool SaveTempReceieveMsg(string msgid, List<string> list_phones) {
            if(list_phones != null && !msgid.Equals(""))
            {
                S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
                //1.获取对应的smscontent表的ID
                var scid =  smscontentBLL.GetListBy(p => p.msgId.Equals(msgid)).FirstOrDefault().ID;
                foreach(var item in list_phones)
                {
                    //2.获取每一个发出电话号码对应的联系人ID
                    var personID = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item)).FirstOrDefault().PID;
                    //3.在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
                    S_SMSRecord_Current smsRecord_Current = new S_SMSRecord_Current()
                    {
                        SCID = scid,
                        PID = personID,
                        StatusCode = 98,
                        DescContent = "暂时未收到查询回执"
                    };
                    this.CurrentDBSession.S_SMSRecord_CurrentDAL.Create(smsRecord_Current);
                }
                return this.CurrentDBSession.SaveChanges();
            }
            else
            {
                return false;
            }

        }
            

        /// <summary>
        /// 将未收到短信的号码及姓名存入结果集
        /// </summary>
        /// <param name="list_QueryReceive"></param>
        /// <param name="result"></param>
        public void getResult(List<SMSModel_QueryReceive> list_QueryReceive, SMSModel_MsgResult result)
        {
            foreach(var item in list_QueryReceive)
            {
                if ("0".Equals(item.status))
                {

                }
                else
                {
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item.phoneNumber)).FirstOrDefault();
                    SMSModel_SendFails sendFails = new SMSModel_SendFails()
                    {
                        name = person.PName,
                        phoneNumber = item.phoneNumber
                    };
                    result.list_SendFails.Add(sendFails);
                }
            }
        }
    }
}
