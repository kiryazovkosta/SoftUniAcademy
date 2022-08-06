namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using BookShop.Common;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<BookShopProfile>());
            var mapper = config.CreateMapper();

            var output = new StringBuilder();

            var books = Deserialize<BookInputModel[]>(xmlString, "Books");
            var validBooks = new List<Book>();
            foreach (var book in books)
            {
                if (!IsValid(book))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(book.PublishedOn, GlobalConstants.BookReleasedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime test))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(Genre), book.Genre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var validBook = mapper.Map<Book>(book);
                validBooks.Add(validBook);
                output.AppendLine(string.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price));
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<BookShopProfile>());
            var mapper = config.CreateMapper();

            var output = new StringBuilder();

            var authors = JsonConvert.DeserializeObject<AuthorInputModel[]>(jsonString);
            var validAuthors = new List<Author>();
            foreach (var author in authors)
            {
                if (!IsValid(author))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (validAuthors.Any(va => va.Email == author.Email))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (author.Books.Count() == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var validAuthor = mapper.Map<Author>(author);
                foreach (var bookId in author.Books.Select(b => b.Id).Distinct())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        validAuthor.AuthorsBooks.Add(new AuthorBook { Author = validAuthor, Book = book });
                    }
                }

                if (validAuthor.AuthorsBooks.Count() == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                validAuthors.Add(validAuthor);
                output.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", validAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader);

            return dtos;
        }
    }
}