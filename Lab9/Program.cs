using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public partial class Concert<T> : ISet<T>
    {
        public Concert(string band, string type, string place_of_performancece, int numbsSinger)
        {
            Band = band;
            Type = type;
            Place_of_performance = place_of_performancece;
            NumbsSinger = numbsSinger;
        }
        private string Type;
        public string Band { get; }
        private string Place_of_performance;
        private int NumbsSinger;

        public void Sing()
        {
            Console.WriteLine("АААААААААА");
        }

        public void ChangePlace()
        {
            Console.Write("Введите новое место выступления: ");
            Place_of_performance = Console.ReadLine();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Группа: {Band}, вид концерта: {Type}, количество поющих: {NumbsSinger}, место выступления: {Place_of_performance}");
        }
    }

    public static class ConcertContainer
    {
        private static Dictionary<string, Concert<object>> concerts = new Dictionary<string, Concert<object>>();

        public static void Add(Concert<object> con)
        {
            concerts.Add(con.Band, con);
        }

        public static void Del ()
        {
            Console.Write("Введите название группы, концерт которой вы хотите удалить: ");
            string band = Console.ReadLine();
            concerts.Remove(band);
        }

        public static void Find()
        {
            Concert<object> con;
            Console.Write("Введите название группы, концерт которой вы хотите найти: ");
            string band = Console.ReadLine();
            concerts.TryGetValue(band, out con);
            con.ShowInfo();
        }

        public static void ShowAll()
        {
            foreach (var con in concerts)
            {
                con.Value.ShowInfo();
            }
        }
    }

    public static class UniversalCollection
    {
        public static Dictionary<int, char> UHD = new Dictionary<int, char>();

        public static void Display()
        {
            foreach (var symbol in UHD)
            {
                Console.Write(symbol.Value);
            }
        }
        public static void DeleteElements(int n)
        {
             UHD.Remove(n);      
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Concert<object> con1 = new Concert<object>("Большие пушки", "Рок", "Брест", 7);
            Concert<object> con2 = new Concert<object>("Ручей", "Классика", "Гродно", 3);
            Concert<object> con3 = new Concert<object>("Кирюха", "Реп", "Витебск", 1);

            ConcertContainer.Add(con1);
            ConcertContainer.Add(con2);
            ConcertContainer.Add(con3);
            ConcertContainer.ShowAll();
            ConcertContainer.Find();
            ConcertContainer.Del();
            ConcertContainer.ShowAll();


            UniversalCollection.UHD.Add(0, 'h');
            UniversalCollection.UHD.Add(1, 'e');
            UniversalCollection.UHD.Add(2, 'l');
            UniversalCollection.UHD.Add(3, 'L');
            UniversalCollection.UHD.Add(4, 'o');

            UniversalCollection.Display();
            UniversalCollection.DeleteElements(3);
            Console.WriteLine();
            UniversalCollection.Display();
            Console.ReadKey();

            List<char> UniversalCollection2 = new List<char>();
            foreach (var symbol in UniversalCollection.UHD)
            {
                UniversalCollection2.Add(symbol.Value);
            }

            Console.WriteLine();

            foreach (char symbol in UniversalCollection2)
            {
                Console.Write(symbol);
            }
            Console.ReadKey();

            ObservableCollection<Concert<object>> users = new ObservableCollection<Concert<object>>();

            users.CollectionChanged += Users_CollectionChanged;
            users.Add(con1);
            users.Remove(con1);
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Concert<object> newConcert = e.NewItems[0] as Concert<object>;
                        Console.Write("Добавлен новый концерт: "); newConcert.ShowInfo();
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        Concert<object> delConcert = e.OldItems[0] as Concert<object>;
                        Console.Write("Удалённый концерт: "); delConcert.ShowInfo();
                        break;
                    }
            }
        }
    }
}
