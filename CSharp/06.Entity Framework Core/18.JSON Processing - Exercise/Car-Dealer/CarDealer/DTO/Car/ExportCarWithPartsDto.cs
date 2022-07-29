using CarDealer.DTO.Part;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Car
{
    public class ExportCarWithPartsDto
    {
        [JsonProperty("car")]
        public ExportCarDataDto Car { get; set; }

        [JsonProperty("parts")]
        public ExportPartDto[] Parts { get; set; }
    }
}
