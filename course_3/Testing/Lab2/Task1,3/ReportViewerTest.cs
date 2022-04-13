using System;
using NUnit.Framework;
using System.IO;
using Moq;

namespace Lab2
{
    public class ReportViewerTest
    {
        ReportViewer reportViewer1;
        MockFileService mockFileService1;

        ReportViewer reportViewer2;
        Mock<IFileService> mockFileService2;

        private string path;

        [OneTimeSetUp]
        public void Setup()
        {
            path = Path.Combine("C:", "Lab2", "Tests");
        }

        [SetUp]
        public void Init()
        {
            mockFileService1 = new MockFileService();
            reportViewer1 = new ReportViewer(mockFileService1);

            mockFileService2 = new Mock<IFileService>();
            reportViewer2 = new ReportViewer(mockFileService2.Object);
        }

        [Test]
        public void PrepareDateTest()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.PrepareDate(path);

            Assert.AreEqual(reportViewer.BlockCount, 3);
        }

        [Test]
        public void PrepareDateNotFileTest()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.PrepareDate(Path.Combine("C:"));

            Assert.AreEqual(reportViewer.BlockCount, 0);
        }

        [Test]
        public void PrepareDataMergeTemporaryFilesWasCalledTest()
        {
            reportViewer1.PrepareDate("labs");
            Assert.IsTrue(mockFileService1.MergeTemporaryFilesWasCalled);
        }

        //3 задание с Moq

        [Test]
        public void PrepareDataMergeTemporaryFilesWasCalledWithMoqTest()
        {
            mockFileService2.Setup(x => x.MergeTemporaryFiles(It.IsAny<string>()));
            reportViewer2.PrepareDate("labs");
            mockFileService2.VerifyAll();
        }
    }
}
