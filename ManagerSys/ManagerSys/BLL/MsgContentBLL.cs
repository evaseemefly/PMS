using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSys.BLL
{
    class MsgContentRecordBLL
    {
        protected PMS.IBLL.IS_SMSContentBLL msgContentRecordBLL;
        protected PMS.IBLL.IS_SMSRecord_CurrentBLL msgRecordCurrentBLL;
        public MsgContentRecordBLL()
        {
            msgContentRecordBLL = new PMS.BLL.S_SMSContentBLL();
            msgRecordCurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();
        }
        /// <summary>
        /// 根据任务id、时间范围获取短信记录
        /// </summary>
        /// <param name="SMID"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeStop"></param>
        /// <returns></returns>
        public List<PMS.Model.S_SMSContent> GetMsgRecord(int SMID,DateTime timeStart,DateTime timeStop)
        {
            var MsgRecordList = msgContentRecordBLL.GetListBy(m => m.SMID == SMID & DateTime.Compare(m.SendDateTime, timeStop) <= 0 & DateTime.Compare(timeStart, m.SendDateTime) <= 0).ToList();
            return MsgRecordList;
        }

        /// <summary>
        /// 根据短信记录的ID获取短信所发送的人数
        /// </summary>
        /// <param name="SCID"></param>
        /// <returns></returns>
        public int GetMsgPersonNumber(int SCID)
        {
            int pn = 0;
            pn = msgRecordCurrentBLL.GetListBy(r => r.SCID == SCID).ToList().Count;
            return pn;
        }

    }
}
