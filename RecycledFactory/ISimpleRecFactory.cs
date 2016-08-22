using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycledFactory
{
    public interface ISimpleRecFactory<T>
    {
        T Create();
    }
}
