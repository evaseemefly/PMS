using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class RoleInfo
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
    }
}
