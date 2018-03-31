using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeStackingGame {
    public class CubeStackingGame {

        private int[][] Cubes { get; set; }

        private void GetCubes(int[] c1, int[] c2, int[] c3, int[] c4) {

            Cubes = new int[c1.Length][];

            for(int i = 0; i < c1.Length; i++) {

                Cubes[i] = new int[] { c1[i], c2[i], c3[i], c4[i] };
            }
        }

        private void Swap(int[] faces, int index1, int index2) {

            int total = faces[index1] + faces[index2];
            faces[index1] = total - faces[index1];
            faces[index2] = total - faces[index2];
        }

        private void Flip(int[] faces) {

            Swap(faces, 1, 3);
        }

        private void Rotate(int[] faces) {

            for(int i = faces.Length - 1; i > 0; i--) {

                Swap(faces, i, i - 1);
            }
        }

        private bool CanStack(int total) {

            for(int i = 0; i < 4; i++) {

                var used = new HashSet<int>();

                for(int j = 0; j < total; j++) {

                    if(used.Contains(Cubes[j][i])) {

                        return false;
                    }

                    used.Add(Cubes[j][i]);
                }
            }

            return true;
        }

        private void GetMax(int counter, ref int max) {

            max = Math.Max(max, counter);

            if(counter == Cubes.Length) {

                return;
            }

            for(int i = 0; i < 8; i++) {

                if(i == 4) {

                    Flip(Cubes[counter]);
                }

                Rotate(Cubes[counter]);

                if(CanStack(counter + 1)) {

                    GetMax(counter + 1, ref max);
                }
            }
        }

        public int MaximumValue(int n, int[] c1, int[] c2, int[] c3, int[] c4) {

            int max = 1;
            GetCubes(c1, c2, c3, c4);
            GetMax(0, ref max);

            return max;
        }
    }
}