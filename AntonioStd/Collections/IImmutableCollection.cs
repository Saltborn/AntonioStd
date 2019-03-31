using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
   public interface IMutableCollection<T> : ICollection<T>
    {      
        void Clear();      
    }
}
