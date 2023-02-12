using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab13
{
    interface LivingEntity
    {
        int hp { get; }

        void Eat();
    }

    [Serializable]
    public abstract class Animal
    {
        public override string ToString()
        {
            return "Животные";
        }
    }


    [Serializable]
    public abstract class Mammals : Animal, LivingEntity
    {
        public int HP = 70;
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

    [Serializable]
    public class Lion : Mammals
    {
        public string Name = "Лев";

        [XmlIgnore]
        public int weight = 100;
        public override void run()
        {
            Console.WriteLine($"{Name} побежал");
        }
        public override string ToString()
        {
            return "Животное: " + Name + ", " + base.ToString();
        }

        public Lion (string name)
        {
            Name = name;
        }
        public Lion()
        {
           
        }

    }
   
}
