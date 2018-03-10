using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ExpectedMinimumPowerDiv2 {
    public class ExpectedMinimumPowerDiv2 {

        private BigInteger Factorial(BigInteger number) {

            return number <= 1 ? 1 : number * Factorial(number - 1);
        }

        //count total combinations of subset with given size
        private long CountSubsets(int total, int size) {

            if(total == size) {

                return 1;
            }

            return (long)(Factorial(total) / Factorial(size) / Factorial(total - size));
        }

        public double findExp(int total, int size) {

            BigInteger powerSum = 0;
            long allSubsets = 0;

            foreach(int number in Enumerable.Range(1, total - size + 1)) {
                //total number of subsets with current number as minimum value
                var subsets = CountSubsets(total - number, size - 1);
                powerSum += (BigInteger)(Math.Pow(2, number) * subsets);
                allSubsets += subsets;
            }

            return (double)powerSum / allSubsets;
        }
    }
}