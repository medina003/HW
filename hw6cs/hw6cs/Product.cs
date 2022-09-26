using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6cs
{
    internal class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, float price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public Product() : this("noname", 0, 1) { }
       
    }

}
