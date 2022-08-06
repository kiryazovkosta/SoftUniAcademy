using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop.Dtos.Product
{
    public class SoldProductsListDto
    {
        [JsonProperty("count")]
        public int Count => this.Products.Any() ? this.Products.Count() : 0;

        [JsonProperty("products")]
        public SoldProductDto[] Products { get; set; }
    }
}
