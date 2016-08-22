using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class RoleInfoBLL : IBaseDelBLL
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

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            var array = this.GetListBy(a => a.DelFlag == true).ToList();
            return array.Select(a => a.ToRecycleModel()).ToList();
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
                item.ActionInfo.Clear();
                item.UserInfo.Clear();
            }
            try
            {
                //3. 从数据库中删除这些实体对象
                 this.CurrentDAL.UpdateByList(list_model);
                this.CurrentDAL.DelByList(list_model);
                this.CurrentDAL.SaveChange();
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
            //this.Update(role);
            return this.CurrentDBSession.SaveChanges();
            //var list_action = 
            //(3)向查找到的RoleInfo对象写入指定的ActionInfo

        }
        //数据验证
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => r.DelFlag == false).ToList();
            return list_model.Exists(r => r.RoleName.Equals(name));
        }
        //数据验证
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.ID != id && r.DelFlag == false).ToList();
            return list_model.Exists(r => r.RoleName.Equals(name));
        }
    }
}
