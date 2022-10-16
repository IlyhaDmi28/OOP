using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void CheckFun()
            {
                int a;
                checked
                {
                    a = int.MaxValue;
                }
                Console.WriteLine(a);
            }

            void UnCheckFun()
            {
                int b;
                unchecked
                {
                    b = int.MaxValue + 1;
                }
                Console.WriteLine(b);
            }

            CheckFun();
            UnCheckFun();
        }
    }
}
