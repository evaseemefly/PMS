using FastDFS.Client;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fdfs.DAL
{
    public class BaseFdfsDAL
    {
        /// <summary>
        /// 目录名,需要提前在fastDFS上建立
        /// </summary>
        public string DFSGroupName { get; private set; }
        /// <summary>
        /// FastDFS结点
        /// 注意此节点在初始化时被赋值，赋值后该节点为tracker节点
        /// </summary>
        public StorageNode Node { get; private set; }

        /// <summary>
        /// fastDFS服务器地址列表
        /// 注意该地址列表实际为storage节点地址，也是在初始化时被赋值
        /// </summary>
        public List<IPEndPoint> trackerIPs = new List<IPEndPoint>();

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// 初始化节点
        /// </summary>
        protected void InitStorageNode()
        {
            //读取配置文件中的fdfs配置节
            var config = FastDfsManager.GetConfigSection();
            try
            {
                //注意需要先初始化tracker
                ConnectionManager.InitializeForConfigSection(config);
                this.DFSGroupName = config.GroupName;
                this.Host = config.FastDfsServer.FirstOrDefault().IpAddress;
                //根据指定群组名称获取存储节点
                /* 注意 
                 * 虽然叫做StorageNode,
                 * 但实际Node中的EndPoint为tracker的地址
                 * eg
                 * 192.168.0.113:23000
                 * 
                 */
                Node = FastDFSClient.GetStorageNode(config.GroupName);
                foreach (var item in config.FastDfsServer)
                {
                    trackerIPs.Add(new IPEndPoint(IPAddress.Parse(item.IpAddress), item.Port));
                }
                //初始化
                ConnectionManager.Initialize(trackerIPs);
            }
            catch (Exception ex)
            {
                //Logger.LoggerFactory.Instance.Logger_Error(ex);
            }

        }
    }
}
