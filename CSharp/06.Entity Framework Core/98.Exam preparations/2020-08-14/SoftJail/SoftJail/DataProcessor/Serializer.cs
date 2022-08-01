namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonerDto()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    CellNumber = p.CellId.HasValue ? p.Cell.CellNumber : default(int?),
                    Officers = p.PrisonerOfficers
                        .Select(po => new ExportOfficerDto() 
                        {
                            Name = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(eod => eod.Name)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(x => x.FullName)
                .ThenBy(x => x.Id)
                .ToArray();
            var output = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return output;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',');
            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerXmlDto()
                {
                    Id = p.Id, 
                    FullName = p.FullName, 
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Messages = p.Mails.Select(m => new ExportMailXmlDto()
                    {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())
                    }).ToArray()
                })
                .ToArray();

            return Serialize(prisoners, "Prisoners");
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