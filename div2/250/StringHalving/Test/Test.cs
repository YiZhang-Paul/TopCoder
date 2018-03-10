using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringHalving;

namespace Test {
    [TestClass]
    public class Test {

        StringHalving.StringHalving stringHalf;

        [TestInitialize]
        public void Setup() {

            stringHalf = new StringHalving.StringHalving();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual("a", stringHalf.lexsmallest("baba"));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual("b", stringHalf.lexsmallest("bbaa"));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual("g", stringHalf.lexsmallest("zyiggiyssz"));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual("c", stringHalf.lexsmallest("topcodertpcder"));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual("f", stringHalf.lexsmallest("rvofqorvfq"));
        }
    }
}