using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJobFactory
{
    class JobAbstractFactory
    {
        private static readonly string JobAssemblyPath= ConfigurationManager.AppSettings["JobAssemblyPath"];

        private static readonly string JobNameSpace= ConfigurationManager.AppSettings["JobNameSpace"];

        /// <summary>
        /// 使用反射的方式创建对象实例
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        private static object CreateInstance(string fullClassName)
        {
            //通过反射创建对象实例
            //根据程序集名称加载程序集
            var assembly = Assembly.Load(JobAssemblyPath);

            //在此程序集中查找指定类型，并创建对象
            return assembly.CreateInstance(fullClassName);
        }

        /// <summary>
        /// 通过反射的方式根据传入的Job类名创建其实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IJob CreateJob(string name)
        {
            string fullClassName = JobNameSpace + "." + name;
            return CreateInstance(fullClassName) as IJob;
        }

        
    }
}
