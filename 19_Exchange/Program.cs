namespace _19_Exchange
{
    public delegate void OnCourseChange(int course);
    class Exchange
    {
        private int course;
        public event OnCourseChange ListTraders;
        public OnCourseChange cource;

        public int Course
        {
            get { return course; }
            set { 

                course = value < 0 ? 0: value; 
            }
        }
        public void GenerationCourse()
        {
            while (true)
            {
            Course = new Random().Next(25,45);
            //Notification....
            ListTraders?.Invoke(Course);
                Thread.Sleep(1000);

            }
        }

    }
    class Trayder
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public Trayder()
        {
            Name = "";
            Money = 10000;
        }
        public Trayder(string name, int money)
        {
            Name = name;
            Money = money;  
        }
        public void BuyOrSold(int course)
        {
            if(course < 30)
            {
                Console.WriteLine($"I bought currence for {course} ");
                Money += course*100;
                Console.WriteLine($"My money  {Money} ");
            }
            else if(course > 40)
            {
                Console.WriteLine($"I sold currence for {course} ");
                Money -= course * 100;
                Console.WriteLine($"My money  {Money} ");
            }
            else
            {
                Console.WriteLine("I'll wait.......");
                Console.WriteLine($"My money  {Money} ");
            }
        }
        public override string ToString()
        {
            return $"Name {Name} . Money {Money}";
        }
    }
    internal class Program
    {
        static void TestMethod(int num)
        {
            Console.WriteLine(num);
        }
        static void Main(string[] args)
        {
            string str = "hello";
            string str2 = "hello";
            string str3 = "hello";
            string str4 = "hello";
            string str5 = "hello";
            string str6 = "hello";
            string str7 = "hello";

            Console.WriteLine(str.Equals(str2));
            Console.WriteLine(str2.Equals(str3));
            Console.WriteLine(str3.Equals(str4));

            Exchange exchange = new Exchange();
            exchange.cource = TestMethod;
            exchange.cource.Invoke(10);

            Trayder[] trayders = new Trayder[]
            {
                 new Trayder{ Name = "Ira",Money = 1000000},
            new Trayder  {Name = "Vlad", Money = 20000},
            new Trayder{ Name = "Vova", Money = 3000},
            new Trayder{ Name = "Nina",Money = 999999}
            };

            foreach (var tr in trayders)
            {
                exchange.ListTraders += tr.BuyOrSold;
            }

            //exchange.GenerationCourse();

            Console.WriteLine($"Поколение объекта: {GC.GetGeneration(trayders)}");
            Console.WriteLine($"Занято памяти(байт): {GC.GetTotalMemory(false)}");

        }
    }
}