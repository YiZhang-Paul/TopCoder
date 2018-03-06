using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicMoleculeEasy;

namespace Test {
    [TestClass]
    public class Test {

        MagicMoleculeEasy.MagicMoleculeEasy magicMolecule;

        [TestInitialize]
        public void Setup() {

            magicMolecule = new MagicMoleculeEasy.MagicMoleculeEasy();
        }

        [TestMethod]
        public void Sample1() {

            int[] power = new int[] { 1, 2 };
            string[] bond = new string[] { "NY", "YN" };
            int size = 1;

            Assert.AreEqual(2, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample2() {

            int[] power = new int[] { 100, 1, 100 };
            string[] bond = new string[] { "NYN", "YNY", "NYN" };
            int size = 1;

            Assert.AreEqual(1, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample3() {

            int[] power = new int[] { 100, 1, 100 };
            string[] bond = new string[] { "NYN", "YNY", "NYN" };
            int size = 2;

            Assert.AreEqual(200, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample4() {

            int[] power = new int[] { 4, 7, 5, 8 };
            string[] bond = new string[] { "NYNY", "YNYN", "NYNY", "YNYN" };
            int size = 2;

            Assert.AreEqual(15, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample5() {

            int[] power = new int[] { 46474, 60848, 98282, 58073, 42670, 50373 };
            string[] bond = new string[] { "NYNNNY", "YNNYNY", "NNNYYY", "NYYNNN", "NNYNNN", "YYYNNN" };
            int size = 3;

            Assert.AreEqual(209503, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample6() {

            int[] power = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            string[] bond = new string[] {

                "NNYYYNYYNYNNY", "NNYNYYYYYYYNY", "YYNYYNYYYYYYY", "YNYNYYNYYYYYY",
                "YYYYNNYYYYYNY", "NYNYNNYYYYYNN", "YYYNYYNYYYYYY", "YYYYYYYNYNYYY",
                "NYYYYYYYNYYYY", "YYYYYYYNYNNNN", "NYYYYYYYYNNYN", "NNYYNNYYYNYNN", "YYYYYNYYYNNNN"
            };
            int size = 9;

            Assert.AreEqual(-1, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample7() {

            int[] power = new int[] { 1, 1 };
            string[] bond = new string[] { "NN", "NN" };
            int size = 1;

            Assert.AreEqual(1, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample8() {

            int[] power = new int[] { 1, 1, 2, 5, 2, 4, 2 };
            string[] bond = new string[] { "NNNNNNN", "NNYNNNN", "NYNNNYN", "NNNNNNY", "NNNNNNN", "NNYNNNN", "NNNYNNN" };
            int size = 3;

            Assert.AreEqual(11, magicMolecule.maxMagicPower(power, bond, size));
        }
    }
}