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
            if (x.DID == y.DID && x.DepartmentName == y.DepartmentName)
            {
                return true;
            }
            else
            {
                return false;
            }
           // return x.DID.Equals(y.DID);
        }

        public int GetHashCode(P_DepartmentInfo obj)
        {
            if (obj == null)
                return 0;
            else
                return obj.DID.ToString().GetHashCode();
           // return 0;
        }
    }
}
