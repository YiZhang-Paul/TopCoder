using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckOfCards;

namespace Test {
    [TestClass]
    public class Test {

        DeckOfCards.DeckOfCards cards;

        [TestInitialize]
        public void Setup() {

            cards = new DeckOfCards.DeckOfCards();
        }

        [TestMethod]
        public void Sample1() {

            int[] value = { 10 };
            string suit = "z";

            Assert.AreEqual("Perfect", cards.IsValid(1, value, suit));
        }

        [TestMethod]
        public void Sample2() {

            int[] value = { 1, 2, 3 };
            string suit = "hhh";

            Assert.AreEqual("Perfect", cards.IsValid(3, value, suit));
        }

        [TestMethod]
        public void Sample3() {

            int[] value = { 2, 3, 2, 3 };
            string suit = "hcch";

            Assert.AreEqual("Perfect", cards.IsValid(4, value, suit));
        }

        [TestMethod]
        public void Sample4() {

            int[] value = { 1, 1, 1 };
            string suit = "hch";

            Assert.AreEqual("Not perfect", cards.IsValid(3, value, suit));
        }

        [TestMethod]
        public void Sample5() {

            int[] value = { 1, 2, 3, 4 };
            string suit = "hhcc";

            Assert.AreEqual("Not perfect", cards.IsValid(4, value, suit));
        }
    }
}