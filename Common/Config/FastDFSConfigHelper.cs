using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    public class FastDFSConfigHelper:ConfigHelper
    {
        /// <summary>
        /// 私有的只能在构造函数中为其赋值的dfs的群组名称
        /// </summary>
        private string dFSGroupName;

        /// <summary>
        /// 外部可访问的只读属性
        /// </summary>
        public string DFSGroupName { get { return dFSGroupName; } }

        /// <summary>
        /// 在构造函数中为dfsgroup赋值
        /// </summary>
        public FastDFSConfigHelper()
        {
            this.dFSGroupName=GetSettingValue("DFSGroup");
        }

    }
}
