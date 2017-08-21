using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSys.ViewModel
{
    public class DepartmentModel
    {
        public string DepartmentName { get; set; }

        public int DID { get; set; }

        public int PID { get; set; }

        public int Area { get; set; }

        public bool isDel { get; set; }

        public string Remark { get; set; }
    }
}
