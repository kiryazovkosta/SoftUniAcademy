﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Required]
        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
    }
}
