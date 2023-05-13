using System;
using System.Text;

namespace _13_InterfaceIndexer
{
    interface IIndexer
    {
        string this[int index] { get; set; }
        string this[string name] { get; }
    }

    enum Numbers { one, two, three, four, five };

    class IndexerClass : IIndexer
    {
        string[] names = new string[5];
        public IndexerClass()
        {
            names[0] = "Bob";
            this[1] = "Irina";
            this[2] = "Oleg";
            this[3] = "Kolya";
            this[4] = "Petro";
        }
        public string this[int index] 
        {
            get { return names[index]; }
            set { names[index] = value; } 
        }

        public string this[string name]//one
        {
            get
            {
                if (Enum.IsDefined(typeof(Numbers), name))
                    return names[(int)Enum.Parse(typeof(Numbers), name)];
                else
                    return " ";
            }
        }
     
    }

    interface IA
    {
        string A1(int n);
    }
    interface IB
    {
        string B1(int n);
        void B2();
    }
    interface IC : IA, IB
    {
        void C1(int n);
    }

    class MyClass : IC
    {
        public string A1(int n)
        {
            throw new NotImplementedException();
        }

        public string B1(int n)
        {
            throw new NotImplementedException();
        }

        public void B2()
        {
            throw new NotImplementedException();
        }

        public void C1(int n)
        {
            throw new NotImplementedException();
        }
    }

    interface IAa
    {
        void Show();
    }
    interface IBb
    {
        void Show();
    }
    interface ICc
    {
        void Show();
    }
    class ImplementClass : IAa, IBb, ICc
    {
        public void Show()//implicit
        {
            Console.WriteLine("Base Realization ICc test");
        }

        //public void Show()
        //{
        //    Console.WriteLine("Base Realization");
        //}

        //private
        void IAa.Show()//explicit
        {
            Console.WriteLine("Base Realization IAa");
        }
        void ICc.Show()//explicit
        {
            Console.WriteLine("Base Realization ICc");
        }

        void IBb.Show()//explicit
        {
            Console.WriteLine("Base Realization IBb");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
           

            ImplementClass implement = new ImplementClass();
            implement.Show();

            ((IAa)implement).Show();
            ((IBb)implement).Show();
            ((ICc)implement).Show();

            IAa implement1 = new ImplementClass();     
            implement1.Show();
            IBb implement2 = new ImplementClass();
            implement2.Show();

            /*
            Console.OutputEncoding = Encoding.UTF8;
            IndexerClass indexer = new IndexerClass();
            Console.WriteLine("Вивід значень колекції");
            Console.WriteLine("Індексатор з цілочисельним параметром");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(indexer[i]);
            }
            indexer[0] = "Muroslav";
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(indexer[i]);
            }

            Console.WriteLine("Індексатор для string");
            foreach (string item in Enum.GetNames(typeof(Numbers)))
            {
                //Console.WriteLine(item);    
                Console.WriteLine(indexer[item]);
            }
            */
        }
    }
}
