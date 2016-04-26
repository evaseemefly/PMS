using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class EasyUICombogrid_Group
    {
        private bool _checked = false;

        /// <summary>
        /// 选中
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
        public int GID { get; set; }

        public string GroupName { get; set; }

        public string Remark { get; set; }

        private string _isPass = "是";

        /// <summary>
        /// 选中
        /// </summary>
        public string IsPass
        {
            set { _isPass = value; }
            get { return _isPass; }
        }
    }
}