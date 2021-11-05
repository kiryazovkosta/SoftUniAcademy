namespace Demos
{
    using System;
    using System.Collections.Generic;

    class Animal
    {
        public virtual void PrintToConsole()
        {
            Console.WriteLine("I am an animal");
        }

        public void AnimalMethod() { }
    }

    class Mammal : Animal
    {
        public void MammalMethod() { }

        public override void PrintToConsole()
        {
            Console.WriteLine("I am a mammal");
        }
    }

    class Snake : Mammal
    {
        public override void PrintToConsole()
        {
            Console.WriteLine("Snake with poison");
        }
    }

    class Person : Mammal
    {
        public override void PrintToConsole()
        {
            Console.WriteLine("I am a person");
        }
        public void PersonMethod() { }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            object obj = new Person();
            Animal animal = new Person();
            Mammal mammal = new Person();
            Person person = new Person();

            List<Animal> list = new List<Animal>();
            //list.Add(animal);
            //list.Add(mammal);
            //list.Add(person);
            list.Add(new Mammal());
            list.Add(new Person());
            list.Add(new Mammal());
            list.Add(new Mammal());
            list.Add(new Person());
            list.Add(new Mammal());
            list.Add(new Animal());
            list.Add(new Animal());
            list.Add(new Mammal());
            list.Add(new Animal());
            list.Add(new Snake());
            list.Add(new Mammal());
            list.Add(new Person());

            foreach (var item in list)
            {
                Console.WriteLine(item.GetType());
                item.PrintToConsole();
                Console.WriteLine(new string('*', 60));
            }
        }
    }
}