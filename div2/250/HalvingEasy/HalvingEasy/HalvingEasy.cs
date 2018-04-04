using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalvingEasy {
    public class HalvingEasy {

        //check if given value can be halved to target value
        private bool CanDivide(int value, int target) {

            while(value >= target) {

                if(value == target) {

                    return true;
                }

                value /= 2;
            }

            return false;
        }

        public int count(int[] s, int t) {

            return s.Count(value => CanDivide(value, t));
        }
    }
}