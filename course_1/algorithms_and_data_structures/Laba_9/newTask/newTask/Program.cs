using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace newTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Pr\слова.txt";
            string[] words = ReadFile(path);
            Dictionary<string, int> freqDict = new Dictionary<string, int>();
            DictFilling(freqDict, words);
            SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>(freqDict);
            TenMostCommon(sortedDict);
        }
        public static string[] ReadFile(string path)
        {
            StreamReader fileRead = new StreamReader(path);
            string text = fileRead.ReadToEnd();
            string[] words = text.Split(' ');
            fileRead.Close();
            return words;
        }
        public static void DictFilling(Dictionary<string, int> freqDict, string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (freqDict.ContainsKey(words[i]))
                {
                    int value = freqDict[words[i]];
                    freqDict[words[i]] = value + 1;
                }
                else
                    freqDict.Add(words[i], 1);
            }
        }
        public static void TenMostCommon(SortedDictionary<string, int> sortedDict)
        {
            Console.WriteLine("10 наиболее встречаемых слов в файле");
            foreach (KeyValuePair<string, int> kvp in sortedDict.OrderByDescending(key => key.Value).Take(10))
                Console.WriteLine(kvp.Key + " " + kvp.Value);
        }
    }
}
