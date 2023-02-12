using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{   
    public abstract partial class Animal
    {
        public Animal (string name, int weight, int birhYear)
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
}
