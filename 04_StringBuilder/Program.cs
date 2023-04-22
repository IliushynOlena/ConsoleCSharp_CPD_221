using System;
using System.Text;

namespace _04_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string str = "Hello";
            Console.WriteLine(str);
            str += ", world";
            Console.WriteLine(str);
            str += "!";
            Console.WriteLine(str);

            StringBuilder builder = new StringBuilder();
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);
            builder.Append("Hello");
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);

        }
    }
}
