using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using PMS.IDAL;

namespace PMS.DALFactory
{
    public partial class AbstractFactory
    {
        /// <summary>
        /// 只读属性
        /// 类库名称
        /// </summary>
        private static readonly string DALAssemblyPath =ConfigurationManager.AppSettings["DALAssemblyPath"];

        /// <summary>
        /// 只读属性
        /// 命名空间
        /// </summary>
        private static readonly string NameSpace =ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// 使用反射的方式创建对象实例
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        private static object CreateInstance(string fullClassName)
        {
            //通过反射创建对象实例
            //根据程序集名称加载程序集
            var assembly = Assembly.Load(DALAssemblyPath);

            //在此程序集中查找指定类型，并创建对象
            return assembly.CreateInstance(fullClassName);
        }

    }
}
