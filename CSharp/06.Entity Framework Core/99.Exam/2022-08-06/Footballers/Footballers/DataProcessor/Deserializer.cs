namespace Footballers.DataProcessor
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
    using Data;
    using Footballers.Common;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var output = new StringBuilder();

            var validCoaches = new List<Coach>();
            var coaches = Deserialize<CoachInputModel[]>(xmlString, "Coaches");
            foreach (var coach in coaches)
            {
                if (!IsValid(coach))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var validCoach = Mapper.Map<Coach>(coach);

                foreach (var footballer in coach.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(footballer.ContractStartDate, GlobalConstants.FootballerDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStartDate)
                        || !DateTime.TryParseExact(footballer.ContractEndDate, GlobalConstants.FootballerDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEndDate))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate > contractEndDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validFootballer = Mapper.Map<Footballer>(footballer);
                    validCoach.Footballers.Add(validFootballer);
                }

                output.AppendLine(string.Format(SuccessfullyImportedCoach, validCoach.Name, validCoach.Footballers.Count));
                validCoaches.Add(validCoach);
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();
            return output.ToString().Trim();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var output = new StringBuilder();

            var realTeams = new List<Team>();
            var teams = JsonConvert.DeserializeObject<TeamInputModel[]>(jsonString);
            foreach (var team in teams)
            {
                if (!IsValid(team))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (team.Trophies < 1)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var realTeam = Mapper.Map<Team>(team);

                foreach (var footballerId in team.Footballers.Distinct())
                {
                    var realFootballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId);
                    if (realFootballer == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    realTeam.TeamsFootballers.Add(new TeamFootballer { Team = realTeam, Footballer = realFootballer });
                }

                realTeams.Add(realTeam);
                output.AppendLine(String.Format(SuccessfullyImportedTeam, realTeam.Name, realTeam.TeamsFootballers.Count));
            }

            context.Teams.AddRange(realTeams);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
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
