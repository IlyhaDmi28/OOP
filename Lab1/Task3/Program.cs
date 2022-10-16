using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Arr2D = {
                { 23, 435, 46 },
                { 65, 877, 76 },
                { 54, 76, 34 }
            };
            for (int y = 0; y < Arr2D.GetLength(1); y++)
            {
                for (int x = 0; x < Arr2D.GetLength(0); x++)
                {
                    Console.Write(Arr2D[y, x] + "\t");
                }
                Console.WriteLine();
            }

            int[] Arr = new int[] { 3, 32, 54, 55 };
            foreach (int i in Arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nДлина массива: " + Arr.Length);
            Console.Write("Какой элемент вы хотите заменить: ");
            int poz = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент: ");
            Arr[poz] = int.Parse(Console.ReadLine());
            foreach (int i in Arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            float[][] ArrFl = new float[3][];
            {
                ArrFl[0] = new float[2];
                ArrFl[1] = new float[3]; 
                ArrFl[2] = new float[4]; 
            }

            for (int y = 0; y < ArrFl.Length; y++)
            {
                for (int x = 0; x < ArrFl[y].Length; x++)
                {
                    Console.Write($"Ввведите элемент {y}.{x}: ");
                    ArrFl[y][x] = float.Parse(Console.ReadLine());
                }
            }

            for (int y = 0; y < ArrFl.Length; y++)
            {
                for (int x = 0; x < ArrFl[y].Length; x++)
                {
                    Console.Write(ArrFl[y][x] + " ");
                }
                Console.WriteLine();
            }

            var VarArray = new[] { 34, 64, 54 };
            var VarString = "jgfhfdghd";

        }
    }
}
