using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace QuartzServiceLib
{
    public class SchedulerFactory
    {
        //private ISchedulerFactory schedFact;
        private static IScheduler sched;

        public SchedulerFactory()
        {
            if (sched == null )
            {
                //实例化调度实例
                //调度池在配置文件中配置
                sched = StdSchedulerFactory.GetDefaultScheduler();
            }
            //if (schedFact == null)
            //{
            //    // 创建调度工厂
            //    schedFact = new StdSchedulerFactory();

            //}
            //if (sched == null&&schedFact!=null)
            //{
            //    //实例化调度实例
            //    sched = schedFact.GetScheduler();
            //}
        }

        /// <summary>
        /// 获取调度实例
        /// </summary>
        /// <returns></returns>
        public IScheduler GetScheduler()
        {
            return sched;
        }
    }
}
