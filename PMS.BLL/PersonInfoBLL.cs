using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using System.Linq.Expressions;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class P_PersonInfoBLL : BaseBLL<P_PersonInfo>, IP_PersonInfoBLL, IBaseDelBLL
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
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            return true;
        }

        /// <summary>
        /// 根据传入的id集合执行物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            return true;
        }

        /// <summary>
        /// 6月15日新添加
        /// 根据传入的Person ID集合软删除删除该ID集合内的Person对象
        /// 且清除这些Person对象与部门及群组的外键关系
        /// </summary>
        /// <param name="list">Person ID 集合</param>
        /// <returns></returns>
        public bool DelSoftPersonAndOtherRelation(List<int> list) 
        {
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            foreach (var person in this.GetListByIds(list))
            {
                person.isDel = true;
                person.P_DepartmentInfo.Clear();
                person.P_Group.Clear();
                
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
        /// 6月15日发现的添加联系人的bug做如下修改
        /// 执行新建联系人的操作
        /// </summary>
        /// <param name="PName"></param>
        /// <param name="PhoneNum"></param>
        /// <param name="list_group_ids"></param>
        /// <param name="id_department"></param>
        /// <returns></returns>
        public bool DoAddPerson(string PName,string PhoneNum,List<int> list_group_ids,int id_department)
        {
            PMS.Model.P_PersonInfo person_model = new P_PersonInfo();
            person_model.PName = PName;
            person_model.PhoneNum = PhoneNum;

            var department_temp = this.CurrentDBSession.P_DepartmentInfoDAL.GetListBy(d => d.DID == id_department).FirstOrDefault();
           // person_model.P_DepartmentInfo = department_temp;

            List<P_Group> list_group=new List<P_Group>();
            //遍历添加group ids集合中的群组对象
            foreach (var item in list_group_ids)
            {
                var group_temp = this.CurrentDBSession.P_GroupDAL.GetListBy(g => g.GID == item).FirstOrDefault();
                //list_group.Add(group_temp);
                person_model.P_Group.Add(group_temp);
            }

            // person_model.P_Group = list_group;

            person_model.P_DepartmentInfo.Add(department_temp);

           return Create(person_model);
            //try
            //{
            //    return (this.CurrentDBSession.SaveChanges());
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 对指定联系人执行修改操作
        /// </summary>
        /// <param name="pid">联系人ID</param>
        /// <param name="PName">姓名</param>
        /// <param name="PhoneNum">电话号码</param>
        /// <param name="Remark">备注</param>
        /// <param name="isVip"></param>
        /// <param name="isDel"></param>
        /// <param name="list_group_ids">该联系人所拥有的群组id集合</param>
        /// <param name="id_department">该联系人所拥有的部门id</param>
        /// <returns></returns>
        public bool DoEditPerson(int pid,string PName, string PhoneNum,string Remark,bool isVip,bool isDel, List<int> list_group_ids, int id_department)
        {
           var person_model= this.CurrentDBSession.P_PersonInfoDAL.GetListBy(p =>p.PID  == pid).FirstOrDefault();
           
            person_model.PName = PName;
            person_model.PhoneNum = PhoneNum;
            person_model.isVIP = isVip;
            person_model.isDel = isDel;
            person_model.Remark = Remark;
            var department_temp = this.CurrentDBSession.P_DepartmentInfoDAL.GetListBy(d => d.DID == id_department).FirstOrDefault();
            // person_model.P_DepartmentInfo = department_temp;

            List<P_Group> list_group = new List<P_Group>();
            person_model.P_Group.Clear();
            //遍历添加group ids集合中的群组对象
            foreach (var item in list_group_ids)
            {
                var group_temp = this.CurrentDBSession.P_GroupDAL.GetListBy(g => g.GID == item).FirstOrDefault();
                //list_group.Add(group_temp);
                person_model.P_Group.Add(group_temp);
            }

            // person_model.P_Group = list_group;
            person_model.P_DepartmentInfo.Clear();
            person_model.P_DepartmentInfo.Add(department_temp);

            return Update(person_model);
            //try
            //{
            //    return (this.CurrentDBSession.SaveChanges());
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

       /// <summary>
       /// 更新联系人：为导入的联系人建立与群组和部门的关联
       /// </summary>
       /// <param name="pid"></param>
       /// <param name="id_group"></param>
       /// <param name="id_department"></param>
       /// <returns></returns>
        public bool UpdatePerson(string phone, int[] id_group, int[] id_department)
        {
            var person_model = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(p => p.PhoneNum == phone).FirstOrDefault();
            
            var departments_temp = this.CurrentDBSession.P_DepartmentInfoDAL.GetListBy(d =>id_department.Contains(d.DID)).ToList();           
            var groups_temp = this.CurrentDBSession.P_GroupDAL.GetListBy(g =>id_group.Contains(g.GID )).ToList();
            var group_exists = person_model.P_Group.Select(g => g.GID).ToArray();
            //为联系人分配群组
            foreach (var item_group in groups_temp)
            {
                if (group_exists.Contains(item_group.GID))
                {
                    continue;
                }
                else
                {
                    person_model.P_Group.Add(item_group);
                }
                
            }
            
            //为联系人分配部门
            person_model.P_DepartmentInfo.Clear();
            foreach (var item_department in departments_temp)
            {
                person_model.P_DepartmentInfo.Add(item_department);
            }
           

            return Update(person_model);

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

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool AddValidation(String phoneNum)
        {
            var list_model = this.GetListBy(r => r.isDel == false).ToList();
            return list_model.Exists(r => r.PhoneNum.Equals(phoneNum));
        }
        //数据验证
        public bool EditValidation(int id, String phoneNum)
        {
            var list_model = this.GetListBy(r => r.PID != id && r.isDel == false).ToList();
            return list_model.Exists(r => r.PhoneNum.Equals(phoneNum));
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            return null;
        }
    }
}
