using System;
using System.IO;


namespace _6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            string path1 = @"C:\Pr\1.txt";
            string path2 = @"C:\Pr\2.txt";
            string correct = "";
            int count = 0;
            try
            {
                WriteText(text, path1);
                correct = ReadText(correct, path1, count);
                WriteNewText(correct, path2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public static void WriteText(string text, string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(filestream);
            writer.WriteLine(text);
            writer.Close();
            filestream.Close();
        }
        public static string ReadText(string correct, string path, int k)
        {
            FileStream filestream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(filestream);
            string t = reader.ReadToEnd();
            char[] s = t.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsUpper(s[i]))
                {
                    s[i] = char.ToLower(s[i]);
                    k++;
                }
                correct += s[i];
            }
            Console.WriteLine("Мы всё исправили: " + correct);
            Console.WriteLine("Кол-во замен: " + k);
            reader.Close();
            filestream.Close();
            return correct;
        }
        public static void WriteNewText(string correct, string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(filestream);
            writer.Write(correct);
            writer.Close();
            filestream.Close();
        }
    }
}
