using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.IBLL
{
    public partial interface IP_GroupBLL
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的GroupInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        List<P_Group> GetListByIds(List<int> list_ids);

        /// <summary>
        /// 查询指定联系人id的所属群组集合
        /// </summary>
        /// <param name="pid">联系人id</param>
        /// <returns></returns>
        List<P_Group> GetListByPerson(int pid);


        /// <summary>
        /// 剔除传入的群组id中的群组，返回剩余群组集合
        /// </summary>
        /// <param name="list_ids_group">需要剔除群组的id集合</param>
        /// <param name="isMiddle">是否需要转成中间变量</param>
        /// <returns></returns>
        List<P_Group> GetRestGroupListByIds(List<int> list_ids_group, bool isMiddle);
        /// <summary>
        /// 根据群组GID删除指定PID的联系人
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        bool DelPersonInfoByGID(int gid, int pid);

        /// <summary>
        /// 修改指定的GroupId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftRoleInfos(List<int> list_ids);
    }
}
