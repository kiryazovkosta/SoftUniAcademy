using Newtonsoft.Json;
using SoftJail.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
        [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
        public string FullName { get; set; }

        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression("^The [A-Z]{1}[a-z]+$")]
        public string Nickname { get; set; }

        [JsonProperty("Age")]
        [Required]
        [Range(ValidationConstants.PrisonerAgeMin, ValidationConstants.PrisonerAgeMax)]
        public int Age { get; set; }

        [JsonProperty("IncarcerationDate")]
        public DateTime IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("Bail")]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public ImportMailDto[] Mails { get; set; }

    }
}
