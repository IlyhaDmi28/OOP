using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;
using System.Diagnostics;


namespace Lab4
{
    class AddException : Exception
    {
        public AddException(string message) : base(message)
        { }
    }
    class AnimalException : OverflowException
    {
        public AnimalException(string message) : base(message)
        { }
    }

    class UndefinedAnimalException : NullReferenceException
    {
        public UndefinedAnimalException(string message) : base(message)
        { }
    }

    
    public enum BirthDay
    {
        LionYear = 2005,
        TigerYear,
        AligatorYear,
        OwlYear,
        ParrotYear,
        SharkYear = 2000,
        KarasYear = 1347,
    }

    public struct Weights
    {
        public int LionWeight;
        public int TigerWeight;
        public int AligatorWeight;
        public int OwlWeight;
        public int ParrotWeight;
        public int SharkWeight;
        public int KarasWeight;

       public Weights (int weight1, int weight2, int weight3, int weight4, int weight5, int weight6, int weight7)
       {
            LionWeight = weight1;
            TigerWeight = weight2;
            AligatorWeight = weight3;
            OwlWeight = weight4;
            ParrotWeight = weight5;
            SharkWeight = weight6;
            KarasWeight = weight7;
       }
    }

    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public Animal this[int i] { get { return animals.ElementAt(i); } }


        public int WeightMammals = 0, numbMammals = 0;
        public int WeightBirds = 0, numbBirds = 0;
        public int WeightFish = 0, numbFish = 0;

        public int PredatorBirds = 0;
        public void Push(Animal animal)
        {
            if (animal == null) throw new UndefinedAnimalException("Ошибка! Животное не определенно!");
            if (animal.Weight <= 0) throw new AddException("Ошибка! Вес не может быть меньше 0");
            if (animal.BirhYear <= 1922) throw new AddException("Ошибка! Животные не могут так долго жить");

            animals.Add(animal);
            if (animal is Fish) { WeightFish += animal.Weight; numbFish++; }     
            if (animal is Mammals) { WeightMammals += animal.Weight; numbMammals++; }
            if (animal is Birds) { WeightBirds += animal.Weight; numbBirds++;
                Birds bird = animal as Birds;
                if (bird.PredatorBird) PredatorBirds++;
            }   
        }

        public void Pop(int number)
        {
            if (number >= animals.Count() || number < 0) throw new AnimalException("Ошибка! Индекс введён не корректно");
            animals.RemoveAt(number);
        }

        public void DisplayAll()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        public void DisplayAllSort()
        {

            var sorted = animals.OrderBy(ob => ob.BirhYear).ToArray();

            Array.ForEach(sorted, Console.WriteLine);
        }

    }

    public static class Zoo_Controler
    {
        public static void PredatorBird(this Zoo zoo)
        {
            Console.WriteLine($"Количество хищных птиц: {zoo.PredatorBirds}");
        }
        public static void AvarageWeight(this Zoo zoo)
        {
            Console.WriteLine("1. Млекопитающие");
            Console.WriteLine("2. Птицы");
            Console.WriteLine("3. Рыбы");
            Console.Write("Выберите вид животных, средний вес которых вы хотите вывести: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1: Console.WriteLine(zoo.WeightMammals / zoo.numbMammals); break;
                case 2: Console.WriteLine(zoo.WeightBirds / zoo.numbBirds); break;
                case 3: Console.WriteLine(zoo.WeightFish / zoo.numbFish); break;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }

        public static void SortAnimals(this Zoo zoo)
        {
            zoo.DisplayAllSort();
        }
    }
    //--------------------------------------------------------------------------------------------------------------
    internal class Program
    {

        static void Main(string[] args)
        {
            Weights weight = new Weights(120, 100, 105, 10, -12, 110, 1);

            Lion lion = new Lion("Лев", weight.LionWeight, (int)BirthDay.LionYear);
            Tiger tiger = new Tiger("Тигр", weight.TigerWeight, (int)BirthDay.TigerYear);
            Aligator alig = new Aligator("Крокодил", weight.AligatorWeight, (int)BirthDay.AligatorYear);
            Owl owl = new Owl("Сова", weight.OwlWeight, (int)BirthDay.OwlYear);
            Parrot parrot = new Parrot("Попугай", weight.ParrotWeight, (int)BirthDay.ParrotYear);
            Shark shark = new Shark("Акула", weight.SharkWeight, (int)BirthDay.SharkYear);
            Karas karas = new Karas("Карась", weight.KarasWeight, (int)BirthDay.KarasYear);
            Karas karp = null;

            Zoo zoo = new Zoo();
            
                zoo.Push(lion);
                zoo.Push(tiger);
                zoo.Push(owl);
            try 
            { 
                zoo.Push(parrot);
            }
            catch (AddException Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.TargetSite);
                Console.WriteLine();
            }
            zoo.Push(shark);
            try
            {
                int x = 0;
                if (x == 0) throw new DivideByZeroException("Ошибка! На ноль делить нельзя");
                else Console.WriteLine(343 / x);
            }
            catch (DivideByZeroException Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.TargetSite);
                Console.WriteLine();
            }
            try
            {
                zoo.Push(karas);
            }
            catch (AddException Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.TargetSite);
                Console.WriteLine();
            }

            try
            {
                zoo.Pop(435);
            }
            catch (AnimalException Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.TargetSite);
                Console.WriteLine();
            }

            try
            {
                try
                {
                    zoo.Push(karp);
                }
                catch (UndefinedAnimalException Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.WriteLine(Ex.TargetSite);
                    Console.WriteLine();
                    throw;
                }
            }
            catch
            {
                Console.WriteLine("Исключение сгенерировалость повторно!");
            }        
            finally
            {
                Console.WriteLine("\nВсе исключения обработанны!");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Введите число, корень которого вы хотите получить: ");
            int number = int.Parse(Console.ReadLine());


            void findsqrt(int Number)   
            {
                //Debugger.
                
                Debug.Assert(Number >= 0, "Дурак? Корня из отрицательных нет!");
                Console.WriteLine(Math.Sqrt(Number));
            }
            findsqrt(number);
        }
    }
}
