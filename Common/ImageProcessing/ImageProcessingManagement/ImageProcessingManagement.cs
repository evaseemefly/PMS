using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public delegate string ImageProcessingEventhandler(string content, out string fileNameIncludeEx);
    /// <summary>
    /// 图像处理管理类
    /// </summary>
    public class ImageProcessingManagement
    {
        public event ImageProcessingEventhandler processingEvent;

        public string DoImageProcessing(string content, out string fileNameIncludeEx)
        {
            
            if(processingEvent != null)
            {
                return processingEvent(content, out fileNameIncludeEx);
            }
            return fileNameIncludeEx="";
        } 

    }
}
