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
        /// </summary>
        public StorageNode Node { get; private set; }

        /// <summary>
        /// fastDFS服务器地址列表
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
