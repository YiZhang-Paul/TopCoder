using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoManyRectangles {

    public class CustomRectangle {

        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }

        public CustomRectangle(int x1, int y1, int x2, int y2) {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public static bool IsOverlap(CustomRectangle first, CustomRectangle second) {
            //check if either rectangle's left edge is greater or equal to other rectangle's right edge
            if(first.X1 >= second.X2 || second.X1 >= first.X2) {

                return false;
            }
            //check if either rectangle's bottom edge is greater or equal to other rectangle's top edge
            if(first.Y1 >= second.Y2 || second.Y1 >= first.Y2) {

                return false;
            }

            return true;
        }
    }

    public class SoManyRectangles {

        public int maxOverlap(int[] x1, int[] y1, int[] x2, int[] y2) {

            int max = 0;

            for(int i = 0; i < x1.Length; i++) {

                int overlap = 0;
                var current = new CustomRectangle(x1[i], y1[i], x2[i], y2[i]);

                for(int j = 0; j < x1.Length; j++) {

                    var other = new CustomRectangle(x1[j], y1[j], x2[j], y2[j]);

                    if(CustomRectangle.IsOverlap(current, other)) {

                        overlap++;
                    }
                }

                max = Math.Max(max, overlap);
            }

            return max;
        }
    }
}