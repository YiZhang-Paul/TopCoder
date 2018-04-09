using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreesAndBrackets;

namespace Test {
    [TestClass]
    public class Test {

        TreesAndBrackets.TreesAndBrackets brackets;

        [TestInitialize]
        public void Setup() {

            brackets = new TreesAndBrackets.TreesAndBrackets();
        }

        [TestMethod]
        public void Sample1() {

            string t1 = "(())";
            string t2 = "()";

            Assert.AreEqual("Possible", brackets.check(t1, t2));
        }

        [TestMethod]
        public void Sample2() {

            string t1 = "()";
            string t2 = "()";

            Assert.AreEqual("Possible", brackets.check(t1, t2));
        }

        [TestMethod]
        public void Sample3() {

            string t1 = "(()()())";
            string t2 = "((()))";

            Assert.AreEqual("Impossible", brackets.check(t1, t2));
        }

        [TestMethod]
        public void Sample4() {

            string t1 = "((())((())())())";
            string t2 = "(()(())())";

            Assert.AreEqual("Possible", brackets.check(t1, t2));
        }

        [TestMethod]
        public void Sample5() {

            string t1 = "((())((())())())";
            string t2 = "((()()()()()))";

            Assert.AreEqual("Impossible", brackets.check(t1, t2));
        }
    }
}