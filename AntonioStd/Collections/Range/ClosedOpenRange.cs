using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class ClosedOpenRange : AbstractRange
    {
        internal ClosedOpenRange(int start, int end) : base(start, end - 1)
        {

        }
    }
}
