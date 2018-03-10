using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ANewHope;

namespace Test {
    [TestClass]
    public class Test {

        ANewHope.ANewHope newHope;

        [TestInitialize]
        public void Setup() {

            newHope = new ANewHope.ANewHope();
        }

        [TestMethod]
        public void Sample1() {

            int[] firstWeek = { 1, 2, 3, 4 };
            int[] lastWeek = { 4, 3, 2, 1 };
            const int daysToDry = 3;

            Assert.AreEqual(4, newHope.count(firstWeek, lastWeek, daysToDry));
        }

        [TestMethod]
        public void Sample2() {

            int[] firstWeek = { 8, 5, 4, 1, 7, 6, 3, 2 };
            int[] lastWeek = { 2, 4, 6, 8, 1, 3, 5, 7 };
            const int daysToDry = 3;

            Assert.AreEqual(3, newHope.count(firstWeek, lastWeek, daysToDry));
        }

        [TestMethod]
        public void Sample3() {

            int[] firstWeek = { 1, 2, 3, 4 };
            int[] lastWeek = { 1, 2, 3, 4 };
            const int daysToDry = 2;

            Assert.AreEqual(1, newHope.count(firstWeek, lastWeek, daysToDry));
        }
    }
}