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
    public partial class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public UserInfoBLL()
        //{
        //    //Console.WriteLine("子类构造函数");
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public override void SetCurrentDAL()
        //{
        //    base.CurrentDAL = base.CurrentDBSession.UserInfoDAL;
        //}
        /// <summary>
        /// 根据id集合批量删除action
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteLogicUserInfos(List<int> list)
        {
            var userInfoList = this.CurrentDBSession.UserInfoDAL.GetListBy(u => list.Contains(u.ID));
            if (userInfoList != null)
            {
                foreach (var user in userInfoList)
                {
                    this.CurrentDBSession.UserInfoDAL.Del(user);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }
        /// <summary>
        /// 修改指定的ActionId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftUserInfos(List<int> list_ids)
        {
            List<UserInfo> list = new List<UserInfo>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //修改其中的删除标记
                item.DelFlag = true;
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
        /// 从数据库中根据id集合查询返回指定的ActionInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<UserInfo> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.ID)).ToList();

        }
        
        /// <summary>
        /// 根据传入的用户id获取该用户的常用群组，并从常用群组中删除传入的群组id集合
        /// </summary>
        /// <param name="list_ids_group">已经拥有的群组id（需要从常用群组中剔除的群组id集合）</param>
        /// <param name="uid">用户id</param>
        /// <param name="isMiddel">是否转成中间对象</param>
        /// <returns></returns>
        public List<P_Group> GetRestGroupListByIds(List<int> list_ids_group,int uid,bool isMiddel)
        {
            //1 获取常用群组
           var list_restgroup= GetGroupListByUID(uid, true);
            //2 从常用群组中剔除该用户已经拥有的群组
            list_restgroup = list_restgroup.Where(g => !list_ids_group.Contains(g.GID)).ToList();
            if(isMiddel)
            {
                return list_restgroup.Select(g=>g.ToMiddleModel()).ToList();
            }
            else
            {
                return list_restgroup;
            }
           
        }

        /// <summary>
        /// 根据用户Id查询该用户所拥有的群组集合（根据用户id获取常用群组）
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="isMiddle">是否中间转换</param>
        /// <returns></returns>
        public List<P_Group> GetGroupListByUID(int uid,bool isMiddle)
        {
            //1 找到指定用户
            var userModel = GetListBy(u => u.ID == uid).FirstOrDefault();

            //2 根据是否禁用删除禁用的群组
           var list_group_isPass= userModel.R_UserInfo_Group.Where(r => r.isPass == true).Select(r=>r.P_Group);
            var list_groupId_isNotPass = userModel.R_UserInfo_Group.Where(r => r.isPass == false).Select(g => g.GID);
            list_group_isPass= list_group_isPass.Where(r => !list_groupId_isNotPass.Contains(r.GID)).ToList();
            if(isMiddle)
            {
                return list_group_isPass.ToList().Select(g => g.ToMiddleModel()).ToList();
            }
            else
            {
                return list_group_isPass.ToList();
            }
            
        }

        //public List<P_Group> GetRestGroupList(List<int> list_ids_group)
        //{
        //    //1 找到指定用户
        //    var userModel = GetListBy(u => u.ID == uid).FirstOrDefault();
        //}

        /// <summary>
        /// 根据UserID查找该用户对应的短信任务
        /// </summary>
        /// <param name="uid">UserInfo ID</param>
        /// <param name="isMiddle">是否转成中间变量（转成中间变量为true）</param>
        /// <returns></returns>
        public List<S_SMSMission> GetMissionListByUID(int uid,bool isMiddle)
        {
            //1 找到对应的用户
            var userModel = GetListBy(u => u.ID == uid).FirstOrDefault();
            List<S_SMSMission> list_mission = new List<S_SMSMission>();
            //2 根据用户查找该用户所用的Mission
            userModel.R_UserInfo_SMSMission.Where(r=>r.isPass==true).ToList().ForEach(r => list_mission.Add(r.S_SMSMission));
            //3 将对应的任务集合转成中间实体
            if (isMiddle)
            {
                return list_mission.Select(m => m.ToMiddleModel()).ToList();
            }
            else
            {
                return list_mission;
            }
            
        }

       

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <returns></returns>
        public bool SetUser4Role(int userID, List<int> list_roleIDs)
        {

            //1 修改User与Role的关系
            //1.1 根据UserID找到对应的UserInfo
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(r => r.ID == userID).FirstOrDefault();
            //1.2 清空原有的关系
            user.RoleInfo.Clear();

            //2 根据roleIDs查询对应的RoleInfo
            foreach (var item in list_roleIDs)
            {
                var roleInfo = this.CurrentDBSession.RoleInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                user.RoleInfo.Add(roleInfo);
                
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 为指定User重新赋予新的任务——指定用户的常用任务（删除不在此任务id集合中的现有任务关系）
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="list_missionIDs">拥有的任务id集合</param>
        /// <returns></returns>
        public bool SetUser4Mission(int userID,List<int> list_missionIDs)
        {
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == userID).FirstOrDefault();
            //user.R_UserInfo_SMSMission.Clear();
            var smids_now = user.R_UserInfo_SMSMission.Select(s => s.SMID).ToList();
            foreach (var item in smids_now)
            {
                var mission_model = user.R_UserInfo_SMSMission.Where(s => s.SMID == item && s.UID == user.ID).FirstOrDefault();
                this.CurrentDBSession.R_UserInfo_SMSMissionDAL.Del(mission_model);
            }
            //添加用户新拥有的常用任务
            foreach (var item in list_missionIDs)
            {
                var r_model = user.R_UserInfo_SMSMission.Where(r => r.SMID == item && r.UID == user.ID).FirstOrDefault();
                if(r_model!=null&&r_model.isPass==true)
                {
                    //删除曾经拥有但现在不再拥有的任务
                    if (!list_missionIDs.Contains(r_model.SMID))
                    {
                        this.CurrentDBSession.R_UserInfo_SMSMissionDAL.Del(r_model);
                    }
                }
                //添加新的关系
                else if(r_model==null)
                {
                    var mission = this.CurrentDBSession.S_SMSMissionDAL.GetListBy(m => m.SMID == item).FirstOrDefault();
                    r_model = new R_UserInfo_SMSMission();
                    r_model.SMID = item;
                    r_model.isPass = true;
                    r_model.UID = user.ID;
                    this.CurrentDBSession.R_UserInfo_SMSMissionDAL.Create(r_model);
                    //user.R_UserInfo_SMSMission.Add(r_model);
                }
                

            }

            //统一保存
            return this.CurrentDBSession.SaveChanges();

        }

        /// <summary>
        /// 为指定User重新赋予新的群组——指定用户的常用群组（删除不在此任务id集合中的现有群组关系）
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="list_groupIDs">现拥有的群组id集合</param>
        /// <returns></returns>
        public bool SetUser4Group(int userID, List<int> list_groupIDs)
        {
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == userID).FirstOrDefault();
            //user.R_UserInfo_SMSMission.Clear();

            //获取当前用户现在所拥有的群组
            //使用Clear这种方式会报错
            //user.R_UserInfo_Group.Clear();
            var gids_now= user.R_UserInfo_Group.Select(r=>r.GID).ToList();
            foreach (var item in gids_now)
            {
                var g_model = user.R_UserInfo_Group.Where(r => r.GID == item && r.UID == user.ID).FirstOrDefault();
                this.CurrentDBSession.R_UserInfo_GroupDAL.Del(g_model);
            }

            //this.CurrentDBSession.SaveChanges();
            //添加用户新拥有的常用任务
            foreach (var item in list_groupIDs)
            {
                var g_model = user.R_UserInfo_Group.Where(r => r.GID == item && r.UID == user.ID).FirstOrDefault();
                //此处有bug
                if (g_model != null && g_model.isPass == true)
                {
                    //删除曾经拥有但现在不再拥有的任务
                    if (!gids_now.Contains(g_model.GID))
                    {
                        this.CurrentDBSession.R_UserInfo_GroupDAL.Del(g_model);
                    }
                }
                //添加新的关系
                else if (g_model == null)
                {
                    //var mission = this.CurrentDBSession.P_GroupDAL.GetListBy(m => m.GID == item).FirstOrDefault();
                    //g_model = new R_UserInfo_Group();
                    R_UserInfo_Group g_temp = new R_UserInfo_Group();
                    //g_model = new R_UserInfo_Group();
                    g_temp.GID = item;
                    g_temp.isPass = true;
                    g_temp.UID = user.ID;
                    
                    this.CurrentDBSession.R_UserInfo_GroupDAL.Create(g_temp);
                    //注意不能用以下此种方式添加关系
                    //user.R_UserInfo_Group.Add(g_temp);
                }


            }

            //统一保存
            return this.CurrentDBSession.SaveChanges();

        }

        /// <summary>
        /// 为用户分配权限
        /// </summary>
        /// <returns></returns>
        public bool SetUser4Action(int userID, List<int> list_actionIDs)
        {
            // 1 修改User与Role的关系
            //1.1 根据UserID找到对应的UserInfo
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(r => r.ID == userID).FirstOrDefault();
            //1.2 清空原来的关系
            //R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
            //r_UserInfo_ActionInfo.
            //2 根据ActionIDs查询对应的RoleInfo

            List<R_UserInfo_ActionInfo> list = new List<R_UserInfo_ActionInfo>();
            foreach (var aid in list_actionIDs)
            {
                var r_user_action = this.CurrentDBSession.R_UserInfo_ActionInfoDAL.GetListBy(r => r.UserInfoID == userID && r.ActionInfoID == aid).FirstOrDefault();
                //根据ActionID与UserID从R表中找到唯一的记录
                if(r_user_action != null&&r_user_action.isPass==true)
                {
                    
                }
                else if(r_user_action==null)
                {
                    R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
                    //r_UserInfo_ActionInfo.UserInfo = user;
                    r_UserInfo_ActionInfo.UserInfoID = userID;
                    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                    r_UserInfo_ActionInfo.isPass = true;
                    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
                    r_UserInfo_ActionInfo.ActionInfoID = aid;
                    this.CurrentDBSession.R_UserInfo_ActionInfoDAL.Create(r_UserInfo_ActionInfo);
                }
               
            }
            var list_del = this.CurrentDBSession.R_UserInfo_ActionInfoDAL.GetListBy(r => r.UserInfoID == userID &&!list_actionIDs.Contains(r.ActionInfoID));
            foreach (var item in list_del)
            {
                this.CurrentDBSession.R_UserInfo_ActionInfoDAL.Del(item);
            }

            return this.CurrentDBSession.SaveChanges();
        }


    }
}
