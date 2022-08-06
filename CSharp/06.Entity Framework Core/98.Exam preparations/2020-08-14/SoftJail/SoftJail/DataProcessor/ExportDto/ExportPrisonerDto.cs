using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportPrisonerDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string FullName { get; set; }

        [JsonProperty("CellNumber")]
        public int? CellNumber { get; set; }

        [JsonProperty("Officers")]
        public ExportOfficerDto[] Officers { get; set; }

        [JsonProperty("TotalOfficerSalary")]
        public decimal TotalOfficerSalary { get; set; }
    }
}
