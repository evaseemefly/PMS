using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzServiceLib;

namespace QuartzProxy
{
   public class QuartzServiceFacade
    {
        private IJobService jobService;

        public QuartzServiceFacade(IJobService jobSer)
        {
            this.jobService = jobSer;
        }

        public bool AddScheduleJob(PMS.Model.J_JobInfo jobInfo)
        {
            return jobService.AddScheduleJob(jobInfo);
        }

        public void PauseJob(string jobName, string jobGroup)
        {
            jobService.PauseJob(jobName, jobGroup);
        }

        public void ResumeAllJob()
        {
            jobService.ResumeAllJob();
        }
    }
}
