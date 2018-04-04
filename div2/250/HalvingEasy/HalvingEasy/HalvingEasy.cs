using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalvingEasy {
    public class HalvingEasy {

        private bool CanDivide(int value, int target) {

            if(value <= target) {

                return value == target;
            }

            while(value > target) {

                value /= 2;

                if(value < target) {

                    return false;
                }
            }

            return true;
        }

        public int count(int[] s, int t) {

            return s.Count(value => CanDivide(value, t));
        }
    }
}