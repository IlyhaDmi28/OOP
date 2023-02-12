using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
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
        public DoubleStack(params double[] args)
        {
            stack = new Stack<double>();
            SIZE = args.Length;
            ID = NumbObj;
            NumbObj++;
            for (int i = 0; i < args.Length; i++)
            {
                stack.Push(args[i]);
            }
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
