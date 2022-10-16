using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public partial class DoubleStack
    {
        private Stack<double> stack;

        private int SIZE;
        private int NumbEl = 0;

        private const string Info = "Класс, содержащий стек";
        private static int NumbObj;
        private readonly int ID;

        public int size { get { return SIZE; } set { SIZE = value; } }

        static DoubleStack()
        {
            NumbObj = 0;
        }
        public DoubleStack(int size, double FirstEl = 0)
        {
            stack = new Stack<double>();
            SIZE = size;
            stack.Push(FirstEl);
            ID = ((NumbObj / 2) * NumbObj) + 1;
            NumbEl++;
            NumbObj++;
        }

        public DoubleStack()
        {
            stack = new Stack<double>();
            ID = ((NumbObj / 2) * NumbObj) + 1;
            NumbObj++;
        }
        private DoubleStack(double[] AutoStack)
        {
            stack = new Stack<double>();
            ID = (NumbObj / 2) * NumbObj;
            for (int i = 0; i < AutoStack.Length; i++)
            {
                stack.Push(AutoStack[i]);
            }
            SIZE = stack.Count();
            NumbEl = stack.Count();
            NumbObj++;
        }

        public void AutoPush(double[] ELStack)
        {
            DoubleStack NewStack;
            NewStack = new DoubleStack(ELStack);
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public override string ToString()
        {
            return $"{Info}. Всего объетов: {NumbObj}. ID объекта: {ID}";
        }
        public static void GetInfo()
        {
            Console.WriteLine($"{Info}");
        }

        public double this[int i]
        {
            get
            {
                return stack.ElementAt(i);
            }
        }
        private bool CheckSize()
        {
            return NumbEl > SIZE;
        }
    }
}
