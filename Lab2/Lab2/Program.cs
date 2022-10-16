using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public partial class DoubleStack
    {
        public void PushEl(ref double val)
        {
            NumbEl++;
            if (CheckSize())
            {
                Console.WriteLine("Не удалось добавить элемент в стек. Стек переполнен!");
                return;
            }
            stack.Push(val);
        }

        public void ShowEl()
        {
            if (NumbEl == 0) { Console.WriteLine("Стек пуст!"); return; };
            Console.WriteLine(stack.Peek());

        }

        public double GetEl()
        {
            double val = stack.Peek();
            stack.Peek();
            NumbEl--;
            return val;
        }

        public void DelEl()
        {
            if (NumbEl == 0) { Console.WriteLine("Стек пуст!"); return; }
            Console.WriteLine($"Элемент успешно удалён! Удалённый элемент: {stack.Peek()}");
            stack.Pop();
            NumbEl--;
        }

        public bool CheckNegativeNumb()
        {
            for (int i = 0; i < stack.Count(); i++)
            {
                if (stack.ElementAt(i) < 0) return true;
            }
            return false;
        }

        public double GetSum()
        {
            return stack.Sum();

        }
    }

 
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleStack Stack1 = new DoubleStack(5, 10);
            DoubleStack Stack2 = new DoubleStack();
            DoubleStack Stack3 = new DoubleStack(3);
            Stack2.size = 5;
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("Ведите элемент: ");
                double val = Convert.ToDouble(Console.ReadLine());
                Stack3.PushEl(ref val);
            }
            while (true)
            {
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Показать первый элемент");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("4. Найти элемент по индексу");
                Console.WriteLine("5. Сравнить объект");
                Console.WriteLine("6. Посмотреть информацию о классе");
                Console.WriteLine("7. Посмотреть информацию о объекте");
                Console.WriteLine("0. Выйти");
                Console.WriteLine();
                Console.WriteLine("Выберите пункт: ");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите число: ");
                            double val = Convert.ToDouble(Console.ReadLine());
                            Stack1.PushEl(ref val);
                            break;
                        };
                    case 2:
                        {
                            Stack1.ShowEl();
                            break;
                        };
                    case 3:
                        {
                            Stack1.DelEl();
                            break;
                        };
                    case 4:
                        {
                            Console.WriteLine("Введите номер элемента: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(Stack1[ind]);
                            break;
                        };
                    case 5:
                        {
                            if(Stack1.Equals(Stack2)) Console.WriteLine("Объекты одинаковы");
                            else Console.WriteLine("Объекты не одинаковы");
                            break;
                        };
                    case 6:
                        {
                            DoubleStack.GetInfo();
                            break;
                        };
                    case 7:
                        {
                            Console.WriteLine(Stack2.ToString());
                            break;
                        };
                    case 0:
                        {
                            break;
                        };
                    default:
                        break;
                }
                if (choise == 0) break;
            }

            DoubleStack[] Stacks = new DoubleStack[4];
            for (int i = 0; i < 4; i++)
            {
                Stacks[i] = new DoubleStack(3, 7);
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 3; j++)
                {

                    Console.Write($"Введите число в стэк[{i}][{j}]: ");
                    double val = Convert.ToDouble(Console.ReadLine());
                    Stacks[i].PushEl(ref val);
                }
            }

            int max = 0, min = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Stacks[i].GetSum() > Stacks[max].GetSum()) max = i;
                if (Stacks[i].GetSum() < Stacks[min].GetSum()) min = i;
            }
            Console.Write("Стек, с самой большой суммой элементов: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{Stacks[max][i]} ");
            }
            Console.WriteLine();
            Console.Write("Стек, с наименьшей суммой элементов: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{Stacks[min][i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("Стеки, в которых есть отрицательные элементы:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Stacks[i].CheckNegativeNumb()) Console.Write($"{Stacks[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var ananim = new
            {
                f = 12,
                g = "АНОНИМНЫЙ ТИП"
            };
            Console.WriteLine($"{ananim.g}: {ananim.f}");
        }
    }
}
