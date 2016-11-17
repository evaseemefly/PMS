using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class J_JobTemplate
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public J_JobTemplate ToMiddleModel()
        {
            return new J_JobTemplate()
            {
                JobGroup = this.JobGroup,
                JTID = this.JTID,
                JTName = this.JTName,
                JobClassName = this.JobClassName,
                CronStr = this.CronStr,
                JobType = this.JobType,
                Remark = this.Remark
            };
        }
    }
}
