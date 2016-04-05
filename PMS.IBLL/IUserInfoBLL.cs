using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;

namespace PMS.IBLL
{
    public partial interface IUserInfoBLL
    {
        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteLogicUserInfos(List<int> list);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftUserInfos(List<int> list_ids);

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <returns></returns>
        bool SetUser4Role(int userID, List<int> list_roleIDs);
        /// <summary>
        /// 为用户分配权限
        /// </summary>
        /// <returns></returns>
        bool SetUser4Action(int userID, List<int> list_actionIDs);
    }
}
