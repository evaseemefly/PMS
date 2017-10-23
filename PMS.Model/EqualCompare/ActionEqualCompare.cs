﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EqualCompare
{
    public class ActionEqualCompare :IEqualityComparer<ActionInfo>
    {
        public bool Equals(ActionInfo x, ActionInfo y)
        {
            return x.ID.Equals(y.ID);
        }

        public int GetHashCode(ActionInfo obj)
        {
            if (obj == null)
                return 0;
            else
                return obj.ID.ToString().GetHashCode();
            //return obj.GetHashCode();
        }
    }
}
