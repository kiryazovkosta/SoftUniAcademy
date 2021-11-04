namespace Explicit
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                var citizen = new Citizen(name, country, age);
                Console.WriteLine(((IPerson) citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
                input = Console.ReadLine();
            }
        }
    }
}
