using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IS_SMSRecord_CurrentBLL
    {
        bool SaveReceieveMsg(List<PMS.Model.SMSModel.SMSModel_queryReceive> list_queryReceive);
    }
}
