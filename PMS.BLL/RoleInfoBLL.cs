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
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            var query = base.GetPageList<DateTime>(pageIndex, pageSize, a => a.DelFlag == true, a => a.ModifiedOnTime, true);
            rowCount = query.Count();
            if (rowCount != 0)
            {
                return query.ToList().Select(a => a.ToRecycleModel()).ToList();
            }
            else
            {
                return new List<ViewModel_Recycle_Common>();
            }
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
                var actionInfo = this.CurrentDBSession.ActionInfoDAL.GetListBy(a => a.ID == item && a.DelFlag == false).FirstOrDefault();
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
        /// <summary>
        ///  根据条件查询：角色名，备注
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="model"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<RoleInfo> GetRoleRecordListByQuery(int pageIndex, int pageSize, ref int rowCount, PMS.Model.ViewModel.ViewModel_RoleInfo_QueryInfo model, bool isAsc, bool isMiddle)
        {
            //1. 找到所有未被删除的用户对象列表，并转为中间件
            var query = GetListBy(a => a.DelFlag == false).ToList().Select(u => u.ToMiddleModel()).ToList();
            //2. 根据用户名查询
            if (model.RoleName != null)
            {
                query = query.Where(c =>c.RoleName.Contains(model.RoleName)).ToList();
            }
            //3. 根据备注查询

            if (model.Remark != null)
            {
                query = query.Where(c => c.Remark != null && c.Remark.Contains(model.Remark)).ToList();
            }

            //4. 获取查询结果条数
            rowCount = query.Count();
            return ToListByPage(query, pageIndex, pageSize, ref rowCount, isAsc, false);


        }
        /// <summary>
        /// 对传入的RoleInfo集合进行分页查询（并排序以及转为中间变量）
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        private List<RoleInfo> ToListByPage(List<RoleInfo> query, int pageIndex, int pageSize, ref int rowCount, bool isAsc, bool isMiddle)
        {
            if (isAsc)
            {
                query = query.OrderBy(c => c.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                query = query.OrderByDescending(c => c.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            if (isMiddle)
            {
                return query.Select(s => s.ToMiddleModel()).ToList();
            }
            else
            {
                return query;
            }

        }
    }
}
