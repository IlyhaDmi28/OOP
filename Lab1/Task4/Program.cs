using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int, string, char, string, ulong) cort = (789, "45r34", 'j', "dgdfmgk", 6748);
            Console.WriteLine(cort);
            Console.WriteLine($"{cort.Item1} {cort.Item3} {cort.Item4}");

            {
                (int a, string b, char c, string d, ulong e) = cort;
            }

            {
                int a; string b; char c; string d; ulong e;
                (a, b, c, d, e) = cort;
            }

            int MMM_ = 644;

            (int, string) cort1 = (5, "4h");
            (int, string) cort2 = (5, "4h");
            if (cort1 == cort2) Console.WriteLine("Кортежи одинаковы!");
        }
    }
}
