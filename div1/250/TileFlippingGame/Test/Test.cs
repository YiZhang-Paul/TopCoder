using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileFlippingGame;

namespace Test {
    [TestClass]
    public class Test {

        TileFlippingGame.TileFlippingGame flip;

        [TestInitialize]
        public void Setup() {

            flip = new TileFlippingGame.TileFlippingGame();
        }

        [TestMethod]
        public void Sample1() {

            string[] board = { "bbb", "eee", "www" };

            Assert.AreEqual(1, flip.HowManyMoves(3, 3, board));
        }

        [TestMethod]
        public void Sample2() {

            string[] board = { "bwe", "wbw", "ewb" };

            Assert.AreEqual(2, flip.HowManyMoves(3, 3, board));
        }

        [TestMethod]
        public void Sample3() {

            string[] board = { "beww", "beww", "beww", "wewe" };

            Assert.AreEqual(1, flip.HowManyMoves(4, 4, board));
        }

        [TestMethod]
        public void Sample4() {

            string[] board = { "ewewbbbb", "bwebewww" };

            Assert.AreEqual(3, flip.HowManyMoves(2, 8, board));
        }

        [TestMethod]
        public void Sample5() {

            string[] board = { "bwebw", "wbebb", "eeeee", "bbebb", "bbebb" };

            Assert.AreEqual(3, flip.HowManyMoves(5, 5, board));
        }

        [TestMethod]
        public void Sample6() {

            string[] board = { "bwbbbbb", "bwbwwwb", "bwbwewb", "bwbbbwb", "bwwwwwb", "bbbbbbb" };

            Assert.AreEqual(1, flip.HowManyMoves(6, 7, board));
        }

        [TestMethod]
        public void Sample7() {

            string[] board = { "bwbbbbb", "bwbwwwb", "eeeeeee", "bwbbbwb", "bwwwwwb", "bbbbbbb" };

            Assert.AreEqual(3, flip.HowManyMoves(6, 7, board));
        }
    }
}