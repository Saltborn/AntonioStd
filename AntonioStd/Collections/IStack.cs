using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IStack<T> : IMutableCollection<T>
    {
        T Peek();

        T Pop();

        IStack<T> Push(T value);
    }
}
