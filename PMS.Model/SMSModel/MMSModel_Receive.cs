using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class MMSModel_Receive:SMSModel_Receive
    {
        /// <summary>
        /// 失败的电话号码列表（只有当result为0时，才能从响应中获得，否则为空）
        /// </summary>
        public List<MMSModel_Receive_Failphones> list { set; get; }
    }
}
