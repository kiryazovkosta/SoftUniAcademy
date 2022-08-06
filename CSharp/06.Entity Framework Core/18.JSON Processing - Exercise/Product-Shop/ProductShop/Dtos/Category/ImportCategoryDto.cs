using Newtonsoft.Json;
using ProductShop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.Dtos.Category
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        [Required]
        [MinLength(GlobalConstants.MinCategoryNameLength)]
        [MaxLength(GlobalConstants.MaxCategoryNameLength)]
        public string Name { get; set; }
    }
}
