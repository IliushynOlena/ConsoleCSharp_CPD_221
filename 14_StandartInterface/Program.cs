using System;
using System.Collections;
using System.Collections.Generic;

namespace _14_StandartInterface
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Student card :{Number}, {Series} ";
        }
    }
    class Student: IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public StudentCard StudentCard { get; set; }

        public object Clone()
        {
            Student newSt = (Student)this.MemberwiseClone();
            newSt.FirstName = (string)this.FirstName.Clone();
            newSt.LastName = (string)this.LastName.Clone();
            newSt.StudentCard = new StudentCard { Number = this.StudentCard.Number,
                Series = this.StudentCard.Series};
            return newSt;
        }

        public int CompareTo(Student other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }

        //public int CompareTo(object obj)
        //{
        //    if (obj is Student)
        //    {
        //     return FirstName.CompareTo( (obj as Student).FirstName);
        //    }
        //    throw new ArgumentException();

        //}

        public override string ToString()
        {
            return $"{FirstName} , {LastName} , {Birthday.ToShortDateString()} , {StudentCard}";
        }
    }
    class SurnameComparer : IComparer<Student>
    {
        //public int Compare(object x, object y)
        //{
        //    if(x is Student && y is Student)
        //    {
        //        return (x as Student).LastName.CompareTo((y as Student).LastName);
        //    }
        //    throw new ArgumentException();
        //}
        public int Compare(Student x, Student y)
        {
           return x.LastName.CompareTo(y.LastName);
        }
    }
    class BirtdayComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Birthday.CompareTo(y.Birthday);
        }
    }
    class Auditory : IEnumerable
    {        
        Student[] students =
        {
            new Student
            {
                 FirstName = "Ira",
                 LastName = "Fedoruk",
                 Birthday = new DateTime(2000,10,31),
                 StudentCard = new StudentCard{ Number = 123654789,
                     Series = "AB"}
            },
            new Student
            {
                 FirstName = "Vlad",
                 LastName = "Yashchuk",
                 Birthday = new DateTime(2007,5,11),
                 StudentCard = new StudentCard{ Number = 654789321, Series = "AB"}
            },
            new Student
            {
                 FirstName = "Vova",
                 LastName = "Bugay",
                 Birthday = new DateTime(2007,7,21),
                 StudentCard = new StudentCard{ Number = 25874136, Series = "AB"}
            },
            new Student
            {
                 FirstName = "Nina",
                 LastName = "Vusochina",
                 Birthday = new DateTime(2000,7,23),
                 StudentCard = new StudentCard{ Number = 963741258, Series = "AB"}
            }
        };

        public void Print()
        {
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }
        public void Sort()
        {
            Array.Sort(students);
        }
       
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students,comparer);
        }
        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

       
    }
    class Child : ICloneable
    {
        public string Name { get; set; }//address
        public int Age { get; set; }//10

        public object Clone()
        {
            return this.MemberwiseClone(); 
        }

        public override string ToString()
        {
            return $"{Name}  {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Student student1 = new Student()
            {
                FirstName = "Ira",
                LastName = "Fedoruk",
                Birthday = new DateTime(2000, 10, 31),
                StudentCard = new StudentCard { Number = 123654789, Series = "AB" }
            };
            Console.WriteLine(student1);

            Student student2 = (Student)student1.Clone();
            Console.WriteLine(student2);
            student2.StudentCard.Number = 11111111;
            Console.WriteLine("------------------------------------");
            Console.WriteLine(student1);
            Console.WriteLine(student2);
            /*
            Child child = new Child { Name = "Artur", Age = 12 };
            Console.WriteLine(child) ;
 
            //Child child2 = child;
            Child child2 = (Child) child.Clone();
            Console.WriteLine(child2);
            child2.Age = 22;
            Console.WriteLine(child);
            Console.WriteLine(child2);
            

            Auditory auditory = new Auditory();
            Console.WriteLine("-----------Students-----------");
            auditory.Print();
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            auditory.Sort();
            Console.WriteLine("-----------Students-----------");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            auditory.Sort(new SurnameComparer());
            Console.WriteLine("-----------Students-----------");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            auditory.Sort(new BirtdayComparer());
            Console.WriteLine("-----------Students-----------");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            */


        }
    }
}
