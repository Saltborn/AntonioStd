using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface ISet<T> : ICollection<T>
    {
        ISet<T> Exept(ISet<T> other);

        ISet<T> Intersect(ISet<T> other);

        ISet<T> Union(ISet<T> other);
    }
}
