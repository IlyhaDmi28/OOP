using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3
{
    interface IActions<G> 
    {
        void Add(G el);
        void DeleteAll();
        void ShowALL();
    }
 



    public class MyQueue<T> : IActions<T> where T : notnull
    {
        private Queue<T> queue = new Queue<T>();
        //private Vector<int> h = new BitVector32();
        
        public MyQueue(string f)
        {
            File = f;
        }

        //Методы работы с очередью
        private string File;
        public void WriteToFile()
        {
           // h[0] = 23;
            StreamWriter sw = new StreamWriter("D:\\лабы ООП\\Lab7\\" + File);
            foreach (T elem in queue)
            {
                sw.WriteLine(elem);
            }
            sw.Close();
        }

        public void ReadFromFile()
        {
            String line;
            StreamReader sr = new StreamReader("D:\\лабы ООП\\Lab7\\" + File);
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        public void Add(T el)
        {
            queue.Enqueue(el);
        }
        public void ShowEl(int i)
        {
            if (i < 0 || i >= queue.Count) throw new Exception("Ошибка! Элемента с таким индексом нет!");
            Console.WriteLine(queue.ElementAt(i));
        }
        public T GetEl(int i)
        {
            if (i < 0 || i >= queue.Count) throw new Exception("Ошибка! Элемента с таким индексом нет!");
            return queue.ElementAt(i);
        }

        public void ShowALL()
        {
            if (this) throw new StackOverflowException("Ошибка! Невозможно вывести очередь, т.к она пустая!");
            for (int i = 0; i < queue.Count(); i++)
            {
                Console.Write(queue.ElementAt(i) + " ");
            }
        }

        public void DeleteAll()
        {
            queue.Clear();
        }

        //Перегруженые операторы

        public static MyQueue<T> operator + (MyQueue<T> q1, T el)
        {
            q1.queue.Enqueue(el);
            return q1;
        }

        public static MyQueue<T> operator --(MyQueue<T> q)
        {
            if (q) throw new Exception("Ошибка! Невозможно удалить элемент очереди, т.к она пустая!");
            q.queue.Dequeue();
            return q;
        }
        public static bool operator false(MyQueue<T> q)
        {
            if (q.queue.Count() != 0) return true;
            else return false;
        }
        public static bool operator true(MyQueue<T> q)
        {
            if (q.queue.Count() == 0) return true;
            else return false;
        }

        public static MyQueue<T> operator <(MyQueue<T> q1, MyQueue<T> q2)
        {
            if (q2) throw new Exception("Ошибка! Копирование невозможно, т.к объект, из которого копируют, пустой!");
            q1.DeleteAll();
            for (int i = 0; i < q2.queue.Count(); i++)
            {
               q1.Add(q2.queue.ElementAt(i));
            }
            return q1;
        }
        public static MyQueue<T> operator >(MyQueue<T> q1, MyQueue<T> q2)
        {
            if (q2) throw new Exception("Ошибка! Копирование невозможно, т.к объект, из которого копируют, пустой!");
            q2.DeleteAll();
            for (int i = 0; i < q1.queue.Count(); i++)
            {
                q2.Add(q1.queue.ElementAt(i));
            }

            return q2;
        }

        //Свойство для просмотра размера очереди
        public int size { get { return queue.Count(); } } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue<char> q1 = new MyQueue<char>("q1.txt");
            MyQueue<int> q2 =  new MyQueue<int>("q2.txt");
            MyQueue<Animal> q3 =  new MyQueue<Animal>("q3.txt");
            MyQueue<char> q4 =  new MyQueue<char>("q4.txt");

            Weights weight = new Weights(120, 100, 105, 10, 1, 110, 1);

            Lion lion = new Lion("Лев", weight.LionWeight, (int)BirthDay.LionYear);
            Tiger tiger = new Tiger("Тигр", weight.TigerWeight, (int)BirthDay.TigerYear);
            Aligator alig = new Aligator("Крокодил", weight.AligatorWeight, (int)BirthDay.AligatorYear);
            Owl owl = new Owl("Сова", weight.OwlWeight, (int)BirthDay.OwlYear);
            Parrot parrot = new Parrot("Попугай", weight.ParrotWeight, (int)BirthDay.ParrotYear);
            Shark shark = new Shark("Акула", weight.SharkWeight, (int)BirthDay.SharkYear);
            Karas karas = new Karas("Карась", weight.KarasWeight, (int)BirthDay.KarasYear);

            q1.Add('g');
            q1.Add('o');
            q1.Add('o');
            q1.Add('d');

            q2.Add(23);
            q2.Add(56);
            q2.Add(-5645);
            q2.Add(13);

            q3.Add(lion);
            q3.Add(tiger);
            q3.Add(alig);
            q3.Add(owl);
            q3.Add(parrot);
            q3.Add(shark);
            q3.Add(karas);

            try
            {
                q1.ShowALL();
                Console.WriteLine();

                q2.ShowALL();
                Console.WriteLine();

                for (int i = 0; i < q3.size; i++)
                {
                    q3.ShowEl(i);
                }
                Console.WriteLine();

                q4.ShowALL();
                Console.WriteLine();
            }
            catch (StackOverflowException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            q1 = q1 + '!';
            
            try
            {
                q2--;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            try
            {
                q4 = q4 < q1;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            try
            {
                q1.ShowALL();
                Console.WriteLine();

                q2.ShowALL();
                Console.WriteLine();

                for (int i = 0; i < q3.size; i++)
                {
                    q3.ShowEl(i);
                }

                q4.ShowALL();
                Console.WriteLine();
            }
            catch (StackOverflowException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            
            finally
            {
                Console.WriteLine("Программа отработала!");
            }
            q1.WriteToFile();
            q2.WriteToFile();
            q3.WriteToFile();
            q4.WriteToFile();          
        }
    }
}
