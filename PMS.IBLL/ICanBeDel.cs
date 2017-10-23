using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public interface ICanBeDel
    {
        /// <summary>
        /// 可以被物理删除（没有关联）
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool CanBeDel(List<int> list_ids);
    }
}
