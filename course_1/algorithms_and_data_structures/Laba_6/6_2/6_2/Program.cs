using System;
using System.IO;

namespace _6_2
{
    class Program

    {
        static void Main(string[] args)
        {
            string path1 = @"C:\PR\11.dat";
            string path2 = @"C:\PR\12.dat";
            Console.WriteLine("Подождите...");
            double[] arrayLogs = new double[128];
            try
            {
                WriteLogs(path1);
                ReadLogs(arrayLogs, path1);
                WriteFile(arrayLogs, path2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteLogs(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(filestream);
            for (int n = 1; n <= 128; n++)
            {
                double N = Math.Log(n, 2);
                Console.Write(n + " - " + N + "\n");
                writer.Write(n);
                writer.Write(N);
            }
            writer.Close();
            filestream.Close();
        }
        public static void ReadLogs(double[] a, string path)
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryReader reader = new BinaryReader(filestream);
            for (int i = 0; i < 128; i++)
            {
                filestream.Seek(4, SeekOrigin.Current);
                a[i] = reader.ReadDouble();
            }
            reader.Close();
        }
        public static void WriteFile(double[] a, string path)
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(filestream);
            for (int i = 0; i < 128; i++)
            {
                writer.Write(a[i] + "\n");
            }
            writer.Close();
            filestream.Close();
        }
    }
}


