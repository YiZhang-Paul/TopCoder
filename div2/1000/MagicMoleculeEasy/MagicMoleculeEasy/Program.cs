using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoleculeEasy {
    class Program {
        static void Main(string[] args) {

            var molecule = new MagicMoleculeEasy();

            Console.WriteLine(molecule.maxMagicPower(

                new int[] { 1, 2 },
                new string[] { "NY", "YN" },
                1
            ));
        }
    }
}