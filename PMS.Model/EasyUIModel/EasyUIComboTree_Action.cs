using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Model.EasyUIModel
{
    public class EasyUIComboTree_Action
    {
        public bool Checked { get; set; }

        public bool selected { get; set; }

        public int id { get; set; }

        public string text { get; set; }
        
        public List<EasyUIComboTree_Action> children { get; set; }
    }
}