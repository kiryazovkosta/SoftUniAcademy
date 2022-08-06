namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var countries = new List<Country>();
            var countriesDtos = Deserialize<ImportCountryDto[]>(xmlString, "Countries");
            foreach (var countryDto in countriesDtos)
            {
                if (!IsValid(countryDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                countries.Add(new Country() { CountryName = countryDto.CountryName, ArmySize = countryDto.ArmySize });
                output.AppendLine(string.Format(SuccessfulImportCountry, countryDto.CountryName, countryDto.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var manufacturers = new List<Manufacturer>();
            var manufacturersDtos = Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");
            foreach (var manufacturerDto in manufacturersDtos)
            {
                if (!IsValid(manufacturerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (manufacturers.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var address = manufacturerDto.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var townNameCountryName = $"{address[address.Length - 2]}, {address[address.Length - 1]}";

                manufacturers.Add(new Manufacturer() { ManufacturerName = manufacturerDto.ManufacturerName, Founded = manufacturerDto.Founded });
                output.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturerDto.ManufacturerName, townNameCountryName));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var shellsDtos = Deserialize<ImportShellDto[]>(xmlString, "Shells");
            var shells = new List<Shell>();
            foreach (var shellDto in shellsDtos)
            {
                if (!IsValid(shellDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                shells.Add(new Shell() { Caliber = shellDto.Caliber, ShellWeight = shellDto.ShellWeight });
                output.AppendLine(string.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var output = new StringBuilder();

            var gunsDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            var guns = new List<Gun>();
            foreach (var gunDto in gunsDtos)
            {
                if (!IsValid(gunDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(GunType), gunDto.GunType))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunType = Enum.Parse<GunType>(gunDto.GunType);

                var gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    GunType = gunType,
                    Range = gunDto.Range,
                    ShellId = gunDto.ShellId
                };

                foreach (var countryDto in gunDto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun { CountryId = countryDto.Id, Gun = gun });
                }

                guns.Add(gun);
                output.AppendLine(string.Format(SuccessfulImportGun, gunDto.GunType, gunDto.GunWeight, gunDto.BarrelLength));
            }

            context.Guns.AddRange(guns);
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
