using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.EasyUIModel
{
   public class EasyUIDataGrid_Group
    {
        public bool Checked { get; set; }

        public int GID { get; set; }

        public string GroupName { get; set; }

        public string Remark { get; set; }

        public bool selected { get; set; }

        /// <summary>
        /// 禁止删除标识符
        /// </summary>
        public bool forbidDel { get; set; }
    }
}
