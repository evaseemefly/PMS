using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class S_SMSContent
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public S_SMSContent ToMiddleModel()
        {
            return new S_SMSContent()
            {
                UID = this.UID,
                BlackList = this.BlackList,
                ID = this.ID,
                isDel = this.isDel,
                msgId = this.msgId,
                ResultCode = this.ResultCode,
                SendDateTime = this.SendDateTime,
                SMID = this.SMID,
                SMSContent = this.SMSContent

            };
        }
    }
}
