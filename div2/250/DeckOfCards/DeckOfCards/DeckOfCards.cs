using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards {
    public class DeckOfCards {

        private Dictionary<int, HashSet<char>> GetCards(int[] value, string suit) {

            var cards = new Dictionary<int, HashSet<char>>();

            for(int i = 0; i < value.Length; i++) {

                if(!cards.ContainsKey(value[i])) {

                    cards[value[i]] = new HashSet<char>();
                }

                cards[value[i]].Add(suit[i]);
            }

            return cards;
        }

        private int CountCards(Dictionary<int, HashSet<char>> cards) {

            return cards.Sum(pair => pair.Value.Count);
        }

        public string IsValid(int n, int[] value, string suit) {

            var cards = GetCards(value, suit);

            if(CountCards(cards) != n) {

                return "Not perfect";
            }

            for(int i = 0; i < value.Length - 1; i++) {

                for(int j = i + 1; j < value.Length; j++) {

                    if(!cards[value[i]].Contains(suit[j])) {

                        return "Not perfect";
                    }

                    if(!cards[value[j]].Contains(suit[i])) {

                        return "Not perfect";
                    }
                }
            }

            return "Perfect";
        }
    }
}