using SoftJail.Common;
using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
        [MinLength(ValidationConstants.OfficerFullNameMinLength)]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal Salary  { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerIndexDto[] Prisoners { get; set; }
    }
}
