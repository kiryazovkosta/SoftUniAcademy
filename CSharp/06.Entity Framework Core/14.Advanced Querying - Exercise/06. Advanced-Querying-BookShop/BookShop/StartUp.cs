namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //// 2. Age Restriction
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //// 3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            //// 4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            //// 5.Not Released In
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //// 6. Book Titles by Category
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));

            //// 7. Released Before Date
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            //// 8. Author Search
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "dy"));

            //// 9. Book Search
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));

            //// 10. Book Search by Author
            //Console.WriteLine(GetBooksByAuthor(db, "R"));
            //Console.WriteLine("------------------------");
            //Console.WriteLine(GetBooksByAuthor(db, "po"));

            //// 11. Count Books
            //Console.WriteLine(CountBooks(db, 12));
            //Console.WriteLine(CountBooks(db, 40));

            //// 12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            //// 13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //// 14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            //// 15. Increase Prices
            //IncreasePrices(db);

            // 16. Remove Books
            Console.WriteLine(RemoveBooks(db));
        }

        /// <summary>
        /// Return in a single string all book titles, each on a new line, that have an age restriction, equal to the given command. 
        /// Order the titles alphabetically. 
        /// Read input from the console in your main method and call your method with the necessary arguments.
        /// Print the returned string to the console.Ignore the casing of the input.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();
            command = command.ToLower();
            var restriction = Enum.Parse<AgeRestriction>(char.ToUpper(command[0]) + command[1..]);
            var books = context.Books
                .Where(b => b.AgeRestriction == restriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            sb.AppendLine(string.Join(Environment.NewLine, books));

            return sb.ToString().Trim();

        }

        /// <summary>
        /// Return in a single string title of the golden edition books that have less than 5000 copies, 
        /// each on a new line. Order them by book id ascending.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }

        /// <summary>
        /// Return in a single string all titles and prices of books with a price higher than 40, 
        /// each on a new row in the format given below. Order them by price descending.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { BookData = $"{b.Title} - ${b.Price:F2}" })
                .ToList();
            var output = new StringBuilder();
            books.ForEach(b => output.AppendLine(b.BookData));
            return output.ToString().Trim();
        }

        /// <summary>
        /// Return in a single string with all titles of books that are NOT released in a given year. 
        /// Order them by book id ascending.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }

        /// <summary>
        /// Return in a single string the titles of books by a given list of categories. 
        /// The list of categories will be given in a single line separated by one or more spaces. 
        /// Ignore casing. Order by title alphabetically.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => s.ToLowerInvariant()).ToList();
            var categoriesIndexes = context.Categories.Where(c => categories.Contains(c.Name.ToLower())).Select(c => c.CategoryId).ToList();
            var books = context.BooksCategories.Where(cb => categoriesIndexes.Contains(cb.CategoryId)).Select(b => b.Book).OrderBy(b => b.Title).Select(b => b.Title).ToList();
            string output = string.Join(Environment.NewLine, books);
            return output;
        }

        /// <summary>
        /// Return the title, edition type and price of all books that are released before a given date. 
        /// The date will be a string in the format dd-MM-yyyy.
        /// Return all of the rows in a single string, ordered by release date descending.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.CompareTo(targetDate) < 0)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var output = new StringBuilder();
            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:F2}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Return the full names of authors, whose first name ends with a given string.
        /// Return all names in a single string, each on a new row ordered alphabetically.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.FullName)
                .ToList();
            var sb = new StringBuilder();
            authors.ForEach(a => sb.AppendLine(a.FullName));
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Return the titles of the book, which contain a given string. Ignore casing.
        /// Return all titles in a single string, each on a new row ordered alphabetically.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            var output = string.Join(Environment.NewLine, books);
            return output;
        }

        /// <summary>
        /// Return all titles of books and their authors' names for books, which are written by authors whose last names start with the given string.
        /// Return a single string with each title on a new row.Ignore casing.Order by book id ascending.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    Author = (!string.IsNullOrWhiteSpace(b.Author.FirstName) ? b.Author.FirstName + " " : string.Empty) + b.Author.LastName
                })
                .ToList();
            var sb = new StringBuilder();
            books.ForEach(b => sb.AppendLine($"{b.Title} ({b.Author})"));
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Return the number of books, which have a title longer than the number given as an input.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lengthCheck"></param>
        /// <returns></returns>
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }

        /// <summary>
        /// Return the total number of book copies for each author.
        /// Order the results descending by total book copies.
        /// Return all results in a single string, each on a new line.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    Name = (!string.IsNullOrWhiteSpace(a.FirstName) ? a.FirstName + " " : string.Empty) + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.BookCopies)
                .ToList();

            var sb = new StringBuilder();
            authors.ForEach(a => sb.AppendLine($"{a.Name} - {a.BookCopies}"));
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Return the total profit of all books by category. 
        /// rofit for a book can be calculated by multiplying its number of copies by the price per single book. 
        /// Order the results by descending by total profit for a category and ascending by category name.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    TotalPrice = c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(b => b.TotalPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();
            categories.ForEach(c => sb.AppendLine($"{c.Category} ${c.TotalPrice:f2}"));
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Get the most recent books by categories. 
        /// The categories should be ordered by name alphabetically. 
        /// Only take the top 3 most recent books from each category - ordered by release date (descending). 
        /// Select and print the category name and for each book – its title and release year.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => cb.Book)
                        .Take(3)
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Increase the prices of all books released before 2010 by 5.
        /// </summary>
        /// <param name="context"></param>
        public static void IncreasePrices(BookShopContext context)
        {
            var books =context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .Select(b => b)
                .ToList();
            books.ForEach(b => b.Price += 5);
            context.Books.UpdateRange(books);
            context.SaveChanges();
        }

        /// <summary>
        /// Remove all books, which have less than 4200 copies. 
        /// Return an int - the number of books that were deleted from the database.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

                var removedBooks = books.Length;

                context.Books.RemoveRange(books);
                context.SaveChanges();

                return removedBooks;
        }
    }
}