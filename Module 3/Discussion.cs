using System;

public class Program
{
    public static void Main()
    {
        
        var panda1 = new Panda("Jack");
        var panda2 = new Panda("Lisa", 2);

        Console.WriteLine($"Panda 1: Name = {panda1.Name}, Age = {panda1.Age}");
        Console.WriteLine($"Panda 2: Name = {panda2.Name}, Age = {panda2.Age}");


        Panda.Zoo zoo = new Panda.Zoo("San Diego Zoo", "California");
        zoo.PrintDetails();
    }
}

public class Panda
{
    
    public string Name { get; set;}
    public int Age {get; set;}

        public Panda(string name) => Name = name;

    public Panda(string name, int age) : this(name) => Age = age;


    public class Zoo
    {
                public string Name { get; set; }      
                    public string Location { get; set; }  
        
        public Zoo(string name, string location)
        {
            Name = name;
            Location = location;
        }

               public void PrintDetails()
        {
            Console.WriteLine($"Zoo: {Name}, Location: {Location}");
        }
    }
}
