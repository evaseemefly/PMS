using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IS_SMSMsgContentBLL
    {
        bool SaveMsg(string smsContent,string mid);

    }
}
