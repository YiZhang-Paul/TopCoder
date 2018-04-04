using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HalvingEasy;

namespace Test {
    [TestClass]
    public class Test {

        HalvingEasy.HalvingEasy halving;

        [TestInitialize]
        public void Setup() {

            halving = new HalvingEasy.HalvingEasy();
        }

        [TestMethod]
        public void Sample1() {

            int[] integers = { 6, 14, 11, 3, 1 };

            Assert.AreEqual(3, halving.count(integers, 3));
        }

        [TestMethod]
        public void Sample2() {

            int[] integers = { 42, 10, 10, 10, 11, 11, 20, 21, 39, 40, 42, 43, 44 };

            Assert.AreEqual(9, halving.count(integers, 10));
        }

        [TestMethod]
        public void Sample3() {

            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            Assert.AreEqual(20, halving.count(integers, 1));
        }

        [TestMethod]
        public void Sample4() {

            int[] integers = { 987654321, 1000000000, 998244353, 123456789, 999999999 };

            Assert.AreEqual(3, halving.count(integers, 476));
        }

        [TestMethod]
        public void Sample5() {

            int[] integers = { 987654321, 1000000000, 998244353, 123456789, 999999999 };

            Assert.AreEqual(1, halving.count(integers, 1000000000));
        }
    }
}