using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RingLex;

namespace Test {
    [TestClass]
    public class Test {

        RingLex.RingLex ringLex;

        [TestInitialize]
        public void Setup() {

            ringLex = new RingLex.RingLex();
        }

        [TestMethod]
        public void Sample1() {

            Assert.AreEqual("abc", ringLex.getmin("cba"));
        }

        [TestMethod]
        public void Sample2() {

            Assert.AreEqual("abc", ringLex.getmin("acb"));
        }

        [TestMethod]
        public void Sample3() {

            Assert.AreEqual("aaaabcb", ringLex.getmin("abacaba"));
        }

        [TestMethod]
        public void Sample4() {

            Assert.AreEqual("aabab", ringLex.getmin("aaabb"));
        }

        [TestMethod]
        public void Sample5() {

            Assert.AreEqual("abazabaz", ringLex.getmin("azzzabbb"));
        }

        [TestMethod]
        public void Sample6() {

            Assert.AreEqual("aaaaaa", ringLex.getmin("abbaac"));
        }

        [TestMethod]
        public void Sample7() {

            Assert.AreEqual("dehifsfsoy", ringLex.getmin("fsdifyhsoe"));
        }

        [TestMethod]
        public void Sample8() {

            Assert.AreEqual("aamuyngymzzgqpqrvocsodukdfeintuultxyexhiznorkjzowb", ringLex.getmin("ufnuxxzrzbmnmgqooketlyhnkoaugzqrcddiuteiojwayyzpvs"));
        }

        [TestMethod]
        public void Sample9() {

            Assert.AreEqual("aacftdrodzscukheewuutidffmyjrnscbzukzbiunbhiiuekvc", ringLex.getmin("cudhnefnjhaimuczfskuiduburiswtbrecuykabfcvkdzeztoi"));
        }

        [TestMethod]
        public void Sample10() {

            Assert.AreEqual("zzzzzzzzzz", ringLex.getmin("zzzzzzzzzz"));
        }
    }
}