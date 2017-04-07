using PMS.Model.Enum;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMS
{
    public interface IMMSQuery
    {
        /// <summary>
        /// 根据传入的信息进行短信发送状态的查询
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        bool QueryMsg(MMSModel_Query smsdata, out List<MMSModel_QueryReceive> list_receiveModel);

        /// <summary>
        /// 根据刚刚查询所返回的回执集合
        /// 获取本次查询状态——是否已经查询完毕（若是第一个线程，则说明当前查询后，本次线程中所有用户已经查询完毕；
        /// 若是第二个线程，则还需要做相关操作
        /// </summary>
        /// <param name="list">刚刚查询所返回的回执集合</param>
        /// <returns></returns>
        QueryState_Enum GetQueryState(List<MMSModel_QueryReceive> list);
    }
}
