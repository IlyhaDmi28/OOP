using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
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
