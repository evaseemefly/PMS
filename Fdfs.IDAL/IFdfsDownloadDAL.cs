using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fdfs.IDAL
{
    public interface IFdfsDownloadDAL
    {
        /// <summary>
        /// 下载指定文件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        FileDownloadResult GetTargetFile(FileDownParameter param);
    }
}
