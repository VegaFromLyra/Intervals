using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a few intervals like [1, 5], [3, 6] and [8, 9], find the continuous interval range
// In this case the above can be written as [1,6] and [8, 9] so the number of values in range are 5 + 1 = 6

namespace Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Interval interval = new Interval();

                interval.AddInterval(4, 9);
                interval.AddInterval(11, 15);
                interval.AddInterval(3, 6);
                interval.AddInterval(12, 16);
                interval.AddInterval(1, 5);


                int result = interval.GetContinuousInterval();

                Console.WriteLine("Result is {0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }

    class Interval
    {
        List<int[]> intervals = new List<int[]>();

        public void AddInterval(int start, int end)
        {
            bool intervalMerged = false;
            foreach (int[] interval in intervals)
            {
                if (CanIntervalsBeMerged(start, end, interval[0], interval[1]))
                {
                    interval[0] = start < interval[0] ? start : interval[0];
                    interval[1] = end > interval[1] ? end : interval[1];
                    intervalMerged = true;
                    break;
                }
            }

            if (!intervalMerged)
            {
                int[] range = new int[2] { start, end };
                intervals.Add(range);
            }
        }

        public int GetContinuousInterval()
        {
            int continuousInterval = 0;

            foreach (int[] interval in intervals)
            {
                continuousInterval += (interval[1] - interval[0]);
            }

            return continuousInterval;
        }

        bool CanIntervalsBeMerged(int start1, int end1, int start2, int end2)
        {
            if ((start2 <= end1 && end1 <= end2) ||
                (start1 <= end2 && end2 <= end1) ||
                (start2 <= start1 && end1 <= end2) ||
                (start1 <= start2 && end2 <= end1))
            {
                return true;
            }

            return false;
        }
    }
}
