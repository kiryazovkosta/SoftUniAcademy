namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                Person person = new Person(data[0], int.Parse(data[1]));
                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}