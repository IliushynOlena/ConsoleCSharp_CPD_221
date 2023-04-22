using System;

namespace _07_PartialClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mark = 12;
            MyClassBlaBla bla = new MyClassBlaBla();
            bla.SetMark(ref mark);
            bla.Print();
            Console.WriteLine("Hello World!");
        }
    }
}
