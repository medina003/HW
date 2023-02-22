using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreHw3.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }  
        public string Color { get; set; }
        public float Price { get; set; }    
        public ICollection<Salon> SalonList { get; set;}
    }
}
