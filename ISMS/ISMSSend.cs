using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.SMSModel;

namespace ISMS
{
    /// <summary>
    /// 短信发送接口
    /// 本接口主要用于：根据xml格式发送短信，以及返回短信发送后的反馈信息
    /// </summary>
    public interface ISMSSend
    {
       // /// <summary>
       // /// 短信发送
       // /// </summary>
       // /// <param name="smsdata">短信实体对象</param>
       // /// <returns></returns>
       //bool SendMsg(SMSModel_Send smsdata);

        /// <summary>
        /// 短信发送
        /// 返回是否成功bool
        /// 以及根据out参数输出短信发送接收实体对象
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        bool SendMsg(SMSModel_Send smsdata, out SMSModel_Receive receiveModel);
    }
}
