using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Admin.Models
{
    public class EasyUIDataGrid_Action
    {
        public int AID { get; set; }

        public string ActionName { get; set; }

        public string Remark { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public int Sort { get; set; }

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

        ///<summary>
        ///该权限是否为角色赋予的
        /// </summary>
        public bool byRole { get; set; }
    }
}