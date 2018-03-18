using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingLex {
    public class RingLex {

        //generate new text base on given offset and step
        private string CreateText(string old, int offset, int step) {

            var text = new StringBuilder();

            for(int i = 0; i < old.Length; i++) {

                text.Append(old[(offset + i * step) % old.Length]);
            }

            return text.ToString();
        }

        private bool IsPrime(int number) {

            for(int i = 2; i < number; i++) {

                if(number % i == 0) {

                    return false;
                }
            }

            return true;
        }

        //choose lexicographically smaller string
        private string PickSmaller(string text1, string text2) {

            return text1.CompareTo(text2) < 0 ? text1 : text2;
        }

        public string getmin(string old) {

            string minimum = null;
            //offset
            for(int i = 0; i < old.Length; i++) {
                //step
                for(int j = 2; j < old.Length; j++) {

                    if(IsPrime(j)) {
                        //find lexicographically smallest string
                        string text = CreateText(old, i, j);
                        minimum = minimum == null ? text : PickSmaller(minimum, text);
                    }
                }
            }

            return minimum;
        }
    }
}