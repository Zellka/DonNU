using System;
using System.IO;

namespace _7_1
{
    class Program
    {
        public enum Type
        {
            З,
            Б
        }
        public struct Village
        {
            public string Name;
            public Type Type;
            public double Area;
            public double Harvest;
        }
        public const int ViewTable = 1;
        public const int AddNote = 2;
        public const int DeleteNote = 3;
        public const int UpdateNote = 4;
        public const int SearchNote = 5;
        public const int SortTable = 6;
        public const int ViewLog = 7;
        public const int Exit = 8;
        public enum Operations
        {
            ADD = 1,
            DELETE,
            UPDATE
        }
        public struct Logo
        {
            public DateTime time;
            public Operations action;
            public string line;
        }

        static void Main(string[] args)
        {
            int size = 3;
            int choice = 0;
            Village[] agro = new Village[10];
            Village line = new Village { };
            Table(agro, line);
            Logo[] log = new Logo[50];
            int countLog = 0;
            string path = @"C:\Pr\lab.dat";
            ReadFile(path);
            while (choice != 8)
            {
                PrintMenu();
                int number;
                string input = Console.ReadLine();
                bool res = int.TryParse(input, out number);
                if (res == false)
                {
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 8.");
                }
                else
                {
                    choice = int.Parse(input);
                    switch (choice)
                    {
                        case ViewTable:
                            Clean();
                            ViewTbl(agro, size);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case AddNote:
                            Clean();
                            size = Add(agro, line, size);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case DeleteNote:
                            Clean();
                            size = Delete(agro, size);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case UpdateNote:
                            Clean();
                            Update(agro, line, size);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case SearchNote:
                            Clean();
                            int count = 0;
                            count = Search(agro, size, count);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case SortTable:
                            Clean();
                            ChoiceSort(agro, size);
                            ViewTbl(agro, size);
                            countLog = Log(log, countLog, choice, agro, size);
                            break;

                        case ViewLog:
                            Clean();
                            countLog = Log(log, countLog, choice, agro, size);
                            ViewLg(log, countLog);
                            break;

                        case Exit:
                            Clean();
                            WriteFile(path, agro, size);
                            break;

                        default:
                            Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 8.");
                            break;
                    }
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("{0,18} {1,7}", "Выберите пункт", "|");
            Console.WriteLine("{0,-10} {1,5}", "1 - Просмотр таблицы", "|");
            Console.WriteLine("{0,-10} {1,6}", "2 - Добавить запись", "|");
            Console.WriteLine("{0,-10} {1,7}", "3 - Удалить запись", "|");
            Console.WriteLine("{0,-10} {1,6}", "4 - Oбновить запись", "|");
            Console.WriteLine("{0,-10} {1,8}", "5 - Поиск записей", "|");
            Console.WriteLine("{0,-10} {1,10}", "6 - Сортировать", "|");
            Console.WriteLine("{0,-10} {1,6}", "7 - Просмотреть лог", "|");
            Console.WriteLine("{0,-10} {1,15}", "8 - Выход", "|");
            Console.WriteLine("-------------------------");
        }

        public static void Table(Village[] vil, Village ln)
        {
            ln.Name = "Соя";
            ln.Type = Type.Б;
            ln.Area = 13000;
            ln.Harvest = 45;
            vil[0] = ln;
            ln.Name = "Чумиза";
            ln.Type = Type.З;
            ln.Area = 8000;
            ln.Harvest = 17;
            vil[1] = ln;
            ln.Name = "Рис";
            ln.Type = Type.З;
            ln.Area = 25650;
            ln.Harvest = 24;
            vil[2] = ln;
        }
        public static void ReadFile(string path)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Create));
            while (reader.PeekChar() > -1)
            {
                string Name = reader.ReadString();
                string type = reader.ReadString();
                Type Type;
                if (type == "З")
                    Type = Type.З;
                else
                    Type = Type.Б;
                double Area = reader.ReadDouble();
                double Harvest = reader.ReadDouble();
                Village vlg;
                vlg.Name = Name; vlg.Type = Type; vlg.Area = Area; vlg.Harvest = Harvest;
            }
            reader.Close();
        }
        public static void WriteFile(string path, Village[] vil, int n)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            for (int i = 0; i < n; i++)
            {
                writer.Write(vil[i].Name + " - " + vil[i].Type + " - " + vil[i].Area + " - " + vil[i].Harvest + "\n");
            }
            writer.Close();
        }
        public static void ViewTbl(Village[] vil, int n)
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8} ", "Наименование", "Тип", "Площадь (га)", "Урожайность", "*");
            Console.WriteLine("*************************************************************************");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8}", vil[i].Name, vil[i].Type, vil[i].Area, vil[i].Harvest, "*");
            }
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,29}", "Перечисляемый тип: З - зерновые, Б-бобовые", "*");
            Console.WriteLine("*************************************************************************");
        }


        public static int Add(Village[] vil, Village ln, int n)
        {
            Console.WriteLine("Введите наименование сельскохозяйственной культуры");
            ln.Name = Console.ReadLine();
        Mark1:
            Console.WriteLine("Введите тип сельскохозяйственной культуры. З - зерновые, Б-бобовые");
            string text1 = Console.ReadLine();
            if (text1 != "Б" && text1 != "З")
            {
                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести Б или З");
                goto Mark1;
            }
        Mark2:
            Console.WriteLine("Введите величину посевной площади в га");
            try
            {
                ln.Area = double.Parse(Console.ReadLine());
                if (ln.Area <= 0)
                {
                    Console.WriteLine("Ошибка.Попробуйте ещё раз.");
                    goto Mark2;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                goto Mark2;
            }
        Mark3:
            Console.WriteLine("Введите размер урожая");
            try
            {
                ln.Harvest = double.Parse(Console.ReadLine());
                if (ln.Harvest < 0)
                {
                    Console.WriteLine("Ошибка.Такого не может быть. Попробуйте ещё раз.");
                    goto Mark3;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                goto Mark3;
            }
            n++;
            vil[n - 1] = ln;
            Console.WriteLine("Строка " + n + " добавлена в таблицу");
            return n;
        }


        public static int Delete(Village[] vil, int n)
        {
        Mark4:
            Console.WriteLine("Введите номер строки, которую хотите удалить");
            string input2 = Console.ReadLine();
            int delNum;
            int number2;
            bool res2 = int.TryParse(input2, out number2);
            if (res2 == false)
            {
                Console.WriteLine("Ошибка. Вы ввели неправильное значение.");
                goto Mark4;
            }
            else
            {
                delNum = int.Parse(input2);
                if (delNum > n || delNum <= 0)
                {
                    Console.WriteLine("Ошибка. Строки с таким номером нет.");
                    goto Mark4;
                }
                else
                {
                    for (int i = delNum - 1; i < n - 1; i++)
                        vil[i] = vil[i + 1];
                    n--;
                }
                Console.WriteLine("Строка " + delNum + " удалена");
            }
            return n;
        }

        public static void Update(Village[] vil, Village ln, int n)
        {
        Mark5:
            Console.WriteLine("Введите номер строки, которую хотите изменить");
            int number3;
            int upNum;
            string input3 = Console.ReadLine();
            bool res3 = int.TryParse(input3, out number3);
            if (res3 == false)
            {
                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Попробуйте ещё раз.");
                goto Mark5;
            }
            else
            {
                upNum = int.Parse(input3);
                if (upNum <= 0 || upNum > n)
                {
                    Console.WriteLine("Ошибка. Строки с таким номером нет. Попробуйте ещё раз.");
                    goto Mark5;
                }
                else
                {
                    Console.WriteLine("************************************************************************");
                    Console.WriteLine("{0,-5} {1,10} {2,20} {3,15}", vil[upNum - 1].Name, vil[upNum - 1].Type, vil[upNum - 1].Area, vil[upNum - 1].Harvest);
                    Console.WriteLine("************************************************************************");
                    Console.WriteLine("Введите новое наименование сельскохозяйственной культуры");
                    ln.Name = Console.ReadLine();
                    Console.WriteLine("Введите новый тип сельскохозяйственной культуры");
                Mark6:
                    string text2 = Console.ReadLine();
                    if (text2 != "Б" && text2 != "З")
                    {
                        Console.WriteLine("Ошибка. Вы ввели неправильное значение.Попробуйте ещё раз. Рекомендуем ввести Б или З");
                        goto Mark6;
                    }
                Mark7:
                    Console.WriteLine("Введите новую величину посевной площади в га");
                    try
                    {
                        ln.Area = double.Parse(Console.ReadLine());
                        if (ln.Area <= 0)
                        {
                            Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                            goto Mark7;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                        goto Mark7;
                    }
                Mark8:
                    Console.WriteLine("Введите новый размер урожая");
                    try
                    {
                        ln.Harvest = double.Parse(Console.ReadLine());
                        if (ln.Harvest < 0)
                        {
                            Console.WriteLine("Ошибка.Такого не может быть. Попробуйте ещё раз.");
                            goto Mark8;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                        goto Mark8;
                    }
                }
                vil[upNum - 1] = ln;
                Console.WriteLine("Строка " + upNum + " обновлена");
            }
        }

        public static int Search(Village[] vil, int n, int count)
        {
            Type tp;
        Mark9:
            Console.WriteLine("Введите тип сельскохозяйственной культуры. З - зерновые, Б-бобовые");
            string srchTxt = Console.ReadLine();
            tp = (Type)Enum.Parse(typeof(Type), srchTxt);
            if (srchTxt != "Б" && srchTxt != "З")
            {
                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Попробуйте ещё раз. Рекомендуем ввести Б или З");
                goto Mark9;
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("{0,15} {1,10} {2,20} {3,15}", "Наименование", "Тип", "Площадь (га)", "Урожайность");
            Console.WriteLine("----------------------------------------------------------------------");
            for (int i = 0; i < n; i++)
            {
                if (vil[i].Type == tp)
                {
                    Console.WriteLine("{0,15} {1,10} {2,20} {3,15}", vil[i].Name, vil[i].Type, vil[i].Area, vil[i].Harvest);
                    count++;
                }
            }
            Console.WriteLine("----------------------------------------------------------------------");
            return count;
        }
        public static void ChoiceSort(Village[] agro, int size)
        {
            Console.WriteLine("Выберите ключ сортировки: ");
            Console.WriteLine("1 - Сортировка по размеру урожая");
            Console.WriteLine("2 - Сортировка по размеру площади");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    SortHarvest(agro, size);
                    break;
                case 2:
                    SortArea(agro, size);
                    break;
                default:
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение.");
                    break;
            }
        }
        public static Village[] SortHarvest(Village[] agro, int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (agro[j].Harvest < agro[min].Harvest)
                    {
                        min = j;
                    }
                }
                var tmp = agro[min];
                agro[min] = agro[i];
                agro[i] = tmp;
            }
            return agro;
        }
        public static Village[] SortArea(Village[] agro, int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (agro[j].Area < agro[min].Area)
                    {
                        min = j;
                    }
                }
                var tmp = agro[min];
                agro[min] = agro[i];
                agro[i] = tmp;
            }
            return agro;
        }
        public static int Log(Logo[] log, int l, int choice, Village[] vil, int n)
        {
            log[l].time = DateTime.Now;
            switch (choice)
            {
                case 1:
                    log[l].line = "Просмотр таблицы завершён";
                    break;
                case 2:
                    log[l].action = Operations.ADD;
                    log[l].line = "Строка " + n + " добавлена в таблицу";
                    break;
                case 3:
                    log[l].action = Operations.DELETE;
                    log[l].line = "Строка удалена";
                    break;
                case 4:
                    log[l].action = Operations.UPDATE;
                    log[l].line = "Строка обновлена";
                    break;
                case 5:
                    int count = 0;
                    count = Search(vil, n, count);
                    log[l].line = "Найдено: " + count + Str(count);
                    break;
                case 6:
                    log[l].line = "Таблица отсортирована";
                    break;
                case 7:
                    log[l].line = "Лог просмотрен";
                    break;
                default:
                    break;
            }
            l++;
            return l;
        }
        public static void ViewLg(Logo[] log, int l)
        {
            TimeSpan tmp, result;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("{0,30}", "Просмотр лога");
            for (int k = 0; k < l; k++)
            {
                Console.WriteLine("{0,10} {2,2} {1,8}", log[k].time, log[k].line, " - ");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            result = log[1].time - log[0].time;
            for (int k = 1; k < l; k++)
            {
                tmp = log[k + 1].time - log[k].time;
                if (tmp > result)
                    result = tmp;
            }
            Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", result.Hours, result.Minutes, result.Seconds + " - Самый долгий период бездействия пользователя");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        
        public static string Str(int x) //подбирает правильное окончание к слову "строка"
        {
            string s;
            int a = x % 10;
            int b = x % 100;
            if (a == 1 && b != 11)
                s = " строка";
            else if (a > 1 && a < 5 && b < 10 || b > 21)
                s = " строки";
            else
                s = " строк";
            return s;
        }

        public static void Clean()
        {
            Console.Clear();
        }

    }
}
