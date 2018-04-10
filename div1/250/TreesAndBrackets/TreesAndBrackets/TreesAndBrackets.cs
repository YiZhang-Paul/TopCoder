using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndBrackets {
    public class TreesAndBrackets {

        private Dictionary<string, bool> Solved { get; set; }

        //retrieve all siblings on current level
        private string GetSiblings(string node) {

            return node.Substring(1, node.Length - 2);
        }

        //retrieve leftmost sibling on current level
        private string GetFirstSibling(string siblings) {

            for(int i = 0, counter = 0; i < siblings.Length; i++) {

                counter += siblings[i] == '(' ? 1 : -1;

                if(counter == 0) {

                    return siblings.Substring(0, i + 1);
                }
            }

            return siblings;
        }

        private string[] GroupSiblings(string siblings) {

            string first = GetFirstSibling(siblings);
            string other = siblings.Substring(first.Length);

            return new string[] { first, other };
        }

        //check if node can be reduced to given form
        private bool CanReduce(string current, string target) {

            if(current == string.Empty || target == string.Empty) {

                return target == string.Empty;
            }

            string toSolve = current + "," + target;

            if(Solved.ContainsKey(toSolve)) {

                return Solved[toSolve];
            }
            //pick out first sibling
            string[] group1 = GroupSiblings(current);
            string[] group2 = GroupSiblings(target);

            Solved[toSolve] = (CanReduce(GetSiblings(group1[0]), GetSiblings(group2[0])) &&
                               CanReduce(group1[1], group2[1])) ||
                               CanReduce(group1[1], target);

            return Solved[toSolve];
        }

        public string check(string t1, string t2) {

            Solved = new Dictionary<string, bool>();

            return CanReduce(t1, t2) ? "Possible" : "Impossible";
        }
    }
}