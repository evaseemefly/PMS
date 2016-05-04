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
            //foreach (var item in list_actionIDs)
            //{
            //    R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
            //    //r_UserInfo_ActionInfo.UserInfo = user;
            //    r_UserInfo_ActionInfo.UserInfoID = userID;
            //    //var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
            //    r_UserInfo_ActionInfo.isPass = true;
            //    //r_UserInfo_ActionInfo.ActionInfo = actionInfo;
            //    r_UserInfo_ActionInfo.ActionInfoID = item;
            //    list.Add(r_UserInfo_ActionInfo)
            //    //this.CurrentDBSession.R_UserInfo_ActionInfoDAL.UpdateByList
            //    //user.R_UserInfo_ActionInfo.Add(r_UserInfo_ActionInfo);
            //}
            return this.CurrentDBSession.SaveChanges();
        }


    }
}
