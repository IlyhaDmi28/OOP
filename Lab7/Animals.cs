using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
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
        public Weights(int weight1, int weight2, int weight3, int weight4, int weight5, int weight6, int weight7)
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
    public abstract class Animal : IComparable<Animal>
    {
        protected string Name;

        public int Weight;

        public int BirhYear;

        public int CompareTo(Animal an)
        {

            if (this.BirhYear > an.BirhYear)
                return 1;
            if (this.BirhYear < an.BirhYear)
                return -1;
            else
                return 0;

        }
        public Animal(string name, int weight, int birhYear)
        {
            Name = name;
            Weight = weight;
            BirhYear = birhYear;
        }

        public override string ToString()
        {
            return $"Год рождения: {BirhYear}, Вес: {Weight}";
        }
    }

    interface LivingEntity
    {
        int hp { get; }

        void Eat();
    }
    public abstract class Mammals : Animal, LivingEntity
    {
        public Mammals(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {
        }
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
            return $"Вид: Млекопитающее, HP: {HP}, " + base.ToString();
        }
    }
    public abstract class Birds : Animal, LivingEntity
    {
        public Birds(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {
        }

        protected int HP = 50;
        public int hp { get { return HP; } }

        public bool PredatorBird;
        public void Eat()
        {
            HP = HP + 10;
            Console.WriteLine("+10HP");

        }
        public abstract void fly();
        public override string ToString()
        {
            return $"Вид: Птица, HP: {HP}, " + base.ToString();
        }
    }
    public abstract class Fish : Animal, LivingEntity
    {
        protected int HP = 30;
        public Fish(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {
        }
        public int hp { get { return HP; } }
        public void Eat()
        {
            HP = HP + 5;
            Console.WriteLine("+5HP");

        }
        public abstract void swim();
        public override string ToString()
        {
            return $"Вид: Рыба, HP: {HP}, " + base.ToString();
        }
    }

    public class Owl : Birds
    {
        public Owl(string name, int weight, int birhYear) : base(name, weight, birhYear)
        {
            PredatorBird = true;
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
}
