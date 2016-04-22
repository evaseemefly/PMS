using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EqualCompare
{
    public class P_GroupEqualCompare : IEqualityComparer<P_Group>
    {
        public bool Equals(P_Group x, P_Group y)
        {
            return x.GID.Equals(y.GID);
        }

        public int GetHashCode(P_Group obj)
        {
            return obj.GetHashCode();
        }
    }
}
