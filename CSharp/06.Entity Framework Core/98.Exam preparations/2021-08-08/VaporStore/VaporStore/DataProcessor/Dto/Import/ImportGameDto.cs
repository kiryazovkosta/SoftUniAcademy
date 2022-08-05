using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("Developer")]
        [Required]
        public string Developer { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [Required]
        [JsonProperty("Tags")]
        public string[] Tags { get; set; }
    }
}
