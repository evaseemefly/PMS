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
        List<N_News> GetAllNewsListByUser(int uid, int count);

        /// <summary>
        /// 根据snid查找对应的News对象以及已经checked的人员集合
        /// </summary>
        /// <param name="snid"></param>
        /// <param name="toMiddle"></param>
        /// <returns></returns>
        ViewModel_News GetNewsBySNID(int snid, bool toMiddle);
    }
}
