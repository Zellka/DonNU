using System;

namespace ConsoleApp1
{
    class Program
    {
        public enum Type
        {
            З = 1,
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
        public const int ViewLog = 6;
        public const int Exit = 7;
        public enum Operations
        {
            ADD=1,
            DELETE,
            UPDATE
        }
        public struct Logo
        {
            public DateTime time;
            public Operations action;
            public string line;
        }
        static string Str (int x)
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
        static void Main(string[] args)
        {
            int n = 3; //начальная таблица из 3-х строк
            Village[] vil = new Village[10];
            Village ln;
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

            int l = 0; //счётчик логов
            Logo[] log = new Logo[50];

            int item = 0;
            while (item != 7)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------");
                Console.WriteLine("{0,18} {1,7}", "Выберите пункт", "|") ;
                Console.WriteLine("{0,-10} {1,5}", "1 - Просмотр таблицы", "|");
                Console.WriteLine("{0,-10} {1,6}", "2 - Добавить запись", "|");
                Console.WriteLine("{0,-10} {1,7}", "3 - Удалить запись", "|");
                Console.WriteLine("{0,-10} {1,6}", "4 - Oбновить запись", "|");
                Console.WriteLine("{0,-10} {1,8}", "5 - Поиск записей", "|");
                Console.WriteLine("{0,-10} {1,6}", "6 - Просмотреть лог", "|");
                Console.WriteLine("{0,-10} {1,15}", "7 - Выход", "|");
                Console.WriteLine("-------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                int number;
                string input = Console.ReadLine();
                bool res = int.TryParse(input, out number);
                Type tp;
                if (res == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 7.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                else
                {
                    item = int.Parse(input);
                    switch (item)
                    {
                        case ViewTable:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                            Console.ForegroundColor = ConsoleColor.White;
                            log[l].time = DateTime.Now;
                            log[l].line = "Просмотр таблицы завершён";
                            l++;
                            break;
                            
                        case AddNote:
                            Console.WriteLine("Введите наименование сельскохозяйственной культуры");
                            ln.Name = Console.ReadLine();
                        Mark1:
                            Console.WriteLine("Введите тип сельскохозяйственной культуры. З - зерновые, Б-бобовые");
                            string text1 = Console.ReadLine();
                            tp = (Type)Enum.Parse(typeof(Type), text1);
                            if (text1 != "Б" && text1 != "З")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести Б или З");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto Mark1;
                            }
                        Mark2:
                            Console.WriteLine("Введите величину посевной площади в га");
                            try
                            {
                                ln.Area = double.Parse(Console.ReadLine());
                                if (ln.Area <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка.Попробуйте ещё раз.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    goto Mark2;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto Mark2;
                            }
                        Mark3:
                            Console.WriteLine("Введите размер урожая");
                            try
                            {
                                ln.Harvest = double.Parse(Console.ReadLine());
                                if (ln.Harvest < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка.Такого не может быть. Попробуйте ещё раз.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    goto Mark3;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto Mark3;
                            }
                            n++;
                            vil[n - 1] = ln;
                            Console.WriteLine("Строка " + n +  " добавлена в таблицу");
                            log[l].time = DateTime.Now;
                            log[l].action = Operations.ADD;
                            log[l].line = "Строка " + n + " добавлена в таблицу";
                            l++;
                            break;

                        case DeleteNote:
                        Mark4:
                            Console.WriteLine("Введите номер строки, которую хотите удалить");
                            int number2;
                            int delNum = 0;
                            string input2 = Console.ReadLine();
                            bool res2 = int.TryParse(input2, out number2);
                            if (res2 == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели неправильное значение.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                delNum = int.Parse(input2);
                                if (delNum > n || delNum <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка. Строки с таким номером нет.");
                                    Console.ForegroundColor = ConsoleColor.White;
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
                            log[l].time = DateTime.Now;
                            log[l].action = Operations.DELETE;
                            log[l].line = "Строка " + delNum + " удалена";
                            l++;
                            break;

                        case UpdateNote:
                        Mark5:
                            Console.WriteLine("Введите номер строки, которую хотите изменить");
                            int number3;
                            int upNum = 0;
                            string input3 = Console.ReadLine();
                            bool res3 = int.TryParse(input3, out number3);
                            if (res3 == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Попробуйте ещё раз.");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto Mark5;
                            }
                            else
                            {
                                upNum = int.Parse(input3);
                                if (upNum <= 0 || upNum > n)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка. Строки с таким номером нет. Попробуйте ещё раз.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    goto Mark5;
                                }
                                else
                                {
                                    //Выводим старую строку
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("************************************************************************");
                                    Console.WriteLine("{0,-5} {1,10} {2,20} {3,15}", vil[upNum - 1].Name, vil[upNum - 1].Type, vil[upNum - 1].Area, vil[upNum - 1].Harvest);
                                    Console.WriteLine("************************************************************************");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Введите новое наименование сельскохозяйственной культуры");
                                    //Вводим новые данные в строку
                                    ln.Name = Console.ReadLine();
                                    Console.WriteLine("Введите новый тип сельскохозяйственной культуры");
                                Mark6:
                                    string text2 = Console.ReadLine();
                                    tp = (Type)Enum.Parse(typeof(Type), text2);
                                    if (text2 != "Б" && text2 != "З")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка. Вы ввели неправильное значение.Попробуйте ещё раз. Рекомендуем ввести Б или З");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        goto Mark6;
                                    }
                                Mark7:
                                    Console.WriteLine("Введите новую величину посевной площади в га");
                                    try
                                    {
                                        ln.Area = double.Parse(Console.ReadLine());
                                        if (ln.Area <= 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            goto Mark7;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        goto Mark7;
                                    }
                                Mark8:
                                    Console.WriteLine("Введите новый размер урожая");
                                    try
                                    {
                                        ln.Harvest = double.Parse(Console.ReadLine());
                                        if (ln.Harvest < 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Ошибка.Такого не может быть. Попробуйте ещё раз.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            goto Mark8;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка. Вы ввели не число. Попробуйте ещё раз.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        goto Mark8;
                                    }
                                }
                                vil[upNum - 1] = ln;
                                Console.WriteLine("Строка " + upNum + " обновлена");
                            }
                            log[l].time = DateTime.Now;
                            log[l].action = Operations.UPDATE;
                            log[l].line = "Строка " + upNum + " обновлена";
                            l++;
                            break;

                        case SearchNote:
                        Mark9:
                            Console.WriteLine("Введите тип сельскохозяйственной культуры. З - зерновые, Б-бобовые");
                            string srchTxt = Console.ReadLine();
                            tp = (Type)Enum.Parse(typeof(Type), srchTxt);
                            int count = 0;
                            Type b2;
                            Type z2;
                            string b1 = "Б";
                            string z1 = "З";
                            b2 = (Type)Enum.Parse(typeof(Type), b1);
                            z2 = (Type)Enum.Parse(typeof(Type), z1);
                            if (b2 != tp || z2 != tp) /*(srchTxt != "Б" && srchTxt != "З")*/
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы ввели неправильное значение. Попробуйте ещё раз. Рекомендуем ввести Б или З");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto Mark9;
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
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
                            Console.ForegroundColor = ConsoleColor.White;
                            log[l].time = DateTime.Now;
                            log[l].line = "Найдено: " + count + Str(count) + " типа: " + srchTxt;
                            l++;
                            break;

                        case ViewLog:
                            log[l].time = DateTime.Now;
                            log[l].line = "Лог просмотрен";
                            l++;
                            TimeSpan tmp, result;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("{0,30}","Просмотр лога");
                            Console.WriteLine("{0,33}", "*-----------------*");
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
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case Exit:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Работа завершена.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 7.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
            }
        } 
    }
}
