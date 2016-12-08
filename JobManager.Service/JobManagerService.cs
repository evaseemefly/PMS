using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzJobFactory;

namespace JobManager.Service
{
    public class JobManagerService
    {
        public void Start()
        {
            JobService.InitScheduler();
            JobService.StartScheduler();
            //QuartzHelper.InitScheduler();
            //QuartzHelper.StartScheduler();
        }

        public void Stop()
        {
            JobService.StopScheduler();
            //QuartzHelper.StopScheduler();
            System.Environment.Exit(0);
        }
    }
}
