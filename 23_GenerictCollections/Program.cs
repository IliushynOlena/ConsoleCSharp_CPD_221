namespace _23_GenerictCollections
{
    //Generics
    /*
     * Classes
     * Structures
     * Collections
     * Methods
     * Interface
     * Delegate 
     */
    public delegate float SubDelegate(float a, float b);
    public delegate int SummaDelegate2(int a, int b);
    public delegate Type SummaOperation<Type>(Type a, Type b);
    public delegate bool CompareDelegate<T1, T2>(T1 elem, T2 elem2);

    interface IMyComparable<T>
    {
        void CompareMyObject(T x, T y);
    }
    interface IIndexer<T>
    {
        T this[int index] { get; set; }
    }
    class User : IMyComparable<User>
    {
        public void CompareMyObject(User x, User y)
        {
            throw new NotImplementedException();
        }
    }
    class MyList: IIndexer<string>, IMyComparable<MyList>
    {
        string[] lines;
        public string this[int index] { get => lines[index]; set => lines[index] = value; }

        public void CompareMyObject(MyList x, MyList y)
        {
            throw new NotImplementedException();
        }
    }
    //We can set the limits to generics type
    //struct - 
    // class
    //interface
    //new()
    //Base Class
    class MyArray<Type>: IIndexer<Type> 
    {
        Type[] arr;

        public Type this[int index] 
        { get 
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                return arr[index];
            }
            set {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                arr[index] = value;
            }
        }
        public MyArray(int size = 10)
        {
            Random rnd = new Random();
            arr = new Type[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = default(Type);
            }
        }
        public void AddElement(Type element)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = element;
        }
        public override string ToString()
        {
            string res = "";
            foreach (var item in arr)
            {
                res += item + "- ";
            }
            return res;
        }
    }

    class Point<T1, T2> //where T1: struct ,new() // where T1 : class, IComparable<T1>, new()
    {
        // do not allow to use arif and logic operations for generic types: T1, T2
        public T1 X { get; set; }
        public T2 Y { get; set; }

        // Default ctor
        public Point()
        {
            //X = 0;       // error
            //Y = null;    // error

            // -------- Default values:
            // for reference: null
            // numbers: 0
            // boolean: false
            X = default(T1);
            Y = default(T2);

            // with limited new()
            //T1 item = new T1();
            // with interface limit
            //item.CompareTo(X);
       }

        public Point(T1 x, T2 y)
        {
            this.X = x;
            Y = y;

            // typeof - return Type of an element
            if (typeof(T1) == typeof(int))
            {
                Console.WriteLine("T1 is int");
            }
            if (typeof(T2) == typeof(double))
            {
                Console.WriteLine("T2 is double");
            }
        }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
  
    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static float Add(float a, float b)
        {
            return a + b;
        }
        static float Sub(float a, float b)
        {
            return a - b;
        }
        static bool Compare(double n1, decimal n2)
        {
            return (decimal)n1 == n2;
        }
        // Generic Method ------------------------

        static void ShowObject<T>(T obj)
        {
            Console.WriteLine(obj.ToString());
        }

        static bool CompareHashCode<T1, T2>(T1 obj1, T2 obj2)
        {
            return obj1.GetHashCode() == obj2.GetHashCode();
        }

        static TRes Mult<T1, T2, TRes>(T1 op1, T2 op2)
        {
            TRes result = default(TRes);
            return result;
        }

        static void Main(string[] args)
        {
            //////////// methods
            short a = 10;
            int b = 10;

            if (CompareHashCode<short, int>(a, b))
                Console.WriteLine("Hash codes equals!");
            else
                Console.WriteLine("Hash codes not equals!");

            ShowObject<int>(55);
            ShowObject<string>("Hello");
            ShowObject(55);
            ShowObject<Point<int, int>>(new Point<int, int>());

            Mult<int, double, decimal>(5, 1.5);

            // pause
            Console.ReadKey();

            /*
            Point<MyClass, int> r;
            Point<int, double> p = new Point<int, double>(5, 6.7);
            Console.WriteLine(p);
            Console.WriteLine(p.GetType().ToString());
            Console.WriteLine(p.GetType().Name);*/
            /*
            MyArray<float> myArr = new MyArray<float>();
            myArr.AddElement(77.33f);
            myArr.AddElement(15.23f);
            myArr.AddElement(3.33f);
            myArr.AddElement(77.33f);
            Console.WriteLine(myArr[0]);
            Console.WriteLine(myArr);

            MyArray<bool> myArr2 = new MyArray<bool>();
            myArr2.AddElement(true);
            myArr2.AddElement(false);
            myArr2.AddElement(true);
            myArr2.AddElement(true);
            Console.WriteLine(myArr2);
            */
            /*
            CompareDelegate<double, decimal> compareDelegate= Compare;

            SummaOperation<int> summaDelegateInt = Add;
            SummaOperation<float> summaDelegateFloat = Add;

            SubDelegate subDel = Sub;
            Console.WriteLine(compareDelegate?.Invoke(3.14, 5.55m));
            Console.WriteLine(summaDelegateInt?.Invoke(15, 4));
            Console.WriteLine(summaDelegateFloat?.Invoke(3.14f, 5.55f));
            Console.WriteLine(Sub(1.33f, 2.22f));*/


        }
    }
}