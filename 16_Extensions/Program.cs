using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace _16_Extensions
{
    static class ExampeExtensions
    {
        public static int NumberWords(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            return text.Split(new char[] {' ', '.',',','!','-'}, 
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int NumberSymbol(this string data, char s )
        {
            int c = 0;
            if (string.IsNullOrEmpty(data))
                return 0;
            foreach (var item in data)
            {
                if (item == s) c++;
            }
            return c;
        }
        public static void Test(this char data)
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ExampeExtensions.NumberWords(str);
            string str = Console.ReadLine();
            Console.WriteLine("Number of words : " + str.NumberWords()  ); 
            Console.WriteLine("Number of symbols : " + str.NumberSymbol('o')  ); 
        }
    }
}
