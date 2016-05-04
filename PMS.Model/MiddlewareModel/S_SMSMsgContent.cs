using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class S_SMSMsgContent
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public S_SMSMsgContent ToMiddleModel()
        {
            return new S_SMSMsgContent()
            {
                TID = this.TID,
                isDel = this.isDel,
                MsgContent = this.MsgContent,
                SMID = this.SMID,
                SubTime = this.SubTime,
                Sort = this.Sort,
                MsgName = this.MsgName,
                Remark = this.Remark
            };
        }
    }
}
