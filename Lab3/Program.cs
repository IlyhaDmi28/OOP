using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    static class StatisticOperation
    {
        public static int SumMaxMin(this MyQueue q)
        {
            int MAX = q.GetEl(0);
            int MIN = q.GetEl(0);
            for (int i = 0; i < q.size; i++)
            {
                if (q.GetEl(i) > MAX) MAX = q.GetEl(i);
                if (q.GetEl(i) < MIN) MIN = q.GetEl(i);
            }
            return MAX + MIN;
        }

        public static int MinusMaxMin(this MyQueue q)
        {
            int MAX = q.GetEl(0);
            int MIN = q.GetEl(0);
            for (int i = 0; i < q.size; i++)
            {
                if (q.GetEl(i) > MAX) MAX = q.GetEl(i);
                if (q.GetEl(i) < MIN) MIN = q.GetEl(i);
            }
            return MAX - MIN;
        }

        public static int NumbEl(this MyQueue q)
        {
            return q.size;
        }

        public static int LastEl(this MyQueue q)
        {
            return q.GetEl(q.size - 1);
        }

        public static int indZero(this MyQueue q)
        {
            for (int i = 0; i < q.size; i++)
            {
                if (q.GetEl(i) == 0) return i;
            }
            return -1;
        }
    }

    public class Info
    {
        public readonly int ID;
        private const string org = "Организация любителей пива";
        public Info(int id)
        {
            ID = id;
        }

        public string getInfo { get { return $"ID: {ID}, Организация: {org}"; } }
    }


    public class MyQueue
    {
        public class Developer
        {
            private string FIO;
            public readonly int ID;
            private string OTDEL;

            public Developer (int id, string otdel = "Отдел любителей повалятся в кровате", string fio = "Дмитрук Илья Игоревич")
            {
                FIO = fio;
                ID = id;
                OTDEL = otdel;
            }

            public string getInfo { get { return $"ID: {ID}, ФИО: {FIO}, Отдел: {OTDEL}"; ; } }
        }
        

        private Queue<int> queue;

        private static int NumbObj;
        static MyQueue()
        {
            NumbObj = 0;
        }


        public Info Production;
        public Developer Dev;
        public MyQueue()
        {
            queue = new Queue<int>();
            NumbObj++;
            Production = new Info(NumbObj);
        }

        //Методы работы с очередью
        public void AddEl (int el)
        {
            queue.Enqueue(el);
        }
        public void ShowEl(int i)
        {
            Console.WriteLine(queue.ElementAt(i));
        }
        public int GetEl(int i)
        {
            return queue.ElementAt(i);
        }

        public void ShowALL()
        {
            for (int i = 0; i < queue.Count(); i++)
            {
                Console.Write(queue.ElementAt(i) + " ");
            }
        }
        public void SetInfoDev()
        {
            string FIO;
            string OTDEL;
            Console.Write("Введите своё имя: ");
            FIO = Console.ReadLine();
            Console.Write("Введите отдела: ");
            OTDEL = Console.ReadLine();
            Dev = new Developer(Production.ID, OTDEL, FIO);
        }

        //Перегруженые операторы
        public static MyQueue operator + (MyQueue q1, int el)
        {
            q1.queue.Enqueue(el);
            return q1;
        }
        public static MyQueue operator --(MyQueue q)
        {
            q.queue.Dequeue();
            return q;
        }
        public static bool operator false(MyQueue q)
        {
            if (q.queue.Count() != 0) return true;
            else return false;
        }
        public static bool operator true(MyQueue q)
        {
            if (q.queue.Count() == 0) return true;
            else return false;
        }
        public static MyQueue operator <(MyQueue q1, MyQueue q2)
        {
            int[] sortArr = new int[q2.queue.Count()];
            sortArr = q2.queue.ToArray();
            Array.Sort(sortArr);
            Array.Reverse(sortArr);
            for (int i = 0; i < q2.queue.Count(); i++)
            {
                q1.queue.Enqueue(sortArr[i]);
            }
            return q1;
        }
        public static MyQueue operator >(MyQueue q1, MyQueue q2)
        {
            int[] sortArr = new int[q1.queue.Count()];
            sortArr = q1.queue.ToArray();
            Array.Sort(sortArr);
            Array.Reverse(sortArr);
            for (int i = 0; i < q1.queue.Count(); i++)
            {
                q2.queue.Enqueue(sortArr[i]);                
            }
            return q2;
        }

        //Индексатор
        public int this[int i]
        {
            get
            {
                return queue.ElementAt(i);
            }
        }

        //Свойство для просмотра размера очереди
        public int size { get { return queue.Count(); } } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue q1 = new MyQueue();
            MyQueue q2 =  new MyQueue();
            MyQueue q3 =  new MyQueue();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите {i + 1} элемент: ");
                q1.AddEl(Convert.ToInt32(Console.ReadLine())); 
            }

            byte choise = 255;
            while (choise != 0)
            {
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент элемент");
                Console.WriteLine("3. Скопировать отсортированую очередь в другую");
                Console.WriteLine("4. Проверить, пустая ли очередь");
                Console.WriteLine("5. Просмотреть элемент");
                Console.WriteLine("6. Просмотреть очередь 1");
                Console.WriteLine("7. Просмотреть очередь 2");
                Console.WriteLine("8. Индекс первого нуля");
                Console.WriteLine("9. Сумма максимального и минимального элемента");
                Console.WriteLine("10. Разность максимального и минимального элемента");
                Console.WriteLine("11. Размер очереди");
                Console.WriteLine("12. Установить информацию о разработчике");
                Console.WriteLine("13. Просмотреть информацию о продукте");
                Console.WriteLine("14. Просмотреть информацию о разработчике");
                Console.Write("Сделайте выбор: ");

                choise = Convert.ToByte(Console.ReadLine());
                switch (choise)
                {   
                    case 1: 
                        {
                            int numb;
                            Console.Write("Введите число: ");
                            numb = (Convert.ToInt32(Console.ReadLine()));
                            q1 = q1 + numb;
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            q1--;
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            q2 = q2 < q1;
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            if (q1) Console.WriteLine("Очередь пустая");
                            else Console.WriteLine("Очередь не пустая");
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            int i;
                            Console.Write("Какой элемент вы хотите просмотреть: ");
                            i = (Convert.ToInt32(Console.ReadLine())) - 1;
                            Console.WriteLine(q1[i]);
                            Console.WriteLine();

                            break;
                        }
                    case 6:
                        {
                            q1.ShowALL();
                            Console.WriteLine();

                            break;
                        }
                    case 7:
                        {
                            q2.ShowALL();
                            Console.WriteLine();

                            break;
                        }
                    case 8:
                        {
                            Console.Write(q1.indZero());
                            Console.WriteLine();
                            break;
                        }
                    case 9:
                        {
                            Console.Write(q1.SumMaxMin());
                            Console.WriteLine();
                            break;
                        }
                    case 10:
                        {
                            Console.Write(q1.MinusMaxMin());
                            Console.WriteLine();
                            break;
                        }
                    case 11:
                        {
                            Console.Write(q1.NumbEl());
                            Console.WriteLine();
                            break;
                        }
                        case 12:
                        {
                            q1.SetInfoDev();
                            Console.WriteLine();

                            break;
                        }
                    case 13:
                        {
                            Console.WriteLine(q1.Production.getInfo);
                            Console.WriteLine();

                            break;
                        }
                    case 14:
                        {
                            Console.WriteLine(q1.Dev.getInfo);
                            Console.WriteLine();

                            break;
                        }
                    default:
                        { 
                            Console.WriteLine("Некорректный выбор!!!");
                            Console.WriteLine();

                            break;
                        }
                        
                }

            }

        }
    }
}
