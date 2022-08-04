using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [JsonProperty("Number")]
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Number { get; set; }

        [JsonProperty("CVC")]
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        [RegularExpression("[0-9]{3}")]
        public string CVC { get; set; }

        [JsonProperty("Type")]
        [Required]
        public CardType? Type { get; set; }

    }

}
