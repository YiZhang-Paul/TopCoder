using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        private int[] GetAtoms(int total) {

            return Enumerable.Range(0, total).ToArray();
        }

        private bool IsValid(int[] subset, string[] relations) {

            var atoms = new HashSet<int>(subset);

            for(int i = 0; i < relations.Length; i++) {

                if(atoms.Contains(i)) {

                    continue;
                }

                for(int j = 0; j < relations[i].Length; j++) {

                    if(relations[i][j] == 'Y' && !atoms.Contains(i) && !atoms.Contains(j)) {

                        return false;
                    }
                }
            }

            return true;
        }

        private int GetPower(int[] subset, int[] powers) {

            return subset.Sum(atom => powers[atom]);
        }

        private void TestSubsets(

            int[] atoms,
            int counter,
            int[] subset,
            string[] relations,
            int[] powers,
            ref int max
        ) {

            if(counter == subset.Length || atoms.Length == 0) {

                if(counter == subset.Length) {

                    int power = GetPower(subset, powers);
                    max = power > max && IsValid(subset, relations) ? power : max;
                }

                return;
            }

            for(int i = 0; i < atoms.Length; i++) {

                var others = atoms.Skip(i + 1).ToArray();
                subset[counter] = atoms[i];
                TestSubsets(others, counter + 1, subset, relations, powers, ref max);
            }
        }

        public int maxMagicPower(int[] powers, string[] relations, int size) {

            int maxPower = -1;

            TestSubsets(

                GetAtoms(powers.Length),
                0,
                new int[size],
                relations,
                powers,
                ref maxPower
            );

            return maxPower;
        }
    }
}