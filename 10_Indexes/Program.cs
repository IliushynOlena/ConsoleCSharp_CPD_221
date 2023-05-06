using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace _10_Indexes
{
    public class MultArray
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }
    class Laptop
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Model} {Price}";
        }
    }
    class Shop
    {
        Laptop[] laptopArr;
        public Shop(int size)
        {
            laptopArr = new Laptop[size];
        }
        public int Length
        {
            get { return laptopArr.Length; }
        }
        public void SetLaptop(int index, Laptop laptop)
        {
            laptopArr[index] = laptop;
        }
        public Laptop GetLaptop(int index)
        {
            if(index >= 0 && index < laptopArr.Length)
            {
               return laptopArr[index];
            }
            throw new IndexOutOfRangeException();
        }
        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptopArr.Length)
                {
                    return laptopArr[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < laptopArr.Length)
                {
                    laptopArr[index] = value;
                }
            }

        }
        public Laptop this[string model]
        {
            get
            {
                foreach (var item in laptopArr)//read only 
                {
                    if (item.Model == model)
                        return item;
                }
                return null;
            }
            private set
            {
                for (int i = 0; i < laptopArr.Length; i++)
                {
                    if (laptopArr[i].Model == model)
                    {
                        laptopArr[i] = value;
                        break;
                    }
                }
            }

        }
        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptopArr.Length; i++)
            {
                if (laptopArr[i].Price == price)
                {
                    return i;
                }
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get
            {
               int index = FindByPrice(price);  
                if(index != -1)
                {
                    return laptopArr[index];
                }
                throw new Exception("Incorrect price");
            }
            set
            {
                int index = FindByPrice(price);
                if (index != -1)
                {                   
                     this[index] = value;
                }
                
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop(3);

            //shop.SetLaptop(0, new Laptop() { Model = "HP", Price = 20000.00 });
            //shop.SetLaptop(1, new Laptop() { Model = "Samsung", Price = 42000.00 });
            //shop.SetLaptop(2, new Laptop() { Model = "Lenovo", Price = 23000.00 });

            //var laptop = shop.GetLaptop(0);    
            //Console.WriteLine(laptop);
            //string model = Console.ReadLine();
            //double price = double.Parse(Console.ReadLine());

            //shop[0] = new Laptop() { Model = model, Price = price };
            shop[0] = new Laptop() { Model = "Samsung", Price = 42000.00 };
            shop[1] = new Laptop() { Model = "HP", Price = 20000.00 };
            shop[2] = new Laptop() { Model = "Lenovo", Price = 23000.00 };
            Console.WriteLine(shop[0]);
            try
            {
                for (int i = 0; i < shop.Length + 1; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                           }
            Console.WriteLine("Countinue......");
            //shop["HP"] = new Laptop() { Model = "DEL", Price = 45000 };
            for (int i = 0; i < shop.Length ; i++)
            {
                Console.WriteLine(shop[i]);
            }


            Console.WriteLine($" Price 42_000 : {shop[42000.0]}");
            Console.WriteLine($" Price 20_000 : {shop[20000.0]}");

            shop[20000.0] = new Laptop() { Model = "Asus", Price = 12000 };
            for (int i = 0; i < shop.Length; i++)
            {
                Console.WriteLine(shop[i]);
            }
            /*
            MultArray multArray = new MultArray(2, 3);

            for (int i = 0; i < multArray.Rows; i++)
            {
                for (int j = 0; j < multArray.Cols; j++)
                {
                    multArray[i, j] = i + j;//indexator - set
                    Write($"{multArray[i, j]} ");//indexator - get
                }
                WriteLine();
            }
            */
        }
    }
}
