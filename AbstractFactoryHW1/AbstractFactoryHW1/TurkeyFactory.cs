using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryHW1
{
    internal class TurkeyFactory : ICountryFactory
    {
        public ICountry CreateCountry()
        {
            return new Turkey();    
        }
    }
}
