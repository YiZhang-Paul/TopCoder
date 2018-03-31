using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards {
    public class DeckOfCards {

        private Dictionary<int, HashSet<char>> Deck { get; set; }
        //total number of cards in deck
        private int Total {

            get {

                if(Deck == null) {

                    return 0;
                }

                return Deck.Sum(pair => pair.Value.Count);
            }
        }

        //retrieve a deck of unique cards
        private void GetDeck(int[] value, string suit) {

            Deck = new Dictionary<int, HashSet<char>>();

            for(int i = 0; i < value.Length; i++) {

                if(!Deck.ContainsKey(value[i])) {

                    Deck[value[i]] = new HashSet<char>();
                }

                Deck[value[i]].Add(suit[i]);
            }
        }

        //for given cards (v1, s1), (v2, s2), check if (v1, s2) and (v2, s1) also exist
        private bool HasMutual(int[] value, string suit, int index1, int index2) {

            return Deck[value[index1]].Contains(suit[index2]) &&
                   Deck[value[index2]].Contains(suit[index1]);
        }

        public string IsValid(int n, int[] value, string suit) {

            GetDeck(value, suit);
            //check duplicate cards
            if(Total != n) {

                return "Not perfect";
            }

            for(int i = 0; i < value.Length - 1; i++) {

                for(int j = i + 1; j < value.Length; j++) {

                    if(!HasMutual(value, suit, i, j)) {

                        return "Not perfect";
                    }
                }
            }

            return "Perfect";
        }
    }
}