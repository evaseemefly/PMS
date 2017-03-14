using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Message.Fdfs
{
    /// <summary>
    /// 下载结果父类
    /// </summary>
    public class BaseDownloadResult
    {
        /// <summary>
        /// 流
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// 二进制数组
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 错误日志
        /// </summary>
        public string ErrorMessage { get; set; }


    }
}
