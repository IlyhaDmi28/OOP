using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "aaaaaaaa";
            string str2 = "bbbbbbbbbbbbbbbb";
            string str3 = "ccccccccccccccccccccccccccccc";
            string strBuf;
            if(str1 != str2) Console.WriteLine("str1 != str2");
            Console.WriteLine();

            strBuf = String.Join(" ", str1, str2, str3);
            Console.WriteLine(strBuf);
            Console.WriteLine();

            str2 = String.Copy(strBuf);
            Console.WriteLine(str2);
            Console.WriteLine();

            strBuf = strBuf.Substring(0, 8);
            Console.WriteLine(strBuf);
            Console.WriteLine();

            strBuf = "gjdngjnd hbfhdbgf hgbdhj jjd jdf";
            string[] words = strBuf.Split(' ');
            Console.WriteLine($"{strBuf}");
            foreach (var word in words)
            {
                Console.WriteLine($"{word}");
            }
            Console.WriteLine();

            strBuf = "dddd";
            strBuf = strBuf.Insert(2, str1);
            Console.WriteLine(strBuf);
            Console.WriteLine();

            strBuf = strBuf.Remove(2, 7);
            Console.WriteLine(strBuf);
            Console.WriteLine();

            Console.WriteLine($"Привет, {"Витя"}! Пойдёшь играть в футбол в {7} часов?");
            Console.WriteLine();

            string strEmpt = "";
            string strNull = null;
            if (String.IsNullOrEmpty(strEmpt) && String.IsNullOrEmpty(strNull)) Console.WriteLine("Здесь строки пустые");
            Console.WriteLine();

            StringBuilder sb = new StringBuilder("Привет, я xxx Илья");
            Console.WriteLine(sb.ToString());
            sb.Remove(10, 4);
            sb.Insert(0, "XXX ");
            sb.Append(" XXX");
            Console.WriteLine(sb.ToString());
        }
    }
}
