using PMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class P_Group
    {
        /// <summary>
        /// 返回该对象的回收站对象
        /// </summary>
        /// <returns></returns>
        public ViewModel_Recycle_Common ToRecycleModel()
        {
            return new ViewModel_Recycle_Common()
            {
                Id = this.GID,
                Name = this.GroupName,
                Sort = this.Sort,
                SubDateTime = this.SubTime
            };
        }
    }
}
