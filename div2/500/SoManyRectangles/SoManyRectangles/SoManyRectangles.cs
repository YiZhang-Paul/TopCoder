using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoManyRectangles {

    public class SoManyRectangles {

        //check if a point is inside given rectangle
        private bool Contains(int x, int y, int x1, int y1, int x2, int y2) {
            //intersection cannot touch the right edge of rectangle
            if(x < x1 || x >= x2) {

                return false;
            }
            //intersection cannot touch the top edge of rectangle
            if(y < y1 || y >= y2) {

                return false;
            }

            return true;
        }

        public int maxOverlap(int[] x1, int[] y1, int[] x2, int[] y2) {

            int[] allX = x1.Concat(x2).ToArray();
            int[] allY = y1.Concat(y2).ToArray();
            int overlaps = 0;
            //test all intersections
            foreach(int x in allX) {

                foreach(int y in allY) {

                    int current = 0;

                    for(int i = 0; i < x1.Length; i++) {
                        //check if current intersection is inside rectangles
                        if(Contains(x, y, x1[i], y1[i], x2[i], y2[i])) {

                            current++;
                        }
                    }

                    overlaps = Math.Max(overlaps, current);
                }
            }

            return overlaps;
        }
    }
}