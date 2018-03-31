using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CubeStackingGame;

namespace Test {
    [TestClass]
    public class Test {

        CubeStackingGame.CubeStackingGame cube;

        [TestInitialize]
        public void Setup() {

            cube = new CubeStackingGame.CubeStackingGame();
        }

        [TestMethod]
        public void Sample1() {

            int[] face1 = { 1, 1 };
            int[] face2 = { 2, 1 };
            int[] face3 = { 1, 2 };
            int[] face4 = { 2, 2 };

            Assert.AreEqual(1, cube.MaximumValue(2, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample2() {

            int[] face1 = { 1, 2 };
            int[] face2 = { 1, 2 };
            int[] face3 = { 1, 2 };
            int[] face4 = { 1, 2 };

            Assert.AreEqual(2, cube.MaximumValue(2, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample3() {

            int[] face1 = { 1, 1 };
            int[] face2 = { 1, 2 };
            int[] face3 = { 1, 2 };
            int[] face4 = { 1, 2 };

            Assert.AreEqual(1, cube.MaximumValue(2, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample4() {

            int[] face1 = { 1, 1 };
            int[] face2 = { 2, 2 };
            int[] face3 = { 1, 1 };
            int[] face4 = { 2, 2 };

            Assert.AreEqual(2, cube.MaximumValue(2, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample5() {

            int[] face1 = { 1, 1 };
            int[] face2 = { 1, 2 };
            int[] face3 = { 2, 2 };
            int[] face4 = { 2, 1 };

            Assert.AreEqual(2, cube.MaximumValue(2, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample6() {

            int[] face1 = { 1, 1, 3, 4 };
            int[] face2 = { 1, 2, 3, 4 };
            int[] face3 = { 1, 3, 3, 4 };
            int[] face4 = { 1, 4, 3, 4 };

            Assert.AreEqual(1, cube.MaximumValue(4, face1, face2, face3, face4));
        }

        [TestMethod]
        public void Sample7() {

            int[] face1 = { 1, 1, 1, 1 };
            int[] face2 = { 2, 2, 2, 4 };
            int[] face3 = { 3, 3, 3, 3 };
            int[] face4 = { 4, 4, 4, 2 };

            Assert.AreEqual(4, cube.MaximumValue(4, face1, face2, face3, face4));
        }
    }
}