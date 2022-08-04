namespace BookShop.Data.Models
{
    using BookShop.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AuthorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AuthorLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
