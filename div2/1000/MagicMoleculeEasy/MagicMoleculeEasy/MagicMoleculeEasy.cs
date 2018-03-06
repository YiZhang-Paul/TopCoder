using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        //get representation of bond between atoms
        private string GetKey(int atom1, int atom2) {

            return atom1 + "," + atom2;
        }

        //record unique bond between two atoms
        private void AddBond(int atom1, int atom2, HashSet<string> bonds) {

            if(!bonds.Contains(GetKey(atom2, atom1))) {

                bonds.Add(GetKey(atom1, atom2));
            }
        }

        private void RemoveBond(int atom1, int atom2, HashSet<string> bonds, bool removeOther = true) {

            string key = GetKey(atom1, atom2);

            if(bonds.Contains(key)) {

                bonds.Remove(key);
            }

            if(removeOther) {
                //in case the bond is represented in another form
                RemoveBond(atom2, atom1, bonds, false);
            }
        }

        //record all unique bonds between all atoms
        private HashSet<string> GetBonds(string[] relations) {

            var bonds = new HashSet<string>();

            for(int i = 0; i < relations.Length; i++) {

                for(int j = 0; j < relations[i].Length; j++) {

                    if(relations[i][j] == 'Y') {

                        AddBond(i, j, bonds);
                    }
                }
            }

            return bonds;
        }

        private List<int[]> GetSubsets(int[] atoms, int total, int[] current, List<int[]> subsets) {

            current = current ?? new int[total];
            subsets = subsets ?? new List<int[]>();

            if(total == 0) {

                subsets.Add(current.ToArray());

                return null;
            }

            for(int i = 0; i < atoms.Length; i++) {

                current[current.Length - total] = atoms[i];
                int[] otherAtoms = atoms.Skip(i + 1).ToArray();
                GetSubsets(otherAtoms, total - 1, current, subsets);
            }

            return subsets;
        }

        private int CalculatePower(int[] subset, int[] powers) {

            return subset.Aggregate(0, (power, atom) => power + powers[atom]);
        }

        //check if all bonds are covered by atoms in a given subset
        private bool IsValid(int[] subset, string[] relations) {

            var bonds = GetBonds(relations);

            foreach(var atom in subset) {

                for(int i = 0; i < relations[atom].Length; i++) {

                    if(relations[atom][i] == 'Y') {

                        RemoveBond(atom, i, bonds);
                    }
                }
            }

            return bonds.Count == 0;
        }

        public int maxMagicPower(int[] powers, string[] relations, int size) {

            int maxPower = -1;
            int[] atoms = Enumerable.Range(0, powers.Length).ToArray();

            foreach(var subset in GetSubsets(atoms, size, null, null)) {

                if(IsValid(subset, relations)) {

                    maxPower = Math.Max(maxPower, CalculatePower(subset, powers));
                }
            }

            return maxPower;
        }
    }
}