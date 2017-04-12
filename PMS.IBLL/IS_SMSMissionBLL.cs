using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.ViewModel;

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
        List<S_SMSMission> GetMissionExt(List<int> missionIdsByUser, bool showDel);

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
        bool SetSMSMission4Group(int smid, List<ViewModel_isPass_Group> list_isPass_group,bool ismms);
        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的任务对象
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="list_groupIDs"></param>
        /// <param name="list_isPass"></param>
        /// <returns></returns>

        bool SetSMSMission4Department(int smid, List<ViewModel_isPass_Department> list_isPass_group, bool ismms);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        List<P_PersonInfo> GetPersonByMission(int smid, PMS.Model.Enum.MMS_Enum IsMMS, bool isMiddle);

        ///<summary>
        ///根据选中任务获得群组
        ///</summary>
        ///<returns></returns>
        List<P_Group> GetMMSGroups(bool isPass, S_SMSMission SMSMission);


        ///<summary>
        ///根据选中任务获得群组
        ///</summary>
        ///<returns></returns>
        List<P_Group> GetSMSGroups(bool isPass, S_SMSMission SMSMission);


        /// <summary>
        /// 移除所有传入ID的任务所拥有的群组
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        bool RemoveAllGroup(int smid, bool ismms);

        /// <summary>
        /// 移除所有传入ID的任务所拥有的部门
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        bool RemoveAllDepartment(int smid, bool ismms);

        bool AddValidation(String name);

        bool EditValidation(int id, String name);

    }

}
