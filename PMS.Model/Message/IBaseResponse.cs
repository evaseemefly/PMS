using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Message
{
    public interface IBaseResponse
    {
        bool Success { get; set; }

        string Message { get; set; }
    }
}
