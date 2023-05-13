using System;
using System.Text;

namespace _15_Enum
{
    enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    enum TransportType
    {
        Semitrailer, Coupling, Refrigerator, OpenSideTruck, Tank, FuelTruck
    }
    enum Discount
    {
        Default, Incentive = 2, Patron = 5, VIP = 15
    }
    enum CommodityType // product type
    {
        FrozenFood = 1, Food, DomesticChemistry,
        BuildingMaterials, Petrol
    }
    enum DayType // : base type: byte, sbyte, short, ushort, int, uint, long, ulong
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Satureday,
        Sunday
    }

    enum DistanceSun : ulong
    {
        Sun = 0,
        Mercury = 57900000,
        Venus = 108200000,
        Earth = 149600000,
        Mars = 227900000,
        Jupiter = 7783000000,
        Saturn = 1427000000,
        Uranus = 2870000000,
        Neptune = 4496000000,
        Pluto = 5946000000
    }


    internal class Program
    {
        public static DayOfWeek NextDay(DayOfWeek day)
        {
            return (day < DayOfWeek.Sunday) ? ++day : DayOfWeek.Monday;
        }
        static void Main(string[] args)
        {
            /*
            DayOfWeek day = DayOfWeek.Sunday;

            day = NextDay(day);

            Console.WriteLine($"Next day (name): {day.ToString()}");
            Console.WriteLine($"Next day (name): {day}");
            Console.WriteLine($"Next day (value): {(int)day}");

            string[] names = Enum.GetNames(typeof(TransportType));

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            int a = 5;
            Console.WriteLine(typeof(int));
            Console.WriteLine(a.GetType());
            // Discount[] values = (Discount[])Enum.GetValues(typeof(Discount));
            var values1 = (Discount[])Enum.GetValues(typeof(Discount));

            foreach (Discount item in values1)
            {
                Console.WriteLine($"{item} - {(int)item}");
            }*/

            /*
              foreach (var item in Enum.GetValues(typeof(CommodityType)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            Console.WriteLine("Input number from 1 to 5");
            string name = Console.ReadLine();
            //int number = Int32.Parse(name);
            //if (number >= 1 && number <= 5)
            {
                // get enum from name of value
                CommodityType commodity = (CommodityType)Enum.Parse(typeof(CommodityType), name);

                // get enum from index
                //CommodityType commodity = (CommodityType)Enum.GetValues(typeof(CommodityType)).GetValue(number - 1);

                //CommodityType commodity =  Enum.GetValues(typeof(CommodityType)).GetValue(number - 1);
                TransportType transport = TransportType.Semitrailer;

                switch (commodity)
                {
                    case CommodityType.FrozenFood:
                        transport = TransportType.Refrigerator;
                        break;
                    case CommodityType.Food:
                        transport = TransportType.Semitrailer;
                        break;
                    case CommodityType.DomesticChemistry:
                        transport = TransportType.Coupling;
                        break;
                    case CommodityType.BuildingMaterials:
                        transport = TransportType.OpenSideTruck;
                        break;
                    case CommodityType.Petrol:
                        transport = TransportType.FuelTruck;
                        break;
                }
                Console.WriteLine($"Product - {commodity} needs a transport - {transport}.");
            }
            //else
            {
                //Console.WriteLine("Input error");
            }*/

            
            Console.OutputEncoding = Encoding.UTF8;

            string moon = "Moon";
            // check if exists constant in enumeration
            if (!Enum.IsDefined(typeof(DistanceSun), moon))
            {
                Console.WriteLine($"\tValue {moon} is not exists in DistanceSun.");
            }            

            Console.WriteLine("\n\tFormatted output all constants.");
            foreach (DistanceSun item in Enum.GetValues(typeof(DistanceSun)))
            {
                Console.WriteLine("{0,-10} {1,-10} {2,20}",
                //output string with constant name
                Enum.Format(typeof(DistanceSun), item, "G"),
                //output decimal value
                Enum.Format(typeof(DistanceSun), item, "D"),
                //output hexvalue
                Enum.Format(typeof(DistanceSun), item, "X"));
            }
            Console.WriteLine("\n\tAll constants of the specified enum.");
            foreach (string str in Enum.GetNames(typeof(DistanceSun)))
            {
                Console.WriteLine(str);
            }
            ulong number = 227900000;
            Console.WriteLine($"\n\tConstans name {number} from the specified enum.\n");
            Console.WriteLine(Enum.GetName(typeof(DistanceSun), number));         
        }
    }
}
