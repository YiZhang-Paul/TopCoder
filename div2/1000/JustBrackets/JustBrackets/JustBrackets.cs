using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace JustBrackets {
    public class JustBrackets {

        //retrieve all siblings on same nested level
        private List<string> GetSiblings(string text) {

            var siblings = new List<string>();

            for(int i = 0, counter = 0, start = 0; i < text.Length; i++) {
                //"(" -> increment counter; ")" -> decrement counter
                counter += text[i] == '(' ? 1 : -1;
                //when a matching bracket is found
                if(counter == 0) {

                    siblings.Add(text.Substring(start, i + 1 - start));
                    start = i + 1;
                }
            }

            return siblings;
        }

        private bool IsNested(string text) {

            return text.Length > 2 && GetSiblings(text).Count == 1;
        }

        private List<string> GetTail(List<string> list, string separator) {

            int head = list.LastIndexOf(separator) + 1;
            //when separator is not found
            if(head == 0) {

                return list;
            }

            return list.Skip(head).ToList();
        }

        //remove all larger siblings up to the last occurrence of current smallest sibling
        private List<string> RemoveLargerSiblings(List<string> siblings) {

            string currentMin = siblings.Min();
            var removed = siblings.Where(sibling => sibling == currentMin).ToList();
            //when trailing portion exists
            if(currentMin != siblings.Last()) {

                var tail = GetTail(siblings, currentMin);
                removed.AddRange(RemoveLargerSiblings(tail));
            }

            return removed;
        }

        private string Nest(string text) {

            return "(" + text + ")";
        }

        private string UnNest(string text) {

            return text.Substring(1, text.Length - 2);
        }

        public string getSmallest(string text) {

            bool nested = IsNested(text);
            var siblings = GetSiblings(nested ? UnNest(text) : text);

            for(int i = 0; i < siblings.Count; i++) {

                if(IsNested(siblings[i])) {

                    siblings[i] = getSmallest(siblings[i]);
                }
            }

            siblings = RemoveLargerSiblings(siblings);

            return nested ? Nest(string.Join("", siblings)) : siblings.First();
        }
    }
}