using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        private string GetKey(int atom1, int atom2) {

            return atom1 < atom2 ? atom1 + "," + atom2 : atom2 + "," + atom1;
        }

        private Dictionary<string, int[]> GetBonds(string[] relations) {

            var bonds = new Dictionary<string, int[]>();

            for(int i = 0; i < relations.Length; i++) {

                for(int j = 0; j < relations[i].Length; j++) {

                    if(relations[i][j] == 'Y') {

                        bonds[GetKey(i, j)] = new int[] { i, j };
                    }
                }
            }

            return bonds;
        }

        private int SumLargestPowers(int[] powers, int total) {

            return powers.OrderByDescending(power => power).Take(total).Sum();
        }

        private int[] GetAtoms(int total) {

            return Enumerable.Range(0, total).ToArray();
        }

        private int[] GetUnused(int[] candidate, List<int> used) {

            var toCheck = new HashSet<int>(used);

            return candidate.Where(atom => !toCheck.Contains(atom)).ToArray();
        }

        private List<int> Concat(List<int> subset, int atom) {

            return subset.Concat(new List<int>() { atom }).ToList();
        }

        private string[] GetUnsatisfied(string[] keys, Dictionary<string, int[]> bonds, List<int> subset) {

            var used = new HashSet<int>(subset);

            return keys.Where(key => bonds[key].All(atom => !used.Contains(atom))).ToArray();
        }

        private int[] RemoveIndex(int[] array, int index) {

            return array.Take(index).Concat(array.Skip(index + 1)).ToArray();
        }

        private int FillToMaxPowers(List<int> subset, int toFill, int[] atoms, int[] powers) {

            var unusedPower = GetUnused(atoms, subset).Select(atom => powers[atom]).ToArray();

            if(toFill > unusedPower.Length) {

                return -1;
            }

            return GetPower(subset, powers) + unusedPower.Take(toFill).Sum();
        }

        private int GetPower(List<int> subset, int[] powers) {

            return subset.Select(atom => powers[atom]).Sum();
        }

        private void GetMaxPower(

            string[] keys,
            Dictionary<string, int[]> bonds,
            List<int> subset,
            int size,
            int[] powers,
            int[] atoms,
            ref int max

        ) {

            keys = GetUnsatisfied(keys, bonds, subset);

            if(keys.Length == 0) {

                max = Math.Max(max, FillToMaxPowers(subset, size - subset.Count, atoms, powers));

                return;
            }

            if(subset.Count == size) {

                if(keys.Length == 0) {

                    max = Math.Max(max, GetPower(subset, powers));
                }

                return;
            }

            foreach(string key in keys) {

                var unused = GetUnused(bonds[key], subset);

                if(unused.Length == bonds[key].Length) {

                    foreach(var atom in unused) {

                        GetMaxPower(keys, bonds, Concat(subset, atom), size, powers, atoms, ref max);
                    }
                }
            }
        }

        public int maxMagicPower(int[] powers, string[] relations, int size) {

            var bonds = GetBonds(relations);

            if(bonds.Count == 0) {

                return SumLargestPowers(powers, size);
            }

            int max = -1;

            GetMaxPower(

                bonds.Select(pair => pair.Key).ToArray(),
                bonds,
                new List<int>(),
                size,
                powers,
                GetAtoms(powers.Length),
                ref max
            );

            return max;
        }
    }
}