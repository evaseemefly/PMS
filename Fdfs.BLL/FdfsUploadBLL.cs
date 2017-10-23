using FastDFS.Client;
using Fdfs.IBLL;
using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fdfs.IDAL;

namespace Fdfs.BLL
{
    public class FdfsUploadBLL : BaseFdfsBLL, IFdfsUploadBLL
    {
       private IFdfsUploadDAL idal;

        public FdfsUploadBLL()
        {
            this.idal = FdfsUploadFactoryBLL.Instance;
        }

        public FileUploadResult UploadFile(FileUploadParameter param)
        {
            return idal.UploadFile(param);
        }

        public ImageUploadResult UploadImage(ImageUploadParameter param)
        {
            return idal.UploadImage(param);
        }
    }
}
