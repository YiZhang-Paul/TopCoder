using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANewHope {
    public class ANewHope {

        private int[] ToNextWeek(int[] week, int daysToDry) {

            return week.Skip(week.Length - daysToDry)
                       .Concat(week.Take(week.Length - daysToDry))
                       .ToArray();
        }

        private bool IsValid(int[] current, int[] target, int daysToDry) {

            for(int i = 0; i < current.Length; i++) {

                int days = Array.IndexOf(target, current[i]) + current.Length - i;

                if(days < daysToDry) {

                    return false;
                }
            }

            return true;
        }

        public int count(int[] firstWeek, int[] lastWeek, int daysToDry) {

            int weeks = 1;
            int[] current = firstWeek;

            while(!IsValid(current, lastWeek, daysToDry)) {

                current = ToNextWeek(current, daysToDry);
                weeks++;
            }

            return weeks == 1 ? weeks : weeks + 1;
        }
    }
}