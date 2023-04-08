
using System.Text;

namespace IntroToCSharp
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the range number:");
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Hello world");
            Console.Write("Word....");
            Console.WriteLine("continue!");

            Console.WriteLine("Enter number : ");
            //string str = Console.ReadLine();
            //int number =  int.Parse(str);
            //Console.WriteLine(str + "!!!");
            //Console.WriteLine("Your number : " + number + " !!!");
            //Console.WriteLine("Your number : " + (number + 5) + " !!!");
            //Console.WriteLine($"Your number : {number + 10}!!!");
            int b = 135;
            Console.WriteLine(b);
            int a = 0;//not nullable
            //int b = null;
            string address = "";
            string address2 = null;//nullable
            //Nullable<int> num = null;
            int? num = null;
            int? num2 = null;

            Console.OutputEncoding = Encoding.UTF8;
            DateTime date = DateTime.Now;
            Console.WriteLine($"Default :  {date} \n" +
                $"ToShortDateString : {date.ToShortDateString()} \n" +
                $"ToShortTimeString :{date.ToShortTimeString()} \n" +
                $"ToLongDateString : {date.ToLongDateString()} \n" +
                $"ToLongTimeString : {date.ToLongTimeString()} \n" +
                $" Custom : {date.ToString("yyyy-MM-dd")}" );


            object obj = new object();
            Console.WriteLine(obj.ToString());

            bool myBool = true;
            Console.WriteLine(myBool);
            short myShort = 6;
            Console.WriteLine(myShort);
            float myFloat = 3.33F;
            Console.WriteLine(myFloat);

            DateTime date1 = new DateTime(2023, 04, 15);
            Console.WriteLine(date1.ToShortDateString());

            float f1 = 4.5f;
            int n1 = 44;
            float res = f1 + n1;
            Console.WriteLine(res);
            double res2 = f1;
            Console.WriteLine(res2);

            int res3 = (int)f1;
            Console.WriteLine(res3);

            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());
            int D = int.Parse(Console.ReadLine());
            int E = int.Parse(Console.ReadLine());
            Console.WriteLine($"Sum = {A+B+C}");
            try
            {
                Console.WriteLine("Введи число :");
                string numberString = Console.ReadLine();
                int number = int.Parse(numberString);
                Console.WriteLine("Число : " + number);

                number = Convert.ToInt32(numberString);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Continue.....");

            string s = null;
            string s2 = s;
            if(s != null)
                s.ToUpper();    
            //or - null-condotional operator
            s?.ToLower();

            s2 = s == null ? "Error" : s;

            if(s == null)
            {
                s2 = "Empty";
            }
            else
            {
                s2 = s;
            }
            s2 = s ?? "Empty";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(rnd.Next(10,100) + " ");
            }
            Console.WriteLine(rnd.Next());
            Console.WriteLine(rnd.Next(100));//0...99
            Console.WriteLine(rnd.Next(100,1000));//0...99
        }
    }
}




