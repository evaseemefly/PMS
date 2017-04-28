using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    public class ViewModel_QueryInfo
    {
        public string PersonName { get; set; }

        public string PhoneNum { get; set; }

        /// <summary>
        /// 查询当前用户（1）还是查询全部用户（0）
        /// </summary>
        public int MissionUser_id { get; set; }

        public int Mission_id { get; set; }

        public int[] Mission_ids { get; set; }

        public string Dt_target { get; set; }

        public string Dt_start { get; set; }

        public string Dt_finish { get; set; }

        public bool[] Type { get; set; }
    }
}
