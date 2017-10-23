using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class S_SMSMission
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public S_SMSMission ToMiddleModel()
        {
            return new S_SMSMission()
            {
                SMID = this.SMID,
                isDel = this.isDel,
                isMMS = this.isMMS,
                ModifiedOnTime = this.ModifiedOnTime,
                Remark = this.Remark,
                SMSMissionName = this.SMSMissionName,
                SubTime = this.SubTime,
                Sort=this.Sort
            };
        }
    }
}
