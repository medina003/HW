using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreHw3.Data.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int Quantity { get; set; }

    }
}
