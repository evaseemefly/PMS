using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using System.Linq.Expressions;

namespace PMS.BLL
{
    public partial class P_PersonInfoBLL : BaseBLL<P_PersonInfo>, IP_PersonInfoBLL
    {
        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteLogicPersonInfos(List<int> list)
        {
            var PersonInfoList = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(u => list.Contains(u.PID));
            if(PersonInfoList != null)
            {
                foreach(var person in PersonInfoList)
                {
                    this.CurrentDBSession.P_PersonInfoDAL.Del(person);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftPersonInfos(List<int> list)
        {

                List<P_PersonInfo> list_person = new List<P_PersonInfo>();
                foreach (var person in this.GetListByIds(list))
                {
                    person.isDel = true;
                    list_person.Add(person);
                }
            try
            {
                this.UpdateByList(list_person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的PersonInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<P_PersonInfo> GetListByIds(List<int> list_ids)
        {
            return GetListBy(p => list_ids.Contains(p.PID)).ToList();

        }

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        public bool SetPerson4Department(int personId,List<int> list_departmentIds)
        {
            //1 根据联系人id查询联系人
            var person =this.CurrentDBSession.P_PersonInfoDAL.GetListBy(p => p.PID == personId).FirstOrDefault();
            //2 清除该联系人所属的部门
            person.P_DepartmentInfo.Clear();
            //3 根据群组id为该联系人赋予对应的部门权限
            foreach (var item in list_departmentIds)
            {
                var departmentInfo = this.CurrentDBSession.P_DepartmentInfoDAL.GetListBy(d => d.DID == item).FirstOrDefault();
                person.P_DepartmentInfo.Add(departmentInfo);
            }

            try
            {
                return this.CurrentDBSession.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        public bool SetPerson4Group(int personId, List<int> list_groupIds)
        {
            //1 根据联系人id查询联系人
            var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(p => p.PID == personId).FirstOrDefault();

            //2 清除该联系人所属的群组
            person.P_Group.Clear();

            //3 根据群组id为该联系人赋予对应的群组权限
            foreach (var item in list_groupIds)
            {
                var groupInfo = this.CurrentDBSession.P_GroupDAL.GetListBy(g =>g.GID == item).FirstOrDefault();
                person.P_Group.Add(groupInfo);
            }

            try
            {
                return (this.CurrentDBSession.SaveChanges());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
