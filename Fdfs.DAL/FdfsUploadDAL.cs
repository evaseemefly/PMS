using FastDFS.Client;
using Fdfs.IDAL;
using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fdfs.DAL
{
    public class FdfsUploadDAL : BaseFdfsDAL, IFdfsUploadDAL
    {
        /// <summary>
        /// 文件上传的缓冲区大小
        /// </summary>
        const int SIZE = 1024 * 1024;

        /// <summary>
        /// 失败次数
        /// </summary>
        protected int FaildCount { get; set; }
        /// <summary>
        /// 失败阀值
        /// </summary>
        public int MaxFaildCount { get; set; }

        public FdfsUploadDAL()
        {
            base.InitStorageNode();
            MaxFaildCount = 3;
        }

        #region 上传时需要用到的方法


        /// <summary>
        /// 上传小文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string SmallFileUpload(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath 参数不能为空");
            if (!File.Exists(filePath))
                throw new Exception("上传的文件不存在");
            byte[] content;
            using (FileStream streamUpload = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(streamUpload))
                {
                    content = reader.ReadBytes((int)streamUpload.Length);
                }
            }
            string shortName = FastDFSClient.UploadFile(Node, content, "png");
            return GetFormatUrl(shortName);
        }

        /// <summary>
        /// 文件分块上传，适合大文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string MultipartUpload(BaseUploadParameter param)
        {
            Stream stream = param.Stream;
            byte[] content = param.Content;
            //注意此处抛出一个架构级异常
            if (stream == null && content == null)
                throw new ArgumentNullException("stream及content参数不能同时为空");
            //1 若传入的参数对象中二进制数组为空，说明将文件内容读取至流对象中
            if (content == null)
            {
                content = new byte[SIZE];
                Stream streamUpload = stream;
                //将流以二进制的形式读取出来
                streamUpload.Read(content, 0, SIZE);
            }

            //2  第一个数据包上传或获取已上传的位置
            string ext = param.FileName.Substring(param.FileName.LastIndexOf('.') + 1);


            string shortName = FastDFSClient.UploadAppenderFile(Node, content, ext);

            BeginUploadPart(stream, shortName);

            return CompleteUpload(stream, shortName);
        }
        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="serverShortName"></param>
        private void ContinueUploadPart(Stream stream, string serverShortName)
        {
            var serviceFile = FastDFSClient.GetFileInfo(Node, serverShortName);
            stream.Seek(serviceFile.FileSize, SeekOrigin.Begin);
            BeginUploadPart(stream, serverShortName);
        }
        /// <summary>
        /// 从指定位置开始上传文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="beginOffset"></param>
        /// <param name="serverShortName"></param>
        private void BeginUploadPart(Stream stream, string serverShortName)
        {
            try
            {

                byte[] content = new byte[SIZE];

                while (stream.Position < stream.Length)
                {
                    stream.Read(content, 0, SIZE);
                    FastDFSClient.AppendFile(DFSGroupName, serverShortName, content);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.Instance.Logger_Info("上传文件中断！" + ex.Message);
                if (NetCheck())
                {
                    //重试
                    if (FaildCount < MaxFaildCount)
                    {
                        FaildCount++;
                        InitStorageNode();
                        ContinueUploadPart(stream, serverShortName);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        //LoggerFactory.Instance.Logger_Info("已达到失败重试次数仍没有上传成功"); ;
                        throw ex;
                    }
                }
                else
                {
                    // LoggerFactory.Instance.Logger_Info("当前网络不可用");
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 网络可用为True,否则为False
        /// </summary>
        /// <returns></returns>
        private bool NetCheck()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
        /// <summary>
        /// 拼接Url
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        private string GetFormatUrl(string shortName)
        {
            //return string.Format("http://{0}/{1}/{2}", Host, DFSGroupName, shortName);
            return string.Format("http://{0}/{1}/{2}", Host, DFSGroupName, shortName);
        }

        /// <summary>
        /// 完成上传，关闭传入的流，并返回最终的文件地址
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        private string CompleteUpload(Stream stream, string shortName)
        {
            stream.Close();
            return GetFormatUrl(shortName);
        }

        private string GetShortNameFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;
            Uri uri = new Uri(url);
            string urlFirstPart = string.Format("http://{0}/{1}/", Host, DFSGroupName);
            if (!url.StartsWith(urlFirstPart))
                return string.Empty;
            return url.Substring(urlFirstPart.Length);
        }
        #endregion

        #region IUploader 实现方法

        /// <summary>
        /// 上传普通文件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FileUploadResult UploadFile(FileUploadParameter param)
        {
            var result = new FileUploadResult();
            try
            {
                //return FastDFSClient.UploadFile(Node, content, ext);
                string fileName = MultipartUpload(param);
                result.FullFilePath = fileName;
            }
            catch (Exception ex)
            {

                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="param"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ImageUploadResult UploadImage(ImageUploadParameter param)
        {
            byte[] content;
            string shortName = "";
            //1 获取拓展名
            string ext = System.IO.Path.GetExtension(param.FileName).ToLower();
            //1.2判断上传图片对象中的拓展名是否与实际拓展名相符
            //若上传图片对象的拓展名为空或不行相符
            if (param.FilenameExtension != null && param.FilenameExtension.Contains(ext))
            {
                if (param.Stream.Length > param.MaxSize)
                {
                    return new ImageUploadResult
                    {
                        ErrorMessage = "图片大小超过指定大小" + param.MaxSize / (1024 * 1024) + "M，请重新选择",
                        FullFilePath = shortName
                    };
                }
                else
                {
                    using (BinaryReader reader = new BinaryReader(param.Stream))
                    {
                        //BinaryReader reader = new BinaryReader(param.Stream);
                        int count = (int)param.Stream.Length;
                        content = reader.ReadBytes(count);
                    }

                //**注意 调用FdfsClient的UploadFile时，拓展名不含.，需要手动去掉
                //**注意返回值为：M00/00/00/wKgAcVjGSpSANp6XAAInn_BrY3k752.jpg
                // 即是BaseUploadResult中的FileNameIncludeScroll
                shortName = FastDFSClient.UploadFile(Node, content, ext.Contains('.') ? ext.Substring(1) : ext);
                    
                }
            }
            else
            {
                return new ImageUploadResult
                {
                    ErrorMessage = "文件类型不匹配",
                    FullFilePath = shortName
                };

            }
            return new ImageUploadResult(Node, shortName,Node.GroupName)
            {
                FullFilePath = CompleteUpload(param.Stream, shortName),
                //FileNameIncludeScroll = shortName,
                //GroupName = Node.GroupName,
                //Host:192.168.0.113
                //注意此处的Host
                //StoragePort = Host.Substring(Host.IndexOf(':')),
                //StorageUrl =  Host.Substring(0,Host.IndexOf(':')+1),
                //TrackerNode=Node,    
            };
        }
        #endregion
    }
}
