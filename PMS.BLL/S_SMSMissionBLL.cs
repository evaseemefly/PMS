using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model.ViewModel;
using PMS.Model.EqualCompare;

namespace PMS.BLL
{
    public partial class S_SMSMissionBLL: BaseBLL<S_SMSMission>, IS_SMSMissionBLL,IBaseDelBLL,ICanBeDel
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
        public List<S_SMSMission> GetMissionExt(List<int> missionIdsByUser,bool showDel)
        {
            var list_missionExt= GetAllList();
            //8月31日修改签名及方法
            
            list_missionExt = list_missionExt.Where(m => !missionIdsByUser.Contains(m.SMID)).ToList();
            //若显示删除标记为false，则取出所有未被删除的任务集合
            if (!showDel)
                list_missionExt=list_missionExt.Where(m => m.isDel == false).ToList();
            return list_missionExt;
        }

        ///<summary>
        ///根据选中任务获得群组
        ///</summary>
        ///<returns></returns>
        public List<P_Group> GetMMSGroups(bool isPass, S_SMSMission SMSMission)
        {

            return GetBaseGroupMission(isPass, SMSMission).Where(r => r.isMMS == (int)PMS.Model.Enum.MMS_Enum.mms).Select(r => r.P_Group).ToList();
        }

        ///<summary>
        ///根据选中任务获得群组
        ///</summary>
        ///<returns></returns>
        public List<P_Group> GetSMSGroups(bool isPass, S_SMSMission SMSMission)
        {
            return GetBaseGroupMission(isPass, SMSMission).Where(r => r.isMMS == (int)PMS.Model.Enum.MMS_Enum.sms).Select(r => r.P_Group).ToList();
        }

        public IEnumerable<R_Group_Mission> GetBaseGroupMission(bool isPass, S_SMSMission smsMission)
        {
            if (smsMission != null)
            {
                var list_R_Group_Mission = smsMission.R_Group_Mission;
                var r_group_mission = (
                   from r in list_R_Group_Mission
                   where r.isPass == isPass
                   select r
                    );
                return r_group_mission;
            }
            return null;
        }

        private void GetPersonByMissionFactory(int smid,int isMMS,bool isMiddle)
        {

        }

        private void GetPersonByMission_MMS()
        {

        }

        private void GetPersonByMission_SMS()
        {

        }

        private void BaseGetGroupByMission(S_SMSMission mission)
        {
            var groups_allow = from r in mission.R_Group_Mission
                               where r.isPass == true && r.P_Group.isDel == false && r.isMMS == 0
                               select r.P_Group;
            //2.2 禁用的群组
            var groups_forbid = from r in mission.R_Group_Mission
                                where r.isPass == false && r.P_Group.isDel == false && r.isMMS == 0
                                select r.P_Group;
        }

        private List<P_PersonInfo> BaseGetPersonByMission(int smid,PMS.Model.Enum.MMS_Enum isMms, bool isMiddle)
        {
            //1 根据mid获取指定任务对象
            var mission = GetListBy(s => s.SMID == smid).FirstOrDefault();
            //启用的联系人
            List<P_PersonInfo> list_person_allow = new List<P_PersonInfo>();
            //禁用的联系人
            List<P_PersonInfo> list_person_forbid = new List<P_PersonInfo>();

            var groups_allow = from r in mission.R_Group_Mission
                               where r.isPass == true && r.P_Group.isDel == false && r.isMMS == (int)isMms
                               select r.P_Group;
            //2.2 禁用的群组
            var groups_forbid = from r in mission.R_Group_Mission
                                where r.isPass == false && r.P_Group.isDel == false && r.isMMS == (int)isMms
                                select r.P_Group;
            ////2.1 创建该任务所拥有的群组对象集合
            //List < P_Group > list_group = new List<P_Group>();
            ////2.2 添加至群组对象集合中
            //group.ForEach(g => list_group.Add(g.P_Group));
            //2.3 根据群组对象集合获取该群组集合中所共有的联系人
            groups_allow.ToList().ForEach(g => list_person_allow.AddRange(g.P_PersonInfo));
            groups_forbid.ToList().ForEach(g => list_person_forbid.AddRange(g.P_PersonInfo));

            //3 根据短信任务查找对应的部门
            var departments_allow = from r in mission.R_Department_Mission
                                    where r.isPass == true && r.P_DepartmentInfo.isDel == false && r.isMMS == (int)isMms
                                    select r.P_DepartmentInfo;

            var departments_forbid = from r in mission.R_Department_Mission
                                     where r.isPass == false && r.P_DepartmentInfo.isDel == false && r.isMMS == (int)isMms
                                     select r.P_DepartmentInfo;

            ////3.1 创建该任务所拥有的部门对象集合
            //List < P_DepartmentInfo > list_department = new List<P_DepartmentInfo>();
            ////3.2 添加至部门对象集合中
            //department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            departments_allow.ToList().ForEach(d => list_person_allow.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));

            departments_forbid.ToList().ForEach(d => list_person_forbid.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));
            var list_person_forbid_ids = from p in list_person_forbid
                                         select p.PID;
            //4 将联系人集合去重
            list_person_allow = list_person_allow.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).Select(p => p.ToMiddleModel()).ToList();
            //去除禁用的联系人
            if (isMiddle)
            {

                list_person_allow = (from p in list_person_allow
                                     where !list_person_forbid_ids.Contains(p.PID)
                                     select p.ToMiddleModel()).ToList();
            }

            else
            {
                list_person_allow = (from p in list_person_allow
                                     where !list_person_forbid_ids.Contains(p.PID)
                                     select p).ToList();
            }
            return list_person_allow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<P_PersonInfo> GetPersonByMission(int smid,PMS.Model.Enum.MMS_Enum isMMS, bool isMiddle)
        {
            
            //1 根据mid获取指定任务对象
            var mission = GetListBy(s => s.SMID == smid).FirstOrDefault();

            ExtEntityBLL.ExtEntity_Mission mission_Ext = new ExtEntityBLL.ExtEntity_Mission(mission);

            //2 根据短信任务查找对应的群组
            //10月29日
            //以下有修改：注意：筛选时需要剔除已经删除的（软删除的）各类对象!
            //2.1 启用的群组
            //获取短信联系人 1月6日添加 By QuYuan
            #region 以下已全部重写，注释备份
            //if (isMMS == 0)
            //{
            //    //启用的联系人
            //    List<P_PersonInfo> list_person_allow = new List<P_PersonInfo>();
            //    //禁用的联系人
            //    List<P_PersonInfo> list_person_forbid = new List<P_PersonInfo>();
            //    var groups_allow = from r in mission.R_Group_Mission
            //                       where r.isPass == true && r.P_Group.isDel == false && r.isMMS == 0
            //                       select r.P_Group;
            //    //2.2 禁用的群组
            //    var groups_forbid = from r in mission.R_Group_Mission
            //                        where r.isPass == false && r.P_Group.isDel == false && r.isMMS == 0
            //                        select r.P_Group;
            //    ////2.1 创建该任务所拥有的群组对象集合
            //    //List < P_Group > list_group = new List<P_Group>();
            //    ////2.2 添加至群组对象集合中
            //    //group.ForEach(g => list_group.Add(g.P_Group));
            //    //2.3 根据群组对象集合获取该群组集合中所共有的联系人


            //    groups_allow.ToList().ForEach(g => list_person_allow.AddRange(g.P_PersonInfo));
            //    groups_forbid.ToList().ForEach(g => list_person_forbid.AddRange(g.P_PersonInfo));

            //    //3 根据短信任务查找对应的部门
            //    var departments_allow = from r in mission.R_Department_Mission
            //                            where r.isPass == true && r.P_DepartmentInfo.isDel == false && r.isMMS == 0
            //                            select r.P_DepartmentInfo;

            //    var departments_forbid = from r in mission.R_Department_Mission
            //                             where r.isPass == false && r.P_DepartmentInfo.isDel == false && r.isMMS == 0
            //                             select r.P_DepartmentInfo;

            //    ////3.1 创建该任务所拥有的部门对象集合
            //    //List < P_DepartmentInfo > list_department = new List<P_DepartmentInfo>();
            //    ////3.2 添加至部门对象集合中
            //    //department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            //    //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            //    departments_allow.ToList().ForEach(d => list_person_allow.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));

            //    departments_forbid.ToList().ForEach(d => list_person_forbid.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));
            //    var list_person_forbid_ids = from p in list_person_forbid
            //                                 select p.PID;
            //    //4 将联系人集合去重
            //    list_person_allow = list_person_allow.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).Select(p => p.ToMiddleModel()).ToList();
            //    //去除禁用的联系人
            //    if (isMiddle)
            //    {

            //        list_person_allow = (from p in list_person_allow
            //                             where !list_person_forbid_ids.Contains(p.PID)
            //                             select p.ToMiddleModel()).ToList();
            //    }

            //    else
            //    {
            //        list_person_allow = (from p in list_person_allow
            //                             where !list_person_forbid_ids.Contains(p.PID)
            //                             select p).ToList();
            //    }
            //    return list_person_allow;

            //}
            ////获取彩信联系人 1月6日添加 By QuYuan
            //else if(isMMS == 1)

            //{
            //    //启用的联系人
            //    List<P_PersonInfo> list_person_allow = new List<P_PersonInfo>();
            //    //禁用的联系人
            //    List<P_PersonInfo> list_person_forbid = new List<P_PersonInfo>();
            //    var groups_allow = from r in mission.R_Group_Mission
            //                       where r.isPass == true && r.isMMS == 1 && r.P_Group.isDel == false && r.isMMS == 1
            //                       select r.P_Group;
            //    //2.2 禁用的群组
            //    var groups_forbid = from r in mission.R_Group_Mission
            //                        where r.isPass == false && r.P_Group.isDel == false && r.isMMS == 1
            //                        select r.P_Group;
            //    ////2.1 创建该任务所拥有的群组对象集合
            //    //List < P_Group > list_group = new List<P_Group>();
            //    ////2.2 添加至群组对象集合中
            //    //group.ForEach(g => list_group.Add(g.P_Group));
            //    //2.3 根据群组对象集合获取该群组集合中所共有的联系人

            //    groups_allow.ToList().ForEach(g => list_person_allow.AddRange(g.P_PersonInfo));
            //    groups_forbid.ToList().ForEach(g => list_person_forbid.AddRange(g.P_PersonInfo));

            //    //3 根据短信任务查找对应的部门
            //    var departments_allow = from r in mission.R_Department_Mission
            //                            where r.isPass == true && r.P_DepartmentInfo.isDel == false && r.isMMS == 1
            //                            select r.P_DepartmentInfo;

            //    var departments_forbid = from r in mission.R_Department_Mission
            //                             where r.isPass == false && r.P_DepartmentInfo.isDel == false && r.isMMS == 1
            //                             select r.P_DepartmentInfo;

            //    ////3.1 创建该任务所拥有的部门对象集合
            //    //List < P_DepartmentInfo > list_department = new List<P_DepartmentInfo>();
            //    ////3.2 添加至部门对象集合中
            //    //department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            //    //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            //    departments_allow.ToList().ForEach(d => list_person_allow.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));

            //    departments_forbid.ToList().ForEach(d => list_person_forbid.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));
            //    var list_person_forbid_ids = from p in list_person_forbid
            //                                 select p.PID;
            //    //4 将联系人集合去重
            //    list_person_allow = list_person_allow.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).Select(p => p.ToMiddleModel()).ToList();
            //    //去除禁用的联系人
            //    if (isMiddle)
            //    {

            //        list_person_allow = (from p in list_person_allow
            //                             where !list_person_forbid_ids.Contains(p.PID)
            //                             select p.ToMiddleModel()).ToList();
            //    }

            //    else
            //    {
            //        list_person_allow = (from p in list_person_allow
            //                             where !list_person_forbid_ids.Contains(p.PID)
            //                             select p).ToList();
            //    }
            //    return list_person_allow;
            //}
            #endregion
            //1月7日 重新修改 重复代码较多 重写并重新封装 ——liu
            return mission_Ext.GetPersonAllowByMission(smid, isMMS, true);      
            
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
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            var list_model = this.GetListByIds(list_id);
            list_model.ForEach(p => p.isDel = false);
            try
            {
                this.UpdateByList(list_model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 根据传入的id集合执行物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            //1. 得到所有要删除的实体集合
            var list_model = this.GetListByIds(list_ids);
            if (list_model == null) { return false; }
            foreach (var item in list_model)
            {
                
                //item.S_SMSMsgContent.Clear();
                //item.S_SMSContent.Clear();
                //item.S_SMSRecord_History.Clear();
                //this.CurrentDAL.SaveChange();

                #region 采用以下方式——可行
                var list_r_Department_Mission = item.R_Department_Mission.Select(r => r).ToList();
                R_Department_MissionBLL rdmBLL = new R_Department_MissionBLL();
                rdmBLL.DelByList(list_r_Department_Mission);

                var list_r_Group_Mission = item.R_Group_Mission.Select(r => r).ToList();
                R_Group_MissionBLL rgmBLL = new R_Group_MissionBLL();
                rgmBLL.DelByList(list_r_Group_Mission);

                var list_r_UserInfo_SMSMission = item.R_UserInfo_SMSMission.Select(r => r).ToList();
                R_UserInfo_SMSMissionBLL rusBLL = new R_UserInfo_SMSMissionBLL();
                rusBLL.DelByList(list_r_UserInfo_SMSMission);
                #endregion

                #region 暂时不用
                //item.R_Department_Mission.Clear();
                //item.R_Group_Mission.Clear();
                //item.R_UserInfo_SMSMission.Clear();
                #endregion
            }
            if (CanBeDel(list_ids) || !isCheckCanBeDel)
            {
                try
                {
                    //3. 从数据库中删除这些实体对象
                    //this.CurrentDAL.UpdateByList(list_model);
                    this.CurrentDAL.SaveChange();
                    this.CurrentDAL.DelByList(list_model);
                    this.CurrentDAL.SaveChange();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;   
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

        public bool SetSMSMission4Group(int smid, List<ViewModel_isPass_Group> list_isPass_group,bool ismms)
        {
            var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            List<R_Group_Mission> list = new List<R_Group_Mission>();
            //var times = 0;
            foreach (var item in list_isPass_group)
            {
                //2017-04-12 加入短彩信判断
                var r_group_mission = this.CurrentDBSession.
                    R_Group_MissionDAL.
                    GetListBy(r => r.MissionID == smid && r.GroupID == item.gid).
                    Where(r=>r.isMMS==((ismms)?1:0)).//2017-04-12 加入判断是否为短彩信的判断
                    FirstOrDefault();
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
                    r_Group_Mission.isMMS= (ismms) ? 1 : 0;
                    this.CurrentDBSession.R_Group_MissionDAL.Create(r_Group_Mission);
                }
                //times++;
            }

            #region 传入的的与本任务相关的群组中筛选出需要禁用的群组集合
            //传入的的与本任务相关的群组中筛选出需要禁用的群组集合
            //var list_isNotPass_group_ids =
            //    (from g in list_isPass_group
            //     where g.isPass==false
            //     select g.gid).ToArray();
            //var list_isPass_group_ids= (from g in list_isPass_group
            //                            where g.isPass == true
            //                            select g.gid).ToArray();
            #endregion
            //7月28日从群组——任务关系表 中删除 本任务但在传入的集合中没有的对象

            var group_ids = (from g in list_isPass_group
                                  select g.gid).ToArray();
            //删除关系表中存在，但在传入的集合中既不是禁用的也不是启用的权限
            var list_2del_group = this.CurrentDBSession.
                R_Group_MissionDAL.
                GetListBy(r => r.MissionID == smid&&!group_ids.Contains(r.GroupID)).
                Where(r=>r.isMMS == ((ismms) ? 1 : 0)).//2017-04-12 加入是否为彩信的判断
                ToList();

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

        #region 2017-04-12 注释掉，可删除
        /// <summary>
        /// 为任务分配部门
        /// </summary>
        /// <returns></returns>

        //public bool SetSMSMission4Department(int smid, List<ViewModel_isPass_Department> list_isPass_department)
        //{
        //    #region 7月28日
        //    //var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
        //    //List<R_Department_Mission> list = new List<R_Department_Mission>();
        //    //var times = 0;
        //    //foreach (var did in list_departmentIDs)
        //    //{
        //    //    var r_department_mission = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && r.DepartmentID == did).FirstOrDefault();
        //    //    //根据departmentID与smID从R表中找到唯一的记录
        //    //    if (r_department_mission != null)
        //    //    {
        //    //        r_department_mission.isPass = list_isPass[times];
        //    //    }
        //    //    else if (r_department_mission == null)
        //    //    {
        //    //        R_Department_Mission r_Department_Mission = new R_Department_Mission();
        //    //        //r_UserInfo_ActionInfo.UserInfo = user;
        //    //        r_Department_Mission.MissionID = smid;
        //    //        //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
        //    //        r_Department_Mission.isPass = list_isPass[times];
        //    //        //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
        //    //        r_Department_Mission.DepartmentID = did;
        //    //        this.CurrentDBSession.R_Department_MissionDAL.Create(r_Department_Mission);
        //    //    }
        //    //    times++;
        //    //}
        //    //var list_del = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && !list_departmentIDs.Contains(r.DepartmentID));
        //    #endregion
        //    var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
        //    List<R_Department_Mission> list = new List<R_Department_Mission>();
        //    //var times = 0;
        //    foreach (var item in list_isPass_department)
        //    {
        //        var r_department_mission = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && r.DepartmentID == item.did).FirstOrDefault();
        //        //根据groupID与smID从R表中找到唯一的记录
        //        if (r_department_mission != null)
        //        {
        //            r_department_mission.isPass = item.isPass;
        //        }
        //        else if (r_department_mission == null)
        //        {
        //            R_Department_Mission r_Department_Mission = new R_Department_Mission();
        //            //r_UserInfo_ActionInfo.UserInfo = user;
        //            r_Department_Mission.MissionID = smid;
        //            //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
        //            r_Department_Mission.isPass = item.isPass;
        //            //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
        //            r_Department_Mission.DepartmentID = item.did;
        //            this.CurrentDBSession.R_Department_MissionDAL.Create(r_Department_Mission);
        //        }

        //    }

        //    var department_ids = (from d in list_isPass_department
        //                     select d.did).ToArray();
        //    //删除关系表中存在，但在传入的集合中既不是禁用的也不是启用的权限
        //    var list_2del_department = this.CurrentDBSession.R_Department_MissionDAL.GetListBy(r => r.MissionID == smid && !department_ids.Contains(r.DepartmentID)).ToList();

        //    foreach (var item in list_2del_department)
        //    {
        //        this.CurrentDBSession.R_Department_MissionDAL.Del(item);
        //    }
        //    try
        //    {
        //        return this.CurrentDBSession.SaveChanges();

        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
        #endregion
        
        /// <summary>
        /// 为任务分配部门
        /// </summary>
        /// <returns></returns>

        public bool SetSMSMission4Department(int smid, List<ViewModel_isPass_Department> list_isPass_department, bool ismms)
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
                var r_department_mission = this.CurrentDBSession.
                    R_Department_MissionDAL.
                    GetListBy(r => r.MissionID == smid && r.DepartmentID == item.did).
                    Where(r => r.isMMS == ((ismms) ? 1 : 0)).//2017-04-12 加入判断是否为短彩信的判断
                    FirstOrDefault();
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
                    r_Department_Mission.isMMS = ((ismms) ? 1 : 0);
                    this.CurrentDBSession.R_Department_MissionDAL.Create(r_Department_Mission);
                }

            }

            var department_ids = (from d in list_isPass_department
                                  select d.did).ToArray();
            //删除关系表中存在，但在传入的集合中既不是禁用的也不是启用的权限
            var list_2del_department = this.CurrentDBSession.
                R_Department_MissionDAL.
                GetListBy(r => r.MissionID == smid && !department_ids.Contains(r.DepartmentID)).
                 Where(r => r.isMMS == ((ismms) ? 1 : 0)).//2017-04-12 加入判断是否为短彩信的判断
                ToList();

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

        public bool RemoveAllGroup(int smid, bool ismms)
        {
            //var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();

            var list_del = this.CurrentDBSession.
                R_Group_MissionDAL.
                GetListBy(r => r.MissionID == smid).
                Where(r => r.isMMS == ((ismms) ? 1 : 0));//2017-04-12 加入判断是否为短彩信的判断;

            //如果原本该任务拥有的群组列表就为空
            if (list_del.FirstOrDefault() == null)
            {
                return true;
            }
            //如果原本该任务拥有的群组列表不为空
            //注意取出的list_del添加回数据上下文对象中时，需要让其立即加载，即Tolist或FirstOrDefualt，否则会提示正在被占用
            //2017-04-12 casablanca
            foreach (var item in list_del.ToList())
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

        public bool RemoveAllDepartment(int smid,bool ismms)
        {
           // var SMSMission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(r => r.SMID == smid).FirstOrDefault();
            var list_del = this.CurrentDBSession.
                R_Department_MissionDAL.
                GetListBy(r => r.MissionID == smid).
                Where(r => r.isMMS == ((ismms) ? 1 : 0))//2017-04-12 加入判断是否为短彩信的判断
                ;
            //如果原本该任务拥有的群组列表就为空
            if (list_del.FirstOrDefault() == null)
            {
                return true;
            }
            //如果原本该任务拥有的群组列表不为空
            //注意取出的list_del添加回数据上下文对象中时，需要让其立即加载，即Tolist或FirstOrDefualt，否则会提示正在被占用
            //2017-04-12 casablanca
            foreach (var item in list_del.ToList())
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
            var list_model = this.GetListBy(p => true,true).ToList();
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
            var list_model = this.GetListBy(p => p.SMID != id,true).ToList();
            return list_model.Exists(p => p.SMSMissionName.Equals(name));
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            var array = this.GetListBy(a => a.isDel == true).ToList();
            return array.Select(a => a.ToRecycleModel()).ToList();
        }

        /// <summary>
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            var query = base.GetPageList<DateTime>(pageIndex, pageSize, a => a.isDel == true, a => a.ModifiedOnTime, true);
            rowCount = query.Count();
            return query.ToList().Select(a => a.ToRecycleModel()).ToList();
        }

        public bool CanBeDel(List<int> list_ids)
        {
            var query = base.GetListBy(a => list_ids.Contains(a.SMID));
            foreach (var item in query)
            {
                if (item.R_Department_Mission.Count() > 0)
                {
                    return false;
                }
                if (item.R_Group_Mission.Count() > 0)
                {
                    return false;
                }
                if (item.R_UserInfo_SMSMission.Count() > 0)
                {
                    return false;
                }
                if (item.S_SMSContent.Count() > 0)
                {
                    return false;
                }
                if (item.S_SMSMsgContent.Count() > 0)
                {
                    return false;
                }               
            }
            return true;
        }
    }
}
