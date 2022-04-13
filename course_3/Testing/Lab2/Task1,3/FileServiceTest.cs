using System;
using NUnit.Framework;
using System.IO;
using Moq;

namespace Lab2
{
    [TestFixture]
    class FileServiceTest
    {
        string path;

        FileService fileService1;
        MockFile mockFile1;

        FileService fileService2;
        Mock<IFile> mockFile2;

        [OneTimeSetUp]
        public void Setup()
        {
            path = Path.Combine("C:", "Lab2", "Tests");
        }

        [SetUp]
        public void Init()
        {
            mockFile1 = new MockFile();
            fileService1 = new FileService(mockFile1);

            mockFile2 = new Mock<IFile>();
            fileService2 = new FileService(mockFile2.Object);
        }

        [Test]
        public void MergeTemporaryFilesExistTest()
        {
            IFile file = new StubFile();
            FileService fileService = new FileService(file);
            int count = fileService.MergeTemporaryFiles(path);

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void MergeTemporaryFilesNotExistTest()
        {
            IFile file = new StubFile();
            FileService fileService = new FileService(file);
            int count = fileService.MergeTemporaryFiles(Path.Combine("C:"));

            Assert.AreEqual(count, 0);
        }

        [Test]
        public void MergeTemporaryFilesNotExistPathTest()
        {
            IFile file = new StubFile();
            FileService fileService = new FileService(file);

            Assert.Throws<DirectoryNotFoundException>(() => fileService.MergeTemporaryFiles("C:\\Stab\\LabTesting"));
        }

        [Test]
        public void MergeTemporaryFilesExistWasCalledTest()
        {
            fileService1.MergeTemporaryFiles(path);
            Assert.IsTrue(mockFile1.ExsistsWasCalled);
        }

        [Test]
        public void MergeTemporaryFilesGetFilesWasCalledTest()
        {
            fileService1.MergeTemporaryFiles(path);
            Assert.IsTrue(mockFile1.GetFilesWasCalled);
        }

        [Test]
        public void MergeTemporaryFilesGetFileDataWasCalledTest()
        {
            fileService1.MergeTemporaryFiles(path);
            Assert.IsTrue(mockFile1.GetFileDataWasCalled);
        }

        [Test]
        public void MergeTemporaryFilesDeleteFileWasCalledTest()
        {
            fileService1.MergeTemporaryFiles(path);
            Assert.IsTrue(mockFile1.DeleteFileWasCalled);
        }

        [Test]
        public void MergeTemporaryFilesCreateFileWasCalledTest()
        {
            fileService1.MergeTemporaryFiles(path);
            Assert.IsTrue(mockFile1.CreateFileWasCalled);
        }

        //3 задание с Moq

        [Test]
        public void MergeTemporaryFilesWithMoqTest()
        {
            mockFile2.Setup(x => x.CreateFile(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(true);
            mockFile2.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(new string[] { "lab1.tmp", "lab2.tmp" });
            mockFile2.Setup(x => x.GetFile(It.IsAny<string>())).Returns(new byte[] { });
            mockFile2.Setup(x => x.Exist(It.IsAny<string>())).Returns(true);
            mockFile2.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(true);

            fileService2.MergeTemporaryFiles(path);
            mockFile2.VerifyAll();
        }
    }
}
