using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JustBrackets;

namespace Test {
    [TestClass]
    public class Test {

        JustBrackets.JustBrackets brackets;

        [TestInitialize]
        public void Setup() {

            brackets = new JustBrackets.JustBrackets();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual("()", brackets.getSmallest("()"));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual("()", brackets.getSmallest("()()"));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual("(())", brackets.getSmallest("(())"));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual("((()))", brackets.getSmallest("(()(()))"));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual("(((())(())))", brackets.getSmallest("((())()(()(())(())))"));
        }

        [TestMethod]
        public void Sample6() {

            Assert.AreEqual("(((((((((((((((((())))()())))())()())()())()()))()())()())))))", brackets.getSmallest("(()()(()()(()()(()()(((()()((((()(()()(()()((()()(()()(())))()())))())()())()())()()))()())()())))))"));
        }

        [TestMethod]
        public void Sample7() {

            Assert.AreEqual("(((((((((((((((((((((((((((((((((((((((((((((((((())))))))))))))))))))))))))))))))))))))))))))))))))", brackets.getSmallest("(((((((((((((((((((((((((((((((((((((((((((((((((())))))))))))))))))))))))))))))))))))))))))))))))))"));
        }

        [TestMethod]
        public void Sample8() {

            Assert.AreEqual("((()))", brackets.getSmallest("()()()()()()()()()()()()()()()()()()()()()((()))()()()()()()()()()()()()()()()()()()()()()"));
        }

        [TestMethod]
        public void Sample9() {

            Assert.AreEqual("((((((((((((((((()())()))()()))()()))))()())()))()()))()())())", brackets.getSmallest("(()((()()((()()(()((()()(()()(()()((()()((()()(()(()())()))()()))()()))))()())()))()()))()())())"));
        }

        [TestMethod]
        public void Sample10() {

            Assert.AreEqual("(((((()))())(())())(())(())(()))", brackets.getSmallest("()((())(()()()()())(()()()())()((())()()())((()()))((()())(())((()(()))())()(())())()(())(())()(()))"));
        }
    }
}