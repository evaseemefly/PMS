using Common;
using Common.Redis;
using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IFactoryBLL;

namespace SMSbackgroun_QueryHistoryRedis
{
    class Program
    {
        
        /// <summary>
        /// 本后台程序定时查询Redis中保存的对象集合
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
           IWFBLL bll= WFFactory.AbstractFactory.CreateFirstQuery_WF();
           IWFBLL bll_minor = WFFactory.AbstractFactory.CreateMinorQuery_WF();
           //bll.Execute();
           bll_minor.Execute();

            //9月26日——由于无法重新加载工作流——进行的测试——加载指定id的Wf
            //WFFactory.MinorQuery_WF minorquery = new WFFactory.MinorQuery_WF();
            //minorquery.Execute();

           Console.ReadLine();

        }


        
    }
}
