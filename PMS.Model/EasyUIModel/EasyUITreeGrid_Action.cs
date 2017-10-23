using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EasyUIModel
{
   public class EasyUITreeGrid_Action
    {
        public bool Checked { get; set; }

        public bool selected { get; set; }

        public int ID { get; set; }

        public string ActionName { get; set; }

        public string Remark { get; set; }

        public List<EasyUITreeGrid_Action> children { get; set; }
    }
}
