using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;

namespace Lab4
{
    public enum BirthDay
    {
        LionYear = 2005,
        TigerYear,
        AligatorYear,
        OwlYear,
        ParrotYear,
        SharkYear = 2000,
        KarasYear,
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
    public class Printer
    {
        public void IAmPrinting(Animal obj)
        {
            if (obj is Lion) Console.WriteLine("Тип: Lion, " + obj.ToString());
            if (obj is Tiger) Console.WriteLine("Тип: Tiger, " + obj.ToString());
            if (obj is Aligator) Console.WriteLine("Тип: Aligator, " + obj.ToString());
            if (obj is Owl) Console.WriteLine("Тип: Owl, " + obj.ToString());
            if (obj is Parrot) Console.WriteLine("Тип: Parrot, " + obj.ToString());
            if (obj is Shark) Console.WriteLine("Тип: Shark, " + obj.ToString());
            if (obj is Karas) Console.WriteLine("Тип: Karas, " + obj.ToString());
        }
    }

    interface LivingEntity
    {
        int hp { get; }

        void Eat();
    }

    public class Owl : Birds
    {
        public Owl (string name, int weight, int birhYear) : base(name, weight, birhYear)
        {
         
        }
        public override void fly()
        {
            Console.WriteLine($"{Name} полетела");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }
    public class Parrot : Birds
    {
        public Parrot(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void fly()
        {
            Console.WriteLine($"{Name} полетел");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }

    public class Lion : Mammals
    {
        public Lion(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void run()
        {
            Console.WriteLine($"{Name} побежал");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }
    public class Tiger : Mammals
    {
        public Tiger(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void run()
        {
            Console.WriteLine($"{Name} побежал");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }
    public class Aligator : Mammals
    {
        public Aligator(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void run()
        {
            Console.WriteLine($"{Name} побежал");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }

    public class Shark : Fish
    {
        public Shark(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void swim()
        {
            Console.WriteLine($"{Name} поплыл");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }
    public sealed class Karas : Fish
    {
        public Karas(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {

        }
        public override void swim()
        {
            Console.WriteLine($"{Name} поплыл");
        }

        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }
    }


    interface SimilarIn
    {
        void Speak();
    }

    public abstract class SimilarClass
    {
        public abstract void Speak();
    }

    public class Test : SimilarClass, SimilarIn
    {
        public override void Speak()
        {
            Console.WriteLine("Вызвался абстрактный метод");
        }
        void SimilarIn.Speak()
        {
            Console.WriteLine("Вызвался метод в интерфейсе");
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
        static void AnimalDo(Mammals mammals)
        {
            Console.WriteLine("1. Поесть");
            Console.WriteLine("2. Побегать");
            Console.WriteLine("3. Просмотреть HP");
            Console.WriteLine("4. Просмотреть информацию");
            Console.WriteLine("Что надо сделать: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1: mammals.Eat(); break;
                case 2: mammals.run(); break;
                case 3: Console.WriteLine(mammals.hp); break;
                case 4: Console.WriteLine(mammals.ToString()); break;
                default:
                    Console.WriteLine("Выбор сделан некорректно!");
                    break;
            }
        }
        static void AnimalDo(Birds birds)
        {
            Console.WriteLine("1. Поесть");
            Console.WriteLine("2. Взлететь");
            Console.WriteLine("3. Просмотреть HP");
            Console.WriteLine("4. Просмотреть информацию");
            Console.WriteLine("Что надо сделать: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1: birds.Eat(); break;
                case 2: birds.fly(); break;
                case 3: Console.WriteLine(birds.hp); break;
                case 4: Console.WriteLine(birds.ToString()); break;
                default:
                    Console.WriteLine("Выбор сделан некорректно!");
                    break;
            }
        }
        static void AnimalDo(Fish fish)
        {
            Console.WriteLine("1. Поесть");
            Console.WriteLine("2. Поплыть");
            Console.WriteLine("3. Просмотреть HP");
            Console.WriteLine("4. Просмотреть информацию");
            Console.Write("Что надо сделать: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1: fish.Eat(); break;
                case 2: fish.swim(); break;
                case 3: Console.WriteLine(fish.hp); break;
                case 4: Console.WriteLine(fish.ToString()); break;
                default:
                    Console.WriteLine("Выбор сделан некорректно!");
                    break;
            }

        }

        static void Main(string[] args)
        {
            Weights weight = new Weights(120, 100, 105, 10, 1, 110, 1);

            Lion lion = new Lion("Лев", weight.LionWeight, (int)BirthDay.LionYear);
            Tiger tiger = new Tiger("Тигр", weight.TigerWeight, (int)BirthDay.TigerYear);
            Aligator alig = new Aligator("Крокодил", weight.AligatorWeight, (int)BirthDay.AligatorYear);
            Owl owl = new Owl("Сова", weight.OwlWeight, (int)BirthDay.OwlYear);
            Parrot parrot = new Parrot("Попугай", weight.ParrotWeight, (int)BirthDay.ParrotYear);
            Shark shark = new Shark("Акула", weight.SharkWeight, (int)BirthDay.SharkYear);
            Karas karas = new Karas("Карась", weight.KarasWeight, (int)BirthDay.KarasYear);

            Zoo zoo = new Zoo();
            zoo.Push(lion);
            zoo.Push(tiger);
            zoo.Push(owl);
            zoo.Push(parrot);
            zoo.Push(shark);
            zoo.Push(karas);

            Mammals[] mammals = { lion, tiger, alig };
            Birds[] birds = { owl, parrot };
            Fish[] fish = { shark, karas };
            Animal[][] animals = { mammals, birds, fish };
            int an;
            do
            {
                Console.WriteLine("1. Лев");
                Console.WriteLine("2. Тигр");
                Console.WriteLine("3. Крокодил");
                Console.WriteLine("4. Сова");
                Console.WriteLine("5. Попугай");
                Console.WriteLine("6. Акула");
                Console.WriteLine("7. Карась");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите животное: ");
                an = Convert.ToInt32(Console.ReadLine());
                switch (an)
                {
                    case 1: AnimalDo(mammals[0]); break;
                    case 2: AnimalDo(mammals[1]); break;
                    case 3: AnimalDo(mammals[2]); break;
                    case 4: AnimalDo(birds[0]); break;
                    case 5: AnimalDo(birds[1]); break;
                    case 6: AnimalDo(fish[0]); break;
                    case 7: AnimalDo(fish[1]); break;
                    case 0: an = 0; break;
                    default:
                        Console.WriteLine("Ввыбор сделан некорректно!");
                        break;
                }
            } while (an != 0);
            //Console.WriteLine("\n--------------------------------------------------------------------\n");

            //Printer PrintType = new Printer();
            //for (int i = 0; i < animals.Length; i++)
            //{
            //    for (int j = 0; j < animals[i].Length; j++)
            //    {
            //        PrintType.IAmPrinting(animals[i][j]);
            //    }
            //}

            //Console.WriteLine("\n--------------------------------------------------------------------\n");

            //Test test = new Test();
            //((SimilarIn)test).Speak();
            //test.Speak();

            //Console.WriteLine("\n--------------------------------------------------------------------\n");
            //Console.WriteLine("1. Млекопитающее");
            //Console.WriteLine("2. Птица");
            //Console.WriteLine("3. Рыба");
            //Console.Write("Выберите вид животного: ");
            //int HealType = Convert.ToInt32(Console.ReadLine());
            //int HealAnimal = 0;
            //switch (HealType)
            //{
            //    case 1:
            //        {
            //            Console.WriteLine("1. Лев");
            //            Console.WriteLine("2. Тигр");
            //            Console.WriteLine("3. Крокодил");
            //            Console.Write("Выберите животного: ");
            //            HealAnimal = Convert.ToInt32(Console.ReadLine());
            //            break ;
            //        }
            //    case 2:
            //        {
            //            Console.WriteLine("1. Сова");
            //            Console.WriteLine("2. Попугай");
            //            Console.Write("Выберите животного: ");
            //            HealAnimal = Convert.ToInt32(Console.ReadLine());
            //            break;
            //        }
            //    case 3:
            //        {
            //            Console.WriteLine("1. Акула");
            //            Console.WriteLine("2. Карась");
            //            Console.Write("Выберите животного: ");
            //            HealAnimal = Convert.ToInt32(Console.ReadLine());
            //            break;
            //        }
            //    default:
            //        break;
            //}
            //LivingEntity Heal = null;
            //if (animals[HealType - 1][HealAnimal - 1] is Lion) Heal = lion;
            //if (animals[HealType - 1][HealAnimal - 1] is Tiger) Heal = tiger;
            //if (animals[HealType - 1][HealAnimal - 1] is Aligator) Heal = alig;
            //if (animals[HealType - 1][HealAnimal - 1] is Owl) Heal = owl;
            //if (animals[HealType - 1][HealAnimal - 1] is Parrot) Heal = parrot;
            //if (animals[HealType - 1][HealAnimal - 1] is Shark) Heal = shark;
            //if (animals[HealType - 1][HealAnimal - 1] is Karas) Heal = karas;
            //do
            //{
            //    Console.WriteLine("1. Посмотреть здоровье");
            //    Console.WriteLine("2. Полечиться");
            //    Console.WriteLine("0. Выход");
            //    int choise = Convert.ToInt32(Console.ReadLine());
            //    switch (choise)
            //    {
            //        case 1: Console.WriteLine(Heal.hp); break;
            //        case 2: Heal.Eat(); break;
            //        case 0: return;
            //        default:
            //            Console.WriteLine("Ввыбор сделан некорректно!");
            //            break;
            //    }
            //}
            //while (true);

            Console.WriteLine("\n--------------------------------------------------------------------\n");

            int choise;
            do
            {
                Console.WriteLine("1. Просмотреть всех");
                Console.WriteLine("2. Количество хищных птиц");
                Console.WriteLine("3. Средний вес вида");
                Console.WriteLine("4. Просмотреть всех животных, отсортированных по году рождения");
                Console.Write("Выберите пункт: ");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1: zoo.DisplayAll(); break;
                    case 2: Zoo_Controler.PredatorBird(zoo); break;
                    case 3: Zoo_Controler.AvarageWeight(zoo); break;
                    case 4: Zoo_Controler.SortAnimals(zoo); break;
                    case 0: choise = 0; break;
                    default:
                        Console.WriteLine("Ввыбор сделан некорректно!");
                        break;
                }
            } while (choise != 0);
        }
    }
}
