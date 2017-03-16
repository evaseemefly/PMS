using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Message.Fdfs
{
    /// <summary>
    /// 上传结果父类
    /// </summary>
    public class BaseUploadResult
    {
        /// <summary>
        /// 返回文件的全地址
        /// eg：http://192.168.0.113/group1/M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FullFilePath { get; set; }

        /// <summary>
        /// 文件名称（含卷名）
        /// eg：M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FileNameIncludeScroll { get; set; }

        /// <summary>
        /// 只含文件名称+拓展名
        /// eg:wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FileNameIncludeExt { get; set; }

        /// <summary>
        /// 只含文件名称
        /// eg:wKgAcVjHVVKAGNhPAAInn_BrY3k026
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 群组名称
        /// eg：group1
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 服务器地址
        /// eg：192.168.0.113
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 错误消息列表
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 是否上传成功
        /// </summary>
        public bool IsValid { get { return string.IsNullOrWhiteSpace(ErrorMessage); } }
    }
}
