using Newtonsoft.Json;
using ProductShop.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.User
{
    [JsonObject]
    public class ExportUsersWithSoldProductDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportUserSoldProductsDto[] Products { get; set; }
    }
}
