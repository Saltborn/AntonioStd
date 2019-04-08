using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IIterable<T>
    {
        IIterator<T> GetIterator();

        void ForEach(Action<T> action);       
    }
}
