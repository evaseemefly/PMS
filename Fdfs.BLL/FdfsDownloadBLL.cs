using FastDFS.Client;
using Fdfs.IBLL;
using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fdfs.IDAL;

namespace Fdfs.BLL
{
    public class FdfsDownloadBLL : BaseFdfsBLL, IFdfsDownloadBLL
    {
       private IFdfsDownloadDAL idal;

        public FdfsDownloadBLL()
        {
            idal = FdfsDownloadFactoryBLL.Instance; 
        }

        public FileDownloadResult GetTargetFile(FileDownParameter param)
        {
           return idal.GetTargetFile(param);
        }
    }
}
