using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.IBLL
{
    public partial interface IP_DepartmentInfoBLL
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的DepartmentInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        List<P_DepartmentInfo> GetListByIds(List<int> list_ids);


        /// <summary>
        /// 修改指定的DepartmentId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftRoleInfos(List<int> list_ids);
    }
}
