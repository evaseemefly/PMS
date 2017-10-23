using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ExceptionModel
{
    public class PMSException:Exception
    {
        public PMSException(string message) : base("PMSException:" + message) { }
    }
}
