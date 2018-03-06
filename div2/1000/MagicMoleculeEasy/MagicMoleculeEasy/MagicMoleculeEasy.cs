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

        public int maxMagicPower(int[] magicPower, string[] magicBond, int k) {

            var bond = GetBonds(magicBond);

            return 1;
        }
    }
}