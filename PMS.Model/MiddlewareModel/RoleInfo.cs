using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class RoleInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public RoleInfo ToMiddleModel()
        {
            return new RoleInfo()
            {
                ID = this.ID,
                RoleName = this.RoleName,
                SubTime = this.SubTime,
                Sort = this.Sort,
                Checked = this.Checked,
                DelFlag = this.DelFlag,
                ModifiedOnTime = this.ModifiedOnTime,
                Remark = this.Remark
            };
        }
    }
}
