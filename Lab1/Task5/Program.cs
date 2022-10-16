using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
             dynamic LocFun(int[] Arr, string str)
             {
                (int, int, int, string) cort = (Arr.Max(), Arr.Min(), Arr.Sum(), str.Substring(0, 1));
                return cort;
             }

            int[] ArrToParm = new int[] { 423, 65, 654, 5432, 324 };
            (int, int, int, string) RetCort = LocFun(ArrToParm, "Привет, пошли ко мне :)");
            Console.WriteLine($"Максимальный элемент: {RetCort.Item1}");
            Console.WriteLine($"Минимальный элемент: {RetCort.Item2}");
            Console.WriteLine($"Сумма всех элементов: {RetCort.Item3}");
            Console.WriteLine($"Первый символ строки: {RetCort.Item4}");
        }
    }
}
