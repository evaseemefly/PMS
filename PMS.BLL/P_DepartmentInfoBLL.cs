using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;

namespace PMS.BLL
{
   public partial class P_DepartmentInfoBLL : IBaseDelBLL
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

        public bool PhysicsDel(List<int> list_ids)
        {
            return true;
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
                item.P_PersonInfo.Clear();
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
    }
}
