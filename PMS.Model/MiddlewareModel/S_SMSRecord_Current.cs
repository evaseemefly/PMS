using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class S_SMSRecord_Current
    {
        public string PersonName { get; set; }

        public string PhoneNum { get; set; }

        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public S_SMSRecord_Current ToMiddleModel()
        {
            return new S_SMSRecord_Current()
            {
                PID = this.PID,
                SCID = this.SCID,
                PersonName = this.P_PersonInfo.PName,
                PhoneNum = this.P_PersonInfo.PhoneNum,
                StatusCode = this.StatusCode
            };
        }
    }
}
