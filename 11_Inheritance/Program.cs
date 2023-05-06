using System;


namespace _11_Inheritance
{
    abstract class Person //: object
    {
        private string name;
        private readonly DateTime birthDate;
        public Person()
        {
            name = "No name";
            birthDate = new DateTime();   
        }
        public Person(string n, DateTime b)
        {
            name = n;
            if(b > DateTime.Now)
                birthDate = new DateTime();
            else
                birthDate = b;           
        }
        public abstract void DoWork();
        virtual public void Print()
        {
            Console.WriteLine(" Name : {0} \n Birth : {1}", name, birthDate.ToShortDateString());    
        }
        public override string ToString()
        {
            return $" Name : {name} \n Birth : {birthDate.ToShortDateString()}" ;
        }
    }
    //class Name : BaseClass, Interface1, Interface2, Interface3
    class Worker : Person
    {
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { this.salary =  value >= 0 ? value : 0; }
        }
        public Worker():base()      
        {
            salary = 0;
        }
        public Worker(string n, DateTime d, decimal s):base(n,d)
        {
            Salary = s;
        }
        public override void DoWork()
        {
            Console.WriteLine("Doing some work!");
        }
        public override void Print() 
        {
            base.Print();
            Console.WriteLine($" Salary: {Salary}");
        } 
    }
    class Programmer : Worker
    {
        public string Language { get; set; }
        public int CodeLine { get; private set; }
        public Programmer():base()
        {
            Language = "no lang";
            CodeLine = 0;
        }
        public Programmer(string n, DateTime d, decimal s, string l):base(n,d,s)
        {
            Language = l;
            CodeLine = 0;
        }
        public sealed override void DoWork()
        {
            Console.WriteLine($"Write code {Language}");
        }
        public void WriteLine()
        {
            CodeLine++;
        }
        //public override void Print()
        //{
        //    base.Print();
        //    Console.WriteLine($"Language {Language} . Code Line {CodeLine}");
        //}
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Language {Language} . Code Line {CodeLine}");
        }
    }
    class TeachLead : Programmer
    {
        public int ProjectCount { get; set; }
        //public override void DoWork()
        //{
        //    Console.WriteLine($"Manage team projects!!!");
        //}

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TeachLead t = new TeachLead();
            t.DoWork();
            Worker worker = new Worker("Vova", new DateTime(2000,2,3),15000);   
            worker.DoWork();
            worker.Print();
            Console.WriteLine(worker);

            Person[] people = new Person[]
            {
                //new Person(),
                worker,
                new Programmer("Bill", DateTime.Now, 7800,"C +- ")
            };

            foreach (var person in people)
            {
                person.Print();
                Console.WriteLine();
            }

            Programmer p = null;
            //Person p = null;
            //use cast
            try
            {
                p = (Programmer)people[1];
                Console.WriteLine(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("----------------------");
            //use as
            p = people[1] as Programmer;
            if(p == null)
                Console.WriteLine("Incorrect type !!!!");
            else
                Console.WriteLine("Correct type !!!!");
            //use is with as

            if(people[2] is Programmer)
            {
                p = people[2] as Programmer;
                p.Print();
            }
            else
                Console.WriteLine("Incorrect type with using is !!!!");



        }
    }
}
