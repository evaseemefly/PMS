using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFactoryBLL;
using Common;

namespace WFFactory
{
    public abstract class BaseQuery_WF:IWFBLL
    {
         

        protected void CreateQueryInstance()
        {
            Common.Query.QueryHelper query = new Common.Query.QueryHelper();
        }
        /// <summary>
        /// 需要由每个子类重写的执行工作流的方法
        /// </summary>
        public abstract void Execute();
    }
}
