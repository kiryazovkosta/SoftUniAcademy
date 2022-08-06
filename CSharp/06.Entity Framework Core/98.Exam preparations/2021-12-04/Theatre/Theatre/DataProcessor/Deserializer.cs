namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();

            var plays = new List<Play>();

            var playsDtos = Deserialize<PlayInputModel[]>(xmlString, "Plays");
            foreach (var playDto in playsDtos)
            {
                if (!IsValid(playDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(Genre), playDto.Genre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Genre = Enum.Parse<Genre>(playDto.Genre),
                    Description = playDto.Description,
                    Rating = playDto.Rating,
                    Screenwriter = playDto.Screenwriter
                };
                plays.Add(play);
                output.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();

            var casts = new List<Cast>();

            var castsDtos = Deserialize<CastInputModel[]>(xmlString, "Casts");
            foreach (var castDto in castsDtos)
            {
                if (!IsValid(castDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                casts.Add(new Cast() { FullName = castDto.FullName, IsMainCharacter = castDto.IsMainCharacter, PhoneNumber = castDto.PhoneNumber, PlayId = castDto.PlayId });
                output.AppendLine(string.Format(SuccessfulImportActor, castDto.FullName, castDto.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var output = new StringBuilder();
            var theatres = new List<Theatre>();
            var theatresDtos = JsonConvert.DeserializeObject<TheatreInputModel[]>(jsonString);
            foreach (var theatreDto in theatresDtos)
            {
                if (!IsValid(theatreDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    theatre.Tickets.Add(new Ticket
                    {
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                        Price = ticketDto.Price,
                    });
                }

                theatres.Add(theatre);
                output.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));

            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();
            return output.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
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
