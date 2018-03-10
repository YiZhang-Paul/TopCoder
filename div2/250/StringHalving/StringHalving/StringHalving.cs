using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHalving {
    public class StringHalving {

        private string GetUniqueLetters(string text) {

            var uniqueLetters = new HashSet<char>(text.ToArray());

            return string.Join("", uniqueLetters.ToArray());
        }

        private string SortLetters(string text) {
            //sort letters according to alphabetical order
            return string.Join("", text.OrderBy(letter => letter));
        }

        //retrieve the first N letters in a given string
        private string Slice(string text, int index) {

            return string.Join("", text.Take(index));
        }

        private bool HasDuplicate(string text) {
            //check if all letters in the text are unique
            return GetUniqueLetters(text).Count() != text.Length;
        }

        public string lexsmallest(string text) {
            //start with smallest letter possible
            foreach(char letter in SortLetters(GetUniqueLetters(text))) {

                string prefix = Slice(text, text.IndexOf(letter));
                //make sure every other letters before current letter can be removed
                if(!HasDuplicate(prefix)) {

                    return letter.ToString();
                }
            }

            return null;
        }
    }
}