using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSMS
{
    /// <summary>
    /// 1 获取传入的群组及部门获取对应联系人
    /// 2 获取要删除的联系人id
    /// 3 从联系人集合中去除要删除的联系人获得最终要发送的联系人
    /// </summary>
    /// <param name="dids"></param>
    /// <param name="gids"></param>
    /// <param name="rowCount"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    public delegate List<P_PersonInfo> delegate_GetPersonListByGroupDepartment(string dids, string gids, out int rowCount, int pageSize = -1, int pageIndex = -1);
}
