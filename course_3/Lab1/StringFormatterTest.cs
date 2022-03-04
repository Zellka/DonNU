using System;
using NUnit.Framework;

namespace Lab1
{
    class StringFormatterTest
    {
        StringFormatter stringFormatter;

        [SetUp]
        public void Setup()
        {
            stringFormatter = new StringFormatter();
        }

        [Test]
        public void SafeStringNotCorrectTest()
        {
            Assert.Throws<NullReferenceException>(() => stringFormatter.SafeString(null));
        }

        [TestCase("'select * from Order'", ExpectedResult = "''SELECT * from Order''")]
        [TestCase("'insert * from Order'", ExpectedResult = "''INSERT * from Order''")]
        [TestCase("'update * from Order'", ExpectedResult = "''UPDATE * from Order''")]
        [TestCase("'delete * from Order'", ExpectedResult = "''DELETE * from Order''")]
        [TestCase("", ExpectedResult = "")]
        public string SafeStringCorrectTest(string s)
        {
            return stringFormatter.SafeString(s);
        }
    }
}
