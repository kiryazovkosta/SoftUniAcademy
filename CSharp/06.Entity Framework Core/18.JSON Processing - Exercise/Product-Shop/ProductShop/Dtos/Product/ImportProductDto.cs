namespace ProductShop.Dtos.Product
{
    using System.ComponentModel.DataAnnotations;
    using ProductShop.Common;
    using Newtonsoft.Json;

    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(GlobalConstants.MinProductNameLength)]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("SellerId")]
        public int SellerId { get; set; }

        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
