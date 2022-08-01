using Newtonsoft.Json;
using SoftJail.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportCellDto
    {
        [JsonProperty("CellNumber")]
        [Required]
        [Range(ValidationConstants.CellNumberMin, ValidationConstants.CellNumberMax)]
        public int CellNumber { get; set; }

        [JsonProperty("HasWindow")]
        [Required]
        public bool HasWindow { get; set; }
    }
}
