using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _12_Interfaces
{
    internal class MyClass
    {

    }
    public interface IWorker
    {
        string Work();
        public bool IsWorking { get;  }
        //event EventHandler WorkEnded;   
    }
    public interface IManager
    {
        List<IWorker> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $" Surname : {LastName} . Name {FirstName} . " +
                $"Birthdate :{BirthDate.ToLongDateString()}";
        }
    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" \n Position {Position} . Salary {Salary}$";
        }
    }
    class Director : Employee, IManager//implement(realize)
    {
        public List<IWorker> ListOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("I am controling work.....");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I make budget.....");
        }
        public void Organize()
        {
            Console.WriteLine("Organize work.....");
        }
    }
    class Seller : Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; }  }

        public string Work()
        {
            return "Selling product";
        }
    }
    class Cashier : Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "Cashier count money";
        }
    }
    class Administrator : Employee, IManager, IWorker
    {
        public bool IsWorking { get; }

        public List<IWorker> ListOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("I am administrator. I control work!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I am administrator. I count  money! I am a BOSSS. Xaxaxaxaxaxax");
        }

        public void Organize()
        {
            Console.WriteLine("I am administrator. I Organize work!");
        }

        public string Work()
        {
            return "I work..........";
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            IManager director = new Director
            {
                LastName = "Lutsuk",
                FirstName = "Ivan",
                BirthDate = new DateTime(1956, 2, 5),
                Position = "Director",
                Salary = 12000
            };

         



            director.Organize();
            IWorker seller = new Seller
            {
                FirstName = "Katya",
                LastName = "Oliunuk",
                BirthDate = new DateTime(2000, 4, 15),
                Position = "Seller",
                Salary = 8000
            };
            Console.WriteLine(seller.Work()); 

            if( seller is Employee)
                Console.WriteLine($"Seller salary { (seller as Employee).Salary}");



            var admin = new Administrator();
            admin.Organize();
            admin.Work();

            IManager manager = admin;
            
            manager.MakeBudget();

            IWorker worker = admin;
            worker.Work();

            director.ListOfWorkers = new List<IWorker>
            {
                seller,
                admin,
                worker,
                new Cashier
                {
                    LastName = "Smith",
                    FirstName = "Nicole",
                    BirthDate = new DateTime(2000, 2, 5),
                    Position = "Cashier",
                    Salary = 5000
                }
            };
            Console.WriteLine("-------------------------");
            foreach (var item in director.ListOfWorkers)
            {
                Console.WriteLine(item.Work());
                if(item is Administrator)
                    (item as Administrator).Organize();
            }
        }
    }
}
