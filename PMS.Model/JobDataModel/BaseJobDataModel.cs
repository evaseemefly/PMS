using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IModel;

namespace PMS.Model.JobDataModel
{
   public abstract class BaseJobDataModel : IJobData
    {
        /// <summary>
        /// 由子类重写的返回key的方法
        /// </summary>
        /// <returns></returns>
        public abstract string GetKey();

        /// <summary>
        /// 调度作业中保存于DataMap中的key
        /// </summary>
        public string JobDataKey
        {
            get
            {
               return GetKey();
            }
        }

        /// <summary>
        /// 作业调度中保存于DataMap的value（对象）
        /// </summary>
        public object JobDataValue { get; set; }
    }
}
