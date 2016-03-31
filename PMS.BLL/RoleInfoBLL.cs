using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.BLL
{
    public partial class RoleInfoBLL
    {
        /// <summary>
        /// 根据id集合批量删除RoleInfo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteLogicRoleInfos(List<int> list)
        {
            var roleInfoList = this.CurrentDBSession.RoleInfoDAL.GetListBy(u => list.Contains(u.ID));
            if (roleInfoList != null)
            {
                foreach (var role in roleInfoList)
                {
                    this.CurrentDBSession.RoleInfoDAL.Del(role);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 从数据库中根据id集合查询返回指定的RoleInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<RoleInfo> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.ID)).ToList();

        }


        /// <summary>
        /// 修改指定的RoleId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftRoleInfos(List<int> list_ids)
        {
            List<RoleInfo> list = new List<RoleInfo>();
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



        public bool SetRole4Action(int roleId, List<int> list_actionIds)
        {
            //2.2 修改Role与Action的关系
            //(1)根据RId找到对应的RoleInfo
            var role = this.CurrentDBSession.RoleInfoDAL.GetListBy(r => r.ID == roleId).FirstOrDefault();

            role.ActionInfo.Clear();

            //(2)根据AId查询对应的ActionInfo
            foreach (var item in list_actionIds)
            {
                var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item).FirstOrDefault();
                role.ActionInfo.Add(actionInfo);
            }
            this.Update(role);
            //return this.CurrentDBSession.SaveChanges();
            //var list_action = 
            //(3)向查找到的RoleInfo对象写入指定的ActionInfo

        }

    }
}
