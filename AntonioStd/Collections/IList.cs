using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IList<T> : ICollection<T>
    {
        T Get(int index);
    }
}
