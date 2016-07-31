using PMS.Model;
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
    }
}
