using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EqualCompare
{
    public class P_PersonInfoEqualCompare : IEqualityComparer<P_PersonInfo>
    {
        public bool Equals(P_PersonInfo x, P_PersonInfo y)
        {
            return x.PID.Equals(y.PID);
        }

        public int GetHashCode(P_PersonInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}