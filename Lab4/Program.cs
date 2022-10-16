using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
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
    public abstract class Animal
    {
        public override string ToString()
        {
            return "Царство: Животные";
        }
    }
    public abstract class Mammals : Animal, LivingEntity
    {
        protected int HP = 70;
        public int hp { get { return HP; } }
        public void Eat()
        {
            HP = HP + 15;
            Console.WriteLine("+15HP");
        }
        public abstract void run();
        public override string ToString()
        {
            return $"Вид: Млекопитающее, HP: {HP}";
        }
    }
    public abstract class Birds : Animal, LivingEntity
    {
        protected int HP = 50;
        public int hp { get { return HP; } }
        public void Eat()
        {
            HP = HP + 10;
            Console.WriteLine("+10HP");

        }
        public abstract void fly();
        public override string ToString()
        {
            return $"Вид: Птица, HP: {HP}";
        }
    }
    public abstract class Fish : Animal, LivingEntity
    {
        protected int HP = 30;
        public int hp { get { return HP; } }
        public void Eat()
        {
            HP = HP + 5;
            Console.WriteLine("+5HP");

        }
        public abstract void swim();
        public override string ToString()
        {
            return $"Вид: Рыба, HP: {HP}";
        }
    }

    public class Owl : Birds
    {
        private const string Name = "Cова";
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
        private const string Name = "Попугай";
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
        private const string Name = "Лев";
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
        private const string Name = "Тигр";
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
        private const string Name = "Крокодил";
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
        private const string Name = "Акула";
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
        private const string Name = "Карась";
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
            Lion lion = new Lion();
            Tiger tiger = new Tiger();
            Aligator alig = new Aligator();
            Owl owl = new Owl();
            Parrot parrot = new Parrot();
            Shark shark = new Shark();
            Karas karas = new Karas();

            Mammals[] mammals = { lion, tiger, alig };
            Birds[]  birds = { owl, parrot };
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
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            Printer PrintType = new Printer();
            for (int i = 0; i < animals.Length; i++)
            {
                for (int j = 0; j < animals[i].Length; j++)
                {
                    PrintType.IAmPrinting(animals[i][j]);
                }
            }

            Console.WriteLine("\n--------------------------------------------------------------------\n");

            Test test = new Test();
            ((SimilarIn)test).Speak();
            test.Speak();
            
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine("1. Млекопитающее");
            Console.WriteLine("2. Птица");
            Console.WriteLine("3. Рыба");
            Console.Write("Выберите вид животного: ");
            int HealType = Convert.ToInt32(Console.ReadLine());
            int HealAnimal = 0;
            switch (HealType)
            {
                case 1:
                    {
                        Console.WriteLine("1. Лев");
                        Console.WriteLine("2. Тигр");
                        Console.WriteLine("3. Крокодил");
                        Console.Write("Выберите животного: ");
                        HealAnimal = Convert.ToInt32(Console.ReadLine());
                        break ;
                    }
                case 2:
                    {
                        Console.WriteLine("1. Сова");
                        Console.WriteLine("2. Попугай");
                        Console.Write("Выберите животного: ");
                        HealAnimal = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("1. Акула");
                        Console.WriteLine("2. Карась");
                        Console.Write("Выберите животного: ");
                        HealAnimal = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                default:
                    break;
            }
            LivingEntity Heal = null;
            if (animals[HealType - 1][HealAnimal - 1] is Lion) Heal = lion;
            if (animals[HealType - 1][HealAnimal - 1] is Tiger) Heal = tiger;
            if (animals[HealType - 1][HealAnimal - 1] is Aligator) Heal = alig;
            if (animals[HealType - 1][HealAnimal - 1] is Owl) Heal = owl;
            if (animals[HealType - 1][HealAnimal - 1] is Parrot) Heal = parrot;
            if (animals[HealType - 1][HealAnimal - 1] is Shark) Heal = shark;
            if (animals[HealType - 1][HealAnimal - 1] is Karas) Heal = karas;
            do
            {
                Console.WriteLine("1. Посмотреть здоровье");
                Console.WriteLine("2. Полечиться");
                Console.WriteLine("0. Выход");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1: Console.WriteLine(Heal.hp); break;
                    case 2: Heal.Eat(); break;
                    case 0: return;
                    default:
                        Console.WriteLine("Ввыбор сделан некорректно!");
                        break;
                }
            }
            while (true);

        }
    }
}
