using Newtonsoft.Json;
using SoftJail.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public ImportCellDto[] Cells { get; set; }
    }
}
