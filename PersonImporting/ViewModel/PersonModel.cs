using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersonImporting.ViewModel
{
    public class PersonModel
    {
        public string DepartmentName { get; set; }

        public string GroupName { get; set; }

        public int GroupSort { get; set; }

        public string PersonName { get; set; }

        public string Phone { get; set; }

    }

    public class MissionModel
    {
        public string Name { get; set; }

        public string GroupOrDepartment { get; set; }

        public string MissionName { get; set; }

        public int MissionSort { get; set; }

        public string MSGType { get; set; }

        public string IsPass { get; set; }
    }
}
