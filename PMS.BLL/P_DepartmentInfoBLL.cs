﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
   public partial class P_DepartmentInfoBLL : IBaseDelBLL,ICanBeDel
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的DepartmentInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<P_DepartmentInfo> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.DID)).ToList();

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
            var query = base.GetPageList<int>(pageIndex, pageSize, a => a.isDel == true, a => a.DID, true);
            rowCount = query.Count();
            return query.ToList().Select(a => a.ToRecycleModel()).ToList();
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            //1. 得到所有要删除的实体集合
            var list_model = this.GetListByIds(list_ids);
            if (list_model == null) { return false; }
            var department_Not_assigned = this.GetListBy(p => p.DepartmentName.Equals("无归属部门")).FirstOrDefault();
            if (CanBeDel(list_ids) || !isCheckCanBeDel)
            {
                foreach (var item in list_model)
                {
                    //2. 得到群组和联系人的关联表数据并删除
                    var list_person = item.P_PersonInfo.ToList();
                    //添加到无归属部门
                    list_person.ForEach(p => department_Not_assigned.P_PersonInfo.Add(p));
                    item.P_PersonInfo.Clear();
                    this.CurrentDAL.SaveChange();
                    var list_r_Department_Mission = item.R_Department_Mission.Select(r => r).ToList();
                    R_Department_MissionBLL rdmBLL = new R_Department_MissionBLL();
                    rdmBLL.DelByList(list_r_Department_Mission);
                    var list_r_UserInfo_DepartmentInfo = item.R_UserInfo_DepartmentInfo.Select(r => r).ToList();
                    R_UserInfo_DepartmentInfoBLL rudBLL = new R_UserInfo_DepartmentInfoBLL();
                    rudBLL.DelByList(list_r_UserInfo_DepartmentInfo);
                    ////2. 得到群组和任务的关联表数据并删除
                    //item.R_Department_Mission.Clear();
                    ////2. 得到群组和用户的关联表数据并删除
                    //item.R_UserInfo_DepartmentInfo.Clear();
                    //item.P_PersonInfo.Clear();
                }

                try
                {
                    //3. 从数据库中删除这些实体对象
                    this.CurrentDAL.Update(department_Not_assigned);
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
        /// 根据部门DID删除指定PID的联系人
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public bool DelPersonInfoByDID(int did, int pid)
        {
            //2 根据gid找到对应的群组对象
            var department = this.CurrentDBSession.P_DepartmentInfoDAL.GetListBy(d => d.DID == did).FirstOrDefault();
            //2.2将该群组对象中的指定联系人删除

            var person_bydepartment = department.P_PersonInfo.Where(p => p.PID == pid).FirstOrDefault();
            bool state = department.P_PersonInfo.Remove(person_bydepartment);
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 修改指定的DepartmentId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftRoleInfos(List<int> list_ids)
        {
            List<P_DepartmentInfo> list = new List<P_DepartmentInfo>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //改为不清空关系表
                //item.P_PersonInfo.Clear();
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
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => true,true).ToList();
            return list_model.Exists(r => r.DepartmentName.Equals(name));
        }
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.DID != id,true).ToList();
            return list_model.Exists(r => r.DepartmentName.Equals(name));


        }

        public bool CanBeDel(List<int> list_ids)
        {
            var query = base.GetListBy(a => list_ids.Contains(a.DID));
            foreach (var item in query)
            {
                if (item.P_PersonInfo.Count() > 0)
                {
                    return false;
                }
                if (item.R_Department_Mission.Count() > 0)
                {
                    return false;
                }
                if (item.R_UserInfo_DepartmentInfo.Count() > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
