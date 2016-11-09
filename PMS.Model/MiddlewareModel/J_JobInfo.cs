using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public partial class J_JobInfo
    {
        /// <summary>
        /// 返回去掉导航属性的中间实体
        /// </summary>
        /// <returns></returns>
        public J_JobInfo ToMiddleModel()
        {
            return new J_JobInfo()
            {
                JID = this.JID,
                AppID = this.AppID,
                CreateTime = this.CreateTime,
                CreateUser = this.CreateUser,
                CronStr = this.CronStr,
                EndRunTime = this.EndRunTime,
                InfoState = this.InfoState,
                isDel = this.isDel,
                JobClassName = this.JobClassName,
                JobGroup = this.JobGroup,
                JobName = this.JobName,
                JobState = this.JobState,
                NextRunTime = this.NextRunTime,
                Remark = this.Remark,
                StartRunTime = this.StartRunTime,
                Token = this.Token,
                UID = this.UID
            };
        }
    }
}
