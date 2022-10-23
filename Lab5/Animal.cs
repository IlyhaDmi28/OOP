using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{   
    public abstract class Animal
    {
        protected string Name;
         
        public int Weight;

        public int BirhYear;

        public Animal (string name, int weight, int birhYear)
        {
            Name = name;
            Weight = weight;
            BirhYear = birhYear;
        }

        public override string ToString()
        {
            return "Царство: Животные";
        }
    }
}
