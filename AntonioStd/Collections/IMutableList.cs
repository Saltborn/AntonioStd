using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IMutableList<T> : IList<T>, IMutableCollection<T>
    {
        IMutableList<T> Insert(T value);
    }
}
