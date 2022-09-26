using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace hw6cs
{
    internal class UserInterface
    {
        public Management management = new();
        private bool flag = true;
        public bool Flag { get { return flag; } set { flag = value; } }
        public void ShowOptions()
        {
            
            Console.WriteLine("Options:\n1)Add product\n2)Delete product\n3)Edit product\n4)Make a purchase\n5)Show products\n6)Exit\nEnter 1 - 6  >>> ");
            var choice1 = Convert.ToInt32(Console.ReadLine());
            if (choice1 > 0 && choice1 < 7)
            {
                if (choice1 == 1)
                {
                    management.Add();
                }
                else if (choice1 == 2)
                {
                    management.Delete();
                }
                else if (choice1 == 3)
                {
                    management.Edit();
                }
                else if (choice1 == 4)
                {
                    management.Make_a_Purchase();
                }
                else if (choice1 == 5)
                {
                    foreach (var item in management.Products)
                    {
                        Console.WriteLine($"Name: {item.Name}");
                        Console.WriteLine($"Price: {item.Price}");
                        Console.WriteLine($"Quantity: {item.Quantity}\n\n");
                    }
                }
                else if (choice1 == 6)
                {
                    flag = false;
                }
                
            }
            else Console.WriteLine("Wrong entered number.Try again.");
        }
    }
}
