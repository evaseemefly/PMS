using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class EasyUIComboTree_Department
    {

        public int id { get; set; }

        public string text { get; set; }
        
        public List<EasyUIComboTree_Department> children { get; set; }
    }
}