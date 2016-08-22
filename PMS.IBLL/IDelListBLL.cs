using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.ViewModel;

namespace PMS.IBLL
{
    public interface IDelListBLL
    {
        List<ViewModel_Recycle_Common> GetIsDelList();
    }
}
