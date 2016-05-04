using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class ActionInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public ActionInfo ToMiddleModel()
        {
            return new ActionInfo()
            {
                ID = this.ID,
                ParentID = this.ParentID,
                ActionInfoName = this.ActionInfoName,
                ActionMethodName = this.ActionMethodName,
                ActionTypeEnum = this.ActionTypeEnum,
                AreaName = this.AreaName,
                Checked = this.Checked,
                ControllerName = this.ControllerName,
                DelFlag = this.DelFlag,
                IconHeight = this.IconHeight,
                IconWidth = this.IconWidth,
                MenuIcon = this.MenuIcon,
                ModifiedOnTime = this.ModifiedOnTime,
                Remark = this.Remark,
                Sort = this.Sort,
                Url = this.Url,
                SubTime = this.SubTime
            };
        }
    }
}
