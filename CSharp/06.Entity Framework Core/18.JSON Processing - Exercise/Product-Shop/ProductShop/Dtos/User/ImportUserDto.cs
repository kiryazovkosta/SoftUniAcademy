namespace ProductShop.Dtos.User
{
    using Newtonsoft.Json;
    using ProductShop.Common;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        [MinLength(GlobalConstants.MinUserLastNameLength)]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
