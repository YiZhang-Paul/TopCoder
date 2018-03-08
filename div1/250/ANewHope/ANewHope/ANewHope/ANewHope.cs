using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANewHope {
    public class ANewHope {

        //wear T-shirst as soons as they are dry
        private void WearWhenDry(ref int[] current, int daysToDry) {

            int shiftPoint = current.Length - daysToDry;
            //shift every T-shirt by total days to dry
            current = current.Skip(shiftPoint)
                             .Concat(current.Take(shiftPoint))
                             .ToArray();
        }

        private int DaysBetween(int start, int end, int daysInWeek) {

            return (daysInWeek - start - 1) + (end + 1);
        }

        //check if T-shirts can dry before corresponding days in target week
        private bool CanDryBefore(int[] current, int[] target, int daysToDry) {

            for(int i = 0; i < current.Length; i++) {

                int targetDay = Array.IndexOf(target, current[i]);

                if(DaysBetween(i, targetDay, current.Length) < daysToDry) {

                    return false;
                }
            }

            return true;
        }

        public int count(int[] firstWeek, int[] lastWeek, int daysToDry) {

            if(CanDryBefore(firstWeek, lastWeek, daysToDry)) {

                return 1;
            }
            //include first and last week on default
            int total = 2;

            while(!CanDryBefore(firstWeek, lastWeek, daysToDry)) {

                WearWhenDry(ref firstWeek, daysToDry);
                total++;
            }

            return total;
        }
    }
}