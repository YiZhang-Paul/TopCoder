using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HamiltonianPathsInGraph;

namespace Test {
    [TestClass]
    public class Test {

        HamiltonianPathsInGraph.HamiltonianPathsInGraph path;

        private bool IsValidPath(string[] edges, int[] path) {

            for(int i = 0; i < path.Length - 1; i++) {

                if(edges[path[i]][path[i + 1]] != '+') {

                    return false;
                }
            }

            return true;
        }

        [TestInitialize]
        public void Setup() {

            path = new HamiltonianPathsInGraph.HamiltonianPathsInGraph();
        }

        [TestMethod]
        public void Sample1() {

            string[] edges = { ".+", "-." };

            Assert.IsTrue(IsValidPath(edges, path.findPath(edges)));
        }

        [TestMethod]
        public void Sample2() {

            string[] edges = { ".++", "-.+", "--." };

            Assert.IsTrue(IsValidPath(edges, path.findPath(edges)));
        }

        [TestMethod]
        public void Sample3() {

            string[] edges = { ".--+", "+.+-", "+-.-", "-++." };

            Assert.IsTrue(IsValidPath(edges, path.findPath(edges)));
        }

        [TestMethod]
        public void Sample4() {

            string[] edges = { ".+-+", "-.+-", "+-.-", "-++." };

            Assert.IsTrue(IsValidPath(edges, path.findPath(edges)));
        }

        [TestMethod]
        public void Sample5() {

            string[] edges = { ".++--", "-.-++", "-+.+-", "+--.+", "+-+-." };

            Assert.IsTrue(IsValidPath(edges, path.findPath(edges)));
        }
    }
}