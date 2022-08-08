using Footballers.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerInputModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.FootballerNameMinLength)]
        [MaxLength(GlobalConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        [Required]
        [Range(GlobalConstants.FootballerPositionTypeMinValue, GlobalConstants.FootballerPositionTypeMaxValue)]
        public int PositionType { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [Range(GlobalConstants.FootballerBestSkillTypeTypeMinValue, GlobalConstants.FootballerBestSkillTypeTypeMaxValue)]
        public int BestSkillType { get; set; }
    }
}
