using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.IBLL
{
    public partial interface IS_SMSRecord_CurrentBLL
    {
        bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive,int scid);

        void getResult(List<SMSModel_QueryReceive> list_QueryReceive, SMSModel_MsgResult result);

        bool SaveTempReceieveMsg(string msgid, List<string> list_phones);
    }
}
