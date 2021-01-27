using System;
using System.IO;

namespace _6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите название файла: ");
            string name = Console.ReadLine() + ".bmp";
            string path = @"C:\Pr\" + name;
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            BinaryReader bmp = new BinaryReader(file);
            string comprName = "";
            switch (BmpFile(file, bmp, 30))
            {
                case 0:
                    comprName = "BI_RGB";
                    break;
                case 1:
                    comprName = "BI_RLE8";
                    break;
                case 2:
                    comprName = "BI_RLE4";
                    break;
            }
            Console.WriteLine("Размер файла: " + BmpFile(file, bmp, 2) / 1024);
            Console.WriteLine("Ширина в пикселях: " + BmpFile(file, bmp, 18));
            Console.WriteLine("Высота в пикселях: " + BmpFile(file, bmp, 22));
            Console.WriteLine("Количество бит на пиксель: " + BmpFile(file, bmp, 28));
            Console.WriteLine("Горизонтальное разрешение: " + BmpFile(file, bmp, 38));
            Console.WriteLine("Вертикальное разрешение: " + BmpFile(file, bmp, 42));
            Console.WriteLine("Тип сжатия: " + comprName);
            bmp.Close();

        }
        public static int BmpFile(FileStream file, BinaryReader bmp, int seek)
        {
            int i = 0;
            short s = 0;
            file.Seek(seek, SeekOrigin.Begin);
            if (seek == 0 || seek == 6 || seek == 8 || seek == 26 || seek == 28)
            {
                s = bmp.ReadInt16();
                return s;
            }
            else
            {
                i = bmp.ReadInt32();
                return i;
            }

        }
    }
}
