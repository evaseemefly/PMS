using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.BLL
{
    public partial class S_SMSContentBLL : BaseBLL<S_SMSContent>, IS_SMSContentBLL
    {
        /// <summary>
        /// 将短信存入SMSMsgContent
        /// </summary>
        /// <param name="smsContent"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool SaveMsg(SMSModel_Receive receive, string smsContent, string mid, int uid, out int scid)
        {
            S_SMSContent s_smsContent = new S_SMSContent()
            {   UID = uid,
                SMSContent = smsContent,
                msgId = receive.msgid,
                SendDateTime = DateTime.Now,
                SMID = int.Parse(mid),
                BlackList = string.Join(",", receive.failPhones),
                ResultCode = int.Parse(receive.result)
            };
            this.CurrentDBSession.S_SMSContentDAL.Create(s_smsContent);
            scid = s_smsContent.ID;
            try
            {
                
                return this.CurrentDBSession.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }

        }
        /// <summary>
        /// 将黑名单中短信的号码及姓名存入结果集
        /// </summary>
        /// <returns></returns>
        public void getResult(SMSModel_Receive receive,SMSModel_MsgResult result)
        {
                for (var i = 0; i < receive.failPhones.Length; i++)
                {
                    //根据电话号码查找对应联系人
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(receive.failPhones[i])).FirstOrDefault();
                    SMSModel_Blacklist blacklist = new SMSModel_Blacklist()
                    {
                        name = person.PName,
                        phoneNumber = receive.failPhones[i]
                    };
                    result.list_Blacklist.Add(blacklist);
                }
        }

    }
}
