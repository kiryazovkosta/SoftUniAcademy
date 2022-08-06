using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop.Dtos.User
{
    public class UsersAllListDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount => this.Users.Any() ? this.Users.Count() : 0; 

        [JsonProperty("users")]
        public UserListDto[] Users { get; set; }
    }
}
