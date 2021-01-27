using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int item = 0;
            while (item != 11)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("{0,25} {1,9}", "Выберите номер задания", "|");
                Console.WriteLine("{0,-10} {1,21}", "1 - 1 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "2 - 2 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "3 - 3 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "4 - 4 задание", "|");
                Console.WriteLine("{0,-10} {1,22}", "5 - 5 задание", " | ");
                Console.WriteLine("{0,-10} {1,21}", "6 - 6 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "7 - 7 задание", "|");
                Console.WriteLine("{0,-10} {1,2}", "8 - 1 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,2}", "9 - 2 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,1}", "10 - 3 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,24}", "11 - выход", "|");
                Console.WriteLine("-----------------------------------");
                int number;
                string input = Console.ReadLine();
                bool res = int.TryParse(input, out number);
                if (res == false)
                {
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 11.");
                }
                else
                {
                    item = int.Parse(input);
                    switch (item)
                    {
                        case 1:
                            Console.WriteLine("1 задание");
                            Console.Write("Введите текст: ");
                            string text1 = Console.ReadLine();
                            Console.WriteLine("(1 способ)");
                            char[] words = text1.ToCharArray(); 
                            bool value1;
                            for (int i = 0; i < words.Length; i++)
                            {
                                value1 = true;
                                for (int j = 0; j < words.Length; j++)
                                {
                                    if (words[i] == words[j] && i != j)
                                    {
                                        value1 = false;
                                        break;
                                    }
                                }
                                if (value1 == true)
                                    Console.Write(words[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("(2 способ)");
                            bool value2;
                            for (int i = 0; i < text1.Length; i++)
                            {
                                value2 = true;
                                for (int j = 0; j < text1.Length; j++)
                                {
                                    if (text1.Substring(i, 1) == text1.Substring(j, 1) && i != j)
                                    {
                                        value2 = false;
                                        break;
                                    }
                                }
                                if (value2 == true)
                                    Console.Write(text1.Substring(i, 1) + " ");
                            }
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine("2 задание");
                            Console.Write("Введите текст: ");
                            string text2 = Console.ReadLine();
                            Console.WriteLine("(1 способ)");
                            string newText = "";
                            int num = 0; // счетчик слов 
                            int t = text2.Length;
                            for (int i = 0; i < t + 1; i++)
                            {
                                newText += text2[i];
                                if (text2[i + 1] == '.')
                                {
                                    num++;
                                    newText += "(" + num + ")" + text2[i + 1]; 
                                    Console.WriteLine(newText);
                                    break;
                                }
                                if (text2[i + 1] == ' ') 
                                {
                                    num++;
                                    newText += "(" + num + ")";
                                    if (text2[i + 2] == '-' || text2[i + 2] == ' ') // проверяем, является ли следующий символ дефисом или пробелом 
                                    {
                                        newText += text2[i + 2]; // если является, сразу добавляем дефис к результирующей строке 
                                        i += 2; 
                                    }
                                }
                            }
                            Console.WriteLine("(2 способ)");
                            string newtext = "";
                            int n = 0; 
                            int T = text2.Length;
                            for (int i = 0; i < t + 1; i++)
                            {
                                newtext += text2.Substring(i, 1);
                                if (text2.Substring(i + 1, 1) == ".") 
                                {
                                    n++;
                                    newtext += "(" + n + ")" + text2.Substring(i + 1, 1);// || 
                                    Console.WriteLine(newtext);
                                    break;
                                }
                                if (text2.Substring(i + 1, 1) == " ") 
                                {
                                    n++;
                                    newtext += "(" + n + ")";
                                    if (text2.Substring(i + 2, 1) == "-" || text2.Substring(i + 2, 1) == " ") // проверяем, является ли следующий символ дефисом или пробелом 
                                    {
                                        newtext += text2.Substring(i + 2, 1); // если является, сразу добавляем дефис или пробел к результирующей строке 
                                        i += 2; 
                                    }
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("3 задание");
                            Console.Write("Введите текст: ");
                            string text3 = Console.ReadLine();
                            Console.WriteLine("(1 способ)");
                            string newt = "";
                            int len = 0; // счетчик символов в слове 
                            for (int i = text3.Length - 1; i > -1; i--) //берем длину строки без точки 
                            {
                                if (text3[i] == ' ') //проверка начала слова 
                                {
                                    for (int j = i + 1; j < i + len; j++) newt += text3[j]; // цикл выполняется len-раз с позиции i 
                                    newt += ' ';
                                    len = 0; // обнуляем счетчик длины слова 
                                }
                                len++;
                            }
                            for (int j = 0; j < len - 1; j++) newt += text3[j]; // печатаем последне(первое в исходной строке) слово с нулевой позиции длиной (len-1) 
                            Console.WriteLine('.' + newt);
                            Console.WriteLine("(2 способ)");
                            string newT = "";
                            int leN = 0;
                            for (int i = text3.Length - 1; i > -1; i--) 
                            {
                                if (text3.Substring(i, 1) == " ") //проверка начала слова 
                                {
                                    newT += text3.Substring(i + 1, leN - 1) + " "; // добавляем слово целиком len- длина слова, 
                                                                                   //прибавляем только слово без пробелов 
                                                                                   //text.Substring(i+1,leN-1),len -длина с учетом пробела, i+1 -индекс начала слова 
                                    leN = 0; // обнуляем счетчик длины слова 
                                }
                                leN++;
                            }
                            newT += text3.Substring(0, leN - 1); // дописываем последнее слово 
                            Console.WriteLine('.' + newT);
                            break;

                        case 4:
                            Console.WriteLine("4 задание");
                            Console.Write("Введите 1 строку: ");
                            string s1 = Console.ReadLine();
                            Console.Write("Введите 2 строку: ");
                            string s2 = Console.ReadLine();
                            Console.Write("Введите 3 строку: ");
                            string s3 = Console.ReadLine();
                            Console.Write("Введите 4 строку: ");
                            string s4 = Console.ReadLine();
                            Console.Write("Введите 5 строку: ");
                            string s5 = Console.ReadLine();
                            Console.Write("Введите 6 строку: ");
                            string s6 = Console.ReadLine();
                            Console.Write("Введите 7 строку: ");
                            string s7 = Console.ReadLine();
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("(1 способ)");
                            string[] text = { s1, s2, s3, s4, s5, s6, s7 };
                            for (int i = 0; i < 7; i++)
                            {
                                string s = text[i];
                                for (int k = 0; k < s.Length - 3; k++)
                                {
                                    if (s[k] == '.')
                                    {
                                        if (s[k + 1] == 'c' && s[k + 2] == 'o' && s[k + 3] == 'm') //проверка на слово с .com 
                                        {
                                            if (k + 3 == s.Length - 1) // если .com в конце строки 
                                            {
                                                Console.WriteLine(s);
                                                break;
                                            };
                                            if (s[k + 4] == ' ' || s[k + 4] == '.' || s[k + 4] == ',') //если .com в середине строки 
                                            {
                                                Console.WriteLine(s);
                                                break;
                                            };
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            string l = text[0];
                            int count = 0;
                            for (int k = 0; k < l.Length; k++)
                            {
                                if (l[k] == ' ')
                                    count++;
                            }
                            int num_str = 1; //считает номер строки с минимальным кол-ом пробелов
                            int num_pr = count; //считает кол-во пробелов
                            count = 0;
                            for (int i = 1; i < text.Length; i++)
                            {
                                l = text[i];
                                for (int k = 0; k < l.Length; k++)
                                {
                                    if (l[k] == ' ')
                                        count++;
                                }
                                if (count < num_pr)
                                {
                                    num_pr = count;
                                    num_str = i + 1;
                                }
                                count = 0;
                            }
                            Console.WriteLine("Номер строки, которая содержит минимальное кол-во пробелов: " + num_str);
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.WriteLine("(2 способ)");
                            string st;
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (text.Length > 3)
                                {
                                    st = text[i];
                                    if (st.Contains(".com ") == true || st.Contains(".com.") == true || st.Contains(".com,") == true)
                                        Console.WriteLine(st);
                                    if (st.Substring(st.Length - 4, 4) == ".com")
                                        Console.WriteLine(st);
                                }
                            }
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            string m = text[0];
                            int cnt = 0;
                            for (int k = 0; k < m.Length; k++)
                            {
                                if (m.Substring(k, 1) == " ")
                                    cnt++;
                            }
                            int num_st = 1; //считает номер строки 
                            int num_p = count; //считает кол-во пробелов
                            cnt = 0;
                            for (int i = 1; i < text.Length; i++)
                            {
                                m = text[i];
                                for (int k = 0; k < m.Length; k++)
                                {
                                    if (m[k] == ' ')
                                        cnt++;
                                }
                                if (cnt < num_p)
                                {
                                    num_p = cnt;
                                    num_st = i + 1;
                                }
                                cnt = 0;
                            }
                            Console.WriteLine("Номер строки, которая содержит минимальное кол-во пробелов: " + num_st);
                            break;

                        case 5:
                            Console.WriteLine("5 задание");
                            Console.Write("Введите текст: ");
                            string text5 = Console.ReadLine();
                            Console.WriteLine("(1 способ)");
                            string[] word = text5.Split(' ', ',', '.', '!', ':', '?', ';');
                            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                            string numbers = "0123456789";
                            for (int i = 0; i < word.Length; i++)
                            {
                                string s = word[i];
                                for (int k = 0; k < 26; k++)
                                {
                                    if (s[0] == alphabet[k])
                                    {
                                        for (int a = 0; a < 10; a++)
                                        {
                                            if (s[s.Length - 2] == numbers[a])
                                            {
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if (s[s.Length - 1] == numbers[j])
                                                    {
                                                        Console.Write(s + " ");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("(2 способ)");
                            Regex reg = new Regex(@"[A-Z]\w+\d\d+");
                            foreach (Match wrd in reg.Matches(text5))
                                Console.Write(wrd + " ");
                            Console.WriteLine();
                            break;

                        case 6:
                            Console.WriteLine("6 задание");
                            Console.Write("Введите пример: ");
                            string example = Console.ReadLine();
                            int[] nums = new int[3];
                            Regex rg = new Regex(@"-?\d+"); 
                            int b = 0;
                            foreach (Match match in rg.Matches(example))
                            {
                                nums[b] = int.Parse(match.Groups[0].Value);
                                b++;
                            }
                            for (int j = 0; j < nums.Length; j++)
                            {
                                Console.WriteLine("Ваше значение: " + nums[j] + " ");
                            }
                            break;

                        case 7:
                            Console.WriteLine("7 задание");
                            Console.WriteLine("-----------------------------------------------------------");
                            string[] tracklist = {"Gentle Giant – Free Hand [6:15]",
                                                  "Supertramp – Child Of Vision [07:27]",
                                                  "Camel – Lawrence [10:46]",
                                                  "Yes – Don’t Kill The Whale [3:55]",
                                                  "10CC – Notell Hotel [04:58]",
                                                  "Nektar – King Of Twilight [4:16]",
                                                  "The Flower Kings – Monsters & Men [21:19]",
                                                  "Focus – Le Clochard [1:59]",
                                                  "Pendragon – Fallen Dream And Angel [5:23]",
                                                  "Kaipa – Remains Of The Day (08:02)" };
                            Console.WriteLine(tracklist[0] + "\n" + tracklist[1] + "\n" + tracklist[2] 
                                               + "\n" + tracklist[3] + "\n" + tracklist[4] + "\n" + tracklist[5] 
                                               + "\n" + tracklist[6] + "\n" + tracklist[7] + "\n" + tracklist[8] + "\n" + tracklist[9]);
                            Console.WriteLine("-----------------------------------------------------------");
                            int sec = 0, min = 0;
                            string sum = "";
                            string[] timesongs = new string[tracklist.Length]; //10 
                            Regex r = new Regex(@"(\d+:\d+)");
                            Regex minreg = new Regex(@"^\d*\d");
                            Regex secreg = new Regex(@"\d*\d$");
                            //вычисляем сумму звучания песен
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                string s = tracklist[i];
                                
                                foreach (Match match in r.Matches(s))
                                    timesongs[i] = match.Groups[0].Value;
                            }
                            string[] minnum = new string[tracklist.Length]; //смотрим минуты
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                foreach (Match match in minreg.Matches(timesongs[i]))
                                    minnum[i] = match.Groups[0].Value;
                            }
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                min += int.Parse(minnum[i]);
                            }
                            string[] secnum = new string[tracklist.Length]; //смотрим секунды
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                foreach (Match match in secreg.Matches(timesongs[i]))
                                    secnum[i] = match.Groups[0].Value;
                            }
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                sec += int.Parse(secnum[i]);
                            }
                            for (; sec > 60; min++)
                            {
                                sec -= 60;
                            }
                            sum += Convert.ToString(min) + ":" + Convert.ToString(sec);
                            Console.WriteLine("Общее время звучания песен : " + sum);
                            Console.WriteLine("-----------------------------------------------------------");
                            //вычисляем пару песен с минимальной разницей в звучании
                            string final = "";
                            int[] time = new int[tracklist.Length];
                            for (int i = 0; i < tracklist.Length; i++) //смотрим минуты
                            {
                                foreach (Match match in minreg.Matches(timesongs[i]))
                                    minnum[i] = match.Groups[0].Value;
                            }
                            for (int i = 0; i < tracklist.Length; i++) //смотрим секунды
                            {
                                foreach (Match match in secreg.Matches(timesongs[i]))
                                    secnum[i] = match.Groups[0].Value;
                            }
                            for (int i = 0; i < tracklist.Length; i++) //смотрим длительность песен
                            {
                                time[i] = int.Parse(secnum[i]);
                                for (; int.Parse(minnum[i]) > 0; minnum[i] = Convert.ToString(int.Parse(minnum[i]) - 1))
                                {
                                    time[i] += 60;
                                }
                            }
                            string song1 = "", song2 = "";
                            for (int i = 0; i < time.Length; i++)
                            {
                                for (int k = 0; k < time.Length; k++)
                                {
                                    if (k != i)
                                    {
                                        int min2 = time[i] - time[k];
                                        if (min2 < min && min2 > 0)
                                        {
                                            min = min2;
                                            song1 = tracklist[i];
                                            song2 = tracklist[k];
                                        }
                                    }
                                }
                            }
                            final = song1 + "\n" + song2;
                            Console.WriteLine("Песни с минимальной разницей звучания: " + "\n" + final);
                            Console.WriteLine("-----------------------------------------------------------");
                            //вычисляем самую длинную и короткую песни
                            string[] Time = new string[tracklist.Length];
                            string[] minuteNum = new string[tracklist.Length];
                            string[] secondNum = new string[tracklist.Length];
                            int[] timeAll = new int[tracklist.Length];
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                foreach (Match match in r.Matches(tracklist[i]))
                                {
                                    Time[i] = match.Groups[0].Value;
                                }
                            }
                            for (int i = 0; i < tracklist.Length; i++) //смотрим минуты
                            {
                                foreach (Match match in minreg.Matches(Time[i]))
                                {
                                    minuteNum[i] = match.Groups[0].Value;
                                }
                            }
                            for (int i = 0; i < tracklist.Length; i++) //смотрим секунды
                            {
                                foreach (Match match in secreg.Matches(Time[i]))
                                {
                                    secondNum[i] = match.Groups[0].Value;
                                }
                            }
                            for (int i = 0; i < tracklist.Length; i++)
                            {
                                timeAll[i] = int.Parse(secondNum[i]);
                                while (int.Parse(minuteNum[i]) > 0)
                                {
                                    minuteNum[i] = Convert.ToString(int.Parse(minuteNum[i]) - 1);
                                    timeAll[i] += 60;
                                }
                            }
                            for (int i = 0; i < timeAll.Length; i++)
                            {
                                if (timeAll[i] == timeAll.Min())
                                {
                                    Console.WriteLine("Cамая короткая песня песня: " + tracklist[i]);
                                }
                            }
                            for (int i = 0; i < timeAll.Length; i++)
                            {
                                if (timeAll[i] == timeAll.Max())
                                {
                                    Console.WriteLine("Cамая длинная песня: " + tracklist[i]);
                                }
                            }
                            break;

                        case 8:
                            Console.WriteLine("1 индивидуальное");
                            Console.WriteLine("-ШИФР ПРОСТОЙ ОДИНАРНОЙ ПЕРЕСТАНОВКИ-");
                            Console.WriteLine("Введите слово из 11 символов");
                            string word3 = Console.ReadLine();
                            string key3 = "5 6 8 3 10 9 4 7 2 11 1";
                            Console.WriteLine("Зашифрованное слово: " + (Transposition(word3, key3)));
                            Console.WriteLine("Раcшифрованное слово: " + (DeTransposition(Transposition(word3, key3), key3)));
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("-ШИФР ВИЖЕНЕРА-");
                            Console.WriteLine("Введите текст на английском");
                            string word8 = Console.ReadLine();
                            string key8 = "code";
                            Console.WriteLine("Зашифрованный текст: " + (Vigenere(word8, key8)));
                            Console.WriteLine("Раcшифрованный текст: " + (DeVigenere(Vigenere(word8, key8), key8)));
                            break;

                        case 9:
                            Console.WriteLine("2 индивидуальное (6 вариант)");
                            Console.Write("Введите текст: ");
                            string text9 = Console.ReadLine();
                            Console.WriteLine("(1 способ)");
                            string newtext9 = "";
                            for (int i = 0; i < text9.Length; i++)
                            {
                                if (i == 0 && text9[0] == 'O')
                                {
                                    if (text9[i + 1] == 'R')
                                    {
                                        if (i == text9.Length - 2)
                                        {
                                            newtext9 += "|";
                                            i += 2;
                                        }
                                        else if (text9[i + 2] == ' ')
                                        {
                                            newtext9 += "|";
                                            i += 2;
                                        }
                                        else
                                            newtext9 += text9[i];
                                    }
                                }
                                if (i == 0 && text9[0] == 'A')
                                {
                                    if (text9[i + 1] == 'N')
                                    {
                                        if (text9[i + 2] == 'D')
                                        {
                                            if (i == text9.Length - 3)
                                            {
                                                newtext9 += "&";
                                                i += 3;
                                            }
                                            else if (text9[i + 3] == ' ')
                                            {
                                                newtext9 += "&";
                                                i += 3;
                                            }
                                            else
                                                newtext9 += text9[i];
                                        }
                                    }
                                }
                                if (text9[i] == ' ')
                                {
                                    if (text9[i + 1] == 'O' && i < text9.Length - 2)
                                    {
                                        if (text9[i + 2] == 'R')
                                        {
                                            if (i == text9.Length - 3)
                                            {
                                                newtext9 += " | ";
                                                i += 3;
                                            }
                                            else if (text9[i + 3] == ' ')
                                            {
                                                newtext9 += " | ";
                                                i += 3;
                                            }
                                            else
                                                newtext9 += text9[i];
                                        }
                                    }
                                    else if (text9[i + 1] == 'A' && i < text9.Length - 3)
                                    {
                                        if (text9[i + 2] == 'N')
                                        {
                                            if (text9[i + 3] == 'D')
                                            {
                                                if (i == text9.Length - 4)
                                                {
                                                    newtext9 += " & ";
                                                    i += 4;
                                                }
                                                else if (text9[i + 4] == ' ')
                                                {
                                                    newtext9 += " & ";
                                                    i += 4;
                                                }
                                                else
                                                    newtext9 += text9[i];
                                            }
                                        }
                                    }
                                    else
                                        newtext9 += text9[i];
                                }
                                else
                                    newtext9 += text9[i];
                            }
                            Console.WriteLine(newtext9);
                            Console.WriteLine("(2 способ)");
                            string newText9 = text9.Replace(" AND ", " & ").Replace(" OR ", " | ");
                            Console.WriteLine(newText9);
                            break;

                        case 10:
                            Console.WriteLine("3 индивидуальное (6 вариант)");
                            Console.Write("Введите текст: ");
                            Regex regs = new Regex(@"\w*:\s*(int|short|byte)\s*\[{1}\d*\]{1}");
                            string teXt = Console.ReadLine();
                            foreach (Match substr in regs.Matches(teXt))
                                Console.Write(substr + " ");
                            Console.WriteLine();
                            break;

                        case 11:
                            Console.WriteLine("Работа завершена.");
                            break;

                        default:
                            Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 11.");
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
        //к 1 индивидуальному
        static string Transposition(string input, string key3)
        {
            string result = "";
            string[] Key = key3.Split(' ');
            for (int i = 0; i < Key.Length; i++)
                result += input[int.Parse(Key[i]) - 1];
            return result;
        }
        static string DeTransposition(string input, string key3)
        {
            string result = "";
            string[] Key = key3.Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Key.Length; j++)
                {
                    if (int.Parse(Key[j]) == i + 1)
                    {
                        result += input[j];
                        break;
                    }
                }
            }
            return result;
        }
        static string Vigenere(string input, string key8)
        {
            int bias = (int)'a';
            int n = 26;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int num = (input[i] + key8[i % key8.Length] - 2 * bias) % n;
                char elem = (char)(num + bias);
                result.Append(elem);
            }
            return result.ToString();
        }
        static string DeVigenere(string input, string key8)
        {
            int bias = (int)'a';
            int n = 26;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int num = (input[i] - key8[i % key8.Length] + n) % n;
                char Elem = (char)(num + bias);
                result.Append(Elem);
            }
            return result.ToString();
        }
    }
}
