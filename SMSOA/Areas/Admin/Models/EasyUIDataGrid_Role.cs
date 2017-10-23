using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Admin.Models
{
    public class EasyUIDataGrid_Role
    {

        public int RID { get; set; }

        public string RoleName { get; set; }

        public string Remark { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public int Sort { get; set; }

        private bool _selected = false;

        /// <summary>
        /// 选中
        /// </summary>
        public bool selected
        {
            set { _selected = value; }
            get { return _selected; }
        }


        private bool _checked = false;

        /// <summary>
        /// 选中
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
    }
}