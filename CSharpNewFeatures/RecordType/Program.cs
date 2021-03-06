﻿using System;
using System.Collections.Generic;

namespace RecordType
{
    internal class Program
    {
        private static void Main()
        {
            // var p1 = new Person(name: "John Doe", age: 23);
            var p1 = new Person
            {
                Name = "John Doe",
                Age = 23
            };

            p1.Walk();

            Console.WriteLine($"p1.ToString(): {p1}");
            Console.WriteLine($"p1.Name: {p1.Name}");
            Console.WriteLine($"p1.Age: {p1.Age}");

            var p2 = new Person
            {
                Name = "John Doe",
                Age = 23
            };

            Console.WriteLine($"Are p1 and p2 equal: {p1 == p2}");
            Console.WriteLine($"Are p1 and p2 equal: {p1.Equals(p2)}");
            Console.WriteLine($"Are p1 and p2 equal: {EqualityComparer<Person>.Default.Equals(p1, p2)}");
            Console.WriteLine($"Are p1 and p2 equal: {Object.Equals(p1, p2)}");
            Console.WriteLine($"Are p1 and p2 equal by reference: {Object.ReferenceEquals(p1, p2)}");
        }
    }

    public record Person
    {
        public string Name { get; init; }
        
        public int Age { get; init;  }
        
        public void Walk()
        {
            Console.WriteLine($"{Name} started walking...");
        }
    }
}