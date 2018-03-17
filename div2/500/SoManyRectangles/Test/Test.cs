using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoManyRectangles;

namespace Test {

    [TestClass]
    public class Test {

        SoManyRectangles.SoManyRectangles rectangles;

        [TestInitialize]
        public void Setup() {

            rectangles = new SoManyRectangles.SoManyRectangles();
        }

        [TestMethod]
        public void Sample1() {

            int[] x1 = { 0, 50 };
            int[] y1 = { 0, 50 };
            int[] x2 = { 100, 60 };
            int[] y2 = { 100, 60 };

            Assert.AreEqual(2, rectangles.maxOverlap(x1, y1, x2, y2));
        }

        [TestMethod]
        public void Sample2() {

            int[] x1 = { 0, 90 };
            int[] y1 = { 0, 90 };
            int[] x2 = { 100, 200 };
            int[] y2 = { 100, 200 };

            Assert.AreEqual(2, rectangles.maxOverlap(x1, y1, x2, y2));
        }

        [TestMethod]
        public void Sample3() {

            int[] x1 = { 0, 100 };
            int[] y1 = { 0, 100 };
            int[] x2 = { 100, 200 };
            int[] y2 = { 100, 200 };

            Assert.AreEqual(1, rectangles.maxOverlap(x1, y1, x2, y2));
        }

        [TestMethod]
        public void Sample4() {

            int[] x1 = { 0, 0, 0, 0, 0 };
            int[] y1 = { 0, 0, 0, 0, 0 };
            int[] x2 = { 1, 1, 1, 1, 1 };
            int[] y2 = { 1, 1, 1, 1, 1 };

            Assert.AreEqual(5, rectangles.maxOverlap(x1, y1, x2, y2));
        }

        [TestMethod]
        public void Sample5() {

            int[] x1 = { 0 };
            int[] y1 = { 0 };
            int[] x2 = { 1 };
            int[] y2 = { 1 };

            Assert.AreEqual(1, rectangles.maxOverlap(x1, y1, x2, y2));
        }
    }
}