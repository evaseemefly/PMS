using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.ViewModel;

namespace PMS.Model
{
   public partial class N_News
    {
        /// <summary>
        /// 返回该对象的回收站对象
        /// </summary>
        /// <returns></returns>
        public ViewModel_Recycle_Common ToRecycleModel()
        {
            return new ViewModel_Recycle_Common()
            {
                Id = this.SNID,
                Name = this.Title,
                
                SubDateTime = this.SubDateTime
            };
        }
    }
}
