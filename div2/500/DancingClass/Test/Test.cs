using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DancingClass;

namespace Test {
    [TestClass]
    public class Test {

        DancingClass.DancingClass danceClass;

        [TestInitialize]
        public void Setup() {

            danceClass = new DancingClass.DancingClass();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual("Equal", danceClass.checkOdds(2, 1));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual("High", danceClass.checkOdds(3, 2));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual("Low", danceClass.checkOdds(4, 4));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual("High", danceClass.checkOdds(500, 500));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual("Low", danceClass.checkOdds(40, 397));
        }

        [TestMethod]
        public void Sample6() {

            Assert.AreEqual("Low", danceClass.checkOdds(1, 1));
        }
    }
}