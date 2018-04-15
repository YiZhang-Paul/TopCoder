using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimizeAbsoluteDifferenceDiv2 {
    public class MinimizeAbsoluteDifferenceDiv2 {

        private double CalculateValue(int[] indexes, int[] numbers) {

            return Math.Abs((double)numbers[indexes[0]] / numbers[indexes[1]] - numbers[indexes[2]]);
        }

        private void FindMin(int[] indexes, int[] numbers, List<int> current, ref int[] min) {

            if(current.Count == numbers.Length) {

                if(min == null) {

                    min = current.ToArray();
                }
                else {

                    min = CalculateValue(current.ToArray(), numbers) < CalculateValue(min, numbers) ? current.ToArray() : min;
                }

                return;
            }

            for(int i = 0; i < indexes.Length; i++) {

                int[] others = indexes.Take(i).Concat(indexes.Skip(i + 1)).ToArray();
                var newCurrent = current.ToList();
                newCurrent.Add(indexes[i]);
                FindMin(others, numbers, newCurrent, ref min);
            }
        }

        public int[] findTriple(int x0, int x1, int x2) {

            int[] indexes = Enumerable.Range(0, 3).ToArray();
            int[] numbers = { x0, x1, x2 };
            int[] min = null;

            FindMin(indexes, numbers, new List<int>(), ref min);

            return min;
        }
    }
}