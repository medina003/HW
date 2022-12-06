using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class England : ICountry
    {
        public string? FirstCavalry { get; set; }
        public string? SecondCavalry { get; set; }
        public string? FirstInfantry  { get; set; }
        public string? SecondInfantry { get; set; }
        public void Priority()
        {
            Console.WriteLine("Best cuirassiers in the game, tough Scots, cheap horseshoe.");
        }
    }
}
