using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingLex {
    public class RingLex {

        private string GenerateText(string text, int offset, int step) {

            var newText = new StringBuilder();

            for(int i = 0; i < text.Length; i++) {

                newText.Append(text[(offset + i * step) % text.Length]);
            }

            return newText.ToString();
        }

        private bool IsPrime(int number) {

            for(int i = 2; i < number; i++) {

                if(number % i == 0) {

                    return false;
                }
            }

            return true;
        }

        private string GetSmallerText(string text1, string text2) {

            for(int i = 0; i < text1.Length; i++) {

                if(text1[i] != text2[i]) {

                    return text1[i] < text2[i] ? text1 : text2;
                }
            }

            return text1;
        }

        public string getmin(string text) {

            if(new HashSet<char>(text).Count == 1) {

                return text;
            }

            string min = "";

            for(int i = 0; i < text.Length; i++) {

                for(int j = 2; j < text.Length; j++) {

                    if(IsPrime(j)) {

                        string newText = GenerateText(text, i, j);

                        if(newText != text) {

                            min = min == "" ? newText : GetSmallerText(min, newText);
                        }
                    }
                }
            }

            return min;
        }
    }
}