using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingClass {
    public class DancingClass {
        //count total combination of picking subsets with given size
        private double TotalCombination(int total, int size) {

            double combination = 1;

            for(int i = 0; i < size; i++) {

                combination *= total - i;
                combination /= size - i;
            }

            return combination;
        }

        private string PrintOdds(double odds) {

            if(odds == 0.5) {

                return "Equal";
            }

            return odds < 0.5 ? "Low" : "High";
        }

        public string checkOdds(int total, int pairs) {

            double satisfied = 0;
            //total number of boys in different cases
            for(int i = 0; i <= total; i++) {
                //total number of distinct pairs
                if(i * (total - i) >= pairs) {

                    satisfied += TotalCombination(total, i);
                }
            }
            //check possibility
            for(int i = 0; i < total; i++) {

                satisfied /= 2;
            }

            return PrintOdds(satisfied);
        }
    }
}