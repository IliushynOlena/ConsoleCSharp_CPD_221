namespace _22_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("UA", "Ukraine");
            countries.Add("GB", "Great Britain");
            countries.Add("USA", "United Sates");
            countries.Add("CH", "China");
            countries.Add("PL", "Poland");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + "  " + keyValue.Value);
            }
            Console.WriteLine();
            string country = countries["USA"];
            Console.WriteLine("Find by key : " + country);

            countries["IN"] = "India";
            countries.Remove("CH");
            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + "  " + keyValue.Value);
            }
            Console.WriteLine("-----------------------------------");
            Dictionary<char, Person> people = new Dictionary<char, Person>();
            people.Add('O', new Person() { Name = "Olena" });
            people.Add('I', new Person() { Name = "Irina" });
            //people.Add('O', new Person(){ Name = "Oksana"});error
            people.Add('M', new Person() { Name = "Mukola" });
            people.Add('V', new Person() { Name = "Vova" });

            people['O'] = new Person() { Name = "Oksana" };
            people['D'] = new Person() { Name = "Dmutro" };

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                Console.WriteLine(keyValue.Key + "  " + keyValue.Value.Name);
            }

            if (people.ContainsKey('R'))
            {
                people['R'].Name = "Roman";
            }
            else
            {
                Console.WriteLine("Collection does not contain this key");
            }

            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }
            people.Add('T', new Person() { Name = "Tamara" });
            people['S'] = new Person() { Name = "Sergiy" };

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                Console.WriteLine(keyValue.Key + "  " + keyValue.Value.Name);
            }

           
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
}