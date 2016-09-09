using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.WFModel
{
    public class BookMarkObj<T>
    {
        public string BookMarkName { get; set; }

        public int StepId { get; set; }

        public T State { get; set; }
    }
}
