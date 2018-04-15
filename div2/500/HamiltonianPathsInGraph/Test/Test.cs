using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HamiltonianPathsInGraph;

namespace Test {
    [TestClass]
    public class Test {

        HamiltonianPathsInGraph.HamiltonianPathsInGraph path;

        [TestInitialize]
        public void Setup() {

            path = new HamiltonianPathsInGraph.HamiltonianPathsInGraph();
        }

        [TestMethod]
        public void Sample1() {

            string[] edges = { ".+", "-." };

            CollectionAssert.AreEqual(new int[] { 0, 1 }, path.findPath(edges));
        }

        [TestMethod]
        public void Sample2() {

            string[] edges = { ".++", "-.+", "--." };

            CollectionAssert.AreEqual(new int[] { 0, 1, 2 }, path.findPath(edges));
        }

        [TestMethod]
        public void Sample3() {

            string[] edges = { ".--+", "+.+-", "+-.-", "-++." };

            CollectionAssert.AreEqual(new int[] { 3, 1, 2, 0 }, path.findPath(edges));
        }

        [TestMethod]
        public void Sample4() {

            string[] edges = { ".+-+", "-.+-", "+-.-", "-++." };

            CollectionAssert.AreEqual(new int[] { 3, 2, 0, 1 }, path.findPath(edges));
        }

        [TestMethod]
        public void Sample5() {

            string[] edges = { ".++--", "-.-++", "-+.+-", "+--.+", "+-+-." };

            CollectionAssert.AreEqual(new int[] { 3, 0, 2, 1, 4 }, path.findPath(edges));
        }
    }
}