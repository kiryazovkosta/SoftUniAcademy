namespace Elevator
{
    using System;
    class ElevatorMain
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;
            while (numberOfPeople > 0)
            {
                courses++;
                numberOfPeople -= capacity;
            }

            Console.WriteLine(courses);
        }
    }
}
