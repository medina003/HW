using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace hw6cs
{
    internal class Management
    {

        public List<Product> Products = new();
        public void Add()
        {
            Console.WriteLine("Enter the name > ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the price > ");
            float price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the quantity > ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cant't be empty. Try to add product again.");
            }
            else if (!string.IsNullOrEmpty(name))
            {
                bool flag = false;
                foreach (var item in Products)
                {
                    if (item.Name == name)
                    {
                        flag = true;
                        Console.WriteLine("Product with this name already exists. Add a product again with a non-existent name.");
                        break;
                    }
                }
                if (!flag) 
                { 
                    Products.Add(new(name, price, quantity));
  
                    var json = JsonSerializer.Serialize(Products);
                    bool check = File.Exists("myfile.json");
                    if (!check)
                    {
                        var i = File.Create("myfile.json");
                        i.Close();
                    }
                    FileStream f = new FileStream("myfile.json", FileMode.Truncate);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine(json);
                    s.Close();
                    f.Close();
                }
            }
        }
        public void Delete()
        {

            for (var item = 0; item < Products.Count; item++)
            {

                Console.WriteLine($"{item + 1}) {Products[item].Name}");
            }
            Console.WriteLine("Enter the number of the product which you want to delete >>> ");
            var index = Convert.ToInt32(Console.ReadLine());
            index--;
            if(index <= Products.Count - 1 )
            {
            Products.RemoveAt(index);
            Console.WriteLine("Product was successfully deleted.");
            var json = JsonSerializer.Serialize(Products);
            bool check = File.Exists("myfile.json");
            if (!check)
            {
                var i = File.Create("myfile.json");
                i.Close();
            }
            FileStream f = new FileStream("myfile.json", FileMode.Truncate);
            StreamWriter s = new StreamWriter(f);
            s.WriteLine(json);
            s.Close();
            f.Close();
            }
            else if (index < 0 || index > Products.Count - 1) Console.WriteLine("Wrong entered number.Try again.");
        
        }

    public void Edit()
        {
            for (var item = 0; item < Products.Count; item++)
            {

                Console.WriteLine($"{item + 1}) {Products[item].Name}");
            }
            Console.WriteLine("Enter the number of the product which you want to edit >>> ");
            var index = Convert.ToInt32(Console.ReadLine());
            index--;
            if (index <= Products.Count - 1)
            {
                Console.WriteLine("1)Edit name\n2)Edit price\n3)Edit quantity\nEnter your choice >>> ");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0 && choice < 4)
                {

                    if (choice == 1)
                    {
                        Console.WriteLine("Enter a new name >>> ");
                        var newname = (Console.ReadLine());
                        if (!string.IsNullOrEmpty(newname))
                        {
                            bool flag = false;
                            foreach (var item in Products)
                            {
                                if (item.Name == newname)
                                {
                                    flag = true;
                                    Console.WriteLine("Product with this name already exists. Add a product again with a non-existent name.");
                                    break;
                                }
                            }
                            if (!flag) Products[index].Name = newname;

                        }
                        else Console.WriteLine("Name cant't be empty.Try to enter again.");

                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter a new price >>> ");
                        var newprice = Convert.ToSingle(Console.ReadLine());
                        if (newprice > 0) Products[index].Price = newprice;
                        else Console.WriteLine("Price cant't be empty.Try to enter again.");

                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Enter a new quantity >>> ");
                        var newquantity = Convert.ToInt32(Console.ReadLine());
                        if (newquantity > 0) Products[index].Quantity = newquantity;
                        else Console.WriteLine("Quantity cant't be empty.Try to enter again.");

                    }
                    var json = JsonSerializer.Serialize(Products);
                    bool check = File.Exists("myfile.json");
                    if (!check)
                    {
                        var i = File.Create("myfile.json");
                        i.Close();
                    }
                    FileStream f = new FileStream("myfile.json", FileMode.Truncate);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine(json);
                    s.Close();
                    f.Close();
                }
                else Console.WriteLine("Wrong entered data.Try again.");
            }
            else Console.WriteLine("Wrong entered data.Try again.");
        } 

        public void Make_a_Purchase()
        {
            for (var item = 0; item < Products.Count; item++)
            {

                Console.WriteLine($"{item + 1}) {Products[item].Name}");
            }
            Console.WriteLine("Enter the number of the product which you want to purchase >>> ");
            var index = Convert.ToInt32(Console.ReadLine());
            index--;
            if (index <= Products.Count - 1)
            {
                Console.WriteLine("Enter the quantity  >>> ");
                var q = Convert.ToInt32(Console.ReadLine());
                if (q > 0 && q <= Products[index].Quantity)
                {
                    Products[index].Quantity -= q;
                    var json = JsonSerializer.Serialize(Products);
                    bool check = File.Exists("myfile.json");
                    if (!check)
                    {
                        var i = File.Create("myfile.json");
                        i.Close();
                    }
                    FileStream f = new FileStream("myfile.json", FileMode.Truncate);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine(json);
                    s.Close();
                    f.Close();
                }
                else if (q > Products[index].Quantity) Console.WriteLine($"There is/are only {Products[index].Quantity} item(s) in the stock");
                else if (q < 0) Console.WriteLine("Quantity must be > 0");
            }
            else if (index < 0 || index > Products.Count - 1) Console.WriteLine("Wrong entered number.Try again.");
        }


    }
       
    
}
