using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportOfficerDto
    {
        [JsonProperty("OfficerName")]
        public string Name { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}
