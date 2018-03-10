using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntervalIntersections;

namespace Test {
    [TestClass]
    public class Test {

        IntervalIntersections.IntervalIntersections intersection;

        [TestInitialize]
        public void Setup() {

            intersection = new IntervalIntersections.IntervalIntersections();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual(1, intersection.minLength(3, 6, 1, 2));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual(1, intersection.minLength(1, 2, 3, 6));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual(0, intersection.minLength(1, 10, 2, 5));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual(0, intersection.minLength(4, 5, 1, 4));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual(999999, intersection.minLength(1, 1, 1000000, 1000000));
        }
    }
}