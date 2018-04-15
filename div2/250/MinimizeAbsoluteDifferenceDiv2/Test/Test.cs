using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimizeAbsoluteDifferenceDiv2;

namespace Test {
    [TestClass]
    public class Test {

        MinimizeAbsoluteDifferenceDiv2.MinimizeAbsoluteDifferenceDiv2 minimize;

        [TestInitialize]
        public void Setup() {

            minimize = new MinimizeAbsoluteDifferenceDiv2.MinimizeAbsoluteDifferenceDiv2();
        }

        [TestMethod]
        public void Sample1() {

            CollectionAssert.AreEqual(new int[] { 0, 1, 2 }, minimize.findTriple(1, 1, 1));
        }

        [TestMethod]
        public void Sample2() {

            CollectionAssert.AreEqual(new int[] { 1, 2, 0 }, minimize.findTriple(1, 2, 3));
        }

        [TestMethod]
        public void Sample3() {

            CollectionAssert.AreEqual(new int[] { 1, 0, 2 }, minimize.findTriple(7, 20, 5));
        }

        [TestMethod]
        public void Sample4() {

            CollectionAssert.AreEqual(new int[] { 0, 1, 2 }, minimize.findTriple(6, 2, 3));
        }

        [TestMethod]
        public void Sample5() {

            CollectionAssert.AreEqual(new int[] { 2, 1, 0 }, minimize.findTriple(10, 11, 111));
        }
    }
}