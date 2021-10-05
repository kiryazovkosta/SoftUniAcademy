namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                Person person = new Person(data[0], int.Parse(data[1]));
                family.AddMember(person);
            }

            var olderMembers = family.GetOlderMembers(30);
            foreach (var member in olderMembers)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
