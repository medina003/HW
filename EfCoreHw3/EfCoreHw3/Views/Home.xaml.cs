using EfCoreHw3.Data;
using EfCoreHw3.Data.Contexts;
using EfCoreHw3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EfCoreHw3.Views
{

    public partial class Home : Window
    {
        public AutosalonContext Context { get; set; }
        public Home()
        {
            InitializeComponent();
            Context= new AutosalonContext();
            //Car car= new Car { Model = "Econoline E250", Color = "White",Year = 2002, Price = 10000 };
            //Car car1 = new Car { Model = "Econoline E250", Color = "Black", Year = 2002, Price = 10000 };
            //Car car2 = new Car { Model = "Camaro", Color = "White", Year = 2002, Price = 10000 };
            //Brand brand = new Brand { Name = "Ford" };
            //Brand brand1 = new Brand { Name = "Chevrolet" };
            //Salon salon = new Salon {Brand = brand ,Car = car,Quantity = 20 };
            //Salon salon1 = new Salon { Brand = brand1, Car = car1, Quantity = 20 };
            //Context.Add(salon);
            //Context.Add(salon1);
            //Context.SaveChanges();
            Info_grid.ItemsSource = Context.Salon.Include(x => x.Car).Include(a => a.Brand).ToList();
            BrandName_combo.ItemsSource = Context.Brands.Local.ToBindingList();
            Info_grid.ItemsSource = Context.Salon.Include(x => x.Car).Include(a => a.Brand).ToList();

        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            float price = 0;
            if (Model_txt.Text != "" && Color_txt.Text != "" && Price_txt.Text != "" && float.TryParse(Price_txt.Text,out price) && (Year_txt.Text.All(char.IsDigit)) && Year_txt.Text  != "" && (Quantity_txt.Text.All(char.IsDigit)) && Quantity_txt.Text != "" && !BrandName_combo.Text.IsNullOrEmpty() )
            {
                if(Context.Salon.Any(s => (s.Car.Model.Equals(Model_txt.Text) && s.Car.Year.Equals(Int32.Parse(Year_txt.Text)) && s.Car.Color.Equals(Color_txt.Text) && s.Brand.Name.Equals(BrandName_combo.Text))))
                {
                    var entity = Context.Salon.Where(s => (s.Car.Model.Equals(Model_txt.Text) && s.Car.Year.Equals(Int32.Parse(Year_txt.Text)) && s.Car.Color.Equals(Color_txt.Text) && s.Brand.Name.Equals(BrandName_combo.Text))).FirstOrDefault();
                    entity.Quantity += Int32.Parse(Price_txt.Text);
                    Context.Update(entity);
                    Context.SaveChanges();  

                }
                else
                {
                    Car car = new Car { Model = Model_txt.Text, Color = Color_txt.Text, Year = Int32.Parse(Year_txt.Text), Price = float.Parse(Price_txt.Text) };
                    Brand brand = new Brand { Name = BrandName_combo.Text };
                    var entity = Context.Brands.Where(s => s.Name.Equals(BrandName_combo.Text)).FirstOrDefault();
                    Context.Add(new Salon() { BrandId = entity.Id, Car = car, Quantity = Int32.Parse(Quantity_txt.Text) });
                    Context.SaveChanges();
                }
                Info_grid.ItemsSource = Context.Salon.Include(x => x.Car).Include(a => a.Brand).ToList();

            }

            else MessageBox.Show("All fields are required and quantity,price must contain only numbers");
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if ( Info_grid.SelectedItems.Count == 1)
            {
                Context.Salon.Update((Salon)Info_grid.SelectedItem);
                Context.SaveChanges();
                Info_grid.ItemsSource = Context.Salon.Include(x => x.Car).Include(a => a.Brand).ToList();

            }
            else MessageBox.Show("Select one row and edit info in datagrid");
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Info_grid.SelectedItems.Count >= 0)
            {
                int count = Info_grid.SelectedItems.Count;
                for (int i = 0; i < count; i++)
                {
                    Context.Salon.Remove((Salon)Info_grid.SelectedItems[0]);
                    Context.SaveChanges();
                    Info_grid.ItemsSource = Context.Salon.Include(x => x.Car).Include(a => a.Brand).ToList();
                }
            }
            else MessageBox.Show("Select row(s)");
        }
    }
}
