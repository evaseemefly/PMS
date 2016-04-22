using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.EasyUIModel;

namespace PMS.Model.EqualCompare
{
    public class EasyUIComboboxEqualCompare : IEqualityComparer<EasyUICombobox>
    {
        public bool Equals(EasyUICombobox x, EasyUICombobox y)
        {
            if (x.id == y.id)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return x.id.Equals(y.id);
        }

        public int GetHashCode(EasyUICombobox obj)
        {
            return obj.GetHashCode();
        }
    }
}
