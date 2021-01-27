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
            //file.Seek(2, SeekOrigin.Begin);
            //int size = bmp.ReadInt32();
            //file.Seek(12, SeekOrigin.Current);
            //int width = bmp.ReadInt32();
            //int height = bmp.ReadInt32();
            //file.Seek(2, SeekOrigin.Current);
            //short numBt = bmp.ReadInt16();
            //int compr = bmp.ReadInt32();
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
            //file.Seek(4, SeekOrigin.Current);
            //int horRes = bmp.ReadInt32();
            //int verRes = bmp.ReadInt32();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,14} {2,10} {3,6}", "Размер файла: ", "|", BmpFile(file, bmp, 2) / 1024, "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,9} {2,10} {3,6}", "Ширина в пикселях: ", "|", BmpFile(file, bmp, 18), "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,9} {2,10} {3,6}", "Высота в пикселях: ", "|", BmpFile(file, bmp, 22), "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,1} {2,10} {3,6}", "Количество бит на пиксель: ", "|", BmpFile(file, bmp, 28), "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,1} {2,10} {3,6}", "Горизонтальное разрешение: ", "|", BmpFile(file, bmp, 38), "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,3} {2,10} {3,6}", "Вертикальное разрешение: ", "|", BmpFile(file, bmp, 42), "|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-10} {1,16} {2,10} {3,6}", "Тип сжатия: ", "|", comprName, "|");
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
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
