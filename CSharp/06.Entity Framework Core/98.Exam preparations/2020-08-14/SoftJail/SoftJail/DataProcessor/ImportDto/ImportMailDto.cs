using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportMailDto
    {
        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty("Sender")]
        [Required]
        public string Sender { get; set; }

        [JsonProperty("Address")]
        [Required]
        [RegularExpression("^[A-Za-z0-9 ]+ str.$")]
        public string Address { get; set; }
    }
}
