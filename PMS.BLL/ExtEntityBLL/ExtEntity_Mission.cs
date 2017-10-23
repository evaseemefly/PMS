using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.EqualCompare;

namespace PMS.BLL.ExtEntityBLL
{
    /// <summary>
    /// 拓展任务实体类
    /// </summary>
    public class ExtEntity_Mission
    {
        private S_SMSMission _smsMission;

        public S_SMSMission S_SMSMission { get { return _smsMission; } }

        public ExtEntity_Mission(S_SMSMission smsMission)
        {
            this._smsMission = smsMission;
        }


        private IEnumerable<P_Group> GetGroupByisPass(PMS.Model.Enum.MMS_Enum isMms ,bool isPass=true)
        {
            var groups = from r in _smsMission.R_Group_Mission
                               where r.isPass == isPass && r.P_Group.isDel == false && r.isMMS == (int)isMms
                               select r.P_Group;
            return groups;
        }

        private IEnumerable<P_DepartmentInfo> GetDepartmentByisPass(PMS.Model.Enum.MMS_Enum isMms, bool isPass = true)
        {
            var departments = from r in _smsMission.R_Department_Mission
                                    where r.isPass == isPass && r.P_DepartmentInfo.isDel == false && r.isMMS == (int)isMms
                                    select r.P_DepartmentInfo;
            return departments;
        }

        /// <summary>
        /// 根据任务及短/彩信获取对应的联系人集合
        /// </summary>
        /// <param name="smid">短信任务</param>
        /// <param name="isMms">短/彩信</param>
        /// <param name="isMiddle">是否需要转成中间变量</param>
        /// <returns></returns>
        public List<P_PersonInfo> GetPersonAllowByMission(int smid, PMS.Model.Enum.MMS_Enum isMms, bool isMiddle)
        {
            
            //启用的联系人
            List<P_PersonInfo> list_person_allow = new List<P_PersonInfo>();
            //禁用的联系人
            List<P_PersonInfo> list_person_forbid = new List<P_PersonInfo>();

            //2 根据任务查找对应的群组
            //2.1 启用的群组
            var groups_allow=GetGroupByisPass(isMms);
            //2.2 禁用的群组
            var groups_forbid = GetGroupByisPass(isMms, false);            
            //2.3 根据群组对象集合获取该群组集合中所共有的联系人
            groups_allow.ToList().ForEach(g => list_person_allow.AddRange(g.P_PersonInfo));
            groups_forbid.ToList().ForEach(g => list_person_forbid.AddRange(g.P_PersonInfo));

            //3 根据短信任务查找对应的部门
            //3.1 启用部门
            var departments_allow = GetDepartmentByisPass(isMms);
            //3.2 禁用部门
            var departments_forbid = GetDepartmentByisPass(isMms, false);            
            //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            departments_allow.ToList().ForEach(d => list_person_allow.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));
            departments_forbid.ToList().ForEach(d => list_person_forbid.AddRange(d.P_PersonInfo.Where(p => p.isDel == false)));
            
            // 获取禁用联系人id
            var list_person_forbid_ids = from p in list_person_forbid
                                         select p.PID;
            //4 将联系人集合去重
            list_person_allow = list_person_allow.Distinct(new P_PersonEqualCompare()).ToList().Select(p => p.ToMiddleModel()).Select(p => p.ToMiddleModel()).ToList();
            //去除禁用的联系人
            if (isMiddle)
            {

                list_person_allow = (from p in list_person_allow
                                     where !list_person_forbid_ids.Contains(p.PID)
                                     select p.ToMiddleModel()).ToList();
            }

            else
            {
                list_person_allow = (from p in list_person_allow
                                     where !list_person_forbid_ids.Contains(p.PID)
                                     select p).ToList();
            }
            return list_person_allow;
        }
    }
}
