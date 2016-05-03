using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class P_DepartmentInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public P_DepartmentInfo ToMiddleModel()
        {
            return new P_DepartmentInfo
            {
                DID = this.DID,
                DepartmentName = this.DepartmentName,
                Area = this.Area,
                isDel = this.isDel,
                PDID = this.PDID,
                Remark = this.Remark
            };
        }
    }
}
