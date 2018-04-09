using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndBrackets {
    public class TreesAndBrackets {

        private Dictionary<string, bool> Solved { get; set; }

        private string GetFirstSibling(string tree) {

            for(int i = 0, counter = 0; i < tree.Length; i++) {

                counter += tree[i] == '(' ? 1 : -1;

                if(counter == 0) {

                    return tree.Substring(0, i + 1);
                }
            }

            return tree;
        }

        private string UnNest(string sibling) {

            return sibling.Substring(1, sibling.Length - 2);
        }

        private bool IsContained(string t1, string t2) {

            if(t1 == string.Empty || t2 == string.Empty) {

                return t2 == string.Empty;
            }

            string pair = t1 + "," + t2;

            if(Solved.ContainsKey(pair)) {

                return Solved[pair];
            }

            string firstSibling1 = GetFirstSibling(t1);
            string firstSibling2 = GetFirstSibling(t2);
            string otherSibling1 = t1.Substring(firstSibling1.Length);
            string otherSibling2 = t2.Substring(firstSibling2.Length);

            bool bothContain = IsContained(UnNest(firstSibling1), UnNest(firstSibling2)) &&
                               IsContained(otherSibling1, otherSibling2);
            bool otherContain = IsContained(otherSibling1, t2);

            Solved[pair] = bothContain || otherContain;

            return Solved[pair];
        }

        public string check(string t1, string t2) {

            Solved = new Dictionary<string, bool>();

            return IsContained(t1, t2) ? "Possible" : "Impossible";
        }
    }
}