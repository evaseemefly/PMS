using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJobFactory
{
    public interface IJobService
    {
        /// <summary>
        /// 根据工作对象 添加任务计划
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        bool AddScheduleJob(J_JobInfo jobInfo);
    }
}
