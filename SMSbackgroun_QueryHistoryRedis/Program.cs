using Common;
using Common.Redis;
using ISMS;
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
            bll.Execute();
            Console.ReadLine();
        }


        
    }
}
