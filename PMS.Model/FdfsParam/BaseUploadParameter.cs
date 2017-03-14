using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.FdfsParam
{
    public class BaseUploadParameter
    {
        public BaseUploadParameter()
        {
            MaxSize = 1024 * 1024 * 8;
        }
        /// <summary>
        /// 前一次上传时生成的服务器端文件名，如果需要断点续传，需传入此文件名
        /// </summary>
        public string ServiceFileName { get; set; }
        /// <summary>
        /// 文件流
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// 二进制数组
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小限制（单位bit 默认1M）
        /// </summary>
        public int MaxSize
        {
            get;
            protected set;
        }

        /// <summary>
        /// 上传文件类型限制
        /// </summary>
        public string[] FilenameExtension
        {
            get;
            set;
        }
    }
}
