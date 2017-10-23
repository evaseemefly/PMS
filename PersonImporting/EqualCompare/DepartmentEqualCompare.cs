using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonImporting.ViewModel;

namespace PersonImporting.EqualCompare
{
    public class DepartmentEqualCompare : IEqualityComparer<ViewModel.PersonModel>
    {
        public bool Equals(PersonModel x, PersonModel y)
        {
            return x.DepartmentName == y.DepartmentName;
        }

        public int GetHashCode(PersonModel obj)
        {
            if (obj == null)
                return 0;
            else
                return obj.DepartmentName.ToString().GetHashCode();
        }
    }
}
