using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Model.EasyUIModel
{
    public class EasyUIComboTree_Department
    {
        public bool Checked { get; set; }

        public bool selected { get; set; }

        public int id { get; set; }

        public string text { get; set; }
        
        public List<EasyUIComboTree_Department> children { get; set; }
    }
}