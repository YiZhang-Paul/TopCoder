using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        private void AddBond(int index1, int index2, HashSet<string> bonds) {

            string key1 = index1 + "," + index2;
            string key2 = index2 + "," + index1;

            if(!bonds.Contains(key1) && !bonds.Contains(key2)) {

                bonds.Add(key1);
            }
        }

        private void RemoveBond(int index1, int index2, HashSet<string> bonds) {

            string key1 = index1 + "," + index2;
            string key2 = index2 + "," + index1;

            if(bonds.Contains(key1)) {

                bonds.Remove(key1);
            }

            if(bonds.Contains(key2)) {

                bonds.Remove(key2);
            }
        }

        private HashSet<string> GetBonds(string[] magicBond) {

            var bonds = new HashSet<string>();

            for(int i = 0; i < magicBond.Length; i++ ) {

                for(int j = 0; j < magicBond[i].Length; j++) {

                    if(magicBond[i][j] == 'Y') {

                        AddBond(i, j, bonds);
                    }
                }
            }

            return bonds;
        }

        private List<int[]> GetCombination(int[] indexes, int total, int[] current, List<int[]> collection) {

            current = current ?? new int[total];
            collection = collection ?? new List<int[]>();

            if(total == 0) {

                collection.Add(current.ToArray());

                return null;
            }

            for(int i = 0; i < indexes.Length; i++) {

                current[current.Length - total] = indexes[i];
                GetCombination(indexes.Skip(i + 1).ToArray(), total - 1, current, collection);
            }

            return collection;
        }

        private int GetPower(int[] selection, int[] magicPower) {

            return selection.Aggregate(0, (total, index) => total + magicPower[index]);
        }

        private bool IsValidSelection(int[] selection, string[] magicBond) {

            var bonds = GetBonds(magicBond);

            foreach(var index in selection) {

                for(int i = 0; i < magicBond[index].Length; i++) {

                    if(magicBond[index][i] == 'Y') {

                        RemoveBond(index, i, bonds);
                    }
                }
            }

            return bonds.Count == 0;
        }

        public int maxMagicPower(int[] magicPower, string[] magicBond, int k) {

            var combinations = GetCombination(Enumerable.Range(0, magicPower.Length).ToArray(), k, null, null);
            int maxPower = -1;

            foreach(var combination in combinations) {

                if(IsValidSelection(combination, magicBond)) {

                    maxPower = Math.Max(maxPower, GetPower(combination, magicPower));
                }
            }

            return maxPower;
        }
    }
}