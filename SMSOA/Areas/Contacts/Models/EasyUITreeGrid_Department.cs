using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class EasyUITreeGrid_Department
    {
        /// <summary>
        /// 选中
        /// </summary>
        public bool Checked { get; set; }

        public int DID { get; set; }

        public string DepartmentName { get; set; }

        public int Area { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool IsPass { get; set; }
        /// <summary>
        /// 选中
        /// </summary>
        public string Text { get; set; }

        public List<EasyUITreeGrid_Department> children { get; set; }
    }
}