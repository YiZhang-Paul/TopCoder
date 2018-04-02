using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongMansionDiv1 {
    public class LongMansionDiv1 {

        private long GetHorizontalTime(int[] t, int column1, int column2, int row) {

            return (long)(Math.Abs(column2 - column1) + 1) * t[row];
        }

        private long GetVerticalTime(int[] t, int row1, int row2) {

            int start = Math.Min(row1, row2);
            int end = Math.Max(row1, row2);
            long time = 0;

            for(int i = start + 1; i <= end; i++) {

                time += t[i];
            }

            return time;
        }

        public long minimalTime(int[] t, int sX, int sY, int eX, int eY) {

            long minTime = 0;
            int maxUp = 0 - sX;
            int maxDown = t.Length - 1 - sX;

            for(int i = maxUp; i <= maxDown; i++) {

                long time = GetVerticalTime(t, sX, sX + i) + GetHorizontalTime(t, sY, eY, sX + i) + GetVerticalTime(t, sX + i, eX);
                minTime = minTime == 0 ? time : Math.Min(minTime, time);
            }

            return minTime;
        }
    }
}