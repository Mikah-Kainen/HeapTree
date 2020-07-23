using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HeapTree
{
    class Program
    {

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name}, {Age}";
            }
        }

        public class PersonComparer : Comparer<Person>
        {
            public override int Compare(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        public class PersonNameLengthComparer: Comparer<Person>
        {
            public override int Compare([AllowNull] Person x, [AllowNull] Person y)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }
        }

        static void Main(string[] args)
        {
            //var heap = new HeapTree<Person>(new PersonNameLengthComparer());

            var heap = new HeapTree<Person>(Comparer<Person>.Create((x, y) => x.Age.CompareTo(y.Age)));

            heap.Add(new Person("Jimothy", 55));
            heap.Add(new Person("Jimbo", 35));
            heap.Add(new Person("Jim", 8));
            heap.Add(new Person("Z", 89));
            heap.Add(new Person("Y", 150));

            //var heap = new HeapTree<int>();

            //Random gen = new Random(42);

            //for (int i = 0; i < 5; i++)
            //{
            //    heap.Add(10 - i);
            //}

            foreach(Person person in heap.HeapSort())
            {
                Console.WriteLine($"{person.Name}, {person.Age}");
            }
            //heap.Pop();
            //heap.Add(heap.Pop());

        }
    }
}
