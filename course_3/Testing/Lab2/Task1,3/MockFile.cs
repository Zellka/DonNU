using System;

namespace Lab2
{
    public class MockFile : IFile
    {
        public bool CreateFileWasCalled { get; private set; }
        public bool DeleteFileWasCalled { get; private set; }
        public bool ExsistsWasCalled { get; private set; }
        public bool FileSizeWasCalled { get; private set; }
        public bool GetFileDataWasCalled { get; private set; }
        public bool GetFilesWasCalled { get; private set; }
        public bool ReadLinesWasCalled { get; private set; }

        public bool CreateFile(string name, byte[] data)
        {
            CreateFileWasCalled = true;
            return true;
        }

        public bool DeleteFile(string path)
        {
            DeleteFileWasCalled = true;
            return true;
        }

        public bool Exist(string path)
        {
            ExsistsWasCalled = true;
            return true;
        }

        public int Size(string name)
        {
            FileSizeWasCalled = true;
            return 1;
        }

        public byte[] GetFile(string file)
        {
            GetFileDataWasCalled = true;
            return new byte[] { };
        }

        public string[] GetFiles(string path)
        {
            GetFilesWasCalled = true;
            return new string[] { "lab1.tmp", "lab2.tmp" };
        }

        public string[] ReadLines(string name)
        {
            ReadLinesWasCalled = true;
            return new string[] { "lab1lab2lab3", "Hello.txt" };
        }
    }
}
