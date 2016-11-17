using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    public partial class ViewModel_BaseJob
    {
        /// <summary>
        /// 是否需要开启定时作业功能
        /// </summary>
        public bool isTiming { get; set; }

        /// <summary>
        /// 保存当前作业的发起用户id
        /// </summary>
        public int UID { get; set; }
    }
}
