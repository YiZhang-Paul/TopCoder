﻿using System;
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

        [TestMethod]
        public void Sample9() {

            int[] power = new int[] { 9541, 2041, 3366, 9184, 8169, 657, 989, 5575, 6863, 7596, 7904, 2652, 9861, 7010, 8450, 9936, 4910, 4681, 1980, 8838, 9516, 1833, 1122, 4819, 6993, 1674, 5002, 3735, 721, 8733, 3534, 793, 5938, 2701, 7864, 9401 };
            string[] bond = new string[] { "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN" };
            int size = 14;

            Assert.AreEqual(122003, magicMolecule.maxMagicPower(power, bond, size));
        }

        [TestMethod]
        public void Sample10() {

            int[] power = new int[] { 34, 38, 6, 82, 84, 67, 58, 83, 65, 36, 42, 64, 25, 66, 60, 29, 69, 34, 72, 42, 78, 63, 68, 47, 59, 68, 53, 26, 61, 61, 97, 89, 97, 3, 22, 21, 25, 93, 19, 15, 53, 24, 56, 48 };
            string[] bond = new string[] { "NYNNNNYNNNNNNNNNNNNNYNYNNNYNNNNYNNYNNNNYNNNN", "YNNNYNYYNNNNNNNNYNNNNNNNNYNNNYYYNYNYNNNNNNNN", "NNNNNNNNNNNYNNYNNNYYNYNNNNNYYNNYYNNNNNYNNYNN", "NNNNYYNNNNNNNNYNNNYNNNYYNNNNNNNNNYNNNNYNNNNN", "NYNYNNNNNNYNNNNYNYNYYYNNNNNNNNNNNNNNNNNNYYNN", "NNNYNNYNYYYNYNNNYNNNNYNNNNNNNNNNNNNNNNNYNYYY", "YYNNNYNNNNYYNYYNNYNNNNNNNNNYYNNNNNNNYNNNNNNY", "NYNNNNNNNNNYYNNNNNNNNNNNYNYNNNNYNNYNNNNYNNNN", "NNNNNYNNNNNNYYNNNNNNYNNNYNNNNNYNNNNYNNNYNNNN", "NNNNNYNNNNNNNNNNNNNNNNNNNYNNNYNNYNNNYYNNYNYN", "NNNNYYYNNNNNYNNYNNNNNNYNYNNNNNNNYYNYNNNYYNNY", "NNYNNNYYNNNNNNYYNNNNNNNNNNNNNNNNNNNNYNNNNNYY", "NNNNNYNYYNYNNNNNNNNNYYNNNNNNNNNYYYYYNYNNNNYN", "NNNNNNYNYNNNNNYYNYNNNYYNNNYYNNNNYNYNNNYNNNYN", "NNYYNNYNNNNYNYNYNNNNNYYNNNNNYYNNNYNNNNNNYNNN", "NNNNYNNNNNYYNYYNYNYNYNYNNNYNNNNNNNNNNNNYYNNN", "NYNNNYNNNNNNNNNYNNNNNNNYNYNYNYNYNNNNYNNNYYNN", "NNNNYNYNNNNNNYNNNNNYNNNYNNNNNNNYNYNNNNNYNNYN", "NNYYNNNNNNNNNNNYNNNYNNNNYNNNNNYNNNYYNYNYNNNN", "NNYNYNNNNNNNNNNNNYYNYNNNNNYNYNNYNNNYNYNYNNNY", "YNNNYNNNYNNNYNNYNNNYNNYYNNNNYNYNNNNNNNYNNNNN", "NNYNYYNNNNNNYYYNNNNNNNNNNNNNNNNYNNYYNYNYNNNN", "YNNYNNNNNNYNNYYYNNNNYNNNNNNNNNNNYNNNNNNNNNNY", "NNNYNNNNNNNNNNNNYYNNYNNNNNNNNYNNYNNNNNNNNNNN", "NNNNNNNYYNYNNNNNNNYNNNNNNNYNYYNYNNNNNNNNNNYN", "NYNNNNNNNYNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNYNNN", "YNNNNNNYNNNNNYNYNNNYNNNNYNNYNNNYNNYNNYNYNNNN", "NNYNNNYNNNNNNYNNYNNNNNNNNNYNNNNNNNNYNNNYNNYN", "NNYNNNYNNNNNNNYNNNNYYNNNYNNNNYNYYNNNNNNNNYYN", "NYNNNNNNNYNNNNYNYNNNNNNYYNNNYNNNNYNNYNNYNYYN", "NYNNNNNNYNNNNNNNNNYNYNNNNNNNNNNNNNYNNNNNNNNY", "YYYNNNNYNNNNYNNNYYNYNYNNYNYNYNNNNNYNNNNNNYNN", "NNYNNNNNNYYNYYNNNNNNNNYYNNNNYNNNNNYNNNYNNNYN", "NYNYNNNNNNYNYNYNNYNNNNNNNNNNNYNNNNYNNYYNNYYN", "YNNNNNNYNNNNYYNNNNYNNYNNNNYNNNYYYYNYNNNNNNNY", "NYNNNNNNYNYNYNNNNNYYNYNNNNNYNNNNNNYNYNNNYNNN", "NNNNNNYNNYNYNNNNYNNNNNNNNNNNNYNNNNNYNNNNNNYN", "NNNNNNNNNYNNYNNNNNYYNYNNNNYNNNNNNYNNNNNNNNNN", "NNYYNNNNNNNNNYNNNNNNYNNNNNNNNNNNYYNNNNNYYNNY", "YNNNNYNYYNYNNNNYNYYYNYNNNNYYNYNNNNNNNNYNNNYN", "NNNNYNNNNYYNNNYYYNNNNNNNNYNNNNNNNNNYNNYNNNNY", "NNYNYYNNNNNNNNNNYNNNNNNNNNNNYYNYNYNNNNNNNNNY", "NNNNNYNNNYNYYYNNNYNNNNNNYNNYYYNNYYNNYNNYNNNN", "NNNNNYYNNNYYNNNNNNNYNNYNNNNNNNYNNNYNNNYNYYNN" };
            int size = 7;

            Assert.AreEqual(-1, magicMolecule.maxMagicPower(power, bond, size));
        }
    }
}