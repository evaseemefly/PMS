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
        public BaseUploadResult()
        {

        }

        public BaseUploadResult(string fileNameIncludeScroll,string group)
        {
            this.FileNameIncludeScroll = fileNameIncludeScroll;
            this.GroupName = group;
            this.FileNameIncludeExt = this.FileNameIncludeScroll.Substring(this.FileNameIncludeScroll.LastIndexOf('/')+1);

            //M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg 找到最后一个'/'的位置+1
            int index_fileStart = this.FileNameIncludeScroll.LastIndexOf('/') + 1;
            //M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg 找到最后一个.的位置
            int index_fileFinish = this.FileNameIncludeScroll.LastIndexOf('.');
            this.FileName = this.FileNameIncludeScroll.Substring(index_fileStart,index_fileFinish-index_fileStart);
        }

        /// <summary>
        /// 返回文件的全地址
        /// eg：http://192.168.0.113/group1/M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FullFilePath { get; set; }

        /// <summary>
        /// 文件名称（含卷名）
        /// eg：M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FileNameIncludeScroll { get;protected set; }

        /// <summary>
        /// 只含文件名称+拓展名
        /// eg:wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
        /// </summary>
        public string FileNameIncludeExt { get ;protected set; }

        /// <summary>
        /// 只含文件名称
        /// eg:wKgAcVjHVVKAGNhPAAInn_BrY3k026
        /// </summary>
        public string FileName { get;protected set; }

        /// <summary>
        /// 群组名称
        /// eg：group1
        /// </summary>
        public string GroupName { get;protected set; }

        /// <summary>
        /// 服务器地址，此url为storage节点的地址
        /// eg：192.168.0.113
        /// </summary>
        public string StorageUrl { get;protected set; }

        /// <summary>
        /// 端口号，此端口号为storage节点的端口号
        /// 22122 storage
        /// 23000 tracker
        /// </summary>
        public string StoragePort { get;protected set; }

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
