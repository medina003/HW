namespace HW
{
    //Task1
    class Money
    {
       public int Dollars { set; get; }       
       public int Cents { set; get; } 
        public float GetSum()
        {
            float all = (float)(Dollars + Cents / 100 + (Cents % 100) * 0.01);
            return all;
        }
        public override string ToString()
        {
            return $"{Dollars},{Cents}";
        }
    }
    //Task2 
    abstract class  Device
    {
        public string Name { set; get; } 
        public string Description { set; get; }
        public Device(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void Sound();
        public virtual void Show() 
        {
            Console.WriteLine($"Name: {Name}");
        }
        public virtual void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }
        
    }

    class Kettle : Device
    {
        public Kettle(string name, string description) : base(name, description)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("IUUU");
        }
    }
    class Microwave : Device
    {
        public Microwave(string name,string description) : base(name, description)
        {

        }
        public override void Sound()
        {
            Console.WriteLine("BUZZ");
        }
    }
    class Car : Device
    {
        public Car(string name, string description) : base(name, description)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("VOOM");
        }
    }
    class Steamship : Device
    {
        public Steamship(string name, string description) : base(name, description)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("DUUU");
        }
    }

    //Task3
    abstract class MusicaInstrument
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public MusicaInstrument(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void Sound();
        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}");
        }
        public virtual void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }
        public abstract void History();

    }

    class Violin : MusicaInstrument
    {
        public Violin(string name, string description) : base(name, description)
        {
        }

        public override void History()
        {
            Console.WriteLine("The violin was first known in 16th-century Italy, with some further modifications occurring in the 18th and 19th centuries to give the instrument a more powerful sound and projection.");
        }

        public override void Sound()
        {
            Console.WriteLine("TRRIN");
        }
    }
    class Trombone : MusicaInstrument
    {
        public Trombone(string name, string description) : base(name, description)
        {

        }

        public override void History()
        {
            Console.WriteLine("The trombone is a 15th-century development of the trumpet and, until approximately 1700, was known as the sackbut.");
        }

        public override void Sound()
        {
            Console.WriteLine("POOM");
        }
    }
    class Ukulele : MusicaInstrument
    {
        public Ukulele(string name, string description) : base(name, description)
        {
        }

        public override void History()
        {
            Console.WriteLine("The instrument, with its four plastic strings and a short neck, originated in Europe and was introduced to Hawaii in 1879 when a Portuguese immigrant named Joao Fernandez jumped off the boat and started strumming and singing with his branguinha");
        }

        public override void Sound()
        {
            Console.WriteLine("TRRIN");
        }
    }
    class Cello : MusicaInstrument
    {
        public Cello(string name, string description) : base(name, description)
        {

        }

        public override void History()
        {
            Console.WriteLine("The earliest cellos were developed during the 16th century and frequently were made with five strings. They served mainly to reinforce the bass line in ensembles. Only during the 17th and 18th centuries did the cello replace the bass viola da gamba as a solo instrument.");
        }

        public override void Sound()
        {
            Console.WriteLine("TRR");
        }
    }
    //Task4
    abstract class Worker
    {
        public string FIO { set; get; }
        public DateTime dt;
        public float Salary { set; get; } 
        public string Description { set; get; }
        public Worker(string fio, DateTime date, float salary, string description)
        {
            this.FIO = fio;
            this.dt = date;
            Salary = salary;
            Description = description;
        }
        public virtual void Print()
        {
            Console.WriteLine($"FIO: {FIO}\nBirth date: {dt}\nSalary: {Salary}\nDescription: {Description}");
        }
    }
    class President : Worker
    {
        public string Country { set; get; }
        public President(string fio, DateTime date, float salary, string description,string country) : base(fio, date, salary, description)
        {
            Country = country;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Country: {Country}");
        }
    }
    class Security : Worker
    {
        public string Responsobilities { set; get; }
        public Security(string fio, DateTime date, float salary, string description, string responsobilities) : base(fio, date, salary, description)
        {
            Responsobilities = responsobilities;    
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Responosobilities: {Responsobilities}");
        }
    }
    class Manager : Worker
    {
        public string Company { set; get; }
        public Manager(string fio, DateTime date, float salary, string description, string company) : base(fio, date, salary, description)
        {
            Company = company;  
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Company: {Company}");
        }
    }
    class Engineer : Worker
    {
        public string Field { set; get; }
        public Engineer(string fio, DateTime date, float salary, string description, string field) : base(fio, date, salary, description)
        {
            Field = field;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Field: {Field}");
        }
    }
    
    class Product
    {
        public string Name { set; get; }
        public Money Price { set; get; }
        public void Reduce_price(Money amount)
        {
            if(this.Price.Dollars < amount.Dollars) { Console.WriteLine("Amount must not be greater than price"); }
            else
            {
                float all = Price.GetSum();
                all -= amount.GetSum();
               string[] s =  all.ToString().Split(',');
                Price.Dollars = Convert.ToInt32(s[0]);    
                Price.Cents = Convert.ToInt32(s[1]);

            }

        }

    }
    class Program
    {
        public static void Main()
        {
           
        }
    }
}