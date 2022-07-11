﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P03_FootballBetting.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
