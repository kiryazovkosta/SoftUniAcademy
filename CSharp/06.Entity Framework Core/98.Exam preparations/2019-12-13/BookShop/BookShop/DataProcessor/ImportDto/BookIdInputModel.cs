namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class BookIdInputModel
    {
        [Required]
        public int? Id { get; set; }
    }
}
