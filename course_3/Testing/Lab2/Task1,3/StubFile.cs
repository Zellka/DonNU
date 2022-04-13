using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab2
{
    public class StubFile : IFile
    {
        private readonly string[] dirs;
        private readonly string[] files;
        private readonly byte[][] data;

        private const int count = 3;

        private readonly string _toRemove;
        private readonly string[] removeData;

        public StubFile()
        {
            string path = Path.Combine("C:", "Lab2", "Tests");

            dirs = new[] { Path.Combine("C:", "Lab2", "Tests"), Path.Combine("C:") };
            files = new string[count] { "Lab1.tmp", "Lab2.tmp", "Lab3.tmp" };
            data = new byte[count][] { Encoding.UTF8.GetBytes("1111"), Encoding.UTF8.GetBytes("2222"), Encoding.UTF8.GetBytes("3333") };

            _toRemove = Path.Combine("C:", "Lab2", "Tests", "ToRemove.txt");
            removeData = new string[count + 1] { Path.Combine(path,files[0]), Path.Combine(path, files[1]),  Path.Combine(path, files[2]),"Hello.txt"};
        }
        public bool Exist(string path)
        {
            if (path == "Hello.txt") return false;

            foreach (string d in dirs)
            {
                if (d == path)  return true;
            }

            foreach (string f in files)
            {
                if (f == path) return true;
            }

            foreach (string f in removeData)
            {
                if (f == path) return true;
            }

            if (path == _toRemove)
            {
                return true;
            }

            return false;
        }

        public string[] GetFiles(string path)
        {
            if (path == Path.Combine("C:", "Lab2", "Tests"))
                return files;
            return new string[] { };
        }

        public byte[] GetFile(string file)
        {
            for (int i = 0; i < count; i++)
            {
                if (files[i] == file) return data[i];
            }
            return null;
        }

        public bool DeleteFile(string file)
        {
            for (int i = 0; i < count; i++)
            {
                if (files[i] == Path.GetFileName(file))
                {
                    data[i] = null;
                    files[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool CreateFile(string name, byte[] data)
        {
            for (int i = 0; i < count; i++)
            {
                if (files[i] == name) return false;
            }
            return true;
        }

        public int Size(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (files[i] == Path.GetFileName(name))
                    return files[i].Length;
            }
            return 0;
        }

        public string[] ReadLines(string name)
        {
            if (_toRemove == name) return removeData;

            return null;
        }
    }
}
