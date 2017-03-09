using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client;

namespace Common.FastDFS
{
    public class fastDFSTestClient
    {
        public static string test(byte[] content)
        {
            //3月8日
            //现改为非静态类了，其中storageNode也是非静态属性
            FastDFSHelper fdfsHelper = new FastDFSHelper();
           return FastDFSHelper.UploadFile(fdfsHelper.storageNode, content,"jpg");
           // FastDFSClient.UploadFile();
        }
    }
}
