﻿namespace BookShop.Data.Models
{
    using BookShop.Common;
    using BookShop.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.BookNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }    
    }
}
