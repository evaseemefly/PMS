using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IModel
{
    /// <summary>
    /// 作业调度中需要用到的保存一些信息的接口
    /// </summary>
    public interface IJobData
    {
        /// <summary>
        /// value
        /// </summary>
        Object JobDataValue { get; set; }

        /// <summary>
        /// key
        /// </summary>
        string JobDataKey { get;  }

        //不写此方法了
        ///// <summary>
        ///// 对应key
        ///// </summary>
        //string GetKey();
    }
}
