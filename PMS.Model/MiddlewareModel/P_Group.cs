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
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public P_Group ToMiddleModel()
        {
            return new P_Group()
            {
                GID = this.GID,
                GroupName = this.GroupName,
                ModifiedOnTime = this.ModifiedOnTime,
                Remark = this.Remark,
                Sort = this.Sort,
                SubTime = this.SubTime,
                isDel = this.isDel
            };
        }
    }
}
