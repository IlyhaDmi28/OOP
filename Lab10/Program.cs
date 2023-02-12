using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public partial class DoubleStack
    {
        public void PushEl(double val)
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
            //if (NumbEl == 0) { Console.WriteLine("Стек пуст!"); return; };
            Console.WriteLine(stack.Peek());
        }

        public double GetEl()
        {
            double val = stack.Peek();
            return val;
        }

        public void DelEl()
        {
            if (NumbEl == 0) { Console.WriteLine("Стек пуст!"); return; }
            Console.WriteLine($"Элемент успешно удалён! Удалённый элемент: {stack.Peek()}");
            stack.Pop();
            NumbEl--;
        }

        public void ShowAll()
        {
            for (int i = 0; i < stack.Count; i++)
            {
                Console.Write(stack.ElementAt(i) + " ");
            }
        }
        public bool CheckNegativeNumb()
        {
            for (int i = 0; i < stack.Count(); i++)
            {
                if (stack.ElementAt(i) < 0) return true;
            }
            return false;
        }

        public double GetSum { get { double val = stack.Sum(); return val; } }
       
        
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };



            int NumberOfSymbols = int.Parse(Console.ReadLine());

            IEnumerable<string> CurrentMonths = from n in Months
                                                where n.Length == NumberOfSymbols
                                                select n;

            foreach (string Month in CurrentMonths)
            {
                Console.WriteLine(Month);
            }
            Console.ReadKey();
            Console.WriteLine();


            CurrentMonths = from n in Months
                            where n == Months[0] || n == Months[1] || n == Months[11] || n == Months[5] || n == Months[6] || n == Months[7]
                            select n;
            foreach (string Month in CurrentMonths)
            {
                Console.WriteLine(Month);
            }
            Console.ReadKey();
            Console.WriteLine();


            CurrentMonths = from n in Months
                            orderby n 
                            select n;

            foreach (string Month in CurrentMonths)
            {
                Console.WriteLine(Month);
            }
            Console.ReadKey();
            Console.WriteLine();


            CurrentMonths = from n in Months
                            where n.Contains('u') && n.Length == 4 
                            select n;

            foreach (string Month in CurrentMonths)
            {
                Console.WriteLine(Month);
            }
            Console.ReadKey();
            Console.WriteLine();


            List<DoubleStack> stacks = new List<DoubleStack>()
            {
                new DoubleStack(5, 35, 32),
                new DoubleStack(12, 54,-534),
                new DoubleStack(3, 55.34232, 23435, -546, 34),
                new DoubleStack(9, 12, 4354, 0),
                new DoubleStack(14),
                new DoubleStack(243, -54),
                new DoubleStack(1324, 345,3456, 46, 5654, 68.9824),
                new DoubleStack(7, 43, -546),
                new DoubleStack(1022, 32, 54.24),
                new DoubleStack(9),
            };

            var OurStacks = stacks.Where(min => min.GetEl() == stacks.Min(minEl => minEl.GetEl()));
            DoubleStack SelectStack = OurStacks.First();
            SelectStack.ShowAll();
            Console.WriteLine();

            OurStacks = stacks.Where(max => max.GetEl() == stacks.Max(MaxEl => MaxEl.GetEl()));
            SelectStack = OurStacks.First();
            SelectStack.ShowAll();
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();



            OurStacks = stacks.Where(negative => negative.CheckNegativeNumb());
            foreach (DoubleStack negative in OurStacks)
            {
                negative.ShowAll();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();

            OurStacks = stacks.Where(st => st.size == 1 || st.size == 3);
            DoubleStack[] ArrayStacks = new DoubleStack[OurStacks.Count()];
            for (int i = 0; i < ArrayStacks.Length; i++)
            {
                ArrayStacks[i] = OurStacks.ElementAt(i);
                ArrayStacks[i].ShowAll();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();


            OurStacks = stacks.Where(zeroStacks => zeroStacks.GetEl() == 0).Take(1);
            SelectStack = OurStacks.First();
            SelectStack.ShowAll();
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();


            OurStacks = stacks.OrderBy(st => st.GetSum);
            foreach (DoubleStack st in OurStacks)
            {
                st.ShowAll();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();

            OurStacks = stacks.Where(st => st.CheckNegativeNumb()).OrderBy(st => st.GetEl()).Take(4).Select(st => st);
            foreach (DoubleStack st in OurStacks)
            {
                st.ShowAll();
                Console.WriteLine();
            }

            var MonthStack = from Month in Months
                        join stack in stacks on Month.Length equals stack.size
                        select new { Month, stack };

            foreach (var item in MonthStack)
            {
                Console.WriteLine(item.Month + " - " + item.stack.size);
            }
                        

        }
    }
}
