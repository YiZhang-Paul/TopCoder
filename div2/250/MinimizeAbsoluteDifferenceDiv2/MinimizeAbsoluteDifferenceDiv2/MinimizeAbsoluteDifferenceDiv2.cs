using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimizeAbsoluteDifferenceDiv2 {
    public class MinimizeAbsoluteDifferenceDiv2 {

        private List<int> Include(List<int> list, int element) {

            return list.Concat(new int[] { element }).ToList();
        }

        //exclude value at given index
        private int[] Exclude(int[] values, int index) {

            return values.Take(index).Concat(values.Skip(index + 1)).ToArray();
        }

        //evaluate expression abs(a / b - c)
        private double Evaluate(int[] indexes, int[] values) {

            return Math.Abs((double)values[indexes[0]] / values[indexes[1]] - values[indexes[2]]);
        }

        private bool IsSmaller(int[] toTest, int[] min, int[] values) {

            return Evaluate(toTest, values) < Evaluate(min, values);
        }

        private void FindMinDifference(int[] indexes, int[] values, List<int> current, ref int[] min) {

            if(current.Count == values.Length) {

                if(min == null) {

                    min = current.ToArray();
                }
                else {

                    min = IsSmaller(current.ToArray(), min, values) ? current.ToArray() : min;
                }

                return;
            }

            for(int i = 0; i < indexes.Length; i++) {

                FindMinDifference(Exclude(indexes, i), values, Include(current, indexes[i]), ref min);
            }
        }

        public int[] findTriple(int x0, int x1, int x2) {

            int[] min = null;

            FindMinDifference(

                Enumerable.Range(0, 3).ToArray(),
                new int[] { x0, x1, x2 },
                new List<int>(),
                ref min
            );

            return min;
        }
    }
}