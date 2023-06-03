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
            #region Dictionary
            /*
          
                  Console.OutputEncoding = Encoding.UTF8;

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("RU", "Russia");
            countries.Add("GB", "Great Britain");
            countries.Add("USA", "United States");
            countries.Add("FR", "France");
            countries.Add("CH", "China");
            countries.Add("PL", "Poland");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            // получение элемента по ключу
            string country = countries["USA"];
            Console.WriteLine(country);

            // изменение объектаx
            countries["USA"] = "America";
            // додавання об'єкта, якщо його не існує
            countries["IN"] = "India";
            // удаление по ключу
            countries.Remove("GB");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            ///////////////2
            Dictionary<char, Person> people = new Dictionary<char, Person>();

            people.Add('b', new Person() { Name = "Bill" });
            people.Add('t', new Person() { Name = "Tom" });
            people.Add('j', new Person() { Name = "John" });
            people.Add('r', new Person() { Name = "Rita" });

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                // keyValue.Value представляет класс Person
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.ReadKey();

            Console.WriteLine("\n\n changed value START");
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("original end");

            if (people.ContainsKey('r'))
            {
                people['r'].Name = "rat";
            }
            else
            {
                Console.WriteLine("Collection does not contain such key");
            }
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("changed value END");

            // перебор ключей
            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }

            // перебор по значениям
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }

            ////////adding
            Dictionary<char, Person> people2 = new Dictionary<char, Person>();
            people2.Add('b', new Person() { Name = "Bill" });
            people2['a'] = new Person() { Name = "Alice" };

            /////////init
            Dictionary<string, string> countries2 = new Dictionary<string, string>
            {
                {"Франция", "Париж"},
                {"Германия", "Берлин"},
                {"Великобритания", "Лондон"}
            };

            foreach (var pair in countries2)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            ////// C# 6.0
            Dictionary<string, string> countries3 = new Dictionary<string, string>
            {
                ["Франция"] = "Париж",
                ["Германия"] = "Берлин",
                ["Великобритания"] = "Лондон"
            };

            foreach (var pair in countries3)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);    Console.OutputEncoding = Encoding.UTF8;

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("RU", "Russia");
            countries.Add("GB", "Great Britain");
            countries.Add("USA", "United States");
            countries.Add("FR", "France");
            countries.Add("CH", "China");
            countries.Add("PL", "Poland");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            // получение элемента по ключу
            string country = countries["USA"];
            Console.WriteLine(country);

            // изменение объектаx
            countries["USA"] = "America";
            // додавання об'єкта, якщо його не існує
            countries["IN"] = "India";
            // удаление по ключу
            countries.Remove("GB");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            ///////////////2
            Dictionary<char, Person> people = new Dictionary<char, Person>();

            people.Add('b', new Person() { Name = "Bill" });
            people.Add('t', new Person() { Name = "Tom" });
            people.Add('j', new Person() { Name = "John" });
            people.Add('r', new Person() { Name = "Rita" });

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                // keyValue.Value представляет класс Person
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.ReadKey();

            Console.WriteLine("\n\n changed value START");
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("original end");

            if (people.ContainsKey('r'))
            {
                people['r'].Name = "rat";
            }
            else
            {
                Console.WriteLine("Collection does not contain such key");
            }
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("changed value END");

            // перебор ключей
            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }

            // перебор по значениям
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }

            ////////adding
            Dictionary<char, Person> people2 = new Dictionary<char, Person>();
            people2.Add('b', new Person() { Name = "Bill" });
            people2['a'] = new Person() { Name = "Alice" };

            /////////init
            Dictionary<string, string> countries2 = new Dictionary<string, string>
            {
                {"Франция", "Париж"},
                {"Германия", "Берлин"},
                {"Великобритания", "Лондон"}
            };

            foreach (var pair in countries2)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            ////// C# 6.0
            Dictionary<string, string> countries3 = new Dictionary<string, string>
            {
                ["Франция"] = "Париж",
                ["Германия"] = "Берлин",
                ["Великобритания"] = "Лондон"
            };

            foreach (var pair in countries3)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
             */

            #endregion

            #region Stack
            /* Console.OutputEncoding = Encoding.UTF8;

            // LIFO
            Stack<int> numbers = new Stack<int>();

            numbers.Push(3); // в стеке 3
            numbers.Push(5); // в стеке 5, 3
            numbers.Push(8); // в стеке 8, 5, 3

            // так как вверху стека будет находиться число 8, то оно и извлекается
            int stackElement = numbers.Pop(); // в стеке 5, 3
            Console.WriteLine(stackElement);

            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person() { Name = "Tom" });
            persons.Push(new Person() { Name = "Bill" });
            persons.Push(new Person() { Name = "John" });

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            // Первый элемент в стеке
            Person person = persons.Pop(); // теперь в стеке Bill, Tom
            Console.WriteLine(person.Name);

            Console.ReadLine();*/
            #endregion

            #region Queue
            /*
              Console.OutputEncoding = Encoding.UTF8;

            // FIFO
            Queue<int> numbers = new Queue<int>();

            numbers.Enqueue(3); // очередь 3
            numbers.Enqueue(5); // очередь 3, 5
            numbers.Enqueue(8); // очередь 3, 5, 8

            // получаем первый элемент очереди
            int queueElement = numbers.Dequeue(); //теперь очередь 5, 8
            Console.WriteLine(queueElement);
            Console.ReadKey();

            Queue<Person> persons = new Queue<Person>();
            persons.Enqueue(new Person() { Name = "Tom" });
            persons.Enqueue(new Person() { Name = "Bill" });
            persons.Enqueue(new Person() { Name = "John" });

            // получаем первый элемент без его извлечения
            Person pp = persons.Peek();
            Console.WriteLine(pp.Name);

            Console.WriteLine("Сейчас в очереди {0} человек", persons.Count);

            // теперь в очереди Tom, Bill, John
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            // Извлекаем первый элемент в очереди - Tom
            Person person = persons.Dequeue(); // теперь в очереди Bill, John
            Console.WriteLine(person.Name);

            Console.ReadLine();
             */
            #endregion

            #region List
            /*
               //void Add(T item): добавление нового элемента в список
            //
            //void AddRange(ICollection collection): добавление с список коллекции или массива
            //
            //int BinarySearch(T item): бинарный поиск элемента в списке.Если элемент найден, то метод возвращает индекс этого элемента в коллекции. При этом список должен быть отсортирован.
            //
            //int IndexOf(T item): возвращает индекс первого вхождения элемента в списке
            //
            //void Insert(int index, T item): вставляет элемент item в списке на позицию index
            //
            //bool Remove(T item): удаляет элемент item из списка, и если удаление прошло успешно, то возвращает true
            //
            //void RemoveAt(int index): удаление элемента по указанному индексу index
            //
            //void Sort(): сортировка списка
                        
            Console.OutputEncoding = Encoding.UTF8;

            List<int> numbers = new List<int>() { 1, 2, 3, 45 };

            numbers.Add(6); // добавление элемента
            numbers.AddRange(new int[] { 7, 8, 9 });
            numbers.Insert(0, 777); // вставляем на первое место в списке число 777
            numbers.RemoveAt(1); //  удаляем второй элемент
            numbers.Remove(45);
            numbers.Sort();
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("Index of 7: " + numbers.IndexOf(7));

            Console.ReadKey();

            //numbers.Exists((x) => x % 2 == 0);

            List<Person> people = new List<Person>(3);
            Person person = new Person() { Name = "Billy" };
            people.Add(person);
            people.Add(new Person() { Name = "Antony" });
            people.Add(new Person() { Name = "Julia" });
            people.Sort();

            foreach (Person p in people)
            {
                Console.WriteLine(p.Name);
            }

            Console.ReadLine();
             */
            #endregion





        }
    }
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
