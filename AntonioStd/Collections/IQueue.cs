using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IQueue<T> : IMutableCollection<T>
    {
        T Peek();

        IQueue<T> Enqueue(T value);

        T Dequeue();
    }
}
