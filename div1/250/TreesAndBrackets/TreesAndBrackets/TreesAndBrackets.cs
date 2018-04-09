using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndBrackets {
    public class TreesAndBrackets {

        private HashSet<string> Solved { get; set; }

        private string Slice(string text, int start, int end) {

            return text.Substring(start, end - start + 1);
        }

        private string GetFirstSibling(string tree) {

            for(int i = 1, counter = 0; i < tree.Length; i++) {

                counter += tree[i] == '(' ? 1 : -1;

                if(counter == 0) {

                    return Slice(tree, 1, i);
                }
            }

            return string.Empty;
        }

        private bool IsContained(string t1, string t2) {

            if(t1 == string.Empty || t2 == string.Empty) {

                return t2 == string.Empty;
            }

            string pair = t1 + "," + t2;

            if(Solved.Contains(pair)) {

                return true;
            }

            string firstSibling1 = GetFirstSibling(t1);
            string firstSibling2 = GetFirstSibling(t2);
            string otherSibling1 = Slice(t1, firstSibling1.Length + 1, t1.Length - 2);
            string otherSibling2 = Slice(t2, firstSibling2.Length + 1, t2.Length - 2);

            bool bothContain = IsContained(firstSibling1, firstSibling2) &&
                               IsContained(otherSibling1, otherSibling2);
            bool otherContain = IsContained(otherSibling1, t2);
            bool result = bothContain || otherContain;

            if(result) {

                Solved.Add(pair);
            }

            return result;
        }

        public string check(string t1, string t2) {

            Solved = new HashSet<string>();

            return IsContained(t1, t2) ? "Possible" : "Impossible";
        }
    }
}