using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisFactory
{
    public abstract class BaseRedisBLL<T>
    {
        public T model_config;

        /// <summary>
        /// 无参的构造函数调用抽象的读取配置文件方法
        /// </summary>
        public BaseRedisBLL()
        {
           this.model_config= ReadAppConfig();
        }

        /// <summary>
        /// 定义读取配置文件的抽象方法，并由父类初始化时调用
        /// 由子类重写
        /// </summary>
        /// <returns></returns>
        public abstract T ReadAppConfig();
    }
}
