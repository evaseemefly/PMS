using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.IBLL
{
    public partial interface IS_SMSRecord_CurrentBLL
    {
        bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive,int scid);

        /// <summary>
        /// 在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        bool CreateReceieveMsg(string msgid, List<string> list_phones);

        void getResult(List<SMSModel_QueryReceive> list_QueryReceive, SMSModel_MsgResult result);

        //bool SaveTempReceieveMsg(string msgid, List<string> list_phones);
    }
}
