using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMS.IBLL
{
    public partial interface IRoleInfoBLL
    {
        /// <summary>
        /// 根据id集合批量删除RoleInfo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteLogicRoleInfos(List<int> list);

        /// <summary>
        /// 修改指定的RoleId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftRoleInfos(List<int> list_ids);

        bool SetRole4Action(int roleId, List<int> list_actionIds);
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        bool AddValidation(String name);

        bool EditValidation(int id, String name);
    }
}
