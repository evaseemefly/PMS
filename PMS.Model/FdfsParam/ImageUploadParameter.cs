using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.FdfsParam
{
    public class ImageUploadParameter : BaseUploadParameter
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        /// <param name="filenameExtension">默认支持常用图片格式</param>
        /// <param name="maxSize">3M</param>
        public ImageUploadParameter(Stream stream, string fileName, string[] filenameExtension = null, int maxSize = (3 * 1024 * 1024))
        {
            base.Stream = stream;
            base.FileName = fileName;
            base.MaxSize = maxSize;
            //??即是前面为空，则赋值为后面
            base.FilenameExtension = filenameExtension ?? new string[] { ".jpeg", ".jpg", ".gif", ".png" }; ;

        }
        /// <summary>
        /// 构造方法
        /// 注意该方法中的:this是调用本类的构造方法
        /// base即是调用基类的构造方法
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        /// <param name="maxSize">单位为M</param>
        public ImageUploadParameter(Stream stream, string fileName, int maxSize)
            : this(stream, fileName)
        { }
    }
}
