using FastDFS.Client;
using Fdfs.IDAL;
using PMS.Model.FdfsParam;
using PMS.Model.Message.Fdfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fdfs.DAL
{
    public class FdfsDownloadDAL : BaseFdfsDAL, IFdfsDownloadDAL
    {
        
        public FdfsDownloadDAL()
        {
            base.InitStorageNode();
        }


        /// <summary>
        /// 下载指定名称的文件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FileDownloadResult GetTargetFile(FileDownParameter param)
        {
            byte[] content = null;
            string errorMsg = string.Empty;
            try
            {
                content = FastDFSClient.DownloadFile(base.Node, param.FileName);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return new FileDownloadResult()
            {
                Content = content,
                ErrorMessage = errorMsg
            };
        }

    }
}
