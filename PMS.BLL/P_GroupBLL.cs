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
   public partial class P_GroupBLL : IBaseDelBLL
    {
        /// <summary>
        /// 查询指定联系人id的所属群组集合
        /// </summary>
        /// <param name="pid">联系人id</param>
        /// <returns></returns>
        public List<P_Group> GetListByPerson(int pid)
        {
            //1 根据pid查询人员对象
            var person= this.CurrentDBSession.P_PersonInfoDAL.GetListBy(p => p.PID==pid).FirstOrDefault();

           return person.P_Group.ToList();
        }
       
        /// <summary>
        /// 剔除传入的群组id中的群组，返回剩余群组集合
        /// </summary>
        /// <param name="list_ids_group">需要剔除群组的id集合</param>
        /// <param name="isMiddle">是否需要转成中间变量</param>
        /// <returns></returns>
        public List<P_Group> GetRestGroupListByIds(List<int> list_ids_group,bool isMiddle)
        {
            //1 找到全部的群组
            var list_group = GetListBy(g => g.isDel == false);

            //2 剔除传入的id的群组
            var list_group_rest = list_group.Where(g => !list_ids_group.Contains(g.GID)).ToList();
            if(isMiddle)
            {
               return list_group_rest.Select(g => g.ToMiddleModel()).ToList();
            }
            else
            {
                return list_group_rest.ToList();
            }
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
        public bool PhysicsDel(List<int> list_ids)
        {
            //1. 得到所有要删除的实体集合
            var list_model = this.GetListByIds(list_ids);
            if(list_model == null) { return false; }
            foreach (var item in list_model)
            {
                //2. 得到群组和联系人的关联表数据并删除
                item.P_PersonInfo.Clear();
                //2. 得到群组和任务的关联表数据并删除
                item.R_Group_Mission.Clear();
                //2. 得到群组和用户的关联表数据并删除
                item.R_UserInfo_Group.Clear();
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

        /// <summary>
        /// 从数据库中根据id集合查询返回指定的GroupInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<P_Group> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.GID)).ToList();

        }

        /// <summary>
        /// 根据群组GID删除指定PID的联系人
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public bool DelPersonInfoByGID(int gid,int pid)
        {
            //2 根据gid找到对应的群组对象
            var group = this.CurrentDBSession.P_GroupDAL.GetListBy(g => g.GID == gid).FirstOrDefault();
            //2.2将该群组对象中的指定联系人删除

            var person_bygroup = group.P_PersonInfo.Where(p => p.PID == pid).FirstOrDefault();
            bool state = group.P_PersonInfo.Remove(person_bygroup);
           return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 修改指定的GroupId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftRoleInfos(List<int> list_ids)
        {
            List<P_Group> list = new List<P_Group>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //清空与该群组有关联的人员外键
                item.P_PersonInfo.Clear();
                ///修改其中的删除标记
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
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => r.isDel == false).ToList();
            return list_model.Exists(r => r.GroupName.Equals(name));
        }
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.GID != id && r.isDel == false).ToList();
            return list_model.Exists(r => r.GroupName.Equals(name));

            
        }
    }
}
