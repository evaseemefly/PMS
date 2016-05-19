using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;
using PMS.Model;

namespace PMS.BLL
{
    public partial class S_SMSRecord_CurrentBLL:BaseBLL<S_SMSRecord_Current>,IS_SMSRecord_CurrentBLL
    {
        public bool SaveReceieveMsg(List<PMS.Model.SMSModel.SMSModel_queryReceive> list_queryReceive)
        {
            if (list_queryReceive != null)
            {
                foreach(var item in list_queryReceive)
                {
                    //1.得到该条记录对应的联系人
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum == item.phoneNumber).FirstOrDefault();
                    S_SMSRecord_Current smsRecord_Current = new S_SMSRecord_Current()
                    {
                        PID = person.PID,
                        ResultCode = int.Parse(item.status),
                        //不清楚这个字段要存什么，需要开会讨论
                        SCID = 0             
                    };
                    this.CurrentDBSession.S_SMSRecord_CurrentDAL.Create(smsRecord_Current);
                }
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }
    }
}
