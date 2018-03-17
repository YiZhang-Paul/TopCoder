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

        public List<int[]> Corners {

            get {

                return new List<int[]>() {

                    new int[] { X1, Y1 },
                    new int[] { X1, Y2 },
                    new int[] { X2, Y2 },
                    new int[] { X2, Y1 }
                };
            }
        }

        public CustomRectangle(int x1, int y1, int x2, int y2) {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        private bool IsSame(CustomRectangle rectangle) {

            return X1 == rectangle.X1 && X2 == rectangle.X2 && Y1 == rectangle.Y1 && Y2 == rectangle.Y2;
        }

        private bool HasPoint(int x, int y, CustomRectangle rectangle) {

            return rectangle.X1 < x && x < rectangle.X2 && rectangle.Y1 < y && y < rectangle.Y2;
        }

        public bool IsOverlap(CustomRectangle rectangle) {

            if(IsSame(rectangle)) {

                return true;
            }

            return Corners.Any(corner => HasPoint(corner[0], corner[1], rectangle)) ||
                   rectangle.Corners.Any(corner => HasPoint(corner[0], corner[1], this));
        }
    }

    public class SoManyRectangles {

        private List<CustomRectangle> GetRectangles(int[] x1, int[] y1, int[] x2, int[] y2) {

            var rectangles = new List<CustomRectangle>();

            for(int i = 0; i < x1.Length; i++) {

                rectangles.Add(new CustomRectangle(x1[i], y1[i], x2[i], y2[i]));
            }

            return rectangles;
        }

        public int maxOverlap(int[] x1, int[] y1, int[] x2, int[] y2) {

            var rectangles = GetRectangles(x1, y1, x2, y2);
            int max = 0;

            foreach(var rectangle in rectangles) {

                int current = 1;

                foreach(var other in rectangles) {

                    if(other != rectangle && rectangle.IsOverlap(other)) {

                        current++;
                    }
                }

                max = Math.Max(max, current);
            }

            return max;
        }
    }
}