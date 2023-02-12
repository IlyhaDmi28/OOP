using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    static class Reflector
    {
        private static string fullInfo = "";
        public static void WriteToFile()
        {
            StreamWriter sw = new StreamWriter("D:\\лабы ООП\\Lab11\\Info.txt");

            sw.WriteLine(fullInfo);
            
            sw.Close();
        }

        public static string ReadFromFile()
        {
            string text;
            StreamReader sr = new StreamReader("D:\\лабы ООП\\Lab11\\Param.txt");
            text = sr.ReadLine();

            sr.Close();

            return text;
        }
        public static void BuildInf()
        {         
            string info = AssemblyName.GetAssemblyName("Lab11.exe").Name;
            Console.WriteLine(info);
            fullInfo += info + "\n\n";
        }

        public static void ConstrInf(string ClassName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);


            Console.WriteLine("Публичные конструкторы: ");
            fullInfo += "Публичные конструкторы:\n";
            foreach (ConstructorInfo ctor in myType.GetConstructors())
            {
                if (ctor.IsPublic)
                {
                    Console.WriteLine(ctor.Name);
                    fullInfo += ctor.Name + "\n\n";
                }
            }
            Console.WriteLine();
        }

        public static void MethodInf(string ClassName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);

            Console.WriteLine("Публичные методы: ");
            fullInfo += "Публичные методы:\n";
            foreach (MethodInfo method in myType.GetMethods())
            {
                if (method.IsPublic)
                {
                    Console.WriteLine(method.Name);
                    fullInfo += method.Name + "\n";
                }
            }
            Console.WriteLine();
            fullInfo += "\n";
        }

        public static void FieldInf(string ClassName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);

            Console.WriteLine("Поля: ");

            fullInfo += "Поля:\n";
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine(field.Name);
                fullInfo += field.Name + "\n\n";
            }
            Console.WriteLine();
        }

        public static void ProptInf(string ClassName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);

            Console.WriteLine("Свойства: ");
            fullInfo += "Свойства:\n";
            foreach (PropertyInfo property in myType.GetProperties())
            {
                Console.WriteLine(property.Name);
                fullInfo += property.Name + "\n\n";

            }
            Console.WriteLine();
        }

        public static void InterInf(string ClassName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);

            Console.WriteLine("Реализованные интерфейсы:");

            fullInfo += "Реализованные интерфейсы:\n";
            foreach (Type inter in myType.GetInterfaces())
            {
                Console.WriteLine(inter.Name);
                fullInfo += inter.Name + "\n\n";
            }
            Console.WriteLine();
        }

        public static void MethodForParamInf(string ClassName)
        {
            fullInfo += "Метод, найденный по параметру\n";
            Type myType = Type.GetType("Lab11." + ClassName);


            Console.Write("Введите тип параметра: ");
            string param = Console.ReadLine();

            foreach (MethodInfo method in myType.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == param)
                    {
                        Console.WriteLine(method.Name);
                        fullInfo += method.Name + "\n";                   }
                }
            }

        }

        public static void Invoke(string ClassName, string MethodName)
        {
            Type myType = Type.GetType("Lab11." + ClassName);

            foreach (MethodInfo method in myType.GetMethods())
            {
                if (method.Name == MethodName)
                {
                    object obj = Activator.CreateInstance(myType, "Попугай");
                    method.Invoke(obj, new object[] {ReadFromFile()});
                }
            }

        }

        public static T Create<T> ()
        {
            Type t = typeof(T);
            
            object obj = Activator.CreateInstance(t, "Попугай");

            return (T)obj;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Reflector.BuildInf();
            Reflector.ConstrInf("Tiger");
            Reflector.MethodInf("Tiger");
            Reflector.FieldInf("Tiger");
            Reflector.ProptInf("Tiger");
            Reflector.InterInf("Tiger");
            Console.ReadKey();

            Reflector.MethodForParamInf("Parrot");

            Reflector.WriteToFile();

            Reflector.Invoke("Parrot", "Speak");

            object par = Reflector.Create<Parrot>();
            Type f = par.GetType();
            Console.WriteLine(f.Name);
        }
    }
}
