using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace _05_IntroToOOP
{
    /*access spetificators 
    private (default for field)
    protected
    protected internal
    internal
    public
    */
    class MyClass
    {
        private int number;
        private const float PI = 3.14f;
        private readonly int id = 10;

        public MyClass()
        {
            number = 10;
           
        }   
        public void Show()
        {
            Console.WriteLine($"Id : {id} . Number = {number}");
        }

        //public override string ToString()
        //{
        //    //return base.ToString(); 
        //    return $"Id : {id} . Number = {number}";
        //}
    }

    struct Line
    {
        public float x;
        public float y;
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"X : {x}  Y: {y}");
            Console.ResetColor();
        }
    }
    class Point
    {
        private int xCoord;
        private int yCoord;
        public static int count;
        static Point()
        {
            count = 1000;
        }
        //string name;//full property

        //public string Name
        //{
        //    get 
        //    { 
        //        return name; 
        //    }
        //    set 
        //    { 
        //        name = value;
        //    }
        //}
        //auto property
        public string Color { get; private set; } = "Red";
        public string Name { get; set; }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public Point(int value) : this(value, value) {  }
        public Point(int x, int y) 
        {
            XCoord = x;
            YCoord = y;
           //SetXCoord(x);
           //SetYCoord(y);
        }  
        public void SetXCoord(int newX)
        {
            if (newX >= 0)
                xCoord = newX;
            else
                xCoord = 0;
        }
        public void SetYCoord(int newY)
        {
            if (newY >= 0)
                yCoord = newY;
            else
                yCoord = 0;
        }
        public int GetX()
        {
            return xCoord;
        }
        public int GetY()
        {
            return yCoord;
        }

        public int XCoord
        {
            get
            {  
                return xCoord;
            }  
            set
            {
                if (value >= 0)
                    xCoord = value;
                else
                    xCoord = 0;
            }
        }
        public int YCoord
        {
            get
            {
                return yCoord;
            }
            set
            {
                if (value >= 0)
                    yCoord = value;
                else
                    yCoord = 0;
            }
        }
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"X : {xCoord}  Y: {yCoord}");
            Console.ResetColor();
        }
        public override string ToString()
        {
            return $"X : {xCoord}  Y: {yCoord}";
        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            Point[] arr = new Point[5];
            arr.Append(new Point(5, 9));
            arr.Append(new Point(5, 9));
            arr.Append(new Point(5, 9));
            arr.Append(new Point(5, 9));
            Point point = new Point(4,7);
            Point.count = 0;
    
            Console.SetCursorPosition(2, 2);
            
            point.Print();

            point.SetYCoord(-50);
            Console.WriteLine(point);

            point.SetXCoord(50);
            Console.WriteLine(point.ToString());

            int x = point.GetX();
            Console.WriteLine("X = " + x);

            point.XCoord = 100;//setter
            x = point.XCoord;//getter
            Console.WriteLine("X = " + x);

            point.Name = "2D Point";//setter
            Console.WriteLine(point.Name);//getter
            Console.WriteLine(point.Color);//getter
           
            //MyClass c = new MyClass();
            ////MyClass @class = new MyClass();
            //c.Show();
            
            //Console.WriteLine(c.ToString());
            //Console.WriteLine(c);

           
        }
    }
}
