using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bl = false; 

            byte bt = 46; 
            sbyte sbt = -89;

            short sh = -10357;
            ushort ush = 57533;

            int integ = -6565464;
            uint uinteg = 45456546;

            long lg = -7537864786374938; 
            ulong ulg = 673456783463893;

            float fl = 6.13f; 

            double dl = 12.64565d; 

            decimal dc = 34.43565345734m; 

            char ch = 's'; 


            Console.Write("Введите переменную int: ");
            integ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(integ);

            Console.Write("Введите переменную double: ");
            dl = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(dl);

            Console.Write("Введите переменную char: ");
            ch = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Write(ch);
            Console.WriteLine();

            lg = integ;
            integ = sh;
            sh = bt;
            dl = fl;
            

            bt = (byte)ch;  
            sh = (short)integ;
            integ = (int)lg;
            lg = (long)fl;
            fl = (float)dl;
            string str = "123,56";
            dl = Convert.ToDouble(str);


            int up = 34;
            object box = up;
            int rp = (int)box;


            var x = 'm';
            //x = 34;
        }
    }
}
