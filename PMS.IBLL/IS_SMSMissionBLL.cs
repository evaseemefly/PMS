using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.IBLL
{
    public partial interface IS_SMSMissionBLL
    {

        /// <summary>
        /// 查询全部的短信任务
        /// </summary>
        /// <returns></returns>
        List<S_SMSMission> GetAllList();

        /// <summary>
        /// 从数据库中根据id集合查询返回指定的S_SMSMission集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        List<S_SMSMission> GetListByIds(List<int> list_ids);

        /// <summary>
        /// 修改指定的S_SMSMissionId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftRoleInfos(List<int> list_ids);

    }

}
