using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpectedMinimumPowerDiv2;

namespace Test {
    [TestClass]
    public class Test {

        ExpectedMinimumPowerDiv2.ExpectedMinimumPowerDiv2 minPower;

        [TestInitialize]
        public void Setup() {

            minPower = new ExpectedMinimumPowerDiv2.ExpectedMinimumPowerDiv2();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual(2.0, minPower.findExp(4, 4));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual(2.6666666666666665, minPower.findExp(3, 2));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual(4.666666666666667, minPower.findExp(3, 1));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual(8.076190476190476, minPower.findExp(10, 4));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual(9.90668859655418, minPower.findExp(50, 25));
        }

        [TestMethod]
        public void Sample6() {

            Assert.AreEqual(4.503599627370492E13, minPower.findExp(50, 1));
        }
    }
}