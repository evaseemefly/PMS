using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.IBLL
{
    public partial interface IActionInfoBLL
    {
        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteLogicActionInfos(List<int> list);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftActionInfos(List<int> list_ids);

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        bool AddValidation(String name);

        bool EditValidation(int id, String name);

        /// <summary>
        /// 根据权限名，控制器名，方法名，区域名，备注多条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="model"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        List<ActionInfo> GetActionRecordListByQuery(int pageIndex, int pageSize, ref int rowCount, PMS.Model.ViewModel.ViewModel_ActionInfo_QueryInfo model, bool isAsc, bool isMiddle);
    }
}
