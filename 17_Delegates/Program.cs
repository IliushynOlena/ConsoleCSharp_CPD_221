using System;
using System.Collections.Specialized;
using System.Threading;

namespace _17_Delegates
{
   

    public delegate int IntDelegate(double a);
    //public delegate void VoidDelegate(int i);

    public delegate void StringDelegate(string s);
    public delegate void VoidDelegate();
    public delegate double GetDoubleDelegate();


    public class SuperClass
    {
        public void Print(string str)
        {
            Console.WriteLine("String : " + str);
        }
        public static double GetCoef()
        {
            double res = new Random().NextDouble();
            return res;
        }
        public double GetNumber()
        {
            return new Random().Next();
        }
        public double GetNumberPI()
        {
            return 3.14;
        }
        public void DoWork()
        {
            Console.WriteLine("Doing some work....");
        }
        public void Test()
        {
            Console.WriteLine("Testing....");
        }
    }
    public delegate double CalcDelegate(double x, double y);
    public class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Multy(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if(y != 0)
                return x / y;
            throw new DivideByZeroException();
        }

    }


    internal class Program
    {
        public static void DoOperation1(double a, double b, CalcDelegate oper)
        {
            //count(arr);
            Console.WriteLine(oper?.Invoke(a,b));
        }
        delegate void FinishAction();
        static void HardWork(FinishAction action)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i+1} working....");
                Thread.Sleep(rnd.Next(500));
                Console.WriteLine($"Operation {i+1} ended....");
            }
            //finish action 
            action?.Invoke();
            Console.WriteLine();
        }
        static void Action1()
        {
            Console.WriteLine("bye...bye....");
        }
        static void Main(string[] args)
        {
            HardWork(Action1);
            HardWork(delegate () { Console.WriteLine("Good job!!!"); } );


            Calculator calculator = new Calculator();

            DoOperation1(100, 2, calculator.Add);
            DoOperation1(60, 25, calculator.Sub);
            DoOperation1(55, 4, calculator.Multy);
            DoOperation1(100, 2, calculator.Div);

            CalcDelegate calc = calculator.Add;
            calc += calculator.Sub;
            calc += calculator.Multy;
            calc += calculator.Div;
            calc -= calculator.Div;

            foreach (CalcDelegate item in calc.GetInvocationList())
            {

                Console.WriteLine($" {item.Method.Name}  - Result {item.Invoke(15, 4)}");
            }

            double x, y;
            int key;
            do
            {
                Console.WriteLine("Enter first number : ");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter first number : ");
                y = double.Parse(Console.ReadLine());
                Console.WriteLine("Add - 1 ");
                Console.WriteLine("Sub - 2 ");
                Console.WriteLine("Multy - 3 ");
                Console.WriteLine("Div - 4 ");
                key = int.Parse(Console.ReadLine());
                CalcDelegate calcDelegate = null;
                switch (key)
                {
                    case 1:
                        calcDelegate = new CalcDelegate(calculator.Add);
                        break;
                    case 2:
                        calcDelegate = new CalcDelegate(calculator.Sub);
                        break;
                    case 3:
                        calcDelegate = calculator.Multy;
                        break;
                    case 4:
                        calcDelegate = calculator.Div;
                        break;
                    case 0:
                        Console.WriteLine("Good bye......");
                        break;
                    default:
                        Console.WriteLine("Incrrect choice");
                        break;
                }
                if (calcDelegate != null)
                    Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            } while (key != 0);

            /*
            //SuperClass SuperClass = new SuperClass();
            //Console.WriteLine(SuperClass.GetCoef());
            //GetDoubleDelegate method = new GetDoubleDelegate(SuperClass.GetCoef);
            GetDoubleDelegate method = null;//  SuperClass.GetCoef;
            //Console.WriteLine(method());
            //Console.WriteLine(method?.Invoke());
            if (method != null)
                method();
            if (method != null)
                method.Invoke();

            SuperClass superClass = new SuperClass();
            GetDoubleDelegate[] delArr = new GetDoubleDelegate[]
            {
                SuperClass.GetCoef,
                new GetDoubleDelegate(superClass.GetNumber)
            };
            Console.WriteLine(delArr[0]?.Invoke());
            Console.WriteLine(delArr[1]?.Invoke());

            GetDoubleDelegate dbl = new GetDoubleDelegate(SuperClass.GetCoef);
            StringDelegate srtDel = new StringDelegate(superClass.Print);
            VoidDelegate voidDelegate = new VoidDelegate(superClass.DoWork);

            Console.WriteLine(dbl?.Invoke());
            srtDel.Invoke("Hello world");
            voidDelegate.Invoke();
            Console.WriteLine("------------------------------");
            //Delegate.Combine(dbl, new GetDoubleDelegate(SuperClass.GetCoef));
            //Delegate.Combine(dbl, new GetDoubleDelegate(superClass.GetNumber));
            dbl += superClass.GetNumber;
            dbl += superClass.GetNumberPI;

            //Console.WriteLine(dbl());;
            foreach (var item in dbl.GetInvocationList())
            {
                Console.WriteLine(((GetDoubleDelegate)item).Invoke());
            }
            //Console.WriteLine(dbl.Invoke());
            */
        }
    }
}
