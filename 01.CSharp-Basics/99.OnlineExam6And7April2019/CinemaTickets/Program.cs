using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalTickets = 0;
            double studentsTickets = 0;
            double standardTickets = 0;
            double kidsTickets = 0;

            while (input != "Finish")
            {
                string name = input;
                input = Console.ReadLine();
                int places = int.Parse(input);
                input = Console.ReadLine();

                double tickets = 0;
                while (input != "End" && input != "Finish")
                {
                    string type = input;
                    tickets++;
                    totalTickets++;

                    if (type == "student")
                    {
                        studentsTickets++;
                    }
                    else if (type == "standard")
                    {
                        standardTickets++;
                    }
                    else if (type == "kid")
                    {
                        kidsTickets++;
                    }


                    if (places == tickets)
                    {
                        break;
                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{name} - {(tickets/places) * 100.0:F2}% full.");

                if (input == "Finish")
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(studentsTickets / totalTickets) * 100.0:F2}% student tickets.");
            Console.WriteLine($"{(standardTickets / totalTickets) * 100.0:F2}% standard tickets.");
            Console.WriteLine($"{(kidsTickets / totalTickets) * 100.0:F2}% kids tickets.");
        }
    }
}
