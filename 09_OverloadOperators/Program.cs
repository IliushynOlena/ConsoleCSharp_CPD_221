using System;
using System.Security.Cryptography;

namespace _09_OverloadOperators
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"X: {X} Y: {Y} Z:{Z}";
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() : this(0, 0) { }
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void Print()
        {
            Console.WriteLine($"X = {X}. Y = {Y}");
        }
        public override string ToString()
        {
            return $"X = {X}. Y = {Y}";
        }
        //not allowed ref and out
        //public static return_type operator[symbol](parameters){ code }
        #region Унарні оператори
        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y); 

            //Point point = new Point { X = p.X *-1, Y = p.Y*-1 };
            //return point;
        }
        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }
        #endregion
        #region Бінарні оператори
        public static Point operator +(Point p1, Point p2)
        {
            Point p3 = new Point 
            { 
                X = p1.X + p2.X, 
                Y = p1.Y + p2.Y 
            };
            return p3;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
            return p3;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return p3;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return p3;
        }
        #endregion
        #region Оператори порівняння
        //public override bool Equals(object obj)
        //{
        //    Point p = obj as Point;

        //    return p != null && X == p.X && Y == p.Y;
        //}
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X + p1.Y > p2.X+p2.Y;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return !(p1> p2);
        }
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        public static bool operator <=(Point p1, Point p2)
        {
            return !(p1 >= p2);
        }

        public override int GetHashCode()//13256465413435
        {
            return HashCode.Combine(X, Y);
        }
        #endregion

        public static bool operator true(Point p1)
        {
            return p1.X != 0 || p1.Y != 0;
        }
        public static bool operator false(Point p1)
        {
            return p1.X == 0 && p1.Y == 0;
        }

        public static explicit operator int(Point p)//явне
        {
            return p.X + p.Y;
        }
        public static implicit operator double(Point p)//not явне
        {
            return p.X + p.Y;
        }
        public static implicit operator Point3D(Point p)//not явне
        {
            return new Point3D(p.X, p.Y, 0);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point() { X = 7, Y = 4 };
            int a = 5;
            double b = 6.7;
            b = a;//implicit
            a = (int)b;//explecit

            a = (int)point;//explecit
            Console.WriteLine("A = " + a);
            b = point;//implicit
            Console.WriteLine("B = " + b);

            Point3D newp = point;
            Console.WriteLine(newp);


            string str = "Hello";
            string str2 = "Hello";

            if (str.Equals(str2))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }

          
            point.Print();
            Console.WriteLine("Point : " + point);
            Console.WriteLine("Point : " + ++point);
            Console.WriteLine("Point : " + point++);

            Console.WriteLine("Point : " + --point);
            Console.WriteLine("Point : " + point--);

            Point p = -point;
            Console.WriteLine("Point : " + p);

            //Point point2 = point + p;
            //Point point2 = point - p;
            //Point point2 = point * p;
            Point point2 = point / p;
            Console.WriteLine("Point : " + point);
            Console.WriteLine("P : " + p);
            Console.WriteLine("Point + p : " + point2);

            Point mypoint1 = new Point(0, 0);
            Point mypoint2 = new Point(2, 5);

            if(mypoint1)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");

            }
            if (mypoint1.Equals(mypoint2))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
            if (mypoint1 == mypoint2)
            {
                Console.WriteLine("Equals p1== p2");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
            if (mypoint1 != mypoint2)
            {
                Console.WriteLine("Equals p1== p2");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
            if (mypoint1 > mypoint2)
            {
                Console.WriteLine("Equals p1> p2");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }


        }
    }
}
