using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.SMSModel;

namespace PMS.Model.EqualCompare
{
    public class SMSModel_QueryReceive_Compare : IEqualityComparer<SMSModel_QueryReceive>
    {
        public bool Equals(SMSModel_QueryReceive x, SMSModel_QueryReceive y)
        {
            return x.msgId.Equals(y.msgId);
        }

        public int GetHashCode(SMSModel_QueryReceive obj)
        {
            return obj.GetHashCode();
        }
    }
}
