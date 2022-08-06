using BookShop.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorInputModel
    {
        [Required]
        [MaxLength(GlobalConstants.AuthorFirstNameMaxLength)]
        [MinLength(GlobalConstants.AuthorFirstNameMinLength)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(GlobalConstants.AuthorLastNameMaxLength)]
        [MinLength(GlobalConstants.AuthorLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [JsonProperty("Books")]
        public BookIdInputModel[] Books { get; set; }
    }
}
