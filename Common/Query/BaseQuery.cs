using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query
{
   public abstract class BaseQuery
    {
        /// <summary>
        /// 无参的构造函数调用抽象的读取配置文件方法
        /// </summary>
        public BaseQuery()
        {
            ReadAppConfig();
        }

        /// <summary>
        /// 定义读取配置文件的抽象方法，并由父类初始化时调用
        /// 由子类重写
        /// </summary>
        /// <returns></returns>
        public abstract bool ReadAppConfig();

    }
}
