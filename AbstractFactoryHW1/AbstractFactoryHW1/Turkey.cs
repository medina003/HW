using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class Turkey : ICountry
    {
        public string? FirstCavalry { get; set; }
        public string? SecondCavalry { get; set; }
        public string? FirstInfantry { get; set; }
        public string? SecondInfantry { get; set; }

        public void Priority()
        {
            Console.WriteLine("You can rush with infantry, raid with Tatars, attack with strong janissaries, covered with spakhs, etc.");
        }
    }
}
