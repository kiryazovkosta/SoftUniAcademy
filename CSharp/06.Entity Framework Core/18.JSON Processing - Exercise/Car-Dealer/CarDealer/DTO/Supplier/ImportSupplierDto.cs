using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.DTO.Supplier
{
    public class ImportSupplierDto
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        [Required]
        public bool IsImporter { get; set; }
    }
}
