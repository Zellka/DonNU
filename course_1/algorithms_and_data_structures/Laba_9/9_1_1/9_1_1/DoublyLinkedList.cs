using System;

namespace _9_1_1
{
    
    public class DoublyNode
    {
        public Village data;
        public DoublyNode Next;
        public DoublyNode Previous;
    }
    public class DoublyLinkedList
    {
        DoublyNode head = null;
        DoublyNode tail = null;
        public void View()
        {
            DoublyNode node = head;
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8} ", "Наименование", "Тип", "Площадь (га)", "Урожайность", "*");
            Console.WriteLine("*************************************************************************");
            while (node != null)
            {
                Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8}", node.data.Name, node.data.Type, node.data.Area, node.data.Harvest, "*");
                node = node.Next;
            }
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,29}", "Перечисляемый тип: З - зерновые, Б-бобовые", "*");
            Console.WriteLine("*************************************************************************");
        }
        public void Add(string name, Type type, double area, double harvest)
        {
            DoublyNode node = new DoublyNode();
            node.data = new Village() { Name = name, Type = type, Area = area, Harvest = harvest };
            node.Next = null;
            node.Previous = null;
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
        }
        public void Delete(int delNum)
        {
            DoublyNode node = head;
            for (int i = 0; i <= delNum; i++)
            {
                if (i == delNum)
                {
                    if (node.Next != null)
                        node.Next.Previous = node.Previous;
                    else
                        tail = node.Previous;
                    if (node.Previous != null)
                        node.Previous.Next = node.Next;
                    else
                        head = node.Next;
                }
                node = node.Next;
            }
        }
        public void Update(int upNum, string name, Type type, double area, double harvest)
        {
            DoublyNode node = head;
            for (int i = 0; i <= upNum; i++)
            {
                if (i == upNum)
                {
                    node.data.Name = name;
                    node.data.Type = type;
                    node.data.Area = area;
                    node.data.Harvest = harvest;
                }
                node = node.Next;
            }
        }
        public void Search(string srchTxt)
        {
            Type tp = (Type)Enum.Parse(typeof(Type), srchTxt);
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8} ", "Наименование", "Тип", "Площадь (га)", "Урожайность", "*");
            Console.WriteLine("*************************************************************************");
            for (DoublyNode node = head; node != null; node = node.Next)
            {
                if (node.data.Type == tp)
                    Console.WriteLine("{0,15} {1,10} {2,20} {3,15} {4,8}", node.data.Name, node.data.Type, node.data.Area, node.data.Harvest, "*");
            }
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("{0,15} {1,29}", "Перечисляемый тип: З - зерновые, Б-бобовые", "*");
            Console.WriteLine("*************************************************************************");
        }
    }
}
