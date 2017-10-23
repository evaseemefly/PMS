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
        /// <summary>
        /// 将查询结果写入数据库
        /// </summary>
        /// <param name="list_QueryReceive"></param>
        /// <param name="scid"></param>
        /// <returns></returns>
        bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive,int scid);

        /// <summary>
        /// 根据指定的短信，将该短信的查询状态写回数据库
        /// （更新S_SMSRecord_Current表）
        /// </summary>
        /// <param name="list_QueryReceive">写会的结果集合</param>
        /// <param name="msgid">短信标识符</param>
        /// <returns></returns>
        bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive, string msgid);

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
