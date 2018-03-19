using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    public class MagicMoleculeEasy {

        public int[] Powers { get; private set; }
        public int[][] Edges { get; private set; }

        private void Initialize(int[] powers, string[] relations) {

            Powers = powers;
            Edges = GetEdges(relations);
        }

        private string GetKey(int atom1, int atom2) {

            int[] atoms = { atom1, atom2 };

            return string.Join(",", atoms.OrderBy(value => value));
        }

        private int[][] GetEdges(string[] relations) {

            var edges = new List<int[]>();
            var keys = new HashSet<string>();

            for(int i = 0; i < relations.Length; i++) {

                for(int j = 0; j < relations[i].Length; j++) {

                    if(relations[i][j] == 'Y' && !keys.Contains(GetKey(i, j))) {

                        edges.Add(new int[] { i, j });
                    }
                }
            }

            return edges.ToArray();
        }

        private int[] GetUnusedPower(HashSet<int> subset) {

            return Enumerable.Range(0, Powers.Length)
                             .Where(atom => !subset.Contains(atom))
                             .Select(atom => Powers[atom])
                             .ToArray();
        }

        private int SumLargest(int[] values, int total) {

            return values.OrderByDescending(value => value)
                         .Take(total)
                         .Sum();
        }

        private int GetPower(HashSet<int> subset, int size) {

            int[] unusedPower = GetUnusedPower(subset);
            int remaining = size - subset.Count;

            return subset.Sum(atom => Powers[atom]) + SumLargest(unusedPower, remaining);
        }

        private void FindMaxPower(int counter, int size, HashSet<int> subset, ref int max) {

            if(counter == Edges.Length) {

                max = Math.Max(max, GetPower(subset, size));

                return;
            }

            if(Edges[counter].Any(atom => subset.Contains(atom))) {

                FindMaxPower(counter + 1, size, subset, ref max);

                return;
            }

            if(subset.Count < size) {

                foreach(int atom in Edges[counter]) {

                    var newSubset = new HashSet<int>(subset);
                    newSubset.Add(atom);
                    FindMaxPower(counter + 1, size, newSubset, ref max);
                }
            }
        }

        public int maxMagicPower(int[] powers, string[] relations, int size) {

            int max = -1;

            Initialize(powers, relations);
            FindMaxPower(0, size, new HashSet<int>(), ref max);

            return max;
        }
    }
}