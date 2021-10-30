namespace Animals
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string type = input;
                string[] animalData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];
                Animal animal = null;
                try
                {
                    if (type == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (type == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    Console.WriteLine(animal?.ToString());
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
