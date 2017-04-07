using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class FdfsStorageBLL : IBaseDelBLL, ICanBeDel
    {


        public bool CanBeDel(List<int> list_ids)
        {
            throw new NotImplementedException();
        }

        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            throw new NotImplementedException();
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            throw new NotImplementedException();
        }

        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            throw new NotImplementedException();
        }

        public bool Recovery(List<int> list_ids)
        {
            throw new NotImplementedException();
        }
    }
}
