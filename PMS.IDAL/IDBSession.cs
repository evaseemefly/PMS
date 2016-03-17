using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IDAL
{
    public partial interface IDBSession
    {
        bool SaveChanges();
    }
}
