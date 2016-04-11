using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class EasyUITreeGrid_Department
    {
        public int DID { get; set; }

        public string DepartmentName { get; set; }

        public int Area { get; set; }

        public string Remark { get; set; }

        public List<EasyUITreeGrid_Department> children { get; set; }
    }
}