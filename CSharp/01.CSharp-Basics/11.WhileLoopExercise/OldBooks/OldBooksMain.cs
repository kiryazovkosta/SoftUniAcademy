namespace OldBooks
{
    using System;
    public class OldBooksMain
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            bool isFound = false;
            string myBook = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "No More Books")
            {
                if (input == myBook)
                {
                    isFound = true;
                    break;
                }

                counter++;
                input = Console.ReadLine();
            }

            if (isFound)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
