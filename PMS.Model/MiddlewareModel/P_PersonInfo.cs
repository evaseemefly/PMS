using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class P_PersonInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public P_PersonInfo ToMiddleModel()
        {
            return new P_PersonInfo()
            {
                PID = this.PID,
                PName = this.PName,
                Remark = this.Remark,
                isDel = this.isDel,
                isVIP = this.isVIP,
                PhoneNum = this.PhoneNum
            };
            }
    }
}
