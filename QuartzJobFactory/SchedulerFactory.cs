using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace QuartzJobFactory
{
    public class SchedulerFactory
    {
        //private ISchedulerFactory schedFact;
        private static IScheduler sched;

        /// <summary>
        /// 在构造函数中通过读取配置文件的方式获取调度池
        /// </summary>
        public SchedulerFactory()
        {
            if (sched == null )
            {
                //实例化调度实例
                //调度池在配置文件中配置
                sched = StdSchedulerFactory.GetDefaultScheduler();
            }
            #region 通过读取配置文件获取调度池的一些参数以下方式注释掉
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
            #endregion

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
