using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzJobFactory;
using QuartzServiceLib;

namespace QuartzJobByTopShelfDemo
{
    public class JobManagerService
    {
        public void Start()
        {
            //12月8日可用的，现尝试再次使用wcf方式的方式，此处暂时注释掉
            //JobService.InitScheduler();
            //JobService.StartScheduler();
            //启动调度池
            QuartzServiceLib.JobService.StartScheduler();


        }

        public void Stop()
        {
            //12月8日可用的，现尝试再次使用wcf方式的方式，此处暂时注释掉
            //JobService.StopScheduler();
            QuartzServiceLib.JobService.StopScheduler();
            System.Environment.Exit(0);
        }
    }
}
