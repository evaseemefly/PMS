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

           return FastDFSHelper.UploadFile(FastDFSHelper.DefaultGroup, content,"jpg");
           // FastDFSClient.UploadFile();
        }
    }
}
