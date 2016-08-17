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
    public partial class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL, IBaseDelBLL
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
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            var list_model = this.GetListByIds(list_id);
            list_model.ForEach(p => p.DelFlag = false);
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
        public bool PhysicsDel(List<int> list_ids)
        {
            //1. 得到所有要删除的实体集合
            var list_model = this.GetListByIds(list_ids);
            if (list_model == null) { return false; }
            foreach (var item in list_model)
            {
                //2.清除关系表中的数据
                item.R_UserInfo_ActionInfo.Clear();
                item.RoleInfo.Clear();
                item.R_UserInfo_Group.Clear();
                item.R_UserInfo_SMSMission.Clear();
                item.S_SMSContent.Clear();
                item.R_UserInfo_DepartmentInfo.Clear();
                item.R_UserInfo_PersonInfo.Clear();
                item.S_SMSMsgContent.Clear();
                item.R_UserInfo_News.Clear();
                item.N_News.Clear();
            }
            try
            {
                //3. 从数据库中删除这些实体对象
                this.CurrentDAL.UpdateByList(list_model);
                this.CurrentDAL.DelByList(list_model);
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
        /// 7月17日 
        /// 封装成此方法
        /// 根据用户id 查询该用户所拥有的全部权限（去掉禁用的权限）
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<ActionInfo> GetActionListByUID(int uid,bool AllowNotShow,bool isMiddle)
        {
            //1 从数据库中读取指定的用户对象
            var userInfo = this.GetListBy(u => u.ID == uid).FirstOrDefault();
            if (userInfo != null)
            {
                //2 通过路线二查询 UserInfo所对应的角色，并查询该角色中包含的Action
                var list_action = (
                    from r in userInfo.RoleInfo //linq
                    from a in r.ActionInfo
                    select a).ToList();

                //from r in userInfo.RoleInfo
                //select r.ActionInfo

                //3 获取该用户对象对应的R_UserInfo_ActionInfo导航属性集合
                //list_R_User_Action存储的是userInfoId为1的R_User_Action对象的集合
                var list_R_User_Action = userInfo.R_UserInfo_ActionInfo;
                //4 取出userInfo id为2的用户所对应的Action集合（路线一的方式）
                //var temp = (
                //    from r in list_R_User_Action
                //    select r.ActionInfo
                //    ).ToList();
                //4.1 取出isPass为true的所有集合
                var list_action_isPass = (
                   from r in list_R_User_Action
                   where r.isPass == true
                   select r.ActionInfo
                    ).ToList();

                //4.2 将路线一与路线二取出的ActionInfo集合合并
                list_action.AddRange(list_action_isPass);
                //4.3 此时的集合中可能存在重复，去重
                list_action = list_action.Distinct(new PMS.Model.EqualCompare.ActionEqualCompare()).ToList();
                // IEqualityComparer<ActionInfo>
                //list_action.Distinct()

                //4.4 取出isPass为false的集合
                var list_action_isNotPass = (
                  from r in list_R_User_Action
                  where r.isPass == false
                  select r.ActionInfo
                   ).ToList();

                //4.5 将现有集合中去掉isPass为false的ActionInfo
                if(AllowNotShow)
                {
                    list_action = (from a in list_action
                                   where !list_action_isNotPass.Contains(a)
                                   
                                   select a).ToList();
                }
                else
                {
                    list_action = (from a in list_action
                                   where !list_action_isNotPass.Contains(a)
                                   where a.isShow == true
                                   select a).ToList();
                }

                //list_action = list_action.Where(a => !list_action_isNotPass.Contains(a)).ToList();
                if (isMiddle)
                {
                    return list_action.Select(a=>a.ToMiddleModel()).ToList();
                }
                else
                {
                    return list_action;
                }
            }
            return null;
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

        /// <summary>
        /// 对发送短信内容进行高级搜索，并分页（不查询姓名及电话号码）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="model">高级搜索的查询对象</param>
        /// <param name="uid"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<S_SMSContent> GetSMSContentListByQuery_ExpNamePhone(int pageIndex, int pageSize, ref int rowCount,PMS.Model.ViewModel.ViewModel_QueryInfo model, int uid, bool isAsc, bool isMiddle)
        {
            //1 找到对应用户
            var userModel = GetListBy(u => u.ID == uid).FirstOrDefault();
            //2 查询当前用户所拥有的全部短信
            //rowCount = userModel.S_SMSContent.Count;
            var query = userModel.S_SMSContent.ToList();
            rowCount = query.Count();
            //不根据联系人名称以及联系人电话查询
            //根据任务匹配
            if (model.Mission_id!=-1)
            {
                query= query.Where(u => u.SMID == model.Mission_id).ToList();
                
            }

            //3 根据时间的三个参数获取指定时间范围
            //3.1 只查询某日的 
            if (model.Dt_finish == "999" && model.Dt_start == "999"&&model.Dt_target!="999")
            {
                DateTime dt = new DateTime();
                DateTime.TryParse(model.Dt_target,out dt);
                query = query.Where(u => u.SendDateTime.Date == dt.Date).ToList();
            }
            //3.2 查询一个时间范围
            else if(model.Dt_target=="999"&&model.Dt_finish!="999"&&model.Dt_start!="999")
            {
                DateTime dt_start=new DateTime();
                DateTime dt_finish=new DateTime();
                if(model.Dt_start=="998")
                {
                    dt_start = new DateTime(2000, 1, 1);
                }
                if(model.Dt_finish=="998")
                {
                    dt_finish = DateTime.Now;
                }
                
                    if(model.Dt_finish!="998"&&model.Dt_start!="998")
                    {
                        DateTime.TryParse(model.Dt_start, out dt_start);
                        DateTime.TryParse(model.Dt_finish, out dt_finish);
                    }
                    else if(model.Dt_finish!="998"&&model.Dt_start=="998")
                    {
                        DateTime.TryParse(model.Dt_finish, out dt_finish);
                    }
                    else if (model.Dt_finish == "998" && model.Dt_start != "998")
                    {
                        DateTime.TryParse(model.Dt_start, out dt_start);
                    }
                

                if(dt_start!=null&&dt_finish!=null)
                {
                    query = query.Where(u => u.SendDateTime.Date <= dt_finish.Date && u.SendDateTime.Date >= dt_start.Date).ToList();
                }
            }
            //获取目标日期
            //if(model.dt)
            //query = query.Where(u => u.SendDateTime.Year == model.Dt_target.Year && u.SendDateTime.Month == model.Dt_target.Month && u.SendDateTime.Year == model.Dt_target.Day).ToList();
            //4 降序排列
            //query = query.OrderBy(s => s.SendDateTime).ToList();
            //5 进行分页查询
            return ToListByPage(query, pageIndex, pageSize, ref rowCount, isAsc, isMiddle);
           
        }

        /// <summary>
        /// 对传入的S_SMSContent集合进行分页查询（并排序以及转为中间变量）
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        private List<S_SMSContent> ToListByPage(List<S_SMSContent> query,int pageIndex,int pageSize,ref int rowCount,bool isAsc,bool isMiddle)
        {
            if (isAsc)
            {
                query = query.OrderBy(c => c.SendDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                query = query.OrderByDescending(c => c.SendDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }

            //3
            if (isMiddle)
            {
                return query.Select(s => s.ToMiddleModel()).ToList();
            }
            else
            {
                return query;
            }
        }

            /// <summary>
            /// 根据传入的用户id查询该用户所发送的短信
            /// </summary>
            /// <param name="pageIndex"></param>
            /// <param name="pageSize"></param>
            /// <param name="rowCount"></param>
            /// <param name="uid"></param>
            /// <param name="isAsc"></param>
            /// <param name="isMiddle"></param>
            /// <returns></returns>
        public List<S_SMSContent> GetSMSContentListByUID(int pageIndex,int pageSize,ref int rowCount, int uid,bool isAsc,bool isMiddle)
        {
            //1 找到对应用户
            var userModel = GetListBy(u => u.ID == uid).FirstOrDefault();
            //1.2 为当前用户发送的短信总数赋值
            rowCount = userModel.S_SMSContent.Count;
            var query = userModel.S_SMSContent.ToList();
            //2 找到该用户所发送的短信
            #region 封装至 ToListByPage 方法中
            //   if (isAsc)
            //   {
            //      query= query.OrderBy(c => c.SendDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //   }
            //else
            //   {
            //       query = query.OrderByDescending(c => c.SendDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //   }

            //   //3
            //   if(isMiddle)
            //   {
            //       return query.Select(s => s.ToMiddleModel()).ToList();
            //   }
            //   else
            //   {
            //       return query;
            //   }
            #endregion
           return ToListByPage(query, pageIndex, pageSize,ref rowCount, isAsc, isMiddle);
        }

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
        public bool SetUser4Action(int userID, List<int> list_actionIDs, List<string> list_actionIsPass)
        {


            List<bool> list_isPass = new List<bool>();
            if (list_actionIDs != null)
            {
                foreach (var item in list_actionIsPass)
                {
                    if (item.Equals("启用"))
                    {
                        list_isPass.Add(true);
                    }
                    else if (item.Equals("禁用"))
                    {
                        list_isPass.Add(false);
                    }
                }
            }
            // 1 修改User与Role的关系
            //1.1 根据UserID找到对应的UserInfo
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(r => r.ID == userID).FirstOrDefault();
            //1.2 清空原来的关系
            //R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
            //r_UserInfo_ActionInfo.
            //2 根据ActionIDs查询对应的ActionInfo

            List<R_UserInfo_ActionInfo> list = new List<R_UserInfo_ActionInfo>();
            int times = 0;
            foreach (var aid in list_actionIDs)
            {
                //如果
              
                var r_user_action = this.CurrentDBSession.R_UserInfo_ActionInfoDAL.GetListBy(r => r.UserInfoID == userID && r.ActionInfoID == aid).FirstOrDefault();
                //根据ActionID与UserID从R表中找到唯一的记录
                if(r_user_action != null)
                {
                    r_user_action.isPass = list_isPass[times];
                }
                else if(r_user_action==null)
                {
                    R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
                    //r_UserInfo_ActionInfo.UserInfo = user;
                    r_UserInfo_ActionInfo.UserInfoID = userID;
                    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                    r_UserInfo_ActionInfo.isPass = list_isPass[times];
                    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
                    r_UserInfo_ActionInfo.ActionInfoID = aid;
                    this.CurrentDBSession.R_UserInfo_ActionInfoDAL.Create(r_UserInfo_ActionInfo);
                }
                times++;
            }

            var list_del_User_action = this.CurrentDBSession.R_UserInfo_ActionInfoDAL.GetListBy(r => r.UserInfoID == userID &&!list_actionIDs.Contains(r.ActionInfoID));
            
            foreach (var item in list_del_User_action)
            {
                this.CurrentDBSession.R_UserInfo_ActionInfoDAL.Del(item);
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
        //数据验证
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => r.DelFlag == false).ToList();
            return list_model.Exists(r => r.UName.Equals(name));
        }

        //数据验证
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.ID != id && r.DelFlag == false).ToList();
            return list_model.Exists(r => r.UName.Equals(name));
        }
    }
}
