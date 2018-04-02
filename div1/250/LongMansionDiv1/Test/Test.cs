using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LongMansionDiv1;

namespace Test {
    [TestClass]
    public class Test {

        LongMansionDiv1.LongMansionDiv1 mansion;

        [TestInitialize]
        public void Setup() {

            mansion = new LongMansionDiv1.LongMansionDiv1();
        }

        [TestMethod]
        public void Sample1() {

            int[] time = { 5, 3, 10 };

            Assert.AreEqual(29, mansion.minimalTime(time, 2, 0, 2, 2));
        }

        [TestMethod]
        public void Sample2() {

            int[] time = { 5, 3, 10 };

            Assert.AreEqual(15, mansion.minimalTime(time, 0, 2, 0, 0));
        }

        [TestMethod]
        public void Sample3() {

            int[] time = { 137, 200, 184, 243, 252, 113, 162 };

            Assert.AreEqual(1016, mansion.minimalTime(time, 0, 2, 4, 2));
        }

        [TestMethod]
        public void Sample4() {

            int[] time = { 995, 996, 1000, 997, 999, 1000, 997, 996, 1000, 996, 1000, 997, 999, 996, 1000, 998, 999, 995, 995, 998, 995, 998, 995, 997, 998, 996, 998, 996, 997, 1000, 998, 997, 995, 1000, 996, 997, 1000, 997, 997, 999, 998, 995, 999, 999, 1000, 1000, 998, 997, 995, 999 };

            Assert.AreEqual(293443080673, mansion.minimalTime(time, 18, 433156521, 28, 138238863));
        }

        [TestMethod]
        public void Sample5() {

            int[] time = { 1 };

            Assert.AreEqual(1, mansion.minimalTime(time, 0, 0, 0, 0));
        }
    }
}