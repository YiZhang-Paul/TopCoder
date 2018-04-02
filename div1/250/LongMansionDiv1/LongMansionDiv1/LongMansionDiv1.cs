using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongMansionDiv1 {
    public class LongMansionDiv1 {

        private long GetHorizontalTime(int start, int end, int speed) {

            return (long)(Math.Abs(start - end) + 1) * speed;
        }

        private long GetVerticalTime(int[] t, int row1, int row2) {

            long time = 0;
            int start = Math.Min(row1, row2);
            int end = Math.Max(row1, row2);

            for(int i = start; i <= end; i++) {

                time += t[i];
            }

            return time;
        }

        private long GetTime(int[] t, int sX, int sY, int eX, int eY, int row) {

            long vertical = GetVerticalTime(t, sX, row) + GetVerticalTime(t, row, eX);
            long horizontal = GetHorizontalTime(sY, eY, t[row]);
            //remove duplicate time calculation
            return vertical + horizontal - 2 * t[row];
        }

        public long minimalTime(int[] t, int sX, int sY, int eX, int eY) {

            long min = 0;

            for(int i = 0; i < t.Length; i++) {

                long time = GetTime(t, sX, sY, eX, eY, i);
                min = min == 0 ? time : Math.Min(min, time);
            }

            return min;
        }
    }
}