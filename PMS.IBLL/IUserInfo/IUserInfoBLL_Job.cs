using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IUserInfoBLL
    {
        /// <summary>
        /// 根据用户id查询对应的作业
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<J_JobInfo> GetJobListByUser(int uid);
    }
}
