using FastDFS.Client;
using FastDFS.Client.Common;
using FastDFS.Client.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.FastDFS
{
   public class FastDFSHelper
    {
        #region Constructors
        /// <summary>
        /// fastDFS服务器地址列表
        /// </summary>
        static List<IPEndPoint> trackerIPs = new List<IPEndPoint>();
        /// <summary>
        /// FastDFS文件组
        /// </summary>
        public static StorageNode DefaultGroup;
        /// <summary>
        /// 当前默认的组，节，卷名称
        /// 开发人员可以通过FastDFSClient.GetStorageNode("groupname")去指定自己的组
        /// </summary>
        static FastDFSHelper()
        {
            
        }
        #endregion

        /// <summary>
        /// 获取存储节点,组名为空返回默认组
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <returns>存储节点实体类</returns>
        public static StorageNode GetStorageNode(string groupName = null)
        {
            return FastDFSClient.GetStorageNode(groupName);
        }

        /// <summary>
        /// 拼接Url
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        public static string GetFormatUrl(string host, string group, string shortName)
        {
            //return FastDFSClient
            return null;
        }
        /// <summary>
        /// 返回fastDFS路径
        /// </summary>
        /// <param name="url"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static string GetShortNameFromUrl(string host, string url, string group)
        {
            return null;
        }


        /// <summary>
        /// 上传文件到FastDFS
        /// </summary>
        /// <param name="storageNode"></param>
        /// <param name="contentByte"></param>
        /// <param name="fileExt"></param>
        /// <param name="beginDelegate">上传前回调</param>
        /// <param name="afterDelegate">上传后回调，参数为URL文件名</param>
        /// <returns>返回短文件名</returns>
        public static string UploadFile(StorageNode storageNode, byte[] contentByte, string fileExt, System.Action<string> beginDelegate, System.Action<string> afterDelegate)
        {
            return FastDFSClient.UploadFile(storageNode, contentByte, fileExt);
        }

        /// <summary>
        /// 上传文件到FastDFS
        /// </summary>
        /// <param name="storageNode"></param>
        /// <param name="contentByte"></param>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static string UploadFile(StorageNode storageNode, byte[] contentByte, string fileExt)
        {
            return FastDFSClient.UploadFile(storageNode, contentByte, fileExt);
        }
        /// <summary>
        /// 上传从文件
        /// </summary>
        /// <param name="storageNode">GetStorageNode方法返回的存储节点</param>
        /// <param name="contentByte">文件内容</param>
        /// <param name="master_filename">主文件名</param>
        /// <param name="prefix_name">从文件后缀</param>
        /// <param name="fileExt">文件扩展名(注意:不包含".")</param>
        /// <returns>文件名</returns>
        public static string UploadSlaveFile(string groupName, byte[] contentByte, string master_filename, string prefix_name, string fileExt)
        {
            return FastDFSClient.UploadSlaveFile(groupName, contentByte, master_filename, prefix_name, fileExt);
        }
        /// <summary>
        /// 上传可以Append的文件
        /// </summary>
        /// <param name="storageNode">GetStorageNode方法返回的存储节点</param>
        /// <param name="contentByte">文件内容</param>
        /// <param name="fileExt">文件扩展名(注意:不包含".")</param>
        /// <returns>文件名</returns>
        public static string UploadAppenderFile(StorageNode storageNode, byte[] contentByte, string fileExt)
        {
            return FastDFSClient.UploadAppenderFile(storageNode, contentByte, fileExt);
        }
        /// <summary>
        /// 附加文件
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="fileName">文件名</param>
        /// <param name="contentByte">文件内容</param>
        public static byte[] AppendFile(string groupName, string fileName, byte[] contentByte)
        {

            // return FastDFSClient.AppendFile(groupName, fileName, contentByte);
            return null;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="fileName">文件名</param>
        public static void RemoveFile(string groupName, string fileName)
        {
            FastDFSClient.RemoveFile(groupName, fileName);
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="storageNode">GetStorageNode方法返回的存储节点</param>
        /// <param name="fileName">文件名</param>
        /// <returns>文件内容</returns>
        public static byte[] DownloadFile(StorageNode storageNode, string fileName)
        {
            return FastDFSClient.DownloadFile(storageNode, fileName);
           
        }
        /// <summary>
        /// 增量下载文件
        /// </summary>
        /// <param name="storageNode">GetStorageNode方法返回的存储节点</param>
        /// <param name="fileName">文件名</param>
        /// <param name="offset">从文件起始点的偏移量</param>
        /// <param name="length">要读取的字节数</param>
        /// <returns>文件内容</returns>
        public static byte[] DownloadFile(StorageNode storageNode, string fileName, long offset, long length)
        {
           // FastDFSClient.DownloadFile(storageNode,)
            return null;
        }
        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="storageNode">GetStorageNode方法返回的存储节点</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static FDFSFileInfo GetFileInfo(StorageNode storageNode, string fileName)
        {
            return FastDFSClient.GetFileInfo(storageNode, fileName);
            
        }
    }
}
