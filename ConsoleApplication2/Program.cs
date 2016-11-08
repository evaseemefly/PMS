
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //1.首先创建一个作业调度池
            var properties = new System.Collections.Specialized.NameValueCollection();
            //存储类型
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            //表明前缀
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            //驱动类型
            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";                //数据源名称
            properties["quartz.jobStore.dataSource"] = "myDS";
            //连接字符串
            properties["quartz.dataSource.myDS.connectionString"] = "metadata=res://*/PMSEntities.csdl|res://*/PMSEntities.ssdl|res://*/PMSEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ADMIN-PC;initial catalog=PMS20160325;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //sqlserver版本
            properties["quartz.dataSource.myDS.provider"] = "SqlServer-20";
            //最大链接数
            //properties["quartz.dataSource.myDS.maxConnections"] = "5";
            // First we must get a reference to a scheduler
            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = sf.GetScheduler();

        }
    }
}
