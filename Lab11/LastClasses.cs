using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public abstract class Animal
    {
        protected string Name;
        public override string ToString()
        {
            return "Животные";
        }
    }

    interface LivingEntity
    {
        int hp { get; }

        void Eat();
    }
    public abstract class Mammals : Animal, LivingEntity
    {
        protected int HP = 70;
        public int hp { get { return HP; } }
        public void Eat()
        {
            HP += 15;
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
            HP += 10;
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
            HP += 5;
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
        public Owl(string name)
        {
            Name = name;
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
        public Parrot(string name)
        {
            Name = name;
        }

        public void Speak(string voice)
        {
            Console.WriteLine(voice);
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
        public Lion(string name)
        {
            Name = name;
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
        public Tiger(string name)
        {
            Name = name;
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
        public Aligator(string name)
        {
            Name = name;
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
        public Shark(string name)
        {
            Name = name;
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
        public Karas(string name)
        {
            Name = name;
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
