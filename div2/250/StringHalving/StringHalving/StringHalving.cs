using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHalving {
    public class StringHalving {

        private char GetMinCharacter(string text) {

            return text.OrderBy(character => character).First();
        }

        public string lexsmallest(string text) {

            int[] occurrence = new int[26];

            for(int i = 0; i < text.Length; i++) {
                //when duplicate letter is found
                if(++occurrence[text[i] - 'a'] == 2) {
                    //only letters before can remain in front after removing duplicates
                    string prefix = text.Substring(0, i);

                    return GetMinCharacter(prefix).ToString();
                }
            }

            return null;
        }
    }
}