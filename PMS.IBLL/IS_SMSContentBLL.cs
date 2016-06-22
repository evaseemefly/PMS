using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.IBLL
{
    public partial interface IS_SMSContentBLL
    {
        bool SaveMsg(SMSModel_Receive receive, string smsContent, string mid, int uid);

        void getResult(SMSModel_Receive receive,SMSModel_MsgResult result);

        /// <summary>
        /// 根据联系人名称以及电话号码进行多条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="model">包含 电话号码 以及 联系人名称 的查询实体对象</param>
        /// <param name="cid"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        List<S_SMSRecord_Current> GetSMSRecordListByQuery(int pageIndex, int pageSize, ref int rowCount, PMS.Model.ViewModel.ViewModel_RecordQueryInfo model, int cid, bool isAsc, bool isMiddle);

    }
}
