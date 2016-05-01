using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;
using PMS.IBLL;

namespace PMS.BLL
{
    public partial class S_SMSMissionBLL: BaseBLL<S_SMSMission>, IS_SMSMissionBLL
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的S_SMSMission集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<S_SMSMission> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.SMID)).ToList();

        }

        /// <summary>
        /// 修改指定的S_SMSMission 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftRoleInfos(List<int> list_ids)
        {
            List<S_SMSMission> list = new List<S_SMSMission>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //修改其中的删除标记
                item.isDel = true;
                //并添加至新创建的集合中
                list.Add(item);
            }
            try
            {
                this.UpdateByList(list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// 为任务分配群组
        /// </summary>
        /// <returns></returns>

        public bool SetSMSMission4Group(int smid, List<int> list_groupIDs, List<bool> list_isPass)
        {
            var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            List<R_Group_Mission> list = new List<R_Group_Mission>();
            var times = 0;
            foreach (var gid in list_groupIDs)
            {
                var r_group_mission = this.CurrentDBSession.R_Group_MissionDAL.GetListBy(r => r.MissionID == smid && r.GroupID == gid).FirstOrDefault();
                //根据ActionID与UserID从R表中找到唯一的记录
                if (r_group_mission != null)
                {
                    r_group_mission.isPass = list_isPass[times];
                }
                else if (r_group_mission == null)
                {
                    R_Group_Mission r_Group_Mission = new R_Group_Mission();
                    //r_UserInfo_ActionInfo.UserInfo = user;
                    r_Group_Mission.MissionID = smid;
                    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                    r_Group_Mission.isPass = list_isPass[times];
                    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
                    r_Group_Mission.GroupID = gid;
                    this.CurrentDBSession.R_Group_MissionDAL.Create(r_Group_Mission);
                }
                times++;
            }
            var list_del = this.CurrentDBSession.R_Group_MissionDAL.GetListBy(r => r.MissionID == smid && !list_groupIDs.Contains(r.GroupID));
            foreach (var item in list_del)
            {
                this.CurrentDBSession.R_Group_MissionDAL.Del(item);
            }
            try
            {
            return this.CurrentDBSession.SaveChanges();

            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
