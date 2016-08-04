using PMS.Model;
using PMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IN_NewsBLL
    {
        /// <summary>
        /// 根据登录用户查询该用户所拥有的全部消息（未查看、查看了的都算）——分页查询
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="index">页码</param>
        /// <param name="isMiddleint"></param>
        /// <param name="count">页容量（可不填，不填默认为-1），为-1则不进行分页查询</param>
        /// <returns></returns>
        List<N_News> GetAllNewsPageListByUser(int uid, int index, bool isMiddleint, int count = -1);

        /// <summary>
        /// 根据snid查找对应的News对象以及已经checked的人员集合
        /// </summary>
        /// <param name="snid"></param>
        /// <param name="toMiddle"></param>
        /// <returns></returns>
        ViewModel_News GetNewsBySNID(int snid, bool toMiddle);
    }
}
