using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalIntersections {
    public class IntervalIntersections {

        private bool IsIntersect(int x1, int y1, int x2, int y2) {

            return (x2 >= x1 && x2 <= y1) || (x1 >= x2 && x1 <= y2);
        }

        public int minLength(int x1, int y1, int x2, int y2) {

            if(IsIntersect(x1, y1, x2, y2)) {

                return 0;
            }
            //return distance between two intervals
            return x2 > y1 ? x2 - y1 : x1 - y2;
        }
    }
}