namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .ToList()
                .Where(c => c.Footballers.Count > 0)
                .Select(c => new CoachViewModel()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new FootballerViewModel() 
                        { 
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(fv => fv.Name)   
                        .ToArray()
                })
                .OrderByDescending(ce => ce.FootballersCount)
                .ThenBy(ce => ce.CoachName)
                .ToArray();

            return Serialize(coaches, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tp => tp.Footballer.ContractStartDate >= date)
                        .OrderByDescending(tp => tp.Footballer.ContractEndDate)
                        .ThenBy(tp => tp.Footballer.Name)
                        .Select(tp => new
                        {
                            FootballerName = tp.Footballer.Name,
                            ContractStartDate = tp.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tp.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tp.Footballer.BestSkillType.ToString(),
                            PositionType = tp.Footballer.PositionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(et => et.Footballers.Length)
                .ThenBy(et => et.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented); 
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
