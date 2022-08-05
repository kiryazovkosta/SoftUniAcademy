using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [JsonProperty("FullName")]
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [JsonProperty("Username")]
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [Required]
        public string Email { get; set; }

        [JsonProperty("Age")]
        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        [Required]
        public ImportCardDto[] Cards { get; set; }
    }
}
