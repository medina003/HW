using hw6cs;
using System.Text.Json;
namespace Program
{
class Program
    {
        public static void Main()
        {
         
            UserInterface ui = new UserInterface();
            FileStream fs = new("myfile.json", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string jsonline = sr.ReadToEnd();
            if (jsonline != null)
            {
                ui.management.Products = JsonSerializer.Deserialize<List<Product>>(jsonline);

            }
            sr.Close();
            fs.Close();      

            while (ui.Flag)
            {
                ui.ShowOptions();
            }
        }
        }
    }




