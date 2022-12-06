using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class Portugal : ICountry
    {
        public string? FirstCavalry { get; set; }
        public string? SecondCavalry { get; set; }
        public string? FirstInfantry { get; set; }
        public string? SecondInfantry { get; set; }

        public void Priority()
        {
            Console.WriteLine("Unique Building: A port that fires like a tower.");
        }
    }
}
