using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class UserInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public UserInfo ToMiddleModel()
        {
            return new UserInfo()
            {
                ID = this.ID,
                UName = this.UName,
                DelFlag = this.DelFlag,
                ModifiedOnTime = this.ModifiedOnTime,
                Remark = this.Remark,
                Sort = this.Sort,
                SubTime = this.SubTime,
                UPwd = this.UPwd,
                Checked = this.Checked

            };
        }
    }
}
