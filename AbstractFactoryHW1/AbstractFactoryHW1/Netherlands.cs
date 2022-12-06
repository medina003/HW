
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class Netherlands : ICountry
    {
        public string? FirstCavalry { get; set; }
        public string? SecondCavalry { get; set; }
        public string? FirstInfantry { get; set; }
        public string? SecondInfantry { get; set; }

        public void Priority()
        {
            Console.WriteLine("Musketeers of the 17th century have the highest build speed and rate of fire among musketeers.");
        }
    }
}
