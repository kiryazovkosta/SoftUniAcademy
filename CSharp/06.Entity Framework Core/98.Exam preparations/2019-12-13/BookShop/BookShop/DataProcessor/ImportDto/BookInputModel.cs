namespace BookShop.DataProcessor.ImportDto
{
    using BookShop.Common;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class BookInputModel
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(GlobalConstants.BookNameMaxLength)]
        [MinLength(GlobalConstants.BookNameMinLength)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Required]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range((double)GlobalConstants.BookPriceMinValue, (double)GlobalConstants.BookPriceMaxValue)]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Required]
        [Range(GlobalConstants.BookPageMinValue, GlobalConstants.BookPageMaxValue)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }

    }
}
