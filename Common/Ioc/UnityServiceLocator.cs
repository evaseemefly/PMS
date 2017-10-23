using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Ioc
{
    /// <summary>
    /// 服务定位器
    /// </summary>
    public class UnityServiceLocator : IServiceProvider
    {
        /// <summary>
        /// unity容器
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// 
        /// </summary>
        private static readonly UnityServiceLocator instance = new UnityServiceLocator();

        /// <summary>
        /// 无参构造函数
        /// 读取默认配置文件中的unity的配置或读取
        /// unity.config的外置配置文件
        /// （需要将unity.config文件作为始终复制到输出路径下）
        /// </summary>
        private UnityServiceLocator()
        {
            //1 从默认配置文件中读取配置信息
            UnityConfigurationSection section = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            //2 若配置信息为空则尝试读取外置的配置文件
            if (section == null)
            {
                //2.1 获取unity外置配置文件的所在路径
                var filePath_unityConfig = System.AppDomain.CurrentDomain.BaseDirectory + @"\unity.config";
                //
                var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = filePath_unityConfig };

                //2.2 创建配置文件对象
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                //2.3 读取unity 配置节的信息
                section = configuration.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
                /*
                 * 注意通过上面的方式
                 * UnityConfigurationSection.SectionName默认为unity
                 * 以下方法注释掉
                 */
                //UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            }

            //3 创建unity的容器
            container = new UnityContainer();

            try
            {
                //默认的容器元素的配置适用于给定的容器。
                /*
                 * 注意若在配置文件中
                 * container配置节点处若添加了name，那么需要给定name的值
                 * 
                 */
                //3.1 配置对象不为空，为unity容器按指定配置进行配置
                if (section == null)
                {
                    throw new ArgumentException("unity节点为空");
                }
                //默认的容器元素的配置适用于给定的容器。
                section.Configure(container);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static UnityServiceLocator Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// 获取指定类型的服务对象。
        /// 重载的IServiceProvider接口的实现方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            //解决默认请求类型的一个实例的容器。
            return container.Resolve<T>();
        }

        /// <summary>
        /// 获取指定类型的服务对象
        /// IServiceProvider接口的实现方法
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }
    }
}
