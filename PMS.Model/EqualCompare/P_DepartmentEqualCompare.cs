using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EqualCompare
{
    public class P_DepartmentEqualCompare : IEqualityComparer<P_DepartmentInfo>
    {
        public bool Equals(P_DepartmentInfo x, P_DepartmentInfo y)
        {
            return x.DID.Equals(y.DID);
        }

        public int GetHashCode(P_DepartmentInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
