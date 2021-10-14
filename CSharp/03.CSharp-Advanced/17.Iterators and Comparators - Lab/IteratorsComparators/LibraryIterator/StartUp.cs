namespace IteratorsAndComparators
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("Algorithms", 2002, "John Smith", "Arthur Pinkerton");
            Book bookThree = new Book("Good", 1975);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}
