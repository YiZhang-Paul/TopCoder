using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace JustBrackets {
    public class JustBrackets {

        private List<string> GetSiblings(string text) {

            var siblings = new List<string>();

            for(int i = 0, start = 0, counter = 0; i < text.Length; i++) {

                counter += text[i] == '(' ? 1 : -1;

                if(counter == 0) {

                    siblings.Add(text.Substring(start, i - start + 1));
                    start = i + 1;
                }
            }

            return siblings;
        }

        private bool IsNested(string text) {

            return text.Length > 2 && GetSiblings(text).Count == 1;
        }

        private List<string> RemoveLarger(List<string> siblings) {

            string smallest = siblings.Min();
            int lastIndex = siblings.LastIndexOf(smallest);
            var removed = siblings.Where(sibling => sibling == smallest).ToList();

            if(lastIndex != siblings.Count - 1) {

                removed.AddRange(RemoveLarger(siblings.Skip(lastIndex + 1).ToList()));
            }

            return removed;
        }

        public string getSmallest(string text) {

            if(text.Length <= 2) {

                return text;
            }

            bool isNested = IsNested(text);
            var siblings = GetSiblings(isNested ? text.Substring(1, text.Length - 2) : text);

            for(int i = 0; i < siblings.Count; i++) {

                if(IsNested(siblings[i])) {

                    siblings[i] = getSmallest(siblings[i]);
                }
            }

            siblings = RemoveLarger(siblings);

            return isNested ? "(" + string.Join("", siblings) + ")" : siblings[0];
        }
    }
}