using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
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
            return $"Вид: Млекопитающее, HP: {HP}";
        }
    }
    public abstract class Birds : Animal, LivingEntity
    {
        public Birds (string name, int weight, int birhYear) : base(name,  weight, birhYear)
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
            return $"Вид: Птица, HP: {HP}";
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
            return $"Вид: Рыба, HP: {HP}";
        }
    }
}
