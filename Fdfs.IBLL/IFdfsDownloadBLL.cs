using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fdfs.IBLL
{
    public interface IFdfsDownloadBLL
    {
        FileDownloadResult GetTargetFile(FileDownParameter param);
    }
}
