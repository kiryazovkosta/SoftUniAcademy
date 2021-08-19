namespace WorldTour
{
    using System;
    public class Tour
    {
        static void Main(string[] args)
        {
            string trip = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Travel")
            {
                string[] data = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                if (command == "Add Stop")
                {
                    int index = int.Parse(data[1]);
                    string @string = data[2].Trim();
                    if (index >= 0 && index < trip.Length)
                    {
                        trip = trip.Insert(index, @string);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);
                    if (startIndex >= 0 && endIndex < trip.Length)
                    {
                        for (int index = endIndex; index >= startIndex; index--)
                        {
                            trip = trip.Remove(index, 1);
                        }
                    }

                }
                else if (command == "Switch")
                {
                    string oldString = data[1].Trim();
                    string newString = data[2].Trim();
                    trip = trip.Replace(oldString, newString);
                }

                Console.WriteLine(trip);
                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {trip}");
        }
    }
}