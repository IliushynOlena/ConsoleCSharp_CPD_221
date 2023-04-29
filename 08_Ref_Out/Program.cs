using System;
using System.Drawing;
using System.Text;

namespace _08_Ref_Out
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Print()
        {
            Console.WriteLine($"X + {X}. Y {Y}");
        }
    }
    struct _2D_Point
    {
        public int X { get; set; }//int x;
        public int Y { get; set; }
        //public _2D_Point()//default
        //{
        //    this.X = 0;
        //    this.Y = 0;
        //}
        public _2D_Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Print()
        {
            Console.WriteLine($"X + {X}. Y {Y}");
        }
    }


    internal class Program
    {
        static void MethodWithParams(string name, int age, int stupendia, params int[]marks)
        {
            Console.WriteLine("\n-------------- " + name + " " + age + " ----------");
            Console.WriteLine("\n-------------- " + stupendia + " ----------");
            foreach (var m in marks)
            {
                Console.Write(m + " ");
            }          
        }
        static void Modify(ref int num,ref string str,ref Point p )
        {
            num += 1;
            str += "!";
            p.X = num;
            p.Y = num;
        }
        //static void CuttentTime(ref int hour, ref int minute,ref int sec)
        //{
        //    hour = DateTime.Now.Hour;
        //    minute = DateTime.Now.Minute;
        //    sec = DateTime.Now.Second;
        //}
        static void CuttentTime(out int hour, out int minute, out int sec)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            sec = DateTime.Now.Second;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] arr = new string[] { "Вставити", "задану", "позицію", "рядка", "інший", "рядок" };
            foreach (var item in arr)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine("Enter length of world ");
            int l = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length == l)
                {
                    arr[i] = arr[i].Substring(0, arr[i].Length - 3);
                    arr[i] += "$";
                }
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item + " ");
            }
            Point p  = new Point(5,5);
            _2D_Point d_Point = new _2D_Point();//default ctor
            //int h, m, s;
            //Console.WriteLine($"{h}:{m}:{s}");
            CuttentTime(out int h, out int m, out int s);
            Console.WriteLine($"{h}:{m}:{s}");
            //int h = 0, m = 0, s = 0;
            //Console.WriteLine($"{h}:{m}:{s}");
            //CuttentTime(ref h,ref  m,ref  s);
            //Console.WriteLine($"{h}:{m}:{s}");
            /*
            int num = 10;
            string str = "Hello academy";
            Point p = new Point();
            Console.WriteLine(num);
            Console.WriteLine(str);
            p.Print();
            Modify(ref num,ref str,ref p);
            Console.WriteLine(num);
            Console.WriteLine(str);
            p.Print();




            int[] marks = new int[] {11,8,9,4,7};

            //MethodWithParams("Bob", marks);
            // MethodWithParams("Bob",new int[] {11,12,12,11,10,12,11,8 });
            MethodWithParams("Bob",20,12,12,11,10,12,11,8,8,4,5,6,7,5,8,9,6,8 );
            */
        }
    }
}
