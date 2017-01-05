using PMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public interface IBaseDelBLL
    {
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false);


        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool Recovery(List<int> list_ids);

        /// <summary>
        /// 获取已经软删除的集合
        /// </summary>
        /// <returns></returns>
        List<ViewModel_Recycle_Common> GetIsDelList();

        

        /// <summary>
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <returns></returns>
        List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex,int pageSize,ref int rowCount);
    }
}
