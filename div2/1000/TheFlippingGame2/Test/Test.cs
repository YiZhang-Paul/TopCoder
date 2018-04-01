using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheFlippingGame2;

namespace Test {
    [TestClass]
    public class Test {

        TheFlippingGame2.TheFlippingGame2 flipping;

        [TestInitialize]
        public void Setup() {

            flipping = new TheFlippingGame2.TheFlippingGame2();
        }

        [TestMethod]
        public void Sample1() {

            string[] board = { "bwe", "web", "ebw" };

            Assert.AreEqual(3, flipping.MinimumMoves(3, 3, board));
        }

        [TestMethod]
        public void Sample2() {

            string[] board = { "bwe", "wbw", "ewb" };

            Assert.AreEqual(3, flipping.MinimumMoves(3, 3, board));
        }

        [TestMethod]
        public void Sample3() {

            string[] board = { "beww", "beww", "beww", "wewe" };

            Assert.AreEqual(2, flipping.MinimumMoves(4, 4, board));
        }

        [TestMethod]
        public void Sample4() {

            string[] board = { "bwbwbwbwbwbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwb", "bwbwbwbwbwbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwb", "bwbwbwbwbwbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwb", "bwbwbwbwewbwbwbwbwbw", "wbwbwbwbebwbwbwbwbwb", "bwbwbwbwewbwbwbwbwbw", "wbwbwbwbebwbwbwbwbwb", "bwbwbwbwewbwbwbwbwbw", "wbwbwbwbebwbwbwbwbwb", "bwbwbwbwewbwbwbwbwbw", "wbwbwbwbebwbwbwbwbwb", "bwbwbwbwewbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwb", "bwbwbwbwbwbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwb", "bwbwbwbwbwbwbwbwbwbw", "wbwbwbwbwbwbwbwbwbwe" };

            Assert.AreEqual(16, flipping.MinimumMoves(20, 20, board));
        }

        [TestMethod]
        public void Sample5() {

            string[] board = { "ewewbbbb", "bwebewww" };

            Assert.AreEqual(3, flipping.MinimumMoves(2, 8, board));
        }
    }
}