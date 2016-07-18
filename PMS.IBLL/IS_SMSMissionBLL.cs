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
        /// 根据该用户所拥有的任务id数组，从全部任务中去除这些任务
        /// </summary>
        /// <param name="missionIdsByUser"></param>
        /// <returns></returns>
        List<S_SMSMission> GetMissionExt(List<int> missionIdsByUser);

        /// <summary>
        /// 修改指定的S_SMSMissionId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftRoleInfos(List<int> list_ids);


        /// <summary>
        /// 将传入的群组id集合赋给传入的Id对应的任务对象
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="list_groupIDs"></param>
        /// <param name="list_isPass"></param>
        /// <returns></returns>
        bool SetSMSMission4Group(int smid, List<int> list_groupIDs, List<bool> list_isPass);
        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的任务对象
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="list_groupIDs"></param>
        /// <param name="list_isPass"></param>
        /// <returns></returns>

        bool SetSMSMission4Department(int smid, List<int> list_departmentIDs, List<bool> list_isPass);


        /// <summary>
        /// 移除所有传入ID的任务所拥有的群组
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        bool RemoveAllGroup(int smid);

        /// <summary>
        /// 移除所有传入ID的任务所拥有的部门
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        bool RemoveAllDepartment(int smid);

        bool AddValidation(String name);

        bool EditValidation(int id, String name);

    }

}
