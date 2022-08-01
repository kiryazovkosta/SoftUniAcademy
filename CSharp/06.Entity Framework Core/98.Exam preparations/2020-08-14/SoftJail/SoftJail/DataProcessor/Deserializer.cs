namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            var departmentsDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
            foreach (var departmentDto in departmentsDtos)
            {
                if(!IsValid(departmentDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (departmentDto.Cells.Length == 0)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool areInvalid = false;
                foreach (var cell in departmentDto.Cells)
                {
                    if (!IsValid(cell))
                    {
                        areInvalid = true;
                        break;
                    }
                }

                if (areInvalid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var cells = new List<Cell>();
                foreach (var cell in departmentDto.Cells)
                {
                    cells.Add(new Cell { CellNumber = cell.CellNumber, HasWindow = cell.HasWindow });
                }

                var department = new Department { Name = departmentDto.Name, Cells = cells };

                context.Departments.Add(department);
                context.Cells.AddRange(cells);
                context.SaveChanges();
                output.AppendLine($"Imported {department.Name} with {cells.Count} cells");
                
            }

            return output.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Culture = System.Globalization.CultureInfo.InvariantCulture,
                NullValueHandling = NullValueHandling.Include
            };

            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString, settings);
            foreach (var prisonerDto in prisonersDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool areInvalid = false;
                foreach (var mail in prisonerDto.Mails)
                {
                    if(!IsValid(mail))
                    {
                        areInvalid = true;
                        break;
                    }
                }

                if (areInvalid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var mails = new List<Mail>();
                foreach (var mailDto in prisonerDto.Mails)
                {
                    mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Address = mailDto.Address,
                        Sender = mailDto.Sender

                    });
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = prisonerDto.IncarcerationDate,
                    ReleaseDate = prisonerDto.ReleaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = mails
                };

                context.Prisoners.Add(prisoner);
                context.Mails.AddRange(mails);
                context.SaveChanges();
                output.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return output.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var output = new StringBuilder();

            var officersDtos = Deserialize<ImportOfficerDto[]>(xmlString, "Officers");

            var validOfficers = new List<Officer>();
            foreach (var officerDto in officersDtos)
            {
                if (!IsValid(officerDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.IsDefined(typeof(Position), officerDto.Position) || !Enum.IsDefined(typeof(Weapon), officerDto.Weapon))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                //if (!context.Departments.Any(d => d.Id == officerDto.DepartmentId))
                //{
                //    output.AppendLine("Invalid Data");
                //    continue;
                //}

                var officer = new Officer
                {
                    DepartmentId = officerDto.DepartmentId,
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = Enum.Parse<Position>(officerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerDto.Weapon)
                };

                foreach (var pDto in officerDto.Prisoners)
                {
                    OfficerPrisoner officerPrisoner =  new OfficerPrisoner()
                    {
                        Officer = officer, 
                        PrisonerId = pDto.Id 
                    };

                    officer.OfficerPrisoners.Add(officerPrisoner);
                }

                validOfficers.Add(officer);
                output.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");

            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return output.ToString().Trim();    
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
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