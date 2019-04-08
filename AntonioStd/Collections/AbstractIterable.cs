using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public abstract class AbstractIterable<T> : IIterable<T>
    {
        public void ForEach(Action<T> action)
        {
            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                action.Invoke(iterator.Next());
            }
        }

        public abstract IIterator<T> GetIterator();
    }
}
