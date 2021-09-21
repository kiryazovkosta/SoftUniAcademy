namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class Party
    {
        public static void Main(string[] args)
        {
            var regularGuestReservations = new HashSet<string>();
            var vipGuestReservations = new HashSet<string>();

            var input = Console.ReadLine();
            Populate(regularGuestReservations, vipGuestReservations, input);

            input = Console.ReadLine();
            Guests(regularGuestReservations, vipGuestReservations, input);

            Print(regularGuestReservations, vipGuestReservations);
        }

        private static void Populate(HashSet<string> regularGuestReservations, HashSet<string> vipGuestReservations, string input)
        {
            while (input != "PARTY")
            {
                var firstLetter = input[0];
                if (char.IsDigit(firstLetter))
                {
                    vipGuestReservations.Add(input);
                }
                else
                {
                    regularGuestReservations.Add(input);
                }

                input = Console.ReadLine();
            }
        }

        private static void Guests(HashSet<string> regularGuestReservations, HashSet<string> vipGuestReservations, string input)
        {
            while (input != "END")
            {
                var firstLetter = input[0];
                if (char.IsDigit(firstLetter))
                {
                    vipGuestReservations.Remove(input);
                }
                else
                {
                    regularGuestReservations.Remove(input);
                }

                input = Console.ReadLine();
            }
        }

        private static void Print(HashSet<string> regularGuestReservations, HashSet<string> vipGuestReservations)
        {
            Console.WriteLine(vipGuestReservations.Count + regularGuestReservations.Count);
            foreach (var guest in vipGuestReservations)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuestReservations)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
