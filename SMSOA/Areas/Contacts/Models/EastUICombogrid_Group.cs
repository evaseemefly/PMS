using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class EasyUICombogrid_Group
    {
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
        public int GID { get; set; }

        public string GroupName { get; set; }

        public string Remark { get; set; }

        private bool _isPass = false;

        /// <summary>
        /// 禁用
        /// </summary>
        public bool IsPass
        {
            set { _isPass = value; }
            get { return _isPass; }
        }
        private string _text = "禁用";

        /// <summary>
        /// 选中
        /// </summary>
        public string Text 
        {
            set { _text = value; }
            get { return _text; }
        }

    }
}