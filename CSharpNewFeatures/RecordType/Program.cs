using System;

namespace RecordType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // var p1 = new Person(name: "John Doe", age: 23);
            var p1 = new Person
            {
                Name = "John Doe",
                Age = 23
            };

            p1.Walk();

            Console.WriteLine($"p1.ToString(): {p1.ToString()}");

            var p2 = new Person()
            {
                Name = "John Doe",
                Age = 23
            };

            Console.WriteLine($"Are p1 and p2 equal: {p1 == p2}");
            Console.WriteLine($"Are p1 and p2 equal by reference: {ReferenceEquals(p1, p2)}");
        }
    }

    internal record Person
    {
        internal Person()
        {
        }
        
        internal Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        internal string Name { get; init; }
        
        internal int Age { get; init;  }

        internal void Walk()
        {
            Console.WriteLine($"{this.Name} started walking...");
        }
    }
}