using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    public class ViewModel_Person_QueryInfo
    {
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 群组id
        /// </summary>
        public int GID { get; set; }

        /// <summary>
        /// 任务id
        /// </summary>
        public int SMID { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int DID { get; set; }
    }
}
