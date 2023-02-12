using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab8.Program;

namespace Lab8
{
    public delegate void ChangeInfo();
    public delegate void UpdateLanguage();
    public class Programist
    {
        public event UpdateLanguage NewOper;
        public event ChangeInfo NewInfo;

        private string Name;
        private int Version;
        public Programist (string name, int v)
        {
            Name = name;
            Version = v;
        }

        public void ChangeName()
        {
            Console.Write("Введите новое имя: ");
            Name = Console.ReadLine();
            NewInfo?.Invoke();
        }

        public void SuccsesfulChangeName()
        {
            Console.WriteLine("Имя успешно изменнено!");
        }
        public void AddOper()
        {
            NewOper?.Invoke();
        }
        public void SuccsesfulChange()
        {
            Console.WriteLine("Добавленны новые операции");
        }
        public void Update()
        {
            Version++;
            Console.WriteLine("Язык обновлён до версии " + Version);
           
        }
        public void Info()
        {
            Console.WriteLine($"Название: {Name}, Версия: {Version}");
        }
    }
    internal class Program
    {
        public delegate void ChangeLanguage(Programist language);


        public delegate void Action<T>(T obj);
        static void StringAction(string str, Action<string> action) => action(str);

        static void Main(string[] args)
        {
            Programist JS = new Programist("JavaScript", 6);
            Programist C = new Programist("C++", 5);
            Programist Python = new Programist("Python", 12);

            ChangeLanguage DoChange = (Programist language) =>
            {
                language.NewOper += language.SuccsesfulChange;
                language.NewOper += language.Update;
                language.NewInfo += language.SuccsesfulChangeName;

                language.Info();
                language.ChangeName();
                Console.WriteLine();
                language.AddOper();
                Console.WriteLine();
                language.Info();
                Console.ReadKey();
            };

            DoChange(JS);
            Console.WriteLine();
            DoChange(C);
            Console.WriteLine();
            DoChange(Python);
            

            Console.WriteLine();
            string str = "Привет";
            Action<string> action;
            action = ToUpCase;
            StringAction(str, action);
            action = ToLowCase;
            StringAction(str, action);
            action = AddMessage;
            StringAction(str, action);
            action = ChangeMessage;
            StringAction(str, action);
            action = CutString;
            StringAction(str, action);
            Console.ReadKey();
        }
        

        static void ToUpCase(string str)
        {
            Console.WriteLine(str.ToUpper());

        }
        static void ToLowCase(string str)
        {
            Console.WriteLine(str.ToLower());

        }
        static void AddMessage(string str)
        {
            Console.WriteLine(str.Insert(6, ", ты кто?"));
        }
        static void ChangeMessage(string str)
        {
            Console.WriteLine(str.Replace(str, "Понял! Пока"));
        }
        static void CutString(string str)
        {
            Console.WriteLine(str.Substring(0, 4));
        }
    
    }
}
