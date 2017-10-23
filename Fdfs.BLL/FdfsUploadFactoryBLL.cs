using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fdfs.IDAL;
using Fdfs.DAL;
using Common.Ioc;

namespace Fdfs.BLL
{
    public class FdfsUploadFactoryBLL
    {
        /// <summary>
        /// 上传对象
        /// </summary>
        public readonly static IFdfsUploadDAL Instance;

        private static object lockObj = new object();

        static FdfsUploadFactoryBLL()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    //Instance = new FdfsUploadDAL();
                    Instance =UnityServiceLocator.Instance.GetService<IFdfsUploadDAL>();
                }
            }
        }
    }
}
