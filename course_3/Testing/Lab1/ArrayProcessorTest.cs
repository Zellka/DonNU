using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    class ArrayProcessorTest
    {
        ArrayProcessor array;
        [SetUp]
        public void Setup()
        {
            array = new ArrayProcessor();
        }

        [Test]
        public void SortAndFilterTest()
        {
            int[] a = { 4, -7, 1, -7, 2, 2, -3};
            int[] b = { -7, -3, 1, 2, 2, 4};
            CollectionAssert.AreEquivalent(array.SortAndFilter(a), b);
        }
    }
}
