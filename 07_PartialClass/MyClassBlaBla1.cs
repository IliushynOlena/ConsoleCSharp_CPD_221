using System;

namespace _07_PartialClass
{
    partial class MyClassBlaBla
    {
        public int Age { get; set; } = 100;

        public void Print()
        {
            Console.WriteLine("Age : " + Age); 
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Name : " + SurName);
            Console.WriteLine("Name : " + mark);

        }
    }
}
