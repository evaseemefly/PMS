using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    /// <summary>
    /// fdfs的基本配置对象
    /// </summary>
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

        private string host;

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { get { return host; } }

        /// <summary>
        /// 失败次数
        /// </summary>
        protected int FaildCount { get; set; }
        /// <summary>
        /// 失败阀值
        /// </summary>
        public int MaxFaildCount { get; set; }

        /// <summary>
        /// 在构造函数中为dfsgroup赋值
        /// </summary>
        public FastDFSConfigHelper()
        {
            this.dFSGroupName=GetSettingValue("fdfsGroup");
            this.host = GetSettingValue("fdfsHost");
            this.FaildCount =int.Parse(GetSettingValue("fdfsFailCount"));
            this.MaxFaildCount = int.Parse(GetSettingValue("fdfsMaxFailCount"));
        }

    }
}
