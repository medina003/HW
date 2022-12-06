using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class Austria : ICountry
    {
        public string? FirstCavalry { get; set; }
        public string? SecondCavalry { get; set; }
        public string? FirstInfantry { get; set; }
        public string? SecondInfantry { get; set; }

        public void Priority()
        {
            Console.WriteLine("Everything is here: common European units, light cavalry, rush tunics, elite shooter.");
        }
    }
}
