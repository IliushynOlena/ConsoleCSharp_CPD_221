using System;
using System.Linq;

namespace _02_Array
{
   
    internal class Program
    {
        public enum DayOfWeek
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }
        static void PrintArr(string text, int[]arr)
        {
            Console.Write(text + " : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void PrintArr(string text, double[] arr)
        {
            Console.Write(text + " : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] ModifyArray(int[] array, int modifier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * modifier;
            }
            return array;
        }
        static void ShowArr(string text, int a,  params int[] arr)
        {
            Console.Write(text + " : ");
            Console.Write(a + " : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        public static DayOfWeek NextDay(DayOfWeek day)//1 2 3 5 7
        {
            return (day < DayOfWeek.Sunday) ? ++day : DayOfWeek.Monday;
        }
        static void Main(string[] args)
        {
            DayOfWeek day = DayOfWeek.Sunday;
            day =  NextDay(day);
            Console.WriteLine($" Next day of week : {day}");
            Console.WriteLine($" Next day of week : {(int)day}");
            Console.WriteLine($" Next day of week : {NextDay(day)}");
            Console.WriteLine(typeof(DayOfWeek));
            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(float));
            Console.WriteLine(typeof(string));
            string []days =  Enum.GetNames(typeof(DayOfWeek));
            foreach (var item in days)
            {
                Console.WriteLine(item);
            }

            Random rnd = new Random();
            int [] arr = {1,2,3,4,5,6,7,8,9,10};
            double [] arr_double = {1,2,3,4,5,6,7,8,9,10};
          
            for (int i = 0; i < arr.Length; i++)
            {
                arr_double[i] = Math.Round( rnd.Next(1, 10) + rnd.NextDouble(), 2);
            }
            PrintArr("My arr_double ", arr_double);
            Console.WriteLine();
            ShowArr("Hello",  10,20,30,40,50,60,70);
            Console.WriteLine();
            arr =  ModifyArray(arr, 7);
            PrintArr("My arr ", arr);
            int[] tempArr = (int[]) arr.Clone();
            PrintArr("Clone arr ", tempArr);
            Array.Reverse(tempArr, 3, 5);
            PrintArr("Reverse arr ", tempArr);
            arr = tempArr;
            PrintArr("Operator = in arr ", arr);

            int[] arr2 = new int[20];
            PrintArr("arr2 to copy ", arr2);
            arr.CopyTo(arr2, 2);
            PrintArr("arr2 after copy ", arr2);
            //Array.Clear(arr2,0, arr2.Length);   
            Array.Resize(ref arr2, 10);
            PrintArr("arr2 resize ", arr2);
            Array.Sort(arr2);
            PrintArr("arr2 sort ", arr2 );
            var res = arr.OrderByDescending(x => x);
            ///PrintArr("arr sort OrderByDescending ", arr );
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Index of [3] = "  + Array.IndexOf(arr, 3));
            PrintArr("My arr ", arr);
            Console.WriteLine("Index of [7] = " + Array.BinarySearch(arr, 7));

            Console.WriteLine("Max elem = " + arr.Max());
            Console.WriteLine("Min elem = " + arr.Min());
            Console.WriteLine("Average elem = " + arr.Average());
            int[][] jagged = new int[4][];
            jagged[0] = new int[] { 1, 2, 3 };
            jagged[1] = new int[] { 1, 2, 3 ,4,5 };
            jagged[2] = new int[] { 1, 2 };
            jagged[3] = new int[] { 1, 2, 3,5,6,7,8,9 };
            Console.WriteLine(jagged.Length);

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    //Console.Write($" {jagged[i][j]} ");
                    Console.Write($" {i}:{j} = {jagged[i][j]} ");
                    //Console.Write(i + ":" + j + " = " + jagged[i][j] + " ");
                }
                Console.WriteLine();
            }


            /*
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 11;
            array[2] = 111;
            array[3] = 1111;
            array[4] = 11111;
            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[3]);
            Console.WriteLine(array[4]);
            Console.WriteLine();

            int? a = 55;
            a = null;
            //int b = a;
            //++a;
            //string str = "Hello";
            //str = null;
            int[] array2 = new int[10];//Array
           // array2 = null;

            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = i * 2;
            }
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }
            Console.WriteLine();
            int[] array3 = new int[] { 1,2,3,4,5,6};
            for (int i = 0; i < array3.Length; i++)
            {
                Console.Write(array3[i] + " ");
            }
            Console.WriteLine();
            foreach (int elem in array3) 
            {
                //elem = 100;//read only
                Console.Write(elem + " ");
            }

            int[,] mass = new int[3, 3];
            mass[0, 0] = 1;
            mass[0, 1] = 1;
            mass[0, 2] = 1;
            mass[1, 0] = 1;
            mass[1, 1] = 1;
            mass[1, 2] = 1;
            mass[2, 0] = 1;
            mass[2, 1] = 1;
            mass[2, 2] = 1;
            Console.WriteLine(mass[0, 0]);
            Console.WriteLine(mass.Length);
            for (int i = 0; i < mass.GetLength(0); i++)//3
            {
                for (int j = 0; j < mass.GetLength(1); j++)//3
                {
                    mass[i, j] = i * j + 1;
                }
            }
            for (int i = 0; i <= mass.GetUpperBound(0); i++)//2
            {
                for (int j = 0; j <= mass.GetUpperBound(1); j++)//2
                {
                    Console.Write(mass[i, j] + " "); 
                }
                Console.WriteLine();
            }

            //3
            int[,] array4 = {
                              { 1, 2, 3 },
                              { 4, 5, 6 },
                              { 7, 8, 9 }
                            };

            Console.WriteLine(array4.Length);
            Console.WriteLine(array4);
            Console.WriteLine();
            
            int a = 3, b = 3; // c = 3;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write($"{mass[i, j]}");

                }
                Console.Write("\n");
            }
            Console.ReadKey(); // pause
                               //4
            
                        int[,] matrix = new int[1, 1];
                        matrix[0, 0] = 200;
                        Console.WriteLine(matrix[0, 0]);

                        int? someValue = null;
                        if (someValue == null)
                        {
                            Console.WriteLine("It's not good!");
                        }
                        else
                        {
                            Console.WriteLine("something real wrong!");
                        }
                        Console.WriteLine();
                */

        }
    }
}
