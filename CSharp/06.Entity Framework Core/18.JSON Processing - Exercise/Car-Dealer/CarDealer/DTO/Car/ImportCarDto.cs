using CarDealer.DTO.Part;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Car
{
    public class ImportCarDto
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public long TravelDistance { get; set; }

        [JsonProperty("partsId")]
        public HashSet<long> PartsId { get; set; }
    }
}
