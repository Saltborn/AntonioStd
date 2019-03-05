using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IRange : ICollection<int>
    {
        int Start { get; }

        int End { get; }
    }
}