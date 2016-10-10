using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using IFactoryBLL;
using System.Reflection;
    

namespace WFFactory
{
    /// <summary>
    /// 使用抽象工厂的方式实现
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string WFQueryAssemblyPath = ConfigHelper.GetSettingValue("WFAssemblyPath");

        private static readonly string NameSpace = ConfigHelper.GetSettingValue("WFNameSpace");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        private static object CreateInstance(string fullClassName)
        {
            //通过反射创建对象实例
            //根据程序集名称加载程序集
            var assembly = Assembly.Load(WFQueryAssemblyPath);

            //在此程序集中查找指定类型，并创建对象
            return assembly.CreateInstance(fullClassName);
        }

        /// <summary>
        /// 手动指定要创建的类名称，并根据反射的方式创建该类的实例
        /// </summary>
        /// <returns></returns>
        public static IWFBLL CreateMinorQuery_WF()
        {
            string fullClassName = NameSpace + ".MinorQuery_WF";
            return CreateInstance(fullClassName) as IWFBLL;
        }

        /// <summary>
        /// 手动指定要创建的类名称，并根据反射的方式创建该类的实例
        /// </summary>
        /// <returns></returns>
        public static IWFBLL CreateFirstQuery_WF()
        {
            string fullClassName = NameSpace + ".FirstQuery_WF";
            return CreateInstance(fullClassName) as IWFBLL;
        }
    }
}
