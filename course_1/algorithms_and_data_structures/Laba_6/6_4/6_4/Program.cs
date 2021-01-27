using System;
using System.IO;

namespace _6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathDir = @"C:\Pr\Lab6_Temp";
            string path = @"C:\Pr\lab.dat";
            string newpath = @"C:\Pr\Lab6_Temp\lab_backup.dat";
            Directory.CreateDirectory(pathDir);
            FileInfo file = new FileInfo(path);
            FileCopy(path, newpath);
            Console.WriteLine("Размер файла: " + file.Length);
            Console.WriteLine("Время последнего изменения: " + file.LastWriteTime);
            Console.WriteLine("Время последнего доступа: " + file.LastAccessTime);
        }
        public static void FileCopy(string path, string newpath)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            BinaryWriter writer = new BinaryWriter(File.Open(newpath, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                byte data = reader.ReadByte();
                writer.Write(data);
            }
            reader.Close();
            writer.Close();
        }

    }
}
