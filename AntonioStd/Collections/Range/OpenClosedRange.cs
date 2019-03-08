using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class OpenClosedRange : AbstractRange
    {
        internal OpenClosedRange(int start, int end) : base(start + 1, end)
        {

        }
    }
}
