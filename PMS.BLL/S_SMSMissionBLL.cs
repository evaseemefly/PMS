using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class S_SMSMissionBLL: BaseBLL<S_SMSMission>, IS_SMSMissionBLL,IBaseDelBLL
    {
        /// <summary>
        /// 查询全部的短信任务
        /// </summary>
        /// <returns></returns>
        public List<S_SMSMission> GetAllList()
        {
            return GetListBy(s => s.isDel == false).ToList();
        }

        /// <summary>
        /// 根据该用户所拥有的任务id数组，从全部任务中去除这些任务
        /// </summary>
        /// <param name="missionIdsByUser"></param>
        /// <returns></returns>
        public List<S_SMSMission> GetMissionExt(List<int> missionIdsByUser)
        {
            var list_missionExt= GetAllList();
            list_missionExt = list_missionExt.Where(m => !missionIdsByUser.Contains(m.SMID)).ToList();
            return list_missionExt;
        }

        /// <summary>
        /// 查询全部短信内容，并根据参数决定是否进行中间变量的转换
        /// </summary>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<S_SMSMission> GetAllList(bool isMiddle)
        {
            if(isMiddle)
            {
                return GetListBy(s => s.isDel == false).ToList().Select(m=>m.ToMiddleModel()).ToList();
            }
            else
            {
                return GetListBy(s => s.isDel == false).ToList();
            }
            
        }

        /// <summary>
        /// 根据传入的id集合执行物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            return true;
        }

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

        public bool SetSMSMission4Group(int smid, List<ViewModel_isPass_Group> list_isPass_group)
        {
            var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            List<R_Group_Mission> list = new List<R_Group_Mission>();
            //var times = 0;
            foreach (var item in list_isPass_group)
            {
                var r_group_mission = this.CurrentDBSession.R_Group_MissionDAL.GetListBy(r => r.MissionID == smid && r.GroupID == item.gid).FirstOrDefault();
                //根据groupID与smID从R表中找到唯一的记录
                if (r_group_mission != null)
                {
                    r_group_mission.isPass = item.isPass;
                }
                else if (r_group_mission == null)
                {
                    R_Group_Mission r_Group_Mission = new R_Group_Mission();
                    //r_UserInfo_ActionInfo.UserInfo = user;
                    r_Group_Mission.MissionID = smid;
                    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                    r_Group_Mission.isPass = item.isPass;
                    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
                    r_Group_Mission.GroupID = item.gid;
                    this.CurrentDBSession.R_Group_MissionDAL.Create(r_Group_Mission);
                }
                //times++;
            }
            //7月28日从群组——任务关系表 中删除 本任务但在传入的集合中没有的对象
            //传入的的与本任务相关的群组中筛选出需要禁用的群组集合
            //var list_isNotPass_group_ids =
            //    (from g in list_isPass_group
            //     where g.isPass==false
            //     select g.gid).ToArray();
            //var list_isPass_group_ids= (from g in list_isPass_group
            //                            where g.isPass == true
            //                            select g.gid).ToArray();
            var group_ids = (from g in list_isPass_group
                                  select g.gid).ToArray();
            //删除关系表中存在，但在传入的集合中既不是禁用的也不是启用的权限
            var list_2del_group = this.CurrentDBSession.R_Group_MissionDAL.GetListBy(r => r.MissionID == smid&&!group_ids.Contains(r.GroupID)).ToList();
            foreach (var item in list_2del_group)
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

        /// <summary>
        /// 为任务分配部门
        /// </summary>
        /// <returns></returns>

        public bool SetSMSMission4Department(int smid, List<ViewModel_isPass_Department> list_isPass_department)
        {
            #region 7月28日
            //var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            //List<R_Department_Mission> list = new List<R_Department_Mission>();
            //var times = 0;
            //foreach (var did in list_departmentIDs)
            //{
            //    var r_department_mission = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && r.DepartmentID == did).FirstOrDefault();
            //    //根据departmentID与smID从R表中找到唯一的记录
            //    if (r_department_mission != null)
            //    {
            //        r_department_mission.isPass = list_isPass[times];
            //    }
            //    else if (r_department_mission == null)
            //    {
            //        R_Department_Mission r_Department_Mission = new R_Department_Mission();
            //        //r_UserInfo_ActionInfo.UserInfo = user;
            //        r_Department_Mission.MissionID = smid;
            //        //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
            //        r_Department_Mission.isPass = list_isPass[times];
            //        //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
            //        r_Department_Mission.DepartmentID = did;
            //        this.CurrentDBSession.R_Department_MissionDAL.Create(r_Department_Mission);
            //    }
            //    times++;
            //}
            //var list_del = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && !list_departmentIDs.Contains(r.DepartmentID));
            #endregion
            var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            List<R_Department_Mission> list = new List<R_Department_Mission>();
            //var times = 0;
            foreach (var item in list_isPass_department)
            {
                var r_department_mission = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && r.DepartmentID == item.did).FirstOrDefault();
                //根据groupID与smID从R表中找到唯一的记录
                if (r_department_mission != null)
                {
                    r_department_mission.isPass = item.isPass;
                }
                else if (r_department_mission == null)
                {
                    R_Department_Mission r_Department_Mission = new R_Department_Mission();
                    //r_UserInfo_ActionInfo.UserInfo = user;
                    r_Department_Mission.MissionID = smid;
                    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                    r_Department_Mission.isPass = item.isPass;
                    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
                    r_Department_Mission.DepartmentID = item.did;
                    this.CurrentDBSession.R_Department_MissionDAL.Create(r_Department_Mission);
                }
                
            }
            
            var department_ids = (from d in list_isPass_department
                             select d.did).ToArray();
            //删除关系表中存在，但在传入的集合中既不是禁用的也不是启用的权限
            var list_2del_department = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && !department_ids.Contains(r.DepartmentID)).ToList();

            foreach (var item in list_2del_department)
            {
                this.CurrentDBSession.R_Department_MissionDAL.Del(item);
            }
            try
            {
                return this.CurrentDBSession.SaveChanges();

            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// 移除所有传入ID的任务所拥有的群组
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        public bool RemoveAllGroup(int smid)
        {
            //var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();

            var list_del = this.CurrentDBSession.R_Group_MissionDAL.GetListBy(r => r.MissionID == smid);

            //如果原本该任务拥有的群组列表就为空
            if (list_del.FirstOrDefault() == null)
            {
                return true;
            }
            //如果原本该任务拥有的群组列表不为空
            foreach (var item in list_del)
            {
                this.CurrentDBSession.R_Group_MissionDAL.Del(item);
            }
            try
            {
                return this.CurrentDBSession.SaveChanges();

            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 移除所有传入ID的任务所拥有的部门
        /// </summary>
        /// <param name="smid"></param>
        /// <returns></returns>

        public bool RemoveAllDepartment(int smid)
        {
           // var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            var list_del = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid);
            //如果原本该任务拥有的群组列表就为空
            if (list_del.FirstOrDefault() == null)
            {
                return true;
            }
            //如果原本该任务拥有的群组列表不为空
            foreach (var item in list_del)
            {
                this.CurrentDBSession.R_Department_MissionDAL.Del(item);
            }
            try
            {
                return this.CurrentDBSession.SaveChanges();

            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// 添加新任务时的数据验证（是否重名）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(p => p.isDel == false).ToList();
            return list_model.Exists(p => p.SMSMissionName.Equals(name));
        }
        /// <summary>
        /// 编辑任务时候的数据验证(是否重名)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool EditValidation(int id,String name)
        {
            var list_model = this.GetListBy(p => p.SMID != id && p.isDel == false).ToList();
            return list_model.Exists(p => p.SMSMissionName.Equals(name));
        }
        
    }
}
