using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class ViewModel_PersonDepartmentGroup
    {
        public string userId { get; set; }

        public string[] groupIds { get; set; }

        public string departmentId { get; set; }
    }
}