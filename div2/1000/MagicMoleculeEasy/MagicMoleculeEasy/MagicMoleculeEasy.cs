using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        public int[] Powers { get; private set; }
        public int[][] Bonds { get; private set; }

        //retrieve unique key to represent given bi-directional bond
        private string GetKey(int atom1, int atom2) {

            int[] atoms = new int[] { atom1, atom2 };

            return string.Join(",", atoms.OrderBy(atom => atom));
        }

        private int[][] GetUniqueBonds(string[] relationTable) {

            var keys = new HashSet<string>();
            var bonds = new List<int[]>();

            for(int i = 0; i < relationTable.Length; i++) {

                for(int j = 0; j < relationTable[i].Length; j++) {

                    if(relationTable[i][j] == 'Y') {

                        string key = GetKey(i ,j);
                        //avoid duplicate
                        if(!keys.Contains(key)) {

                            keys.Add(key);
                            bonds.Add(new int[] { i, j });
                        }
                    }
                }
            }

            return bonds.ToArray();
        }

        //retrieve powers of all unused atoms
        private int[] GetUnusedPower(HashSet<int> used) {

            var atoms = Enumerable.Range(0, Powers.Length);

            return atoms.Where(atom => !used.Contains(atom))
                        .Select(atom => Powers[atom])
                        .ToArray();
        }

        //sum first few largest values in a list
        private int SumLargest(int[] values, int total) {

            return values.OrderByDescending(value => value).Take(total).Sum();
        }

        private int GetTotalPower(HashSet<int> used, int size) {
            //total power possessed by atoms in current subset
            int power = used.Sum(atom => Powers[atom]);
            int[] unused = GetUnusedPower(used);
            //pick atoms with as large power as possible to fill remaining spots
            return power + SumLargest(unused, size - used.Count);
        }

        private void CalculateMaxPower(int counter, int size, HashSet<int> used, ref int max) {
            //when all bonds are satisfied
            if(counter == Bonds.Length) {

                max = Math.Max(max, GetTotalPower(used, size));

                return;
            }
            //move to next bond when at least one atoms from current bond is used
            if(Bonds[counter].Any(atom => used.Contains(atom))) {

                CalculateMaxPower(counter + 1, size, used, ref max);

                return;
            }
            //must use at least one atom to satisfy current bond
            if(used.Count < size) {

                foreach(int atom in Bonds[counter]) {

                    var currentUsed = new HashSet<int>(used);
                    currentUsed.Add(atom);
                    CalculateMaxPower(counter + 1, size, currentUsed, ref max);
                }
            }
        }

        public int maxMagicPower(int[] powers, string[] relationTable, int size) {

            int power = -1;
            Powers = powers;
            Bonds = GetUniqueBonds(relationTable);
            CalculateMaxPower(0, size, new HashSet<int>(), ref power);

            return power;
        }
    }
}