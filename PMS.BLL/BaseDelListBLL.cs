using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;

namespace PMS.BLL
{
    public abstract class BaseDelListBLL<T> 
    {
        public abstract List<T> GetDelList();

        public List<T> DoGetDelList()
        {
            return GetDelList();
        }
    }
}
