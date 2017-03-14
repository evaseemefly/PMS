using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fdfs.IDAL;
using Fdfs.DAL;

namespace Fdfs.BLL
{
    public class FdfsDownloadFactoryBLL
    {
        public readonly static IFdfsDownloadDAL Instance;

        private static object lockObj = new object();

        static FdfsDownloadFactoryBLL()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    Instance = new FdfsDownloadDAL();
                }
            }
        }
    }
}
