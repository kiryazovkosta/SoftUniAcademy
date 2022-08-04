namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            };

            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString, settings);

            foreach (var gDto in gamesDtos)
            {
                if (!IsValid(gDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (gDto.Tags.Length == 0)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game()
                {
                    Name = gDto.Name,
                    Price = gDto.Price,
                    ReleaseDate = gDto.ReleaseDate,
                };

                var developer = context.Developers.FirstOrDefault(d => d.Name == gDto.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = gDto.Developer };
                }
                game.Developer = developer;

                var genre = context.Genres.FirstOrDefault(d => d.Name == gDto.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = gDto.Genre };
                }
                game.Genre = genre;

                foreach (var tagName in gDto.Tags.Distinct())
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagName };
                    }

                    game.GameTags.Add(new GameTag() { Game = game, Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();
                output.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");

            }

            return output.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            };

            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString, settings);
            foreach (var uDto in usersDtos)
            {
                if (!IsValid(uDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (uDto.Cards.Length == 0)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if(uDto.Cards.Any(c => !IsValid(c)))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User() { FullName = uDto.FullName, Username = uDto.Username, Email = uDto.Email, Age = uDto.Age };
                foreach (var cDto in uDto.Cards)
                {
                    Card card = context.Cards.FirstOrDefault(c => c.Number == cDto.Number);
                    if (card == null)
                    {
                        card = new Card { Number = cDto.Number, Cvc = cDto.CVC, Type = cDto.Type.Value };
                    }

                    user.Cards.Add(card);
                }

                context.Users.Add(user);
                context.SaveChanges();
                output.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            return output.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var output = new StringBuilder();

            var purchasesDtos = Deserialize<ImportPurchaseDto[]>(xmlString, "Purchases");
            foreach (var pDto in purchasesDtos)
            {
                if (!IsValid(pDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(g => g.Name == pDto.Title);
                if (game == null)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.IsDefined(typeof(PurchaseType), pDto.Type))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(c => c.Number == pDto.Card);
                if (card == null)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                DateTime date;
                if (!DateTime.TryParseExact(pDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase()
                {
                    ProductKey = pDto.Key, 
                    Card = card, 
                    Date = date, 
                    Game = game, 
                    Type = Enum.Parse<PurchaseType>(pDto.Type)
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                output.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

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