namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Common;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType(GlobalConstants.CoachXmlType)]
    public class CoachInputModel
    {
        [XmlElement(GlobalConstants.CoachXmlEmlementName)]
        [Required]
        [MinLength(GlobalConstants.CoachNameMinLength)]
        [MaxLength(GlobalConstants.CoachNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(GlobalConstants.CoachXmlEmlementNationality)]
        [Required]
        public string Nationality { get; set; }

        [XmlArray(GlobalConstants.CoachXmlArrayFootballers)]
        public FootballerInputModel[] Footballers { get; set; }
    }
}