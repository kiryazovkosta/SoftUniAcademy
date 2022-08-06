namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .ToList()
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Sum(t=> t.Price),
                    Tickets = t.Tickets
                        .ToList()
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .OrderByDescending(tt => tt.Price)
                        .Select(tt => new
                        {
                            Price = decimal.Parse(tt.Price.ToString("F2")),
                            RowNumber = tt.RowNumber
                        })
                        .ToArray()
                })
                .ToArray();


            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new PlayViewModel()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.ToList().Where(a => a.IsMainCharacter).OrderByDescending(a => a.FullName).Select(a => new ActorViewModel()
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .ToArray()

                })
                .ToArray();


            return Serialize(plays, "Plays");
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
