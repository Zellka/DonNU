using Moq;
using NUnit.Framework;
using System;

namespace Lab2
{
    [TestFixture]
    class LinksRepositoryTest
    {
        StringFormatter formatter;
        LinksRepository repository;

        [SetUp]
        public void Init()
        {
            formatter = new StringFormatter();
            repository = new LinksRepository();
        }

        [Test]
        public void AddHttpTest()
        {
            repository.Formatter = formatter;
            string link = "zellka.com";
            repository.Add(link);

            Assert.AreEqual(repository.GetLink(0), "http://" + link);
        }

        [Test]
        public void AddGitTest()
        {
            repository.Formatter = formatter;
            string link = "zellka.git";
            repository.Add(link);

            Assert.AreEqual(repository.GetLink(0), "git://" + link);
        }

        [Test]
        public void AddNullTest()
        {
            repository.Formatter = formatter;
            Assert.Throws<NullReferenceException>(() => repository.Add(null));
        }
    }
}
