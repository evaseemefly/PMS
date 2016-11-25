using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EqualCompare
{
    public class P_PersonEqualCompare : IEqualityComparer<P_PersonInfo>
    {
        public bool Equals(P_PersonInfo x, P_PersonInfo y)
        {
            return x.PID.Equals(y.PID);
        }

        public int GetHashCode(P_PersonInfo obj)
        {
            //11月25日重写此处
            if (obj == null)
                return 0;
            else
                return obj.PID.ToString().GetHashCode();
            //return obj.GetHashCode();
        }
    }
}
