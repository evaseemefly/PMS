using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client.Common;

namespace PMS.Model.Message.Fdfs
{
    /// <summary>
    /// 图片上传结果
    /// 返回的是storage的相关信息
    /// </summary>
    public class ImageUploadResult : BaseUploadResult
    {
        /// <summary>
        /// 里面保存的节点是tracker的节点
        /// EndPoint:192.168.0.113:23000
        /// GroupName:group1
        /// StorePathIndex:0
        /// </summary>
        public StorageNode TrackerNode {get;set;}

        public ImageUploadResult()
        {
            if (TrackerNode != null)
            {
                this.TrackerUrl = TrackerNode.EndPoint.Address.ToString();
                this.StoragePort = TrackerNode.EndPoint.Port.ToString();
                this.TrackerGroup = TrackerNode.GroupName;
                this.Scroll = base.FileNameIncludeScroll.Substring(0, base.FileNameIncludeScroll.LastIndexOf('/') + 1);
                Enum.FileExt_Enum enum_ext;
              System.Enum.TryParse<Enum.FileExt_Enum>(base.FileNameIncludeExt.Substring(FileNameIncludeExt.LastIndexOf('.')+1),out enum_ext);
                this.ExtName = enum_ext;
            }
            
        }

        /// <summary>
        /// 192.168.0.113
        /// </summary>
        public string TrackerUrl { get; private set; }

        /// <summary>
        /// 基本都是23000
        /// </summary>
        public string TrackerPort { get; private set; }

        /// <summary>
        /// 群组名称
        /// eg:group1
        /// </summary>
        public string TrackerGroup { get; private set; }

        /// <summary>
        /// 卷
        /// eg:M00/00/00/
        /// </summary>
        public string Scroll { get; private set; }

        /// <summary>
        /// 文件后缀
        /// eg:.png
        /// </summary>
        public PMS.Model.Enum.FileExt_Enum ExtName { get; private set; }
    }
}
