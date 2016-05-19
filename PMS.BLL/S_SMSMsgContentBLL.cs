using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model;

namespace PMS.BLL
{
    public partial class S_SMSMsgContentBLL : BaseBLL<S_SMSMsgContent>, IS_SMSMsgContentBLL
    {
        /// <summary>
        /// 将短信存入SMSMsgContent
        /// </summary>
        /// <param name="smsContent"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool SaveMsg(string smsContent, string mid)
        {
            S_SMSMsgContent smsMsgContent = new S_SMSMsgContent()
            {
                SMID = int.Parse(mid),
                MsgContent = smsContent,
                SubTime = DateTime.Now,
                MsgName = " "
            };
            this.CurrentDBSession.S_SMSMsgContentDAL.Create(smsMsgContent);
            try
            {
                return this.CurrentDBSession.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }

        }

    }
}
