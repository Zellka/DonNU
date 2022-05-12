using System;
using System.IO;

namespace Laba7.Core
{
    internal class FileReader
    {
        private string path;

        public FileReader(string path)
        {
            this.path = path;
        }
        public string[] ReadFile()
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == ',')
                    {
                        lines[i] = lines[i].Insert(j, " ");
                        lines[i] = lines[i].Insert(j + 2, " ");
                        j++;
                    }
                }
                string[] words = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < words.Length; k++)
                    words[k] = words[k].ToUpper();
                lines[i] = string.Join(" ", words);              
            }
            return lines;
        }
    }
}
