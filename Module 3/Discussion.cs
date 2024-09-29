    class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person personInstance = new Person("Genaro", 19);
            personInstance.Introduce();
        }
    }
}
