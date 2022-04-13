using System;

namespace Lab2
{
    public interface IFile
    {
        bool CreateFile(string fileName, byte[] data);
        byte[] GetFile(string fileName);
        bool Exist(string path);
        string[] GetFiles(string path);
        bool DeleteFile(string path);
        int Size(string fileName);
        string[] ReadLines(string fileName);
    }
}
