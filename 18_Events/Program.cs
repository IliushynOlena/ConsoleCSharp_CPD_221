namespace _18_Events
{
    //public delegate void Action();
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($" Student {FirstName}, {LastName} solved the {task}");
        }
    }
    class Teacher
    {
        //public ExamDelegate ExamDelegate;

        public event ExamDelegate ExamDelegate;
        public event Action TestEvent;
        public void CreateExam(string task)
        {
            ///creating exam
            /////some code
            ///
            //call event
            ExamDelegate?.Invoke(task);
        }
        public void StartAction()
        {
            TestEvent();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent += Console.Clear;
            teacher.TestEvent += delegate () { Console.ForegroundColor = ConsoleColor.DarkGreen; };
            teacher.TestEvent += () => Console.Beep(300,1000);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent -= Console.Clear;
            //teacher.TestEvent -= delegate () { Console.ForegroundColor = ConsoleColor.DarkGreen; };
            teacher.StartAction();









            List<Student> students = new List<Student>
          {
            new Student
            {
                 FirstName = "Ira",
                 LastName = "Fedoruk",
                 Birthdate = new DateTime(2000,10,31),
            },
            new Student
            {
                 FirstName = "Vlad",
                 LastName = "Yashchuk",
                 Birthdate = new DateTime(2007,5,11),
            },
            new Student
            {
                 FirstName = "Vova",
                 LastName = "Bugay",
                 Birthdate = new DateTime(2007,7,21),
            },
            new Student
            {
                 FirstName = "Nina",
                 LastName = "Vusochina",
                 Birthdate = new DateTime(2000,7,23),
            }
        };


            foreach (Student st in students)
            {
                teacher.ExamDelegate += new ExamDelegate(st.PassExam);
            }
            teacher.ExamDelegate -= students[1].PassExam;
            //teacher.ExamDelegate = null;

            teacher.CreateExam("C# exam in Microsoft Teams at 13:30 p.m");


        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto generated method"); ;
        }
    }
}