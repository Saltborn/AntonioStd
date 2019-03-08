using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public static class Ranges
    {
       public static IRange ClosedClosed(int start, int end)
        {
            if (start>end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");               
            }
            return new ClosedClosedRange(start, end);
        }

        public static IRange OpenOpen(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new OpenOpenRange(start, end);
        }

        public static IRange ClosedOpen(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new ClosedOpenRange(start, end);
        }

        public static IRange OpenClosed(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new OpenClosedRange(start, end);
        }
    }
}
