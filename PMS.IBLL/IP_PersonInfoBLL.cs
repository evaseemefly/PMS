using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IP_PersonInfoBLL
    {
        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteLogicPersonInfos(List<int> list);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftPersonInfos(List<int> list_ids);

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        bool SetPerson4Department(int personId, List<int> list_departmentIds);

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        bool SetPerson4Group(int personId, List<int> list_groupIds);
    }
}
