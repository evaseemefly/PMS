using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.IBLL
{
    public partial interface IS_SMSContentBLL
    {
        bool SaveMsg(SMSModel_Receive receive, string smsContent, string mid, int uid, out int scid);

        void getResult(SMSModel_Receive receive,SMSModel_MsgResult result);
    }
}
