using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ADONEThw2
{
    public static class Functions
    {
        static readonly ConfigurationBuilder configurationBuilder = new();
        static readonly SqlConnection conn;
        static Functions()
        {
            configurationBuilder.AddJsonFile("appsettings.json");
            var res = configurationBuilder.Build();
            conn = new(res.GetConnectionString("Stock"));

        }
        public static void Menu()
        {
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine($"\nOptions: \n1.Connect to a database \n2.Disconnect from a database \n3.Show all info of products " +
                    $"\n4.Show all types of products \n5.Show all providers \n6.Show products with max quantity" +
                    $"\n7.Show products with min quantity\n8.Show products with min price\n9.Show products with max price\n10.Show products of given type" +
                    $"\n11.Show products of given provider\n12.Show oldest product" +
                    $"\n13.Show average quantity of product of each type \n14.Exit\n\nEnter value from 1 to 14 ->");
                int option;
                bool result = int.TryParse(Console.ReadLine(), out option);
                Console.Clear();
                switch (result)
                {
                    case true:
                        switch (option)
                        {
                            case 1:
                                if (conn.State == System.Data.ConnectionState.Open) { Console.WriteLine("You was already connected"); }
                                else
                                {
                                    conn.Open();
                                    if (conn.State == System.Data.ConnectionState.Open) { Console.WriteLine("Successfully connected"); }
                                    else Console.WriteLine("Can not to connect");
                                }
                                break;
                            case 2:
                                conn.Close();
                                if (conn.State == System.Data.ConnectionState.Closed) { Console.WriteLine("Successfully disconnected"); }
                                else Console.WriteLine("Can not to disconnect");
                                break;

                            case 3:
                                Functions.ShowAll();
                                break;
                            case 4:
                                Functions.ShowTypesNames();
                                break;
                            case 5:
                                Functions.ShowProvidersNames();
                                break;
                            case 6:
                                Functions.ShowProductsWithMaxQuantity();
                                break;
                            case 7:
                                Functions.ShowProductsWithMinQuantity();
                                break;
                            case 8:
                                Functions.ShowProductsWithMinPrice();
                                break;
                            case 9:
                                Functions.ShowProductsWithMaxPrice();
                                break;
                            case 10:
                                Console.WriteLine("Enter type ->");
                                var type = Console.ReadLine();
                                if (type != null)
                                {
                                    Functions.ShowWithGivenType(type);
                                }
                                else Console.WriteLine("Wrong entered data");
                                break;
                            case 11:
                                Console.WriteLine("Enter name ->");
                                var name = Console.ReadLine();
                                if (name != null)
                                {
                                    Functions.ShowWithGivenProvider(name);
                                }
                                else Console.WriteLine("Wrong entered data");
                                break;
                            case 12:
                                Functions.ShowOldest();
                                break;
                            case 13:
                                Functions.ShowAvg();
                                break;
                            case 14:
                                Console.WriteLine("Thanks for using this app:)");
                                Flag = false;
                                break;

                            default:
                                Console.WriteLine("Wrong entered data");

                                break;
                        }

                        break;
                    case false:
                        Console.WriteLine("Wrong entered data!");
                        break;

                }


            }

        }


        public static void ShowAll()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {

                using SqlCommand comm = new("select P.Id,P.Name,P.Quantity,P.Price,P.Date,Gt.TypeName,Pr.Name from Products P inner join GoodsTypes GT on P.TypeId = GT.Id inner join Providers Pr on P.ProvidersId = Pr.Id", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}\t{reader[4]}\t{reader[5]}");
                }
            }
            else { Console.WriteLine("You are't connected to database"); }

        }
        public static void ShowTypesNames()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from GoodsTypes", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}\t{reader[1]}");
                }
            }
            else { Console.WriteLine("You are't connected to database"); }

        }
        public static void ShowProvidersNames()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Providers", conn);
                using SqlDataReader reader = comm.ExecuteReader();

                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}\t{reader[1]}");
                }
            }
            else { Console.WriteLine("You are't connected to database"); }

        }
        public static void ShowProductsWithMaxQuantity()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Products where Quantity = (select  max(Quantity) from Products);", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowProductsWithMinQuantity()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Products where Quantity = (select  min(Quantity) from Products);", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowProductsWithMinPrice()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Products where Price = (select  min(Price) from Products);", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowProductsWithMaxPrice()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Products where Price = (select  max(Price) from Products);", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowWithGivenType(string type)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new($"select P.Id, Name, TypeId, ProvidersId, Quantity, Price, Date from Products as P inner join GoodsTypes as GT on P.TypeId  = GT.Id  where GT.TypeName = '{type}'", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowWithGivenProvider(string name)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new($"select  P.Id, P.Name, TypeId, ProvidersId, Quantity, Price, Date from Products as P left join Providers as Pr on P.TypeId  = Pr.Id  where Pr.Name = '{name}'", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowOldest()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new("select * from Products where Date = (select  min(Date) from Products);", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }
        public static void ShowAvg()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using SqlCommand comm = new($"select GT.TypeName , avg(Quantity) from Products inner join GoodsTypes GT on Products.TypeId = GT.Id group by GT.TypeName", conn);
                using SqlDataReader reader = comm.ExecuteReader();
                foreach (var item in reader.GetColumnSchema())
                {
                    Console.Write(item.ColumnName + '\t');
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You are't connected to database");
            }
        }

    }
}

