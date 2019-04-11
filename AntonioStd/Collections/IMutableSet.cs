using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IMutableSet<T> : ISet<T>, IMutableCollection<T>
    {
        IMutableSet<T> Add(T value);
    }
}
