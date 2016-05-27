using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
   public partial interface IS_SMSMsgContentBLL
    {
        /// <summary>
        /// 根据用户id以及任务id查询与之相对应的短信模板实体对象
        /// </summary>
        /// <param name="uid">UserID</param>
        /// <param name="mid">MissionID</param>
        /// <param name="isMiddle">是否转成中间实体</param>
        /// <returns></returns>
        S_SMSMsgContent GetModelByUserAndMission(int uid, int mid, bool isMiddle);
    }
}
