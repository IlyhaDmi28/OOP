using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace Lab14
{
    static class Processes
    {
        public static void ShowProcesses()
        {
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Prioritet: {process.BasePriority} Time: {process.StartTime}");
                }
                catch
                {
                    continue;
                }

            }
        }
    }
    static class DomainInfo
    {
        public static void Info()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Путь: {domain.BaseDirectory}");

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            AppDomain NewDom = AppDomain.CreateDomain("Gym");
            NewDom.ExecuteAssembly("Build.exe");
            Console.WriteLine($"Name: {NewDom.FriendlyName}");
            Console.WriteLine($"Путь: {NewDom.BaseDirectory}");
            AppDomain.Unload(NewDom);
        }


    }
    static class MyThread
    {
        public static void MyFirstThread()
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Thread thread = new Thread(new ParameterizedThreadStart(SimpleNumbers));
            thread.Name = "Мой любимый поток";
            object o = n;
            thread.Start(o);



        }

        public static void SimpleNumbers(object o)
        {
            int n = (int)o;
            StreamWriter sr = new StreamWriter("D:/лабы ООП/Lab14/Numbs.txt");


            Console.Write("Name: ");
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.Priority);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
                sr.WriteLine(i);
                Thread.Sleep(100);
            }


            Console.WriteLine("Finish");
            sr.Close();
        }
    }


    static class TwoThreads
    {
        private static object locker = new object();
        public static void MyFirstThread()
        {

            Thread thread1 = new Thread(new ParameterizedThreadStart(Numbers));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Numbers));
            thread1.Name = "Чётные";
            thread2.Name = "Нечётные";

            thread1.Priority = ThreadPriority.BelowNormal;
            thread2.Priority = ThreadPriority.Normal;
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            object o = n;
            thread1.Start(o);
            thread2.Start(o);

        }

        public static void Numbers(object n)
        {
            int number = (int)n;

            lock (locker)
            {
                StreamWriter sr = File.AppendText("D:/лабы ООП/Lab14/Numbs2.txt");
                for (int i = 1; i <= number; i++)
                {                   
                    if (i % 2 == 0 && Thread.CurrentThread.Name == "Чётные")
                    {
                        Console.WriteLine(i);
                        sr.WriteLine(i);
                        Thread.Sleep(200);
                    }
                    if (i % 2 != 0 && Thread.CurrentThread.Name == "Нечётные")
                    {
                        Console.WriteLine(i);
                        sr.WriteLine(i);
                        Thread.Sleep(400);
                    }
                    
                }
                sr.Close();
            }
        }
        //public static void Numbers_not_odd(object n)
        //{

        //    int number = (int)n;

        //    lock (locker)
        //    {
        //        for (int i = 1; i <= number; i++)
        //        {

        //            if (i % 2 != 0)
        //            {
        //                Console.WriteLine(i);
        //            }
        //            Thread.Sleep(500);
        //        }
        //        Console.ReadLine();
        //    }
        //}
    }
    static class Timerr
    {
        public static void MyTimer()
        {
            int num = 4;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 5500, 2000);

            Console.ReadLine();
        }

        public static void Count(object obj)
        {

            int x = (int)obj;
            for (int i = 1; i < x; i++)
            {
                Console.WriteLine($"Отработал Timer: {i}");

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Processes.ShowProcesses();
            Console.WriteLine();

            DomainInfo.Info();
            Console.WriteLine();

            MyThread.MyFirstThread();
            Console.WriteLine();

            TwoThreads.MyFirstThread();
            Console.WriteLine();

            Timerr.MyTimer();
            Console.WriteLine();

        }
    }
}
