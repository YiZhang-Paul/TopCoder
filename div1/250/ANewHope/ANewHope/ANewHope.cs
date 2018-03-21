using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANewHope {

    /**
     * Reasoning:
     *
     * since days to dry a shirt is always less than N (total days in week),
     * for any given shirt used on day i in current week, it can
     * be used on any day between day i and day N (inclusive) during the next week;
     * that is to say, any shirt can stay in its original position or move
     * anywhere to its right during next week. Thus, shirts that need to
     * stay or move to the right on final week is not the problem here - it is those
     * shirts that need to move to the left. The earliest day a shirt can be dressed again
     * is: (day in current week) - (N - days to dry); if it results in a negative index, it
     * refers to the day in last week (take calendar for example). Therefore, the maximum
     * number of days to move any shirt to left during one week is (N - days to dry).
     * The question then comes down to finding the shirt with maximum number of days
     * to move to left, and minimum number of weeks to do so.
     */

    public class ANewHope {

        private Dictionary<int, int> RecordIndex(int[] array) {

            var indexes = new Dictionary<int, int>();

            for(int i = 0; i < array.Length; i++) {

                indexes[array[i]] = i;
            }

            return indexes;
        }

        public int count(int[] first, int[] last, int daysToDry) {

            var indexes = RecordIndex(first);
            int maxDaysToLeft = 0;
            //find maximum number of days for any shirt that needs to move to the left
            for(int i = 0; i < last.Length; i++) {

                int initialIndex = indexes[last[i]];

                if(i < initialIndex) {

                    maxDaysToLeft = Math.Max(maxDaysToLeft, initialIndex - i);
                }
            }
            //find minimum number of weeks to move the above shirt to its final position
            return (int)Math.Ceiling((double)maxDaysToLeft / (first.Length - daysToDry)) + 1;
        }
    }
}