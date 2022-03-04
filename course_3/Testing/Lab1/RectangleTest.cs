using System;
using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    class RectangleTests
    {
        Rectangle rectangle;

        [OneTimeSetUp]
        public void Init()
        {
            rectangle = new Rectangle();
        }

        [TestCase(new double[] { 0, 10, 10, 0 }, new double[] { 0, 0, -10, -10 })]
        public void SetVerticesCorrectTest(double[] x, double[] y)
        {
            Assert.DoesNotThrow(() => rectangle.SetVertices(x, y));
        }

        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 1 })]
        [TestCase(new double[] { 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0 })]
        public void SetVerticesNotCorrectTest(double[] x, double[] y)
        {
            Assert.Throws<ArgumentException>(() => rectangle.SetVertices(x, y));
        }
        
        [TestCase(new double[] { 0, 10, 10, 0 }, new double[] { 0, 0, -10, -10 })]
        public void ConstructorCorrectTest(double[] x, double[] y)
        {
            Assert.DoesNotThrow(() => rectangle = new Rectangle(x, y));
        }

        [TestCase(new double[] { -10, -10, 0, 0 }, new double[] { 5, 1, 1, 1 })]
        [TestCase(new double[] { 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0 })]
        public void ConstructorNotCorrectTest(double[] x, double[] y)
        {
            Assert.Throws<ArgumentException>(() => rectangle = new Rectangle(x, y));
        }
    }
}
